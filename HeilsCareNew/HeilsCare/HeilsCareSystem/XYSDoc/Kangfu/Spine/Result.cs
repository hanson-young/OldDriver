using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Properties;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Spine
{
    public partial class Result : SpineBaseForm
    {
        //打印文档字体
        private readonly Font _printFont = new Font("Arial", 10);
        //可连续读取字符的读取流
        private StringReader _streamToPrint;
        //问卷答题时间
        private DateTime _answerTime=DateTime.Now;
        //打印时显示的分数
        private string _score;
        //打印筛查结果
        private string printResult;

        //private readonly ScreeningServiceClient _client = new ScreeningServiceClient();
        private readonly ScreenWebapiClient _screenWebapiClient=new ScreenWebapiClient();

        private static string Tips
        {
            get
            {
                return @"如何脊柱侧弯预防？
1、保持良好坐姿及站姿，适当加强锻炼。
2、普及脊柱健康知识，定期进行脊柱侧
弯筛查，如发现问题及早前往医院检查。

发现脊柱侧弯后家长该做些什么？
1、当有怀疑有脊柱侧凸现象时，家长首
先应向专科医生征询意见，并进一步让
孩子接受脊柱侧凸专业人员的彻底检查。
2、根据专家意见，拍摄站立位全脊柱
X光片

脊柱侧弯拍片时需注意什么？
当怀疑有脊柱侧凸时，小孩常需拍摄全
脊柱正侧位的X光片，此时需注意让小
孩在站立位下进行X光拍摄，这样可避
免平卧位肌肉松弛导致拍片时侧凸角度
的减少，进而影响准确的病情评估及治
疗方案选择。

脊柱侧弯在X光片上是什么样子的？
脊柱侧凸指在脊柱区域（上胸椎，胸椎
或腰椎）产生一个或多个弯曲。脊柱侧
凸可能发生在脊柱的一个或多个区域，
我们称之做单弯，双弯或三弯。侧弯方
向可能向左，也可能向右。";
            }
        }

        public Result()
        {
            InitializeComponent();
        }

        protected override void btnNext_Click(object sender, EventArgs e) { }

        protected override void btnBefore_Click(object sender, EventArgs e) { }

        protected override void FormLoadEven(object sender, EventArgs e)
        {
            BeginInvoke(new Action(GetResult));
        }

        private void GetResult()
        {
            try
            {
                var questionnaire = ClientInfo.GetQuestionnaireByCode(Code);

                //如果本地问卷记录为空，则从数据库取数据
                if (questionnaire == null)
                {
                    questionnaire = _screenWebapiClient.GetQuestionnaireUserDetailById(Properties.Settings.Default.QuestionnaireRecodId);
                    if (questionnaire != null)
                        questionnaire.Questions = _screenWebapiClient.GetQuestionnaireResultDetails(questionnaire.QuestionnaireRecodId);
                }
                //问卷答题时间
                _answerTime = questionnaire != null ? questionnaire.AnswerTime : DateTime.Now;

                var questions =questionnaire!=null? questionnaire.Questions:null;
                var score = CalculateScore(questions);
                //将登录人与活动关联
                if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name))
                {
                    new CottageActivityManager().AddPToCActivity();
                }
                //更新问卷
                if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name) && questionnaire != null)
                {
                    ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaire, score,new List<int>
                    {
                        int.Parse(ConfigHelper.GetAppsettings("SpineModerate")),
                        int.Parse(ConfigHelper.GetAppsettings("SpineSerious"))
                    });
                }
                if (score <= 30)
                {
                    lblResult.Text = @"恭喜您，您的脊柱基本正常，平时请保持正确的坐姿以及站姿，加强肌肉锻炼，预防脊柱侧弯的发生。";
                    printResult = @"恭喜您，您的脊柱基本正常，平时请保持
正确的坐姿以及站姿，加强肌肉锻炼，预
防脊柱侧弯的发生。" + "\r\n";
                    lblResult.Text += AnalysisLightUnusual(questions);
                }
                else if (score > 30 && score <= 50)
                {
                    lblResult.Text = @"可能脊柱异常。建议复查进一步确诊治疗，避免饮食过量以超重从而增加脊椎的重量，平时请保持正确的坐姿以及站姿，到专业机构在专业医生的指导下进行正规的康复训练等，防止病变继续发展而引起身体其他部位异常改变。";
                    printResult = @"可能脊柱异常。建议复查进一步确诊治疗
，避免饮食过量以超重从而增加脊椎的重
量，平时请保持正确的坐姿以及站姿，到
专业机构在专业医生的指导下进行正规的
康复训练等，防止病变继续发展而引起身
体其他部位异常改变。" + "\r\n";

                    TagUser(1725, "可能脊柱异常");
                }
                else if (score > 50)
                {
                    lblResult.Text = @"脊柱异常。建议复查以进一步诊治，并多关注脊柱健康，加强肌肉的锻炼，以及到专业机构选用选择合适的治疗手段（物理治疗、配置脊柱矫形器、手术治疗等），并在专业医生的指导下进行正规的康复训练，尽早进行干预，防止病变继续发展而引起身体其他部位异常改变。";
                    printResult = @"脊柱异常。建议复查以进一步诊治，并多
关注脊柱健康，加强肌肉的锻炼，以及到
专业机构选用选择合适的治疗手段（物理
治疗、配置脊柱矫形器、手术治疗等），
并在专业医生的指导下进行正规的康复训
练，尽早进行干预，防止病变继续发展而
引起身体其他部位异常改变。" + "\r\n";

                    TagUser(1726, "脊柱异常");
                }

                _score = @"本次筛查得分：" + score + "\r\n\r\n" + "筛查结果:\r\n" + printResult;

                //lblResult.Text += @"本次得分：" + score;
                lblResult.Text = string.Format("本次筛查得分：{0}\r\n筛查结果：{1}", score, lblResult.Text);
                

                if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name)) return;
                var number = string.Format("{0:d4}", Properties.Settings.Default.ScreenNumber);
                var saveXml = new SaveXml();
                saveXml.AddXmlElement(number, questions);

                lblVisitor.Text += number;
                lblVisitor.Visible = true;
            }
            catch (Exception ex)
            {
                _screenWebapiClient.AddErrorLog(new M_LogForAtm { Title = "筛查机客户端错误", Content = ex.ToString(), Description = "脊柱筛查问卷" });
            }
        }

        private string AnalysisLightUnusual(IList<M_QuestionnaireResultDetail> questions)
        {
            StringBuilder sb = new StringBuilder();
            //判断是否有轻微异常
            if (questions.Any(p => p.QuestionResult.Contains("A")))
            {
                sb.Append("\r\n轻微异常现象：");
                printResult += "\r\n轻微异常现象：\r\n";

                if (questions.Where(p => p.QuestionCode.Equals(Code + ".1") || p.QuestionCode.Equals(Code + ".2") || p.QuestionCode.Equals(Code + ".5") || p.QuestionCode.Equals(Code + ".6") || p.QuestionCode.Equals(Code + ".7") || p.QuestionCode.Equals(Code + ".8") || p.QuestionCode.Equals(Code + ".9") || p.QuestionCode.Equals(Code + ".10") || p.QuestionCode.Equals(Code + ".11")).Any(i => i.QuestionResult.Contains("A")))
                {
                    sb.Append("脊柱侧弯。");
                    printResult += "脊柱侧弯\r\n";
                }
                if (questions.Where(u => u.QuestionCode.Equals(Code + ".5") || u.QuestionCode.Equals(Code + ".11"))
                        .Any(y => y.QuestionResult.Contains("A")))
                {
                    sb.Append("高低肩。");
                    printResult += "高低肩\r\n";
                }
                if (questions.Where(u => u.QuestionCode.Equals(Code + ".3") || u.QuestionCode.Equals(Code + ".4"))
                    .Any(y => y.QuestionResult.Contains("A")))
                {
                    sb.Append("探头。");
                    printResult += "探头\r\n";
                }
                if (questions.Where(u => u.QuestionCode.Equals(Code + ".4") || u.QuestionCode.Equals(Code + ".8"))
                    .Any(y => y.QuestionResult.Contains("A")))
                {
                    sb.Append("青少年驼背。");
                    printResult += "青少年驼背\r\n";
                }
                if (questions.Where(t => t.QuestionCode.Equals(Code + ".4")).Any(y => y.QuestionResult.Contains("A")))
                {
                    sb.Append("圆肩。");
                    printResult += "圆肩\r\n";
                }
                if (questions.Where(t => t.QuestionCode.Equals(Code + ".12")).Any(y => y.QuestionResult.Contains("A")))
                {
                    sb.Append("骨盆前倾。");
                    printResult += "骨盆前倾\r\n";
                }
            }
            return sb.ToString();
        }

        private static int CalculateScore(IList<M_QuestionnaireResultDetail> questions)
        {
            if (questions == null || !questions.Any()) return 0;
            return questions.Select(question => question.QuestionResult)
                .Where(answer => !string.IsNullOrEmpty(answer) && answer.Contains("A"))
                .Sum(answer => 10);
        }

        private void TagUser(int tag,string remark)
        {
            if (string.IsNullOrEmpty(LoginInfo.GetInstance().Name)) return;
            
            new PatientRecordsManager().UpdatePatientAllRecords(tag,remark);
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            foreach (PaperSize size in printDocument.PrinterSettings.PaperSizes)
            {
                if (!size.PaperName.Contains("Roll Paper 80 x 297 mm")) continue;
                printDocument.DefaultPageSettings.PaperSize = size;
                break;
            }
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.WindowState = FormWindowState.Maximized;
            printPreviewDialog.TopMost = false;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            var count = 0;           //当前正在打印第几行 
            const float leftM = 15; // e.MarginBounds.Left;  //在打印范围内获取左边的打印点 
            const float topT = 0;// e.MarginBounds.Top;    //在打印范围内获取上边的打印点 
            string lineStr = null;       //存储一行数据 
            var totalines = e.MarginBounds.Height / _printFont.GetHeight(e.Graphics);
            //如果没有超过最大行 并且 还存在一行数据 就开始打印 
            //string userName = LoginInfo.GetInstance().PatientAccount == ""
            //    ? "访客"
            //    : (LoginInfo.GetInstance().Name.Equals(LoginInfo.GetInstance().Phone)
            //        ? LoginInfo.GetInstance().PatientAccount
            //        : LoginInfo.GetInstance().Name);

            string userName = LoginInfo.GetInstance().PatientAccount == ""
                ? "访客"
                : LoginInfo.GetInstance().PatientAccount;

            var printTest = string.Empty;
            switch (userName.Length)
            {
                case 2:
                    printTest = "============尊敬的" + userName + "============ \r\n";
                    break;
                case 3:
                    printTest = "===========尊敬的" + userName + "=========== \r\n";
                    break;
                case 4:
                    printTest = "==========尊敬的" + userName + "========== \r\n";
                    break;
                default:
                    if (userName.Length <= 11)
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
                    break;
            }

            printTest +="\r\n"+ _score;
            //printTest += "筛查结果:\r\n" + lblResult.Text;
            if (pnlTips.Visible)//如果有建议提醒
            {
                printTest += "\r\n";
                printTest += "筛查时间：" + _answerTime + "\r\n";
                printTest += "----------------------------------------------------------\r\n";
                printTest += "筛查建议:\r\n";
                printTest += Tips+"\r\n";
            }
            _streamToPrint = new StringReader(printTest);//从本地文件来打印 
            StringFormat fmt = new StringFormat();
            //fmt.LineAlignment = StringAlignment.Center;
            //fmt.FormatFlags = StringFormatFlags.LineLimit;
            while (count < totalines && ((lineStr = _streamToPrint.ReadLine()) != null))
            {
                //因为每打印一行，下一行的位置会发生变化， yPos=打印区域的上边界+ 行数*字体高度 
                var yPos = topT + (count * _printFont.GetHeight(e.Graphics));          //打印点Y轴坐标 
                //打印一行 数据，leftM 和 yPos代表了 打印的起始点坐标 
                var drawRect = new Rectangle((int)leftM, (int)yPos, 300, 600);
                e.Graphics.DrawString(lineStr, _printFont, Brushes.Black, drawRect, fmt);
                count++; //下一行  
            }
            e.HasMorePages = lineStr != null;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (PaperSize size in printDocument.PrinterSettings.PaperSizes)
            {
                if (!size.PaperName.Contains("Roll Paper 80 x 297 mm")) continue;
                printDocument.DefaultPageSettings.PaperSize = size;
                break;
            }
            printDocument.Print();

            //打印按钮置灰
            PrintManager.SetBtnPrint(true, btnPrint, timerPrint);
        }
        //按钮置灰
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }
    }
}
