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

namespace XYS.Remp.Screening.Other.COPD
{
    public partial class CopdResult : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;
        //打印得分
        private string printScore = string.Empty;
        //打印结果
        private string printResult = string.Empty;

        private ScreenWebapiClient screenWebapiClient = new ScreenWebapiClient();

        public CopdResult()
        {
            InitializeComponent();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            var quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //加载
        private void CopdResult_Load(object sender, EventArgs e)
        {
            try
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.Copd);

                //如果本地问卷记录为空，则从数据库取数据
                if (questionnaireUserDetail == null)
                {
                    questionnaireUserDetail = screenWebapiClient.GetQuestionnaireUserDetailById(Properties.Settings.Default.QuestionnaireRecodId);
                    if (questionnaireUserDetail != null)
                        questionnaireUserDetail.Questions = screenWebapiClient.GetQuestionnaireResultDetails(questionnaireUserDetail.QuestionnaireRecodId);
                }

                //问卷答题时间
                answerTime = questionnaireUserDetail != null ? questionnaireUserDetail.AnswerTime : DateTime.Now;

                //将游客的结果保存为xml
                if (LoginInfo.GetInstance().Name.Equals(""))
                {
                    if (questionnaireUserDetail != null && questionnaireUserDetail.Questions != null &&
                        questionnaireUserDetail.Questions.Any())
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

                //统计结果
                //总分
                decimal score = 0;

                string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".1");
                if (answer1.Contains("A"))
                    score += 20;

                string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".2");
                if (answer2.Contains("A"))
                    score += 20;

                string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".3");
                if (answer3.Contains("A"))
                    score += 20;

                string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".4");
                if (answer4.Contains("A"))
                    score += 20;

                string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".5");
                if (answer5.Contains("A"))
                    score += 20;

                //将本次问卷的得分更新
                if (questionnaireUserDetail != null && !string.IsNullOrEmpty(LoginInfo.GetInstance().Name))
                {
                    ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaireUserDetail, score,new List<int>
                    {
                        int.Parse(ConfigHelper.GetAppsettings("CopdUnusual"))
                    });
                }

                //正常（是 <= 2，总分 <= 40）
                if (score <= 40)
                {
                    lblResult.Text = "您本次筛查结果为“正常”。";
                    lblSuggest.Text = "恭喜您，您呼吸功能暂无明显问题。";

                    printScore = @"您本次筛查结果为“正常”。";
                    printResult = @"恭喜您，您呼吸功能暂无明显问题。";
                }
                //异常
                else
                {
                    lblResult.Text = "您本次筛查结果为“异常”。";
                    lblSuggest.Text = "经过初步筛查，您有呼吸功能不全的高风险，可能患上慢阻肺（COPD），建议您马上进行肺功能检查，以排除相关疾病的可能，祝您健康！";

                    printScore = @"您本次筛查结果为“异常”。";
                    printResult = @"经过初步筛查，您有呼吸功能不全的高
风险，可能患上慢阻肺（COPD），建
议您马上进行肺功能检查，以排除相关
疾病的可能，祝您健康！";

                    //给用户打标签
                    if (!LoginInfo.GetInstance().Name.Equals(""))
                    {
                        new PatientRecordsManager().UpdatePatientAllRecords(1918, "慢阻肺异常");
                    }
                }
            }
            catch (Exception ex)
            {
                screenWebapiClient.AddErrorLog(new M_LogForAtm { Title = "筛查机客户端错误", Content = ex.ToString(), Description = "慢阻肺筛查问卷" });
            }
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
        //打印
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
        //打印按钮置灰
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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


            printTest += printScore + "\r\n";
            printTest += "\r\n" + printResult + "\r\n";
            printTest += "\r\n筛查时间：" + answerTime + "\r\n";
            printTest += "----------------------------------------------------------\r\n";
            printTest += PrintString() + "\r\n";

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

        private string PrintString()
        {
            return @"疾病小知识：
慢性阻塞性肺疾病简称为“慢阻肺”，
它是慢性支气管炎和肺气肿的总称，是
一种逐渐削弱患者呼吸功能的破坏性肺
部疾病，病程长、反复发作，具有不可
逆的特征。慢阻肺的症状是不断递进的
，从咳嗽、咳痰到气短或呼吸困难，再
到憋气和胸闷，最后引起全身心疾病，
包括心血管疾病、骨骼肌功能障碍、代
谢综合征、骨质疏松症、肺癌等。早发
现、早治疗可以有效的延缓患者的发病
进程，部分早期患者肺功能可以恢复正
常，促进病变消退和功能恢复，保持较
好的生活质量。";
        }
        //重写，禁止调用父类的此事件
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //base.OnMouseDoubleClick(e);
        }
    }
}
