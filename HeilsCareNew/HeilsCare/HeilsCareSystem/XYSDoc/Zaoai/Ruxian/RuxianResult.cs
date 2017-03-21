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

namespace XYS.Remp.Screening.Zaoai.Ruxian
{
    public partial class RuxianResult : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器
        //问卷答题时间
        private DateTime answerTime;
        public RuxianResult()
        {
            InitializeComponent();
        }

        private void RuxianResult_Load(object sender, EventArgs e)
        {

            //问卷答题时间
            answerTime = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiRuXianAi).AnswerTime;
            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiRuXianAi);

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

            int num = 1;
            string answerA07 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".A07"); //选项为1.未婚 结合个人信息中的性别“女”年龄≥35岁
            string answerA08 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".A08");
            if (answerA07.Contains("A") && answerA08.Contains("A"))
            {
                lblResult.Text += "女性高龄未婚 \r";
                num++;
            }
            string answerA09 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".A09");

            if (answerA09.Contains("A"))
            {
                string answerA091 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                    QuestionnaireCode.ZaoAiRuXianAi + ".A09.1");
                if (answerA091.Length > 0)
                {
                    lblResult.Text += "从事过接触有害致癌物质的职业 \r";
                    num++;
                }
            }

            string answerA10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".A10");
            if (answerA10.Contains("A")) lblResult.Text += "年轻时多次暴露于射线 \r";
            num++;

            string answerB14 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".B01.4");
            if (answerB14.Contains("A")) lblResult.Text += "高脂饮食 \r";
            num++;

            string answerC3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".C03");
            if (answerC3.Contains("B"))
            {
                string answerC31 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                    QuestionnaireCode.ZaoAiRuXianAi + ".C03.1");
                string answerC32 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                    QuestionnaireCode.ZaoAiRuXianAi + ".C03.2");
                string c31Result = "";
                string c32Result = "";
                if (answerC31.Contains("A"))
                {
                    c31Result += "1-5支/天,";
                }
                else if (answerC31.Contains("B"))
                {
                    c31Result += "5-10支/天,";
                }
                else if (answerC31.Contains("C"))
                {
                    c31Result += "10-20支/天,";
                }
                else
                {
                    c31Result += "20支以上/天,";
                }

                if (answerC32.Contains("A"))
                {
                    c32Result += "1-3年,";
                }
                else if (answerC32.Contains("B"))
                {
                    c32Result += "3-5年,";
                }
                else if (answerC32.Contains("C"))
                {
                    c32Result += "5-10年,";
                }
                else
                {
                    c32Result += "10年以上,";
                }
                lblResult.Text += "吸烟（" + c31Result + c32Result.Substring(0, c32Result.Length - 1) + ") \r";
                num++;
            }
            else if (answerC3.Contains("C"))
            {
                string answerC33 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                    QuestionnaireCode.ZaoAiRuXianAi + ".C03.3");
                if (answerC33.Contains("A"))
                {
                    lblResult.Text += "有吸烟史，戒烟少于15年 \r";
                    num++;
                }
            }

            string answerC4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".C04");
            if (answerC4.Contains("B"))
            {

                lblResult.Text += "长期被动吸烟 \r";
                num++;
            }
            string answerC5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".C05");
            if (answerC5.Contains("B"))
            {
                string answerC51 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                    QuestionnaireCode.ZaoAiRuXianAi + ".C05.1");
                if (double.Parse(answerC51) > 24)
                {
                    lblResult.Text += "酒精日摄入量＞24克 \r";
                    num++;
                }
            }

            string answerD01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".D01");
            if (answerD01.Contains("A")) lblResult.Text += "有较大精神创伤史 \r";
            num++;

            string answerD02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
                QuestionnaireCode.ZaoAiRuXianAi + ".D02");
            if (answerD02.Contains("A")) lblResult.Text += "长期精神抑郁 \r";
            num++;
        string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
         QuestionnaireCode.ZaoAiRuXianAi + ".E01");
            if (answerE01.Contains("A"))
            {
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
        QuestionnaireCode.ZaoAiRuXianAi + ".E01.1");
                if (num >= 10)
                {
                    lblResultApped.Text += "有" + answerE011 + "癌病史 \r"; num++;
                }
                else
                {
                    lblResult.Text += "有" + answerE011 + "癌病史 \r"; num++;
                }
              
            }

            string answeW03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
         QuestionnaireCode.ZaoAiRuXianAi + ".W03");
            if (answeW03.Contains("A"))
            {
                string answerW031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
        QuestionnaireCode.ZaoAiRuXianAi + ".W03.1");//03选项是1且 W03.1＞54岁
                if (int.Parse(answerW031) > 54)
                {
                    if (num >= 10)
                    {
                        lblResultApped.Text += "停经年龄≥54岁 \r"; num++;
                    }
                    else
                    {
                        lblResult.Text += "停经年龄≥54岁 \r"; num++;
                    }
 
                }
               
            }

            string answeW04 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
       QuestionnaireCode.ZaoAiRuXianAi + ".W04");//如果W04选项是0且年龄＞35岁则结论是 
            if (answeW04.Contains("B"))
            {
                //判断年龄是否大于35
                string ageAnswerA08 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".A08");
                if (ageAnswerA08.Contains("A"))
                {
                    if (num >= 10)
                    {
                        lblResultApped.Text += "大于35岁未生育 \r"; num++;
                    }
                    else
                    {
                        lblResult.Text += "大于35岁未生育 \r"; num++;
                    }
                }
                //           string answeW041 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
     //QuestionnaireCode.ZaoAiRuXianAi + ".W04.1");//如果W04选项是0且年龄＞35岁则结论是 
     //           if (answeW041.Contains("B"))
     //           {
     //               if (num >= 10)
     //               {
     //                   lblResultApped.Text += "大于35岁未生育 \r"; num++;
     //               }
     //               else
     //               {
     //                   lblResult.Text += "大于35岁未生育 \r"; num++;
     //               }
                   
     //           }
            }

            string answeW06 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
       QuestionnaireCode.ZaoAiRuXianAi + ".W06");//如果W04选项是0且年龄＞35岁则结论是 
            if (answeW06.Contains("A"))
            {
                if (num >= 10)
                {
                    lblResultApped.Text += "曾患良性乳腺疾病 \r"; num++;
                }
                else
                {
                  lblResult.Text += "曾患良性乳腺疾病 \r"; num++;
                }
              
            }

            string answeW08 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
      QuestionnaireCode.ZaoAiRuXianAi + ".W08");
            if(answeW08.Contains("A"))
            {
                 string answeW081 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
      QuestionnaireCode.ZaoAiRuXianAi + ".W08.1");
                if (answeW081.Contains("A"))
                {
                    if (num >= 10)
                    {
                        lblResultApped.Text += "有乳腺癌家族史 （二级内血缘亲属）\r"; num++;
                    }
                    else
                    {
                        lblResult.Text += "有乳腺癌家族史 （二级内血缘亲属）\r"; num++;
                    }
                   
                }
                string answeW082 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
        QuestionnaireCode.ZaoAiRuXianAi + ".W08.2");
                if (answeW082.Contains("A"))
                {
                    if (num >= 10)
                    {
                        lblResultApped.Text += "一级血缘亲属50岁前患乳腺癌 \r"; num++;
                    }
                    else
                    {
                        lblResult.Text += "一级血缘亲属50岁前患乳腺癌 \r"; num++;
                    }

                }
            }


            string answeW10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
    QuestionnaireCode.ZaoAiRuXianAi + ".W10");
            if (answeW10.Contains("A"))
            {
                if (num >= 10)
                {
                    lblResultApped.Text += "多次流产史 \r"; num++;
                }
                else
                {
                    lblResult.Text += "多次流产史 \r"; num++;
                }
               
            }

            string answeW11 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
   QuestionnaireCode.ZaoAiRuXianAi + ".W11");
            if (answeW11.Contains("A"))
            {
                if (num >= 10)
                {
                    lblResultApped.Text += "长期服用含雌激素的保健品 \r"; num++;
                }
                else
                {
                    lblResult.Text += "长期服用含雌激素的保健品 \r"; num++;
                }
             
            }

            string answeW12 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
 QuestionnaireCode.ZaoAiRuXianAi + ".W12");
            if (answeW12.Contains("A"))
            {
                if (num >= 10)
                {
                    lblResultApped.Text += "长期服用避孕药 \r"; num++;
                }
                else
                {
                    lblResult.Text += "长期服用避孕药 \r"; num++;
                }
             
            }

            string answeW13 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
QuestionnaireCode.ZaoAiRuXianAi + ".W13");
            if (answeW13.Contains("A")) lblResult.Text += "雌激素替代治疗 \r"; num++;

            string answeW14 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi,
QuestionnaireCode.ZaoAiRuXianAi + ".W14");
            if (answeW14.Contains("A"))
            {
                if (num >= 10)
                {
                    lblResultApped.Text += "人工受孕史 \r"; num++;
                }
                else
                {
                    lblResult.Text += "人工受孕史 \r"; num++;
                }
               
            }

            if (string.IsNullOrEmpty(lblResult.Text) && string.IsNullOrEmpty(lblResultApped.Text))
            {
                this.lblResult.Text = @"恭喜您，您是乳腺癌的低风险人群。风险低的人群，不能完全排除患癌症的可能性，建议定期做全面体检，以及时了解身体健康状况。并继续保持良好的生活方式。";
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
            ClientInfo.Logout();
            btnBack_Click(this, e);
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
            printTest += this.lblResult.Text;
            printTest += this.lblResultApped.Text;
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
            string str = @"3.1鉴于您存在以上乳腺癌的危险因素，
建议到医院早癌筛查中心或甲乳外科门
诊，在医生指导下进行相关检查。建议
筛查项目：
3.1.1肿瘤相关标志物检查: 癌胚抗原
(CEA)、糖类抗原153（CA153）
3.1.2重点筛查项目:双乳彩超和/或乳
腺钼钯检查（必要时行核磁共振检查
及专科乳腺穿刺活检或手术切检）
3.1.3以上推荐项目供参考，具体请遵
医嘱. 注：怀孕、疑似怀孕以及计划怀
孕者勿检乳腺钼靶。";
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
