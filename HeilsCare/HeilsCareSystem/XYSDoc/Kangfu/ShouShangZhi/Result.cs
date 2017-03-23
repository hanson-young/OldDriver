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

namespace XYS.Remp.Screening.Kangfu.ShouShangZhi
{
    public partial class Result : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器

        //问卷答题时间
        private DateTime answerTime;

        //private ScreeningServiceClient client=new ScreeningServiceClient();
        private ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        //用于打印
        private string strResultPrint = string.Empty;

        public Result()
        {
            InitializeComponent();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmMain = new ScreeningSelect();
            frmMain.TopMost = false;
            frmMain.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this);
            quitComfirmFrm.ShowDialog();
        }

        //加载
        private void Result_Load(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail questionnaire = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.KangFuShouShangZhi);

            //问卷答题时间
            answerTime = questionnaire.AnswerTime;

            IList<M_QuestionnaireResultDetail> questions = questionnaire.Questions;

            //将登录人与活动关联
            if (!LoginInfo.GetInstance().Name.Equals(""))
            {
                new CottageActivityManager().AddPToCActivity();
            }

            //得分
            double score = 0;
            //总和
            double tempScore = 0;

            //计算得分
            if (questions != null && questions.Count > 0)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    M_QuestionnaireResultDetail result = questions[i];

                    string answer = result.QuestionResult;

                    if (answer.Contains("A")) { tempScore += 1; }
                    if (answer.Contains("B")) { tempScore += 2; }
                    if (answer.Contains("C")) { tempScore += 3; }
                    if (answer.Contains("D")) { tempScore += 4; }
                    if (answer.Contains("E")) { tempScore += 5; }
                }
            }

            score = (tempScore - 30)/1.20;


            lblResult.Text = "本次得分：" + Math.Round(score, 2)+"。";
            strResultPrint = "本次得分：" + Math.Round(score, 2)+"。\r\n";

            if (score<=2.5)
            {
                lblResult.Text += @"恭喜您，基本正常。";
                strResultPrint += @"恭喜您，基本正常。";
            }
            else if (score>2.5 && score <=12.5)
            {
                lblResult.Text += @"轻度，您有轻度的手上肢活动障碍问题，建议日常多进行手上肢活动训练，预防手上肢病变，例如关节性疾病风湿、关节炎等。早期手上肢功能的康复训练有重要意义，日常生活和职业动作中很多是手的精细动作，所以通过日常动作的锻炼，对恢复手功能效果明显。";

                strResultPrint += @"轻度，您有轻度的手上肢活动障碍问题，
建议日常多进行手上肢活动训练，预防
手上肢病变，例如关节性疾病风湿、关
节炎等。早期手上肢功能的康复训练有
重要意义，日常生活和职业动作中很多
是手的精细动作，所以通过日常动作的
锻炼，对恢复手功能效果明显。";

                //给用户打标签
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new PatientRecordsManager().UpdatePatientAllRecords(1729,"上肢轻度障碍");
                }
               
            }
            else if (score > 12.5 && score <= 25)
            {
                lblResult.Text += @"中度，您有中度的手上肢活动障碍问题，可能无法很好使用上肢完成日常生活活动和工作，还请及早接受系统康复治疗。早期手功能的康复训练有重要意义，日常生活和职业动作中很多是手的精细动作。假如3个月以后再训练手功能，将有96%左右患者不能恢复功能，所以早期切勿忽略患手的训练。";

                strResultPrint += @"中度，您有中度的手上肢活动障碍问题，
可能无法很好使用上肢完成日常生活活
动和工作，还请及早接受系统康复治疗。
早期手功能的康复训练有重要意义，日
常生活和职业动作中很多是手的精细动
作。假如3个月以后再训练手功能，将
有96%左右患者不能恢复功能，所以早
期切勿忽略患手的训练。";

                //给用户打标签
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new PatientRecordsManager().UpdatePatientAllRecords(1730, "上肢中度障碍");
                }
                
            }
            // >25
            else
            {
                lblResult.Text += @"重度，您手上肢关节活动度、感觉、灵活性差，已经完全影响您的日常生活活动和工作，还请尽快到相关医院进行就医检查，接受针对性的系统治疗。";

                strResultPrint += @"重度，您手上肢关节活动度、感觉、灵
活性差，已经完全影响您的日常生活活
动和工作，还请尽快到相关医院进行就
医检查，接受针对性的系统治疗。";

                //给用户打标签
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new PatientRecordsManager().UpdatePatientAllRecords(1731, "上肢重度障碍");
                }
               
            }

            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                string number= Properties.Settings.Default.ScreenNumber.ToString();
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
                SaveXml saveXml=new SaveXml();
                saveXml.AddXmlElement(number, questions);

                //游客编号
                lblVisitor.Text += number;
                lblVisitor.Visible = true;
            }
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
            else if (userName.Length<=11)
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

            printTest += "筛查时间:" + answerTime + "\r\n" + " 筛查结果:\r\n" + strResultPrint + "\r\n";
            //if (panel1.Visible)//如果有建议提醒
            //{
            //printTest += "\r\n";
            //printTest += "----------------------------------------------------------";
            //printTest += "\n筛查建议:\r\n";
            //printTest += PrintString();
            //}
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

        
        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (this.printDialog1.ShowDialog() == DialogResult.OK)
            //{
                foreach (PaperSize paperSize in printDocument1.PrinterSettings.PaperSizes)
                {
                    if (paperSize.PaperName.Contains("Roll Paper 80 x 297 mm"))
                    {
                        this.printDocument1.DefaultPageSettings.PaperSize = paperSize;
                        break;

                    }
                }
                this.printDocument1.Print();
            //}

            //打印按钮置灰
            PrintManager.SetBtnPrint(true,btnPrint,timerPrint);
        }

        //打印预览
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
