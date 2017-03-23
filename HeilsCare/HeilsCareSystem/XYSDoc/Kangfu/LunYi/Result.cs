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

namespace XYS.Remp.Screening.Kangfu.LunYi
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

        private void Result_Load(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail questionnaire = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.KangFuLunYi);

            //问卷答题时间
            answerTime = questionnaire.AnswerTime;

            IList<M_QuestionnaireResultDetail> questions = questionnaire.Questions;

            //将登录人与活动关联
            if (!LoginInfo.GetInstance().Name.Equals(""))
            {
                new CottageActivityManager().AddPToCActivity();
            }

            int score = 0;

            #region 计算每题得分
            //评分标准：第1题和第6题AB选项各记5分，CD选项各记0分；其他每题是记0分，否记10分。

            if (questions != null && questions.Count > 0)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    M_QuestionnaireResultDetail result = questions[i];

                    string answer = result.QuestionResult;

                    if ((result.QuestionCode == QuestionnaireCode.KangFuLunYi + ".1") || (result.QuestionCode == QuestionnaireCode.KangFuLunYi + ".6"))
                    {
                        if (answer.Contains("A") || answer.Contains("B"))
                        {
                            score += 5;
                        }
                    }
                    else
                    {
                        if (answer.Contains("B")) score += 10;
                    }

                }// end for

            }// end  if (questions != null && questions.Count > 0)

            //更新本次问卷总分
            M_QuestionnaireUserDetail userDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.KangFuLunYi);
            if (userDetail != null && !string.IsNullOrEmpty(LoginInfo.GetInstance().Name))
            {
                ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(userDetail, score, new List<int>
                {
                    int.Parse(ConfigHelper.GetAppsettings("WheelchairMaybeInappropriate")), 
                    int.Parse(ConfigHelper.GetAppsettings("WheelchairInappropriate"))
                });
            }

            if (score >=80 )
            {
                lblResult.Text += "您的轮椅基本合适。\r\n";
            }

            if (score >= 70 && score <80 )
            {
                lblResult.Text += "您的轮椅可能不合适。\r\n";

                //给用户打标签
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new PatientRecordsManager().UpdatePatientAllRecords(1727,"轮椅可能不合适");
                }
            }

            if (score <70)
            {
                lblResult.Text += "您的轮椅基本不合适。\r\n";

                //给用户打标签
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new PatientRecordsManager().UpdatePatientAllRecords(1728, "轮椅基本不合适");
                }
                
            }

            lblResult.Text += "本次得分：" + score;

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

                //游客编号
                lblVisitor.Text += number;
                lblResult.Visible = true;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmSelect = new ScreeningSelect();
            frmSelect.Show();
            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmMain = new ScreeningSelect();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this);
            quitComfirmFrm.ShowDialog();
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

            printTest += lblResult.Text + "\r\n";
            //if (panel1.Visible)//如果有建议提醒
            //{
            printTest += "\r\n";
            printTest += "筛查时间：" + answerTime + "\r\n";
            printTest += "----------------------------------------------------------";
            printTest += "\n筛查建议:\r\n";
            printTest += PrintString();
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
                PrintManager.SetBtnPrint(true, btnPrint, timerPrint);
        }

        public string PrintString()
        {
            string str = @"挑选轮椅就像买衣服一样，随着孩子身
高、体重增加，过一段时间，应当更换
型号适合的轮椅。轮椅的尺寸也应当合
体。尺寸合适可使各部位受力均匀，不
但舒适，还可以预防不良后果的出现。";
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
