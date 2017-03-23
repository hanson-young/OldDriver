using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.AD
{
    public partial class Result : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;

        //private ScreeningServiceClient client = new ScreeningServiceClient();
        private ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            try
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.NaoNianChiDai);

                //如果本地问卷记录为空，则从数据库取数据
                if (questionnaireUserDetail == null)
                {
                    questionnaireUserDetail = screenWebapiClient.GetQuestionnaireUserDetailById(Properties.Settings.Default.QuestionnaireRecodId);
                    if (questionnaireUserDetail != null)
                        questionnaireUserDetail.Questions = screenWebapiClient.GetQuestionnaireResultDetails(questionnaireUserDetail.QuestionnaireRecodId);
                }
                //问卷答题时间
                answerTime =questionnaireUserDetail!=null? questionnaireUserDetail.AnswerTime:DateTime.Now;

                //将游客的结果保存为xml
                if (LoginInfo.GetInstance().Name.Equals(""))
                {
                    if (questionnaireUserDetail != null && questionnaireUserDetail.Questions!=null && questionnaireUserDetail.Questions.Any())
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
                        saveXml.AddXmlElement(number, questionnaireUserDetail.Questions);

                        //显示游客编号
                        lblVisitor.Text += number;
                        lblVisitor.Visible = true;
                    }
                }

                //将登录人与活动关联
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new CottageActivityManager().AddPToCActivity();
                }

                Single score = 0;

                #region 计算每题得分

                int tempScore = 0;

                DateTime dateNow = DateTime.Today;

                //第一题，每个1分，权重0.8：
                string answerWeek = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.1");

                //判断星期
                DayOfWeek week = dateNow.DayOfWeek;
                string todayWeek = week.ToString();

                switch (todayWeek)
                {
                    case "Monday":
                        todayWeek = "星期一";
                        break;
                    case "Tuesday":
                        todayWeek = "星期二";
                        break;
                    case "Wednesday":
                        todayWeek = "星期三";
                        break;
                    case "Thursday":
                        todayWeek = "星期四";
                        break;
                    case "Friday":
                        todayWeek = "星期五";
                        break;
                    case "Saturday":
                        todayWeek = "星期六";
                        break;
                    case "Sunday":
                        todayWeek = "星期日";
                        break;

                }
                if (answerWeek == todayWeek) tempScore += 1;

                //判断日期
                string answerDay1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.2");
                //string answerDay2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.3");

                int tempDay = 0;
                int.TryParse(answerDay1, out tempDay);

                if (tempDay == dateNow.Day) tempScore += 1;

                //判断月份：
                string answerMonth = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.4");

                if (answerMonth.Trim() == dateNow.Month.ToString()) tempScore += 1;

                string strSeason = "";

                //判断季节：
                string answerSeason = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.5");
                ChineseLunisolarCalendar season = new ChineseLunisolarCalendar();
                switch (season.GetMonth(dateNow))
                {
                    case 1:
                    case 2:
                    case 3:
                        strSeason = "春";
                        break;
                    case 4:
                    case 5:
                    case 6:
                        strSeason = "夏";
                        break;
                    case 7:
                    case 8:
                    case 9:
                        strSeason = "秋";
                        break;
                    case 10:
                    case 11:
                    case 12:
                        strSeason = "冬";
                        break;
                }

                if (answerSeason == strSeason) tempScore += 1;

                //判断年
                string answerYear = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.6");
                if (dateNow.Year.ToString() == answerYear) tempScore += 1;

                //第一题得分乘权重 
                score += (Single)(tempScore * 0.8);

                //第二题，每答对一项记1分，共3分，权重2.0
                tempScore = 0;
                string answerTwo1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".2.1");

                string answerTwo2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".2.2");

                string answerTwo3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".2.3");

                if (answerTwo1.Contains("A")) tempScore += 1;

                if (answerTwo2.Contains("A")) tempScore += 1;

                if (answerTwo3.Contains("A")) tempScore += 1;

                score += (Single)(tempScore * 2);

                //第三题，每答对一项记1分，共5分，权重1.8
                tempScore = 0;
                string answerThree = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".3");

                if (answerThree.Contains("A")) tempScore += 1;

                if (answerThree.Contains("B")) tempScore += 1;

                if (answerThree.Contains("C")) tempScore += 1;

                if (answerThree.Contains("D")) tempScore += 1;

                if (answerThree.Contains("E")) tempScore += 1;

                score += (Single)(tempScore * 1.8);

                //第四题，根据准确度给分，共5分，权重2.0
                tempScore = 0;
                string answerFour = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".4");

                if (answerFour.Contains("A")) tempScore += 1;

                string answerFourB = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".4.B");

                if (answerFourB.Contains("A")) tempScore += 1;

                string answerFourC = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".4.C");

                if (answerFourC.Contains("A")) tempScore += 1;
                if (answerFourC.Contains("B")) tempScore += 1;
                if (answerFourC.Contains("C")) tempScore += 1;

                score += (Single)(tempScore * 2);

                //第五题，每答对一项记1分，共2分，权重1.4
                tempScore = 0;
                string answerFive = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".5.1");
                string answerFive2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".5.2");

                if (answerFive.Contains("A")) tempScore += 1;

                if (answerFive2.Contains("A")) tempScore += 1;

                score += (Single)(tempScore * 1.4);


                //第六题，选择（1）自己可以做，记1分；（2）有些困难，记2分；（3）需要帮助，记3分；（4）根本无法做，记4分，最高40分，权重-0.8
                tempScore = 0;
                string[] answer6 = { "", "", "", "", "", "", "", "", "", "" };
                answer6[0] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.1");
                answer6[1] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.2");
                answer6[2] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.3");
                answer6[3] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.4");
                answer6[4] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.5");
                answer6[5] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.6");
                answer6[6] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.7");
                answer6[7] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.8");
                answer6[8] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.9");
                answer6[9] = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".6.10");

                for (int i = 0; i <= 9; i++)
                {
                    if (answer6[i].Contains("A")) tempScore += 1;
                    if (answer6[i].Contains("B")) tempScore += 2;
                    if (answer6[i].Contains("C")) tempScore += 3;
                    if (answer6[i].Contains("D")) tempScore += 4;
                }

                score -= (Single)(tempScore * 0.8);

                //第七题，辨认1词记1分，共10分，权重1.4
                tempScore = 0;
                string answerSeven = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".7");

                if (answerSeven.Contains("A")) tempScore += 1;
                if (answerSeven.Contains("B")) tempScore += 1;
                if (answerSeven.Contains("C")) tempScore += 1;
                if (answerSeven.Contains("D")) tempScore += 1;
                if (answerSeven.Contains("E")) tempScore += 1;
                if (answerSeven.Contains("F")) tempScore += 1;
                if (answerSeven.Contains("G")) tempScore += 1;
                if (answerSeven.Contains("H")) tempScore += 1;
                if (answerSeven.Contains("I")) tempScore += 1;
                if (answerSeven.Contains("J")) tempScore += 1;

                score += (Single)(tempScore * 1.4);

                //第八题，辨认1词记1分，共10分，权重0.2
                tempScore = 0;
                string answerEight = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".8");

                if (answerEight.Contains("B")) tempScore += 1;
                if (answerEight.Contains("D")) tempScore += 1;
                if (answerEight.Contains("E")) tempScore += 1;
                if (answerEight.Contains("H")) tempScore += 1;
                if (answerEight.Contains("I")) tempScore += 1;
                if (answerEight.Contains("K")) tempScore += 1;
                if (answerEight.Contains("N")) tempScore += 1;
                if (answerEight.Contains("O")) tempScore += 1;
                if (answerEight.Contains("R")) tempScore += 1;
                if (answerEight.Contains("T")) tempScore += 1;

                score += (Single)(tempScore * 0.2);


                //第九题，辨认1词记1分，共10分，权重1.4

                tempScore = 0;
                string answerNine = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".9");

                if (answerNine.Contains("A")) tempScore += 1;
                if (answerNine.Contains("D")) tempScore += 1;
                if (answerNine.Contains("E")) tempScore += 1;
                if (answerNine.Contains("H")) tempScore += 1;
                if (answerNine.Contains("J")) tempScore += 1;
                if (answerNine.Contains("K")) tempScore += 1;
                if (answerNine.Contains("N")) tempScore += 1;
                if (answerNine.Contains("O")) tempScore += 1;
                if (answerNine.Contains("Q")) tempScore += 1;
                if (answerNine.Contains("T")) tempScore += 1;

                score += (Single)(tempScore * 1.4);

                #endregion;

                //如果总分为负分数，则改成0分
                if (score < 0)
                {
                    score = 0;
                }

                lblR.Text = "本次筛查得分：" + String.Format("{0:F2}", Convert.ToDecimal(score));

                //将本次问卷的得分更新
                if (questionnaireUserDetail != null && !LoginInfo.GetInstance().Name.Equals(""))
                {
                    ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaireUserDetail, Convert.ToDecimal(score),new List<int>
                    {
                        int.Parse(ConfigHelper.GetAppsettings("AdModerate")),
                        int.Parse(ConfigHelper.GetAppsettings("AdSerious"))
                    });
                }

                if (score > 41.3)
                {
                    //正常
                    lblResult3.Visible = true;
                }
                else if (score > 25.7 && score <= 41.3)
                {
                    //中危
                    lblResult2.Visible = true;

                    //给用户打标签
                    if (!LoginInfo.GetInstance().Name.Equals(""))
                    {
                        new PatientRecordsManager().UpdatePatientAllRecords(1724, "老年痴呆筛查中危");
                    }

                }
                else if (score <= 25.7)
                {
                    //高危
                    lblResult1.Visible = true;

                    //给用户打标签
                    if (!LoginInfo.GetInstance().Name.Equals(""))
                    {
                        new PatientRecordsManager().UpdatePatientAllRecords(1723, "老年痴呆筛查高危");
                    }

                }
            }
            catch (Exception ex)
            {
                screenWebapiClient.AddErrorLog(new M_LogForAtm{Title = "筛查机客户端错误",Content = ex.ToString(),Description = "老年痴呆筛查问卷"});
            }

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

            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new FirstFrm(),this);
            quitComfirmFrm.ShowDialog();
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
            PrintManager.SetBtnPrint(true,btnPrint,timerPrint);
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
            //        : LoginInfo.GetInstance().Name);//LoginInfo.GetInstance().PatientAccount;
            string userName = LoginInfo.GetInstance().PatientAccount == ""
                ? "访客"
                : LoginInfo.GetInstance().PatientAccount;

            string printTest = string.Empty;
            if (userName.Length==2)
            {
                printTest = "============尊敬的" + userName + "============ \r\n";
            }
            else if (userName.Length==3)
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
            else if (userName.Length<=15)
            {
                printTest = "======尊敬的" + userName + "====== \r\n";
            }
            else if (userName.Length <= 18)
            {
                printTest = "=====尊敬的" + userName + "===== \r\n";
            }


            printTest += "\r\n"+lblR.Text;
            if (panel1.Visible)//如果有建议提醒
            {
                printTest += "\r\n";
                printTest += "筛查结果:\r\n";
                printTest += PrintString()+"\r\n";
                printTest += "筛查时间：" + answerTime + "\r\n";
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
            string str = string.Empty;

            if (lblResult1.Visible)
            {
                str = @"基于现有疾病模型，您存在认知功能异
常可能，建议到正规医院神经内科进行
诊治，推荐进行一下检查排除继发性认
知功能异常:血常规、血生化、甲状腺
功能、血叶酸及维生素B12及头颅核磁
检查。   
注意: 头颅核磁需加做冠状位成像；
体内有金属如支架、金属假关节或起搏
器者禁止行核磁检查，可用头颅CT检查
替代。";
            }
            else if (lblResult2.Visible)
            {
                str = @"基于现有认知模型，您的认知功能属于
正常老年认知范围，如您有记忆减退主
诉，属于认知异常高危人群，建议定期
随访，如合并睡眠障碍、心情低落建议
精神心理科就诊。";
            }
            else if (lblResult3.Visible)
            {
                str = @"恭喜您，您的认知表现非常优秀，请继
续保持良好的生活习惯，并参加一些益
智游戏进一步锻炼认知能力。";
            }
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
        //重写，禁止调用父类的此事件
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //base.OnMouseDoubleClick(e);
        }
    }
}
