using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.JiZhu
{
    public partial class Result : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器

        //问卷答题时间
        private DateTime answerTime;

        //private ScreeningServiceClient client=new ScreeningServiceClient();
        private ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        public Result()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmSelect = new ScreeningSelect();
            frmSelect.TopMost = false;
            frmSelect.Show();
            this.Close();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail questionnaire = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.KangFuJiZhu);

            //问卷答题时间
            answerTime = questionnaire.AnswerTime;

            if (questionnaire == null) return;

            IList<M_QuestionnaireResultDetail> questions = questionnaire.Questions;

            //将登录人与活动关联
            if (!LoginInfo.GetInstance().Name.Equals(""))
            {
                new CottageActivityManager().AddPToCActivity();
            }

            int score = 0;

            #region 计算每题得分
            if (questions != null && questions.Count > 0)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    M_QuestionnaireResultDetail result = questions[i];

                    string answer = result.QuestionResult;

                    if (!string.IsNullOrEmpty(answer) && answer.Contains("A"))
                    {
                        score += 10;
                    }

                }// end for

            }// end  if (questions != null && questions.Count > 0)

            if (score <= 10)
            {
                lblResult.Text = @"基本正常。";
            }

            if (score > 10 && score <= 20)
            {
                lblResult.Text = @"疑似脊柱侧弯。";

                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    //给用户打标签
                    List<M_MemberFeaturesRecord> array=new List<M_MemberFeaturesRecord>()
                    {
                        new M_MemberFeaturesRecord() { CreateID = Properties.Settings.Default.DoctorId, CreateTime = DateTime.Now, MFItemID = 1725, PatientID = LoginInfo.GetInstance().UserId }
                    };

                    M_MemberFeaturesRecordLogExt recordLogExt = new M_MemberFeaturesRecordLogExt();
                    recordLogExt.DoctorID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DoctorName = Properties.Settings.Default.DoctorName;
                    recordLogExt.DrID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DrName = Properties.Settings.Default.DoctorName;
                    recordLogExt.OpID = Properties.Settings.Default.DoctorId;
                    recordLogExt.OpName = Properties.Settings.Default.DoctorName;

                    int cARecordId = Properties.Settings.Default.SetIsCustomer
                        ? 0
                        : Properties.Settings.Default.CARecordID;

                    screenWebapiClient.UpdateMemberAllRecords(LoginInfo.GetInstance().UserId, array, recordLogExt, cARecordId, "脊柱筛查");
                }
                
            }

            if (score > 20)
            {
                lblResult.Text = @"确定您有脊柱侧弯，请前往医院就诊。";

                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    //给用户打标签
                    List<M_MemberFeaturesRecord> array = new List<M_MemberFeaturesRecord>()
                    {
                        new M_MemberFeaturesRecord() { CreateID = Properties.Settings.Default.DoctorId, CreateTime = DateTime.Now, MFItemID = 1726, PatientID = LoginInfo.GetInstance().UserId }
                    };

                    M_MemberFeaturesRecordLogExt recordLogExt = new M_MemberFeaturesRecordLogExt();
                    recordLogExt.DoctorID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DoctorName = Properties.Settings.Default.DoctorName;
                    recordLogExt.DrID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DrName = Properties.Settings.Default.DoctorName;
                    recordLogExt.OpID = Properties.Settings.Default.DoctorId;
                    recordLogExt.OpName = Properties.Settings.Default.DoctorName;

                    int cARecordId = Properties.Settings.Default.SetIsCustomer
                        ? 0
                        : Properties.Settings.Default.CARecordID;

                    screenWebapiClient.UpdateMemberAllRecords(LoginInfo.GetInstance().UserId, array, recordLogExt, cARecordId, "脊柱筛查");
                }
                
            }

            lblResult.Text += @"本次得分：" + score;

            //更新本次问卷得分
            M_QuestionnaireUserDetail userDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.KangFuJiZhu);
            if (userDetail != null && !string.IsNullOrEmpty(LoginInfo.GetInstance().Name))
            {
                int result = screenWebapiClient.UpdateQuestionUserScoreStatus(userDetail.QuestionnaireRecodId, score, 1);
            }

            #endregion;

            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                string number = Properties.Settings.Default.ScreenNumber.ToString();
                switch (number.Length)
                {
                    case 1:
                        number = "000" + number;
                        break;
                    case 2:
                        number = "00" + number;
                        break;
                    case 3:
                        number = "0" + number;
                        break;
                }
                SaveXml saveXml = new SaveXml();
                saveXml.AddXmlElement(number, questions);

                lblVisitor.Text += number;
                lblVisitor.Visible = true;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ClientInfo.Logout();
            btnBack_Click(this, e);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (printDialog1.ShowDialog() == DialogResult.OK)
            //{
                foreach (PaperSize paperSize in printDocument1.PrinterSettings.PaperSizes)
                {
                    if (paperSize.PaperName.Contains("Roll Paper 80 x 297 mm"))
                    {
                        this.printDocument1.DefaultPageSettings.PaperSize = paperSize;
                        break;

                    }
                }
                printDocument1.Print();
            //} 

                //打印按钮置灰
                PrintManager.SetBtnPrint(true, btnPrint, timerPrint);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float totalines = 0;  //总行数 
            float yPos = 10;          //打印点Y轴坐标 
            float fltXPos = 0;         //每一行的X坐标 
            int count = 0;           //当前正在打印第几行 
            float leftM = 15; // e.MarginBounds.Left;  //在打印范围内获取左边的打印点 
            float topT = 0;// e.MarginBounds.Top;    //在打印范围内获取上边的打印点 
            string lineStr = null;       //存储一行数据 
            totalines = e.MarginBounds.Height / printFont.GetHeight(e.Graphics); // 打印区域高度/字体高度 
            //如果没有超过最大行 并且 还存在一行数据 就开始打印 
            //string userName = LoginInfo.GetInstance().PatientAccount == ""
            //    ? "访客"
            //    : (LoginInfo.GetInstance().Name.Equals(LoginInfo.GetInstance().Phone)
            //        ? LoginInfo.GetInstance().PatientAccount
            //        : LoginInfo.GetInstance().Name);
            string userName = LoginInfo.GetInstance().PatientAccount == ""
                ? "访客"
                : LoginInfo.GetInstance().PatientAccount;

            string printTest = string.Empty;
            if (userName.Length == 2)
            {
                printTest = "============尊敬的" + userName + "============ \r\n";
            }
            else if (userName.Length == 3)
            {
                printTest = "===========尊敬的" + userName + "=========== \r\n";
            }
            else if (userName.Length == 4)
            {
                printTest = "==========尊敬的" + userName + "========== \r\n";
            }
            else if (userName.Length <= 11)
            {
                printTest = "========尊敬的" + userName + "======== \r\n";
            }
            else if (userName.Length <= 15)
            {
                printTest = "======尊敬的" + userName + "====== \r\n";
            }
            else if (userName.Length <= 18)
            {
                printTest = "=====尊敬的" + userName + "===== \r\n";
            }

            printTest +="筛查结果:\r\n"+ lblResult.Text + "\r\n";
            if (panel1.Visible)//如果有建议提醒
            {
                printTest += "\r\n";
                printTest += "筛查时间：" + answerTime + "\r\n";
                printTest += "----------------------------------------------------------";
                printTest += "\n筛查建议:\r\n";
                printTest += PrintString();
            }
            streamToPrint = (StringReader)new StringReader(printTest);//从本地文件来打印 
            StringFormat fmt = new StringFormat();
            //fmt.LineAlignment = StringAlignment.Center;
            //fmt.FormatFlags = StringFormatFlags.LineLimit;
            while (count < totalines && ((lineStr = streamToPrint.ReadLine()) != null))
            {
                //因为每打印一行，下一行的位置会发生变化， yPos=打印区域的上边界+ 行数*字体高度 
                yPos = topT + (count * printFont.GetHeight(e.Graphics));
                //打印一行 数据，leftM 和 yPos代表了 打印的起始点坐标 
                Rectangle drawRect = new Rectangle((int)leftM, (int)yPos, 300, 600);
                e.Graphics.DrawString(lineStr, printFont, Brushes.Black, drawRect, fmt);
                count++; //下一行  
            }
            if (lineStr != null) //如果还有内容 另换一页 
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        public string PrintString()
        {
            string str = @"如何脊柱侧弯预防？
1、保持良好坐姿及站姿，适当加强锻炼。
2、普及脊柱健康知识，定期进行脊柱侧
弯筛查，如发现问题及早前往医院检查。

发现脊柱侧弯后家长该做些什么？
1、当有怀疑有脊柱侧凸现象时，家长首
先应向专科医生征询意见，并进一步让
孩子接受脊柱侧凸专业人员的彻底检查。
2、根据专家意见，拍摄站立位全脊柱
X光片

脊柱侧弯拍片时需注意什么？
当怀疑有脊柱侧凸时，小孩常需拍摄全
脊柱正侧位的X光片，此时需注意让小
孩在站立位下进行X光拍摄，这样可避
免平卧位肌肉松弛导致拍片时侧凸角度
的减少，进而影响准确的病情评估及治
疗方案选择。

脊柱侧弯在X光片上是什么样子的？
脊柱侧凸指在脊柱区域（上胸椎，胸椎
或腰椎）产生一个或多个弯曲。脊柱侧
凸可能发生在脊柱的一个或多个区域，
我们称之做单弯，双弯或三弯。侧弯方
向可能向左，也可能向右。";
            return str;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            foreach (PaperSize paperSize in printDocument1.PrinterSettings.PaperSizes)
            {
                if (paperSize.PaperName.Contains("Roll Paper 80 x 297 mm"))
                {
                    this.printDocument1.DefaultPageSettings.PaperSize = paperSize;
                    break;

                }
            }
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.TopMost = false;
            printPreviewDialog1.ShowDialog();
        }
        //按钮置灰
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }
    }
}
