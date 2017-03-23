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
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Ganai
{
    public partial class GanaiResult : XYS.Remp.Screening.BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;
        //用于打印
        private string strResultPrint=String.Empty;

        public GanaiResult()
        {
            InitializeComponent();
        }

        private void GanaiResult_Load(object sender, EventArgs e)
        {

            //问卷答题时间
            answerTime = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiGanAi).AnswerTime;
            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiGanAi);

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
                saveXml.AddXmlElement(number, questionnaireUserDetail.Questions);

                //游客编号
                lblVisitor.Text += number;
                lblVisitor.Visible = true;
            }

            //将登录人与活动关联
            if (!LoginInfo.GetInstance().Name.Equals(""))
            {
                new CottageActivityManager().AddPToCActivity();
            }

            string answerC05 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
             QuestionnaireCode.ZaoAiGanAi + ".C05");
            if (answerC05.Contains("B"))
            {
                lblResult.Text += "酗酒 \r";

                strResultPrint += "酗酒 \r";
            }

            string answerE02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
            QuestionnaireCode.ZaoAiGanAi + ".E02");
            if (answerE02.Contains("A"))
            {
                string answerE021 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
          QuestionnaireCode.ZaoAiGanAi + ".E02.1");
                if (answerE021.Contains("B"))
                {
                    lblResult.Text += "乙肝表面抗原（HBsAg）阳性 \r";

                    strResultPrint += "乙肝表面抗原（HBsAg）阳性 \r"; 
                }
            }

            string answerE03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
           QuestionnaireCode.ZaoAiGanAi + ".E03");
            if (answerE03.Contains("A"))
            {
                string answerE031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
          QuestionnaireCode.ZaoAiGanAi + ".E03.1");
                if (answerE031.Contains("B"))
                {
                    lblResult.Text += "丙肝（HCV）阳性 \r";

                    strResultPrint += "丙肝（HCV）阳性 \r";
                }
            }

            string answerE071 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
         QuestionnaireCode.ZaoAiGanAi + ".E07.1");
            if (answerE071.Contains("A"))
            {
                string answerE0711 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
        QuestionnaireCode.ZaoAiGanAi + ".E07.1.1");
                if (answerE0711.Contains("A"))
                {
                    lblResult.Text += "慢性乙型肝炎病史5年以上 \r";

                    strResultPrint += "慢性乙型肝炎病史5年以上 \r";
                }
            }

            string answerE072 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
QuestionnaireCode.ZaoAiGanAi + ".E07.2");
            if (answerE072.Contains("A"))
            {
                string answerE0721 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
        QuestionnaireCode.ZaoAiGanAi + ".E07.2.1");
                if (answerE0721.Contains("A"))
                {
                    lblResult.Text += "慢性丙型肝炎病史5年以上 \r";

                    strResultPrint += "慢性丙型肝炎病史5年以上 \r";
                }
            }

            string answerE073 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
QuestionnaireCode.ZaoAiGanAi + ".E07.3");
            if (answerE073.Contains("A"))
            {
                string answerE0731 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi,
        QuestionnaireCode.ZaoAiGanAi + ".E07.3.1");
                if (answerE0731.Contains("A"))
                {
                    lblResult.Text += "肝硬化病史5年以上 \r";

                    strResultPrint += "肝硬化病史5年以上 \r";
                }
            }

            if (string.IsNullOrEmpty(lblResult.Text))
            {
                this.lblResult.Text = @"恭喜您，您是肝癌的低风险人群。风险低的人群，不能完全排除患癌症的可能性，建议定期做全面体检，以及时了解身体健康状况。并继续保持良好的生活方式。";

                strResultPrint += @"恭喜您，您是肝癌的低风险人群。风险
低的人群，不能完全排除患癌症的可能
性，建议定期做全面体检，以及时了解
身体健康状况。并继续保持良好的生活
方式。";

                panel1.Visible = false;
            }

            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningZaoaiSelect frmMain = new ScreeningZaoaiSelect();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningZaoaiSelect(), this);
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

            printTest += "筛查结果:\r\n";
            printTest += strResultPrint; //this.lblResult.Text;
            //printTest += this.lblResultAppend.Text;
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
            string str = @"在医生指导下进行相关检查。建议筛查
项目：
2.1.1肿瘤相关标志物方案 :甲胎蛋白
（AFP）、癌胚抗原(CEA)、糖类抗原
199（CA199)（HBsAg阳性者应同时行
乙肝DNA定量  肝功能五项检测）
2.1.2重点筛查项目:肝脏彩色多普勒超
声检查(必要时查肝脏增强CT)
2.1.3以上推荐项目供参考，具体请遵
医嘱。";
            return str;
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
