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
using XYS.Remp.Screening.Zaoai;

namespace XYS.Remp.Screening.Zaoai.Weiai
{
    public partial class WeiAiResultForm : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;
        //用于打印
        private StringBuilder strResultPrint=new StringBuilder();
        private StringBuilder strResultPrintAppend=new StringBuilder();

        public WeiAiResultForm()
        {
            InitializeComponent();
        }

        private void WeiAiResultForm_Load(object sender, EventArgs e)
        {
            //问卷答题时间
            answerTime = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiWeiAi).AnswerTime;
            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiWeiAi);

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
            string answerA03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".A03");
            if (answerA03.Contains("A"))
            {
                lblResult.Text += "有不明原因消瘦 \r";
                strResultPrint.Append(@"有不明原因消瘦"+"\r");
            }
            num++;

            string answerA09 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".A09");

            if (answerA09.Contains("A"))
            {
                string answerA091 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".A09.1");
                if (answerA091.Length > 0)
                {
                    lblResult.Text += "从事过接触有害致癌物质的职业 \r";
                    strResultPrint.Append(@"从事过接触有害致癌物质的职业" + "\r");
                    num++;
                }
            }

            string answerB13 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".B01.3");
            string answerB15 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".B01.5");
            string answerB16 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".B01.6");
            string answerB17 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".B01.7");
            string answerB19 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".B01.9");
            string answerB110 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".B01.10");
            if (answerB13.Contains("A"))
            {
                lblResult.Text += "高盐饮食 \r";
                strResultPrint.Append(@"高盐饮食" + "\r");
                num++;
            }
            if (answerB15.Contains("C"))
            {
                lblResult.Text += "喜食腌制、熏制食品 \r";
                strResultPrint.Append(@"喜食腌制、熏制食品" + "\r");
                num++;
            }
            if (answerB16.Contains("C"))
            {
                lblResult.Text += "过多进食霉变食物 \r";
                strResultPrint.Append(@"过多进食霉变食物" + "\r");
                num++;
            }
            if (answerB17.Contains("C"))
            {
                lblResult.Text += "少食新鲜蔬菜 \r";
                strResultPrint.Append(@"少食新鲜蔬菜" + "\r");
                num++;
            }
            if (answerB19.Contains("C"))
            {
                lblResult.Text += "进餐速度快 \r";
                strResultPrint.Append(@"进餐速度快" + "\r");
                num++;
            }
            if (answerB110.Contains("C"))
            {
                lblResult.Text += "饮食不规律 \r";
                strResultPrint.Append(@"饮食不规律" + "\r");
                num++;
            }


            string answerC3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".C03");
            if (answerC3.Contains("B"))
            {
                string answerC31 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".C03.1");
                string answerC32 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".C03.2");
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
                strResultPrint.Append(@"吸烟（" + c31Result + c32Result.Substring(0, c32Result.Length - 1) + ") \r");
                num++;
            }
            else if (answerC3.Contains("C"))
            {
                string answerC33 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".C03.3");
                if (answerC33.Contains("A"))
                {
                    lblResult.Text += "有吸烟史，戒烟少于15年 \r";
                    strResultPrint.Append(@"有吸烟史，戒烟少于15年"+"\r");
                    num++;
                    
                }
            }

           
            string answerC4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".C04");
            if (answerC4.Contains("B"))
            {
                if (num >= 10)
                {
                    lblResultAppend.Text += "长期被动吸烟 \r"; 
                    strResultPrintAppend.Append(@"长期被动吸烟" + "\r");
                    num++;
                }
                else
                {
                    lblResult.Text += "长期被动吸烟 \r";
                    strResultPrint.Append(@"长期被动吸烟"+"\r");
                    num++;
                }
             
            }

            string answerC5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".C05");
            if (answerC5.Contains("B"))
            {
                if (num >= 10)
                {
                    lblResultAppend.Text += "长期酗酒 \r";
                    strResultPrintAppend.Append(@"长期酗酒"+"\r");
                    num++;
                }
                else
                {
                    lblResult.Text += "长期酗酒 \r";
                    strResultPrint.Append("长期酗酒"+"\r");
                    num++;
                }
           
            }

            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".E01");
            if (answerE01.Contains("A"))
            {
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E01.1");
                if (num >= 10)
                {
                    lblResultAppend.Text += "有" + answerE011 + "癌病史 \r";
                    strResultPrintAppend.Append(@"有" + answerE011 + "癌病史 \r");
                    num++;
                }
                else
                {
                    lblResult.Text += "有" + answerE011 + "癌病史 \r";
                    strResultPrint.Append(@"有" + answerE011 + "癌病史 \r");
                    num++;
                }
             
            }

            string answerE04 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".E04");
            if (answerE04.Contains("A"))
            {
                string answerE041 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E04.1");
                if (answerE041.Contains("B"))
                {
                    if (num >= 10)
                    {
                        lblResultAppend.Text += "便潜血阳性，有上消化道出血可能 \r";
                        strResultPrintAppend.Append(@"便潜血阳性，有上消化道出血可能"+"\r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "便潜血阳性，有上消化道出血可能 \r";
                        strResultPrint.Append(@"便潜血阳性，有上消化道出血可能"+"\r");
                        num++;
                    }
             
                 
                }
            }

            ////E06及E06.1-E06.8组合条件判断
            ////E06及E06.1-E06.8任意一个或多个问题选择选项1“是”，则结论均为：有上消化系统疾病病史（病名1、病名2）
            string answerE06 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".E06");
            if (answerE06.Contains("A"))
            {
                string answerE061 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.1");
                string answerE062 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.2");
                string answerE063 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.3");
                string answerE064 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.4");
                string answerE065 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.5");
                string answerE066 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.6");
                string answerE067 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.7");
                string answerE068 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                    QuestionnaireCode.ZaoAiWeiAi + ".E06.8");
                string result = "";
                //用于打印
                string resultTempPrint = "";

                if (answerE061.Contains("A"))
                {
                    result += "反流性食管炎,";
                    resultTempPrint += @"反流性食管炎,"+"\r";
                }
                if (answerE062.Contains("A"))
                {
                    result += "浅表性胃炎,";
                    resultTempPrint += @"浅表性胃炎," + "\r";
                }
                if (answerE063.Contains("A"))
                {
                    result += "萎缩性胃炎,";
                    resultTempPrint += @"萎缩性胃炎," + "\r";
                }
                if (answerE064.Contains("A"))
                {
                    result += "胃溃疡,";
                    resultTempPrint += @"胃溃疡," + "\r";
                }
                if (answerE065.Contains("A"))
                {
                    result += "十二指肠溃疡,";
                    resultTempPrint += @"十二指肠溃疡,"+"\r";
                }
                if (answerE066.Contains("A"))
                {
                    result += "胃息肉病,";
                    resultTempPrint += @"胃息肉病," + "\r";
                }
                if (answerE067.Contains("A"))
                {
                    result += "胃切除手术史,";
                    resultTempPrint += @"胃切除手术史," + "\r";
                }
                if (answerE068.Contains("A"))
                {
                    result += "消化道出血史,";
                    resultTempPrint += @"消化道出血史," + "\r";
                }
                if (!string.IsNullOrEmpty(result))
                {
                    if (num >= 10)
                    {
                        lblResultAppend.Text += "有上消化系统疾病病史(" + result + ") \r";
                        strResultPrintAppend.Append("有上消化系统疾病病史(\r" + resultTempPrint + ") \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有上消化系统疾病病史(" + result + ") \r";
                        strResultPrint.Append("有上消化系统疾病病史(\r" + resultTempPrint + ") \r");
                        num++;
                    }
                  
                }
            }
            string answerE095 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".E09.5");
            string answerE096 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".E09.6");
            if (answerE095.Contains("A"))
            {
                if (num >= 10)
                {
                    lblResultAppend.Text += "有缺铁性贫血病史 \r";
                    strResultPrintAppend.Append(@"有缺铁性贫血病史" + "\r");
                    num++;
                }
                else
                {
                    lblResult.Text += "有缺铁性贫血病史 \r";
                    strResultPrint.Append(@"有缺铁性贫血病史" + "\r");
                    num++;
                }
              
            }
            if (answerE096.Contains("A"))
            {
                if (num >= 10)
                {
                    lblResultAppend.Text += "胃幽门螺旋杆菌感染病史 \r";
                    strResultPrintAppend.Append(@"胃幽门螺旋杆菌感染病史"+"\r");
                    num++;
                }
                else
                {
                    lblResult.Text += "胃幽门螺旋杆菌感染病史 \r";
                    strResultPrint.Append(@"胃幽门螺旋杆菌感染病史"+"\r");
                    num++;
                }
              
            }
            string answerF01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
                QuestionnaireCode.ZaoAiWeiAi + ".F01");

            if (answerF01.Contains("A"))
            {
                string answerF012 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
              QuestionnaireCode.ZaoAiWeiAi + ".F01.2");
                if (answerF012.Contains("A"))
                {
                    string answerF0121 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
            QuestionnaireCode.ZaoAiWeiAi + ".F01.2.1");
                    string result = string.Empty;
                    //用于打印
                    string resultTempPrint = string.Empty;

                    if (answerF0121.Contains("A"))
                    {
                        result += "母亲、";
                        resultTempPrint += @"母亲、";
                    }
                    if (answerF0121.Contains("B"))
                    {
                        result += "父亲、";
                        resultTempPrint += @"父亲、";
                    }
                    if (answerF0121.Contains("C"))
                    {
                        result += "姐妹、";
                        resultTempPrint += @"姐妹、";
                    }
                    if (answerF0121.Contains("D"))
                    {
                        result += "兄弟、";
                        resultTempPrint += @"兄弟、";
                    }
                    if (answerF0121.Contains("E"))
                    {
                        result += "祖父母、";
                        resultTempPrint += @"祖父母、";
                    }
                    if (answerF0121.Contains("F"))
                    {
                        result += "外祖父母、";
                        resultTempPrint += @"外祖父母、";
                    }
                    if (answerF0121.Contains("G"))
                    {
                        result += "叔姑、";
                        resultTempPrint += @"叔姑、";
                    }
                    if (answerF0121.Contains("H"))
                    {
                        result += "舅姨、";
                        resultTempPrint += @"舅姨、";
                    }
                    if (answerF0121.Contains("I"))
                    {
                        result += "堂兄弟姐妹、";
                        resultTempPrint += @"堂兄弟姐妹、";
                    }
                    if (answerF0121.Contains("J"))
                    {
                        result += "表兄弟姐妹、";
                        resultTempPrint += @"表兄弟姐妹、";
                    }
                    if (answerF0121.Contains("K"))
                    {
                        result += "其他、";
                        resultTempPrint += @"其他、";
                    }
                    if (num >= 10)
                    {
                        lblResultAppend.Text += "有食管癌家族史(" + result + ") \r";
                        strResultPrintAppend.Append(@"有食管癌家族史");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有食管癌家族史(" + result + ") \r";
                        strResultPrint.Append(@"有食管癌家族史");
                        num++;
                    }
                 
                }

                string answerF013 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
             QuestionnaireCode.ZaoAiWeiAi + ".F01.3");

                if (answerF013.Contains("A"))
                {
                    string answerF0131 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi,
           QuestionnaireCode.ZaoAiWeiAi + ".F01.3.1");
                    string result = string.Empty;
                    //用于打印
                    string resultTempPrint = string.Empty;

                    if (answerF0131.Contains("A"))
                    {
                        result += "母亲、";
                        resultTempPrint += @"母亲、";
                    }
                    if (answerF0131.Contains("B"))
                    {
                        result += "父亲、";
                        resultTempPrint += @"父亲、";
                    }
                    if (answerF0131.Contains("C"))
                    {
                        result += "姐妹、";
                        resultTempPrint += @"姐妹、";
                    }
                    if (answerF0131.Contains("D"))
                    {
                        result += "兄弟、";
                        resultTempPrint += @"兄弟、";
                    }
                    if (answerF0131.Contains("E"))
                    {
                        result += "祖父母、";
                        resultTempPrint += @"祖父母、";
                    }
                    if (answerF0131.Contains("F"))
                    {
                        result += "外祖父母、";
                        resultTempPrint += @"外祖父母、";
                    }
                    if (answerF0131.Contains("G"))
                    {
                        result += "叔姑、";
                        resultTempPrint += @"叔姑、";
                    }
                    if (answerF0131.Contains("H"))
                    {
                        result += "舅姨、";
                        resultTempPrint += @"舅姨、";
                    }
                    if (answerF0131.Contains("I"))
                    {
                        result += "堂兄弟姐妹、";
                        resultTempPrint += @"堂兄弟姐妹、";
                    }
                    if (answerF0131.Contains("J"))
                    {
                        result += "表兄弟姐妹、";
                        resultTempPrint += @"表兄弟姐妹、";
                    }
                    if (answerF0131.Contains("K"))
                    {
                        result += "其他、";
                        resultTempPrint += @"其他、";
                    }
                    if (num >= 10)
                    {
                        lblResultAppend.Text += "有胃癌家族史(" + result + ") \r";
                        strResultPrintAppend.Append(@"有胃癌家族史");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有胃癌家族史(" + result + ") \r";
                        strResultPrint.Append(@"有胃癌家族史");
                        num++;
                    }
                 
                }
            }

            if (string.IsNullOrEmpty(lblResult.Text) && string.IsNullOrEmpty(lblResultAppend.Text))
            {
                lblResult.Text = @"恭喜您，您是胃癌的低风险人群。风险低的人群，不能完全排除患癌症的可能性，建议定期做全面体检，以及时了解身体健康状况。并继续保持良好的生活方式。";
                strResultPrint.Append(@"恭喜您，您是胃癌的低风险人群。风险
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
            printTest += strResultPrint.ToString();
            printTest += strResultPrintAppend.ToString();
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
            string str = @"4.1鉴于您存在以上胃癌的危险因素，建
议到医院早癌筛查中心或消化内科门诊
或肠胃外科门诊，在医生指导下进行相
关检查。建议筛查项目：
4.1.1肿瘤相关标志物检查：
癌胚抗原(CEA)、糖类抗原242（CA242
）、糖类抗原724（CA724）、糖类抗
原19-9（CA19-9)、胃蛋白酶原Ⅰ、Ⅱ
（PGⅠ、PGⅡ）
4.1.2重点筛查项目：
碳-13呼气试验、无痛胃镜检查。
4.1.3以上推荐项目供参考，具体请遵医
嘱。";
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
