using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Dachang
{
    public partial class DaChangResult : XYS.Remp.Screening.BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;
        //用于打印
        StringBuilder strResultPrint=new StringBuilder();
        StringBuilder strResultAppendPrint=new StringBuilder();

        public DaChangResult()
        {
            InitializeComponent();
        }
        private void DaChangResult_Load(object sender, EventArgs e)
        {
            //问卷答题时间
            answerTime = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiDaChangAi).AnswerTime;

            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                M_QuestionnaireUserDetail questionnaireUserDetail= ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiDaChangAi);

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
            string answerA03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
            QuestionnaireCode.ZaoAiDaChangAi + ".A03");
            if (answerA03.Contains("A"))
            {
                lblResult.Text += "有不明原因消瘦 \r";
                strResultPrint.Append("有不明原因消瘦 \r");
            }
            num++;

            string answerA09 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                QuestionnaireCode.ZaoAiDaChangAi + ".A09");

            if (answerA09.Contains("A"))
            {
                string answerA091 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                    QuestionnaireCode.ZaoAiDaChangAi + ".A09.1");
                if (answerA091.Length > 0)
                {
                    lblResult.Text += "从事过接触有害致癌物质的职业 \r";
                    strResultPrint.Append("从事过接触有害致癌物质的职业 \r");
                    num++;
                }
            }

            string answerB14 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                QuestionnaireCode.ZaoAiDaChangAi + ".B01.4");
            string answerB15 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                QuestionnaireCode.ZaoAiDaChangAi + ".B01.5");
            string answerB16 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                QuestionnaireCode.ZaoAiDaChangAi + ".B01.6");
            string answerB17 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                QuestionnaireCode.ZaoAiDaChangAi + ".B01.7");
            string answerB18 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
         QuestionnaireCode.ZaoAiDaChangAi + ".B01.8");
            if (answerB14.Contains("A"))
            {
                lblResult.Text += "高脂饮食 \r";
                strResultPrint.Append("高脂饮食 \r");
                num++;
            }
            if (answerB15.Contains("C"))
            {
                lblResult.Text += "喜食腌制、熏制食品 \r";
                strResultPrint.Append("喜食腌制、熏制食品 \r");
                num++;
            }
            if (answerB16.Contains("C"))
            {
                lblResult.Text += "过多进食霉变食物 \r";
                strResultPrint.Append("过多进食霉变食物 \r");
                num++;
            }
            if (answerB17.Contains("C"))
            {
                lblResult.Text += "少食新鲜蔬菜 \r";
                strResultPrint.Append("少食新鲜蔬菜 \r");
                num++;
            }
            if (answerB18.Contains("C"))
            {
                lblResult.Text += "低纤维饮食 \r";
                strResultPrint.Append("低纤维饮食 \r");
                num++;
            }

            string answerC3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                QuestionnaireCode.ZaoAiDaChangAi + ".C03");
            if (answerC3.Contains("B"))
            {
                string answerC31 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                    QuestionnaireCode.ZaoAiDaChangAi + ".C03.1");
                string answerC32 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                    QuestionnaireCode.ZaoAiDaChangAi + ".C03.2");
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
                else if (answerC31.Contains("D"))
                {
                    c31Result += "20支以上/天,";
                }
                else
                {
                    c31Result = "";
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
              else if (answerC32.Contains("D"))
              {
                  c32Result += "10年以上,";
              }
              else
              {
                  c32Result = "";
              }
                //by 洪鹏
                if (!string.IsNullOrEmpty(c31Result) && !string.IsNullOrEmpty(c32Result))
                {
                    lblResult.Text += "吸烟（" + c31Result + c32Result.Substring(0, c32Result.Length - 1) + ") \r";
                    strResultPrint.Append("吸烟（" + c31Result + c32Result.Substring(0, c32Result.Length - 1) + ") \r");
                    num++;
                }
                else if (!string.IsNullOrEmpty(c31Result))
                {
                    lblResult.Text += "吸烟（" + c31Result + ") \r";
                    strResultPrint.Append("吸烟（" + c31Result + ") \r");
                    num++;
                }
                else if (!string.IsNullOrEmpty(c32Result))
                {
                    lblResult.Text += "吸烟（" + c32Result.Substring(0, c32Result.Length - 1) + ") \r";
                    strResultPrint.Append("吸烟（" + c32Result.Substring(0, c32Result.Length - 1) + ") \r");
                    num++;
                }
                //end

                //by 杨双
                //if (string.IsNullOrEmpty(c31Result) && !string.IsNullOrEmpty(c32Result))
                //{
                //    lblResult.Text += "吸烟（" +c32Result.Substring(0, c32Result.Length - 1) + ") \r";
                //    strResultPrint.Append("吸烟（" + c32Result.Substring(0, c32Result.Length - 1) + ") \r");
                //    num++;
                //}
                //if (string.IsNullOrEmpty(c32Result) && !string.IsNullOrEmpty(c31Result))
                //{
                //    lblResult.Text += "吸烟（" + c31Result + ") \r";
                //    strResultPrint.Append("吸烟（" + c31Result + ") \r");
                //    num++;
                //}
                //end

                if (string.IsNullOrEmpty(c31Result) && string.IsNullOrEmpty(c32Result))
                {
                    lblResult.Text += "目前仍在吸烟 \r";
                    strResultPrint.Append("目前仍在吸烟 \r");
                    num++;
                }
            }
            else if (answerC3.Contains("C"))
            {
                string answerC33 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
                    QuestionnaireCode.ZaoAiDaChangAi + ".C03.3");
                if (answerC33.Contains("A"))
                {
                    lblResult.Text += "有吸烟史，戒烟少于15年 \r";
                    strResultPrint.Append("有吸烟史，戒烟少于15年 \r");
                    num++;
                }
            }

            string answerC4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
              QuestionnaireCode.ZaoAiDaChangAi + ".C04");
            if (answerC4.Contains("B"))
            {

                lblResult.Text += "长期被动吸烟 \r";
                strResultPrint.Append("长期被动吸烟 \r");
                num++;
            }

            string answerD01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
        QuestionnaireCode.ZaoAiDaChangAi + ".D01");

            if (answerD01.Contains("A"))
            {
                lblResult.Text += "有较大精神创伤史 \r";
                strResultPrint.Append("有较大精神创伤史 \r");
                num++;
            }

            string answerD02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
          QuestionnaireCode.ZaoAiDaChangAi + ".D02");
            if (answerD02.Contains("A"))
            {
                lblResult.Text += "长期精神抑郁 \r";
                strResultPrint.Append("长期精神抑郁 \r");
                num++;
            }

            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
       QuestionnaireCode.ZaoAiDaChangAi + ".E01");
            if (answerE01.Contains("A"))
            {
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
        QuestionnaireCode.ZaoAiDaChangAi + ".E01.1");
                lblResult.Text += "有" + answerE011 + "癌病史 \r";
                strResultPrint.Append("有" + answerE011 + "癌病史 \r");
                num++;
            }

            string answerE74 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
     QuestionnaireCode.ZaoAiDaChangAi + ".E07.4");
            string answerE78 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
QuestionnaireCode.ZaoAiDaChangAi + ".E07.8");
            string answerE79 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
QuestionnaireCode.ZaoAiDaChangAi + ".E07.9");

            if (answerE74.Contains("A"))
            {
                lblResult.Text += "有血吸虫感染病史 \r";
                strResultPrint.Append("有血吸虫感染病史 \r");
                num++;
            }

            if (answerE78.Contains("A"))
            {
                lblResult.Text += "有慢性胆道感染病史 \r";
                strResultPrint.Append("有慢性胆道感染病史 \r");
                num++;
            }

            if (answerE79.Contains("A"))
            {
                lblResult.Text += "有胆囊切除手术史 \r";
                strResultPrint.Append("有胆囊切除手术史 \r");
                num++;
            }

            string answerE08 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08");
            if (answerE08.Contains("A"))
            {
                string answerE081 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.1");
                if (answerE081.Contains("A"))
                {
                    if (num >= 15) 
                    {
                        lblResultAppend.Text += "有肠息肉病史 \r";
                        strResultAppendPrint.Append("有肠息肉病史 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有肠息肉病史 \r";
                        strResultPrint.Append("有肠息肉病史 \r");
                        num++;
                    }
                   
                }

                string answerE082 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.2");
                if (answerE082.Contains("A"))
                {
                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有炎症性肠病病史 \r";
                        strResultAppendPrint.Append("有炎症性肠病病史 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有炎症性肠病病史 \r";
                        strResultPrint.Append("有炎症性肠病病史 \r");
                        num++;
                    }

                }
                string answerE083 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.3");
                if (answerE083.Contains("A"))
                {
                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有慢性阑尾炎病史 \r";
                        strResultAppendPrint.Append("有慢性阑尾炎病史 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有慢性阑尾炎病史 \r";
                        strResultPrint.Append("有慢性阑尾炎病史 \r");
                        num++;
                    }

                
                }
                string answerE084 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.4");
                if (answerE084.Contains("A"))
                {
                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有排血便史 \r";
                        strResultAppendPrint.Append("有排血便史 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有排血便史 \r";
                        strResultPrint.Append("有排血便史 \r");
                        num++;
                    }
                }
                string answerE085 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.5");
                if (answerE085.Contains("A"))
                {

                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有慢性腹痛、腹泻史 \r";
                        strResultAppendPrint.Append("有慢性腹痛、腹泻史 \r");
                        num++;
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有慢性腹痛、腹泻史 \r";
                        strResultPrint.Append("有慢性腹痛、腹泻史 \r");
                        num++;
                    }
                  
                }
                string answerE086 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.6");
                if (answerE086.Contains("A"))
                {

                    if (num >= 15)
                    {
                        lblResultAppend.Text += "结肠息肉综合征史 \r";
                        strResultAppendPrint.Append("结肠息肉综合征史 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "结肠息肉综合征史 \r";
                        strResultPrint.Append("结肠息肉综合征史 \r");
                        num++;
                    }
                }
                string answerE087 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.7");
                if (answerE087.Contains("A"))
                {

                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有下消化系统疾病病史 \r";
                        strResultAppendPrint.Append("有下消化系统疾病病史 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有下消化系统疾病病史 \r";
                        strResultPrint.Append("有下消化系统疾病病史 \r");
                        num++;
                    }
                 
                }
             
            }

            string answerE09 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09");
            if (answerE09.Contains("A"))
            {
                string answerE091 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.1");
                string answerE092 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.2");
                string answerE093 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.3");
                string answerE094 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.4");
                string answerE095 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.5");
                if (answerE094.Contains("A"))
                {

                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有代谢综合征 \r";
                        strResultAppendPrint.Append("有代谢综合征 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有代谢综合征 \r";
                        strResultPrint.Append("有代谢综合征 \r");
                        num++;
                    }
                  
                }
                else
                {
                    if (answerE091.Contains("A") && answerE092.Contains("A") && answerE093.Contains("A"))
                    {
                        if (num >= 15)
                        {
                            lblResultAppend.Text += "有代谢综合征可能 \r";
                            strResultAppendPrint.Append("有代谢综合征可能 \r");
                            num++;
                        }
                        else
                        {
                            lblResult.Text += "有代谢综合征可能 \r";
                            strResultPrint.Append("有代谢综合征可能 \r\n");
                            num++;
                        }
                       
                    }
                }
  

                if (answerE095.Contains("A"))
                {

                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有缺铁性贫血病史 \r";
                        strResultAppendPrint.Append("有缺铁性贫血病史 \r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有缺铁性贫血病史 \r";
                        strResultPrint.Append("有缺铁性贫血病史 \r");
                        num++;
                    }
                  
                }
            }
            string answerE10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E10");
            if (answerE10.Contains("A"))
            {
                if (num >= 15)
                {
                    lblResultAppend.Text += "有盆腔放疗史 \r";
                    strResultAppendPrint.Append("有盆腔放疗史 \r");
                    num++;
                }
                else
                {
                    lblResult.Text += "有盆腔放疗史 \r";
                    strResultPrint.Append("有盆腔放疗史 \r");
                    num++;
                }
            
            }

            string answerF01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
   QuestionnaireCode.ZaoAiDaChangAi + ".F01");
            if (answerF01.Contains("A"))
            {
                string answerF011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
     QuestionnaireCode.ZaoAiDaChangAi + ".F01.1");
                if (answerF011.Contains("A"))
                {
                    string answerF012 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi,
   QuestionnaireCode.ZaoAiDaChangAi + ".F01.2");
                    string result = string.Empty;
                    if (answerF012.Contains("A")) result += "母亲、";
                    if (answerF012.Contains("B")) result += "父亲、";
                    if (answerF012.Contains("C")) result += "姐妹、";
                    if (answerF012.Contains("D")) result += "兄弟、";
                    if (answerF012.Contains("E")) result += "祖父母、";
                    if (answerF012.Contains("F")) result += "外祖父母、";
                    if (answerF012.Contains("G")) result += "叔姑、";
                    if (answerF012.Contains("H")) result += "舅姨、";
                    if (answerF012.Contains("I")) result += "堂兄弟姐妹、";
                    if (answerF012.Contains("J")) result += "表兄弟姐妹、";
                    if (answerF012.Contains("K")) result += "其他、";
                    if (num >= 15)
                    {
                        lblResultAppend.Text += "有大肠癌家族史(" + result + ") \r";
                        strResultAppendPrint.Append("有大肠癌家族史\r");
                        num++;
                    }
                    else
                    {
                        lblResult.Text += "有大肠癌家族史(" + result + ") \r";
                        strResultPrint.Append("有大肠癌家族史\r");
                        num++;
                    }
                  
                }
            }
            if (string.IsNullOrEmpty(lblResult.Text) && string.IsNullOrEmpty(lblResultAppend.Text))
            {
                lblResult.Text = "恭喜您，您是大肠癌的低风险人群。风险低的人群，不能完全排除患癌症的可能性，建议定期做全面体检，以及时了解身体健康状况。并继续保持良好的生活方式。";

                strResultPrint = new StringBuilder(@"恭喜您，您是大肠癌的低风险人群。风
险低的人群，不能完全排除患癌症的可
能性，建议定期做全面体检，以及时了
解身体健康状况。并继续保持良好的生
活方式。");

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
            float leftM = 15;//e.MarginBounds.Left;//20; // e.MarginBounds.Left;  //在打印范围内获取左边的打印点 
            float topT = 0;//e.MarginBounds.Top;//20;// e.MarginBounds.Top;    //在打印范围内获取上边的打印点 
            string lineStr = null;       //存储一行数据 e.MarginBounds.Height
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
            printTest += strResultPrint;//this.lblResult.Text;
            printTest += strResultAppendPrint;//this.lblResultAppend.Text;
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

                //e.Graphics.DrawString(lineStr, printFont, Brushes.Black, leftM, yPos, fmt);
                count++; //下一行  
            }
            if (lineStr != null) //如果还有内容 另换一页 
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            
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
            string str = @"5.1鉴于您存在以上大肠癌的危险因素,
建议到医院早癌筛查中心或消化内科门
诊或肠胃外科门诊，在医生指导下进行
相关检查。

5.1.1肿瘤相关标志物方案癌胚抗原(C
EA)、糖类抗原242（CA242）、糖类抗
原724（CA724）、糖类抗原19-9（CA1
9-9)

5.1.2重点筛查项目
直肠指诊，粪便隐血试验，无痛结肠镜
检。
以上推荐项目供参考，具体请遵医嘱。";
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
        private int number = 2;
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }
    }
}
