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

namespace XYS.Remp.Screening.Naocuzhong
{
    public partial class ResultFrm : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器
        //问卷答题时间
        private DateTime answerTime;
        //用于打印
        private StringBuilder strResultPrint=new StringBuilder();
        //用于打印
        private StringBuilder strSugestionPrint = new StringBuilder();

        //private ScreeningServiceClient client=new ScreeningServiceClient();
        private ScreenWebapiClient screenWebapiClient = new ScreenWebapiClient();

        public ResultFrm()
        {
            InitializeComponent();
            
        }

        private void ResultFrm_Load(object sender, EventArgs e)
        {
            //问卷答题时间
            answerTime = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.NaoCuZhong).AnswerTime;

            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
            {
                M_QuestionnaireUserDetail questionnaireUserDetail= ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.NaoCuZhong);

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


            string[] answer = { "", "", "", "", "", "", "", "", "", "" };
            answer[0] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".1");
            answer[1] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".2");
            answer[2] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".3");
            answer[3] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".4");
            answer[4] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".5");
            answer[5] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6");
            answer[6] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".7");
            answer[7] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".8");
            answer[8] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".9");
            answer[9] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".10");

            string answer41 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".4.1");

            //判断高危中危
            /*
            前八项有任意三项“是”，或者后两项有任意一项“是”，则为高位人群。
            前八项有任意两项“是”，且患有高血压、糖尿病、瓣膜性心脏病中任意一项，则为中危人群。
            《=2项的，没有上述慢性病的为低位人群。*/
            int iForEightCount = 0;  //前八题回答是的个数

            for (int i = 0; i <= 7; i++)
            {
                if (answer[i].Contains("A"))
                    iForEightCount++;
            }

            int iLastTwoCount = 0; //后两题回答为是的个数

            if (answer[8].Contains("A")) iLastTwoCount++;
            if (answer[9].Contains("A")) iLastTwoCount++;

            //高血压风险因子
            bool hasPresure = false;

            //糖尿病风险因子
            bool hasSugar = false;

            bool hasHeart = false;

            if (answer[0].Contains("A")) hasPresure = true;
            if (answer[2].Contains("A")) hasSugar = true;
            if (answer41.Contains("C")) hasHeart = true;


            string strSugestion = "";
            StringBuilder strSugestionTempPrint =new StringBuilder();

            //高血压风险因子
            if (hasPresure)
            {
                strSugestion += "  少食或不吃高脂食物，多吃富含钙的食物，严格限盐(每日摄入量为7g-8g)，多饮水，首选温开水和淡茶水，每日至少1200ml。\r\n";
                strSugestionTempPrint.Append(@"少食或不吃高脂食物，多吃富含钙的食
物，严格限盐(每日摄入量为7g-8g)，
多饮水，首选温开水和淡茶水，每日至
少1200ml。"+"\r\n");
            }

            //糖尿病风险因子
            if (hasSugar)
            { 
                strSugestion += "  少吃水果，每餐主食应控制在7、8分饱即可，适量吃粗杂粮。每日吃50-100g粗粮，每日可以吃适量鱼肉和畜禽肉，一般控制在2两左右为好。\r\n";
                strSugestionTempPrint.Append(@"少吃水果，每餐主食应控制在7、8分
饱即可，适量吃粗杂粮。每日吃50-100g
粗粮，每日可以吃适量鱼肉和畜禽肉，
一般控制在2两左右为好。" + "\r\n");
            }

            //血脂异常风险因子
            if (answer[1].Contains("A")) //血脂异常
            {
                strSugestion += "  每周蛋黄摄入不超过3个，尽量不吃的食物：猪蹄、五花肉、肥肉、动物内脏、腊肉、动物皮、蟹黄、鱼子等，多吃菌藻类食物，每周泡泡山楂茶2-3次，多吃粗杂粮等富含纤维素的食物。\r\n";
                strSugestionTempPrint.Append(@"每周蛋黄摄入不超过3个，尽量不吃的
食物：猪蹄、五花肉、肥肉、动物内脏、
腊肉、动物皮、蟹黄、鱼子等，多吃菌
藻类食物，每周泡泡山楂茶2-3次，多
吃粗杂粮等富含纤维素的食物。" + "\r\n");
            }

            //心脏病风险因子
            if (answer[3].Contains("A")) //心脏病
            {
                strSugestion += "  低脂低胆固醇饮食，低糖饮食：少吃甜食，多吃富含膳食纤维的食物：新鲜蔬菜、水果、菌藻、粗粮等。\r\n";
                strSugestionTempPrint.Append(@"低脂低胆固醇饮食，低糖饮食：少吃甜
食，多吃富含膳食纤维的食物：新鲜蔬
菜、水果、菌藻、粗粮等。" + "\r\n");
            }

            //吸烟因子
            if (answer[4].Contains("A"))
            {
                strSugestion += "  戒烟。\r\n";
                strSugestionTempPrint.Append(@"戒烟。" + "\r\n");
            }

            //肥胖风险因子
            if (answer[5].Contains("A"))
            {
                strSugestion += "  少吃肥肉、糕点甜品、动物油、动物内脏、油炸食品、各种加工零食、碳酸饮料，每日吃1-2两粗杂粮。进食宜慢不宜快，少食多餐控体重。\r\n";
                strSugestionTempPrint.Append(@"少吃肥肉、糕点甜品、动物油、动物内
脏、油炸食品、各种加工零食、碳酸饮
料，每日吃1-2两粗杂粮。进食宜慢不
宜快，少食多餐控体重。" + "\r\n");
            }

            //运动缺乏或轻体力劳动者
            if (answer[6].Contains("A"))
            {
                strSugestion += "  每周体育锻炼≥3次、每次≥30分钟，并坚持形成习惯。\r\n";
                strSugestionTempPrint.Append(@"每周体育锻炼≥3次、每次≥30分钟，并
坚持形成习惯。" + "\r\n");
            }


//            lblSuguestion.Text = strSugestion == "" ? "恭喜您，您属于脑卒中低危人群，请您继续保持合理饮食生活习惯！" : strSugestion;
//            //用于打印
//            strSugestionPrint.Append(strSugestionTempPrint.ToString() == "" ? @"恭喜您，您属于脑卒中低危人群，请您
//继续保持合理饮食生活习惯！" : strSugestionTempPrint.ToString());


            if (iForEightCount >= 3 || iLastTwoCount >= 1) //高危人群
            {
                string strResult = @"您属于脑卒中高危人群，建议您前去医院检查以下项目："+"\r\n";
                string strTempPrint = @"您属于脑卒中高危人群，建议您前去医
院检查以下项目：" + "\r\n";

                strResult += "    颈部血管超声\r\n";
                strTempPrint += "颈部血管超声\r\n";

                strResult += "    心电图\r\n";
                strTempPrint += "心电图\r\n";

                //高血压风险因子
                if (hasPresure)
                {
                    strResult += "    同型半胱氨酸HCY\r\n";
                    strTempPrint += "同型半胱氨酸HCY\r\n";
                }

                //糖尿病风险因子
                if (hasSugar)
                {
                    strResult += "    糖化血红蛋白HbA1c\r\n";
                    strTempPrint += "糖化血红蛋白HbA1c\r\n";
                }

                lblResult.Text = strResult;

                //用于打印
                strResultPrint.Append(strTempPrint);


                //结果建议
                lblSuguestion.Text = strSugestion == "" ? "您属于脑卒中高危人群，请检查以上项目！" : strSugestion;
                //用于打印
                strSugestionPrint.Append(strSugestionTempPrint.ToString() == "" ? @"您属于脑卒中高危人群，请检查以上项目！" : strSugestionTempPrint.ToString());

                //给用户打标签
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new PatientRecordsManager().UpdatePatientAllRecords(1734, "脑卒中高危");
                }
                
                return;
            }

            if (iForEightCount>=2)
            {
                if ( hasPresure || hasSugar  || hasHeart ) //中危人群
                {
                    lblResult.Text = @"您属于脑卒中中危人群，请多注意饮食生活习惯。";
                    strResultPrint.Append(@"您属于脑卒中中危人群，请多注意饮食
生活习惯。");


                    //结果建议
                    lblSuguestion.Text = strSugestion == "" ? "您属于脑卒中中危人群，请多注意饮食生活习惯。" : strSugestion;
                    //用于打印
                    strSugestionPrint.Append(strSugestionTempPrint.ToString() == "" ? @"您属于脑卒中中危人群，请多注意饮食生活习惯。" : strSugestionTempPrint.ToString());

                    //给用户打标签
                    if (!LoginInfo.GetInstance().Name.Equals(""))
                    {
                        new PatientRecordsManager().UpdatePatientAllRecords(1735, "脑卒中中危");
                    }
                    
                    return;
                }
            }

            //低危人群
            lblResult.Text = @"您属于脑卒中低危人群，请继续保持合理的饮食生活习惯。";
            strResultPrint.Append(@"您属于脑卒中低危人群，请继续保持合
理的饮食生活习惯。");


            lblSuguestion.Text = strSugestion == "" ? "恭喜您，您属于脑卒中低危人群，请您继续保持合理饮食生活习惯！" : strSugestion;
            //用于打印
            strSugestionPrint.Append(strSugestionTempPrint.ToString() == "" ? @"恭喜您，您属于脑卒中低危人群，请您
继续保持合理饮食生活习惯！" : strSugestionTempPrint.ToString());

            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FirstFrm frmMain = new FirstFrm();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new FirstFrm(), this);
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

            printTest += "筛查结果：\r\n"+strResultPrint + "\r\n";
            //if (panel1.Visible)//如果有建议提醒
            //{
            //printTest += "\n筛查建议:\r\n";
            //printTest += PrintString();
            printTest += "\r\n";
            printTest += "筛查时间：" + answerTime + "\r\n";
            printTest += "----------------------------------------------------------\r\n";
            printTest += "结果建议：\r\n"+strSugestionPrint;
            //}
            streamToPrint = (StringReader)new StringReader(printTest);//从本地文件来打印 
            StringFormat fmt = new StringFormat();
            //fmt.LineAlignment = StringAlignment.Center;
            //fmt.FormatFlags = StringFormatFlags.LineLimit;
            while (count < totalines && ((lineStr = streamToPrint.ReadLine()) != null))
            {
                lineStr = lineStr.Replace("  ", "");
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
