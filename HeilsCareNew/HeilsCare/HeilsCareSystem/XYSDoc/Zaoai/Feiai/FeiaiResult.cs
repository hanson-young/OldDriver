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

namespace XYS.Remp.Screening.Zaoai.Feiai
{
    public partial class FeiaiResult : XYS.Remp.Screening.BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;
        StringBuilder strResultPrint=new StringBuilder();

        public FeiaiResult()
        {
            InitializeComponent();
        }

        private void FeiaiResult_Load(object sender, EventArgs e)
        {
            //问卷答题时间
            answerTime = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiFeiAi).AnswerTime;

            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiFeiAi);

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


            string answerA03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
     QuestionnaireCode.ZaoAiFeiAi + ".A03");
            if (answerA03.Contains("A"))
            {
                lblResult.Text += @"有不明原因消瘦" + "\r";
                strResultPrint.Append(@"有不明原因消瘦" + "\r");
            }

            string answerA09 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
                QuestionnaireCode.ZaoAiFeiAi + ".A09");

            if (answerA09.Contains("A"))
            {
                string answerA091 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
                    QuestionnaireCode.ZaoAiFeiAi + ".A09.1");
                if (answerA091.Length > 0)
                {
                    lblResult.Text += @"从事过接触有害致癌物质的职业"+"\r";
                    strResultPrint.Append(@"从事过接触有害致癌物质的职业"+"\r");
                }
            }

            string answerC01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
     QuestionnaireCode.ZaoAiFeiAi + ".C01");
            if (answerC01.Contains("A"))
            {
                lblResult.Text += @"长期居住有空气污染的生活环境中" + "\r";
                strResultPrint.Append(@"长期居住有空气污染的生活环境中"+"\r");
            }

            string answerC02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
  QuestionnaireCode.ZaoAiFeiAi + ".C02");
            if (answerC02.Contains("C") || answerC02.Contains("D"))
            {
                lblResult.Text += @"长期接触厨房油烟"+"\r";
                strResultPrint.Append(@"长期接触厨房油烟" + "\r");
            }

            string answerC03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
    QuestionnaireCode.ZaoAiFeiAi + ".C03");
            if (answerC03.Contains("B"))
            {
                string answerC031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
    QuestionnaireCode.ZaoAiFeiAi + ".C03.1");
                if (answerC031.Contains("A"))
                {
                    lblResult.Text += @"吸烟≥30包/年"+"\r";
                    strResultPrint.Append(@"吸烟≥30包/年"+"\r");
                }
            }
            if (answerC03.Contains("C"))
            {
                  string answerC033 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
   QuestionnaireCode.ZaoAiFeiAi + ".C03.3");
                  if (answerC033.Contains("A"))
                {
                    lblResult.Text += @"有吸烟≥30包/年史，戒烟少于15年"+"\r";
                    strResultPrint.Append(@"有吸烟≥30包/年史，戒烟少于15年"+"\r");
                }
            }

            string answerC4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
              QuestionnaireCode.ZaoAiFeiAi + ".C04");
            if (answerC4.Contains("A"))
            {
                string answerC41 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
             QuestionnaireCode.ZaoAiFeiAi + ".C04.1");
                if (!string.IsNullOrEmpty(answerC41))
                {
                    if (answerC41.Contains("A"))
                    {
                        lblResult.Text += @"长期被动吸烟 1-3年" + "\r";
                        strResultPrint.Append(@"长期被动吸烟 1-3年" + "\r");
                    }

                    if (answerC41.Contains("B"))
                    {
                        lblResult.Text += @"长期被动吸烟 3-5年" + "\r";
                        strResultPrint.Append(@"长期被动吸烟 3-5年" + "\r");
                    }

                    if (answerC41.Contains("C"))
                    {
                        lblResult.Text += @"长期被动吸烟 5-10年" + "\r";
                        strResultPrint.Append(@"长期被动吸烟 5-10年" + "\r");
                    }

                    if (answerC41.Contains("D"))
                    {
                        lblResult.Text += @"长期被动吸烟 10年以上" + "\r";
                        strResultPrint.Append(@"长期被动吸烟 10年以上" + "\r");
                    }
                }
                else
                {
                    lblResult.Text += @"长期被动吸烟" + "\r";
                    strResultPrint.Append(@"长期被动吸烟" + "\r");
                }
             
            }

            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
            QuestionnaireCode.ZaoAiFeiAi + ".E01");
            if (answerE01.Contains("A"))
            {
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
         QuestionnaireCode.ZaoAiFeiAi + ".E01.1");
                lblResult.Text += @"有" + answerE011 + @"癌病史"+"\r";
                strResultPrint.Append(@"有" + answerE011 + @"癌病史" + "\r");
            }

            string answerE05 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
          QuestionnaireCode.ZaoAiFeiAi + ".E05");
            if (answerE05.Contains("A"))
            {
                string result = "";
                //用于打印
                string tempResultPrint = "";

                string answerE051 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
       QuestionnaireCode.ZaoAiFeiAi + ".E05.1");
                string answerE052 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
      QuestionnaireCode.ZaoAiFeiAi + ".E05.2");
                string answerE053 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
      QuestionnaireCode.ZaoAiFeiAi + ".E05.3");
                string answerE054 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
      QuestionnaireCode.ZaoAiFeiAi + ".E05.4");
                string answerE055 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
      QuestionnaireCode.ZaoAiFeiAi + ".E05.5");
                string answerE056 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
QuestionnaireCode.ZaoAiFeiAi + ".E05.6");
                string answerE097 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
      QuestionnaireCode.ZaoAiFeiAi + ".E09.7");
                if (answerE051.Contains("A"))
                {
                    result += @"肺结核,";
                    tempResultPrint += @"肺结核," + "\r";
                }
                if (answerE052.Contains("A"))
                {
                    result += @"慢性支气管炎,";
                    tempResultPrint += @"慢性支气管炎,"+"\r";
                }
                if (answerE053.Contains("A"))
                {
                    result += @"肺气肿,";
                    tempResultPrint += @"肺气肿," + "\r";
                }
                if (answerE054.Contains("A"))
                {
                    result += @"哮喘支气管扩张,";
                    tempResultPrint += @"哮喘支气管扩张," + "\r";
                }
                if (answerE055.Contains("A"))
                {
                    result += @"矽肺或尘肺,";
                    tempResultPrint += @"矽肺或尘肺," + "\r";
                }
                if (!string.IsNullOrEmpty(answerE056))
                {
                    result += answerE056+",";
                    tempResultPrint += answerE056 + ",";
                }
                lblResult.Text += @"有慢性肺部疾病史(" + result + ")" + " \r";
                //用于打印
                strResultPrint.Append("有慢性肺部疾病史(\r" + tempResultPrint + ")" + " \r");

                if (answerE097.Contains("A"))
                {
                    lblResult.Text += @"有慢性咳嗽咳痰、咯血表现"+"\r";
                    strResultPrint.Append(@"有慢性咳嗽咳痰、咯血表现" + "\r");
                }
             }

            string answerF01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
       QuestionnaireCode.ZaoAiFeiAi + ".F01");
            if (answerF01.Contains("A"))
            {
                string answerF011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
     QuestionnaireCode.ZaoAiFeiAi + ".F01.1");
                if (answerF011.Contains("A"))
                {
                    string answerF012 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi,
   QuestionnaireCode.ZaoAiFeiAi + ".F01.2");
                    string result = string.Empty;
                    //用于打印
                    string resultTempPrint = string.Empty;

                    if (answerF012.Contains("A"))
                    {
                        result += @"母亲、";
                        resultTempPrint += @"母亲、";
                    }
                    if (answerF012.Contains("B"))
                    {
                        result += "父亲、";
                        resultTempPrint += "父亲、";
                    }
                    if (answerF012.Contains("C"))
                    {
                        result += "姐妹、";
                        resultTempPrint += "姐妹、";
                    }
                    if (answerF012.Contains("D"))
                    {
                        result += "兄弟、";
                        resultTempPrint += "兄弟、";
                    }
                    if (answerF012.Contains("E"))
                    {
                        result += "祖父母、";
                        resultTempPrint += "祖父母、";
                    }
                    if (answerF012.Contains("F"))
                    {
                        result += "外祖父母、";
                        resultTempPrint += "外祖父母、";
                    }
                    if (answerF012.Contains("G"))
                    {
                        result += "叔姑、";
                        resultTempPrint += "叔姑、";
                    }
                    if (answerF012.Contains("H"))
                    {
                        result += "舅姨、";
                        resultTempPrint += "舅姨、";
                    }
                    if (answerF012.Contains("I"))
                    {
                        result += "堂兄弟姐妹、";
                        resultTempPrint += "堂兄弟\r\n姐妹、";
                    }
                    if (answerF012.Contains("J"))
                    {
                        result += "表兄弟姐妹、";
                        resultTempPrint += "表兄弟姐妹、";
                    }
                    if (answerF012.Contains("K"))
                    {
                        result += "其他、";
                        resultTempPrint += "其他、";
                    }
                    lblResult.Text += @"有肺癌家族史(" + result + ")";
                    strResultPrint.Append(@"有肺癌家族史");
                }
            }

            if (string.IsNullOrEmpty(lblResult.Text))
            {
                this.lblResult.Text = @"恭喜您，您是肺癌的低风险人群。风险低的人群，不能完全排除患癌症的可能性，建议定期做全面体检，以及时了解身体健康状况。并继续保持良好的生活方式。";
                strResultPrint.Append(@"恭喜您，您是肺癌的低风险人群。风险
低的人群，不能完全排除患癌症的可能
性，建议定期做全面体检，以及时了解
身体健康状况。并继续保持良好的生活
方式。");
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (PaperSize paperSize in printDocument1.PrinterSettings.PaperSizes)
            {
                if (paperSize.PaperName.Contains("Roll Paper 80 x 297 mm"))
                {
                    this.printDocument1.DefaultPageSettings.PaperSize = paperSize;
                    break;

                }
            }
            this.printDocument1.Print();

            //打印按钮置灰
            PrintManager.SetBtnPrint(true, btnPrint, timerPrint);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float totalines = 0;  //总行数 
            float yPos = 10;          //打印点Y轴坐标 
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
            printTest += strResultPrint.ToString();
            if (panel1.Visible)
            {
                printTest += "\r\n";
                printTest += "筛查时间：" + answerTime + "\r\n";
                printTest += "----------------------------------------------------------";
                printTest += "\n筛查建议:\r\n";
                printTest += PrintString();
            }
            streamToPrint =new StringReader(printTest);//从本地文件来打印 
            while (count < totalines && ((lineStr = streamToPrint.ReadLine()) != null))
            {
                //因为每打印一行，下一行的位置会发生变化， yPos=打印区域的上边界+ 行数*字体高度 
                yPos = topT + (count * printFont.GetHeight(e.Graphics));
                //打印一行 数据，leftM 和 yPos代表了 打印的起始点坐标 
                Rectangle drawRect = new Rectangle((int)leftM, (int)yPos, 300,100);
                e.Graphics.DrawString(lineStr, printFont, Brushes.Black, drawRect, new StringFormat());
                count++; //下一行  
            }
            if (lineStr != null) //如果还有内容 另换一页 
                e.HasMorePages = true;
            else
                e.HasMorePages = false; 

        }

        public string PrintString()
        {
            StringBuilder str = new StringBuilder("1.1.鉴于您存在以上肺癌的危险因素，建\r议到");
            str.Append("医院早癌筛查中心或呼吸内科门诊\r，在医生");
            str.Append("指导下进行相关检查。建议筛\r查项目：\r");
            str.Append("1.1.1.肿瘤相关标志物检查：\r");
            str.Append("癌胚抗原(CEA)、细胞角蛋白19片段\r(CYFRA21-1)、");
            str.Append("神经元特异性烯醇化酶\r(NSE)、糖类抗原125");
            str.Append("（CA125）、鳞\r状上皮细胞癌相关抗原（SCCA)\r");
            str.Append("1.1.2.  重点筛查项目 ：\r");
            str.Append("低剂量CT胸部扫描；肺功能检测；（必\r要时在精密");
            str.Append("导航引导下行纤维支气管镜\r检查。\r）");
            str.Append("以上推荐项目供参考，具体请遵医嘱。\r");
            return str.ToString();
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
 
                   
                
            

