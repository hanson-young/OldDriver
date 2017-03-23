using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Properties;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Diabetes
{
    public partial class Result : QuestionnaireBaseForm
    {
        //private readonly ScreeningServiceClient _client = new ScreeningServiceClient();
        private readonly ScreenWebapiClient _screenWebapiClient = new ScreenWebapiClient();
        //打印文档字体
        private readonly Font _printFont = new Font("Arial", 10);
        //打印时显示的分数
        private string _score;
        //可连续读取字符的读取流
        private StringReader _streamToPrint;
        //问卷答题时间
        private DateTime _answerTime;


        public Result()
            : base(QuestionnaireCode.Diabetes, "糖尿病筛查")
        {
            InitializeComponent();
        }

        public override void btnNext_Click(object sender, EventArgs e) { }

        public override void btnBefore_Click(object sender, EventArgs e) { }

        public override BaseForm GetParentForm()
        {
            return new ScreenOtherSelect();
        }

        public override void FormLoadEven(object sender, EventArgs e)
        {
            BeginInvoke(new Action(GetResult));
            TopMost = false;
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

                //取出第6.1题用来判断
                var question6_1 = questions.Where(p => p.QuestionCode.Equals(Code + ".6.1")).FirstOrDefault();

                if (score < 25)
                {
                    //高危（只要选了该选项，分数为33）
                    if (question6_1 != null && question6_1.QuestionResult.Contains("A"))
                    {
                        score = 33;
                    }
                    //中危（只要选了该选项，分数为25）
                    else if (question6_1 != null && question6_1.QuestionResult.Contains("B"))
                    {
                        score = 25;
                    }
                    else
                    {
                        lblResult.Text = @"应该不用担心患有糖尿病。
健康的生活习惯和适量的运动可以预防糖尿病。
合理控制饮食也至关重要，饮食要清淡，控制糖分的摄入，多吃新鲜的蔬菜等。";
                        _score = @"应该不用担心患有糖尿病。健康的生活习
惯和适量的运动可以预防糖尿病。合理控
制饮食也至关重要，饮食要清淡，控制糖
分的摄入，多吃新鲜的蔬菜等。";

                        //更新问卷
                        if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name) && questionnaire != null)
                        {
                            ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaire, score, new List<int>
                            {
                                int.Parse(ConfigHelper.GetAppsettings("DiabetesMediumRisk")),
                                int.Parse(ConfigHelper.GetAppsettings("DiabetesHighRisk"))
                            });
                        }
                    }
                }
                if (score >= 25 && score < 33)
                {
                    //高危（只要选了该选项，分数为33）
                    if (question6_1 != null && question6_1.QuestionResult.Contains("A"))
                    {
                        score = 33;
                    }
                    else
                    {
                        lblResult.Text = @"您本次糖尿病筛查的结果为中危，存在患有糖尿病风险。
请平衡饮食以及控制体重，保持适量的运动。
建议您咨询专科医生，在医院作进一步检查，预防并发症的发生。
祝您健康！";
                        _score = @"您本次糖尿病筛查的结果为中危，存在患
有糖尿病风险。请平衡饮食以及控制体重
，保持适量的运动。建议您咨询专科医生
，在医院作进一步检查，预防并发症的发
生。祝您健康！";
                        //更新问卷
                        if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name) && questionnaire != null)
                        {
                            ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaire, score,new List<int>
                            {
                                int.Parse(ConfigHelper.GetAppsettings("DiabetesMediumRisk")),
                                int.Parse(ConfigHelper.GetAppsettings("DiabetesHighRisk"))
                            });
                        }
                        TagUser(1909, "糖尿病中危");
                    }
                }
                if (score >= 33)
                {
                    lblResult.Text = @"您本次糖尿病筛查的结果为高危，存在患有糖尿病风险。
建议您咨询专科医生，在医院作进一步检查，预防并发症的发生，
必要时在医生指导下使用降糖药物治疗。
祝您健康！";
                    _score = @"您本次糖尿病筛查的结果为高危，存在患
有糖尿病风险。建议您咨询专科医生，在
医院作进一步检查，预防并发症的发生，
必要时在医生指导下使用降糖药物治疗。
祝您健康！";
                    //更新问卷
                    if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name) && questionnaire != null)
                    {
                        ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaire, score,new List<int>
                        {
                            int.Parse(ConfigHelper.GetAppsettings("DiabetesMediumRisk")),
                            int.Parse(ConfigHelper.GetAppsettings("DiabetesHighRisk"))
                        });
                    }
                    TagUser(1910, "糖尿病高危");
                }

                _score = @"本次筛查得分：" + score + "\r\n" + "筛查结果:\r\n" + _score;

                lblResult.Text = @"本次筛查得分：" + score + "\r\n" + "筛查结果:\r\n" + lblResult.Text;
                
                if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name)) return;
                var number = string.Format("{0:d4}", Settings.Default.ScreenNumber);
                var saveXml = new SaveXml();
                saveXml.AddXmlElement(number, questions);

                lblVisitor.Text += number;
                lblVisitor.Visible = true;
            }
            catch (Exception ex)
            {
                _screenWebapiClient.AddErrorLog(new M_LogForAtm { Title = "筛查机客户端错误", Content = ex.ToString(), Description = "糖尿病筛查问卷" });
            }
        }

        private static int CalculateScore(IList<M_QuestionnaireResultDetail> questions)
        {
            if (questions == null || !questions.Any()) return 0;
            return (int)questions.Sum(p => p.QuestionScore);
        }

        private void TagUser(int tag,string remark)
        {
            if (string.IsNullOrEmpty(LoginInfo.GetInstance().Name)) return;
            //var array = new List<M_MemberFeaturesRecord>
            //{
            //    new M_MemberFeaturesRecord
            //    {
            //        CreateID = Settings.Default.DoctorId < 1 ? 0 : Settings.Default.DoctorId,
            //        CreateTime = DateTime.Now,
            //        MFItemID = tag,
            //        PatientID = LoginInfo.GetInstance().UserId
            //    }
            //};

            //var recordLogExt = new M_MemberFeaturesRecordLogExt
            //{
            //    DoctorID = Settings.Default.DoctorId,
            //    DoctorName = Settings.Default.DoctorName,
            //    DrID = Settings.Default.DoctorId,
            //    DrName = Settings.Default.DoctorName,
            //    OpID = Settings.Default.DoctorId,
            //    OpName = Settings.Default.DoctorName
            //};

            //var activityId = Settings.Default.SetIsCustomer ? 0 : Settings.Default.CARecordID;

            //_screenWebapiClient.UpdateMemberAllRecords(
            //    LoginInfo.GetInstance().UserId,
            //    array,
            //    recordLogExt,
            //    activityId,
            //    QuestionnaireCode.DiabetesName);

            new PatientRecordsManager().UpdatePatientAllRecords(tag, remark);
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
            var count = 0; //当前正在打印第几行 
            const float leftM = 15; // e.MarginBounds.Left;  //在打印范围内获取左边的打印点 
            const float topT = 0; // e.MarginBounds.Top;    //在打印范围内获取上边的打印点 
            string lineStr = null; //存储一行数据 
            var totalines = e.MarginBounds.Height / _printFont.GetHeight(e.Graphics);

            var userName = LoginInfo.GetInstance().PatientAccount == ""
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

            printTest += "\r\n" + _score;
            printTest += "\r\n";
            printTest += "筛查时间：" + _answerTime + "\r\n";
            _streamToPrint = new StringReader(printTest); //从本地文件来打印 
            var fmt = new StringFormat();
            while (count < totalines && ((lineStr = _streamToPrint.ReadLine()) != null))
            {
                //因为每打印一行，下一行的位置会发生变化， yPos=打印区域的上边界+ 行数*字体高度 
                var yPos = topT + (count * _printFont.GetHeight(e.Graphics)); //打印点Y轴坐标 
                //打印一行 数据，leftM 和 yPos代表了 打印的起始点坐标 
                var drawRect = new Rectangle((int)leftM, (int)yPos, 300, 600);
                e.Graphics.DrawString(lineStr, _printFont, Brushes.Black, drawRect, fmt);
                count += 1; //下一行  
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

        /// <summary>
        ///     按钮置灰
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }
    }
}