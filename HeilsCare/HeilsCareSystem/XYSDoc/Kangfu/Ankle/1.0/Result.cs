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

namespace XYS.Remp.Screening.Kangfu.Ankle._1._0
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
        //打印结果
        private string printResult;

        public Result()
            : base(QuestionnaireCode.KangFuAnkle, "足踝疾病筛查")
        {
            InitializeComponent();
        }

        private static string Tips
        {
            get
            {
                return @"============健康小贴士============
1.选择穿合适的鞋是保障足部健康的先
决条件
* 理想的尺码至少是：十个脚趾可以在
鞋里自由地活动，有舒服的衬垫和适度
的内部空间。试鞋是要以偏大脚的舒适
度为主，一定要站起来走几步，看看两
只鞋子是否都跟脚；
* 鞋底面与脚部凹陷处的弧度十分合脚
，确认脚围的松紧是否合适，踝骨与脚
尖触不到鞋；
* 鞋跟高2cm-4cm最佳如偏爱高跟鞋，
可选择防水台较高的鞋，以减少鞋跟的
相对高度，并在鞋子里放置柔软的半垫
，从而减轻前脚掌收到的压力；

2.简单的足部放松
* 爱穿高跟鞋的女士们可以在办公室换
上平底鞋或拖鞋，坐在凳子上，双腿略
分开，把脚平放在地上。先把脚跟提起
，到最大限度，坚持5秒，然后还原。
整个动作过程要缓慢，感觉到跟腱循序
渐进地被拉伸，最少重复10次。
* 足疗给足部以良性刺激，使局部血管
扩张，也是一种有效的缓解手段。
* 晚上回家脱下鞋时，可以给累了一天
的脚做做按摩，舒缓僵硬的踝关节。

3.足部辅具的应用
足部辅具作为一种以减轻足底骨骼肌肉
系统的功能障碍为目的的辅助器具，包
括矫形鞋、矫形鞋垫，是国际上公认的
最有效的改善和医治足部病变的方法。
常用于通过控制距下关节的内外翻等减
少髋关节、膝关节、踝关节及脊柱的受
力并吸收部分地面反作用力；减少溃疡
、趾骨疼痛；支撑足弓，辅助步行；为
糖尿病、脑卒中、关节炎等提供合理的
足部承载力。";
            }
        }

        public override void btnNext_Click(object sender, EventArgs e)
        {
        }

        public override void btnBefore_Click(object sender, EventArgs e)
        {
        }

        #region 获取父窗口
        /// <summary>
        /// 获取父窗口
        /// </summary>
        /// <returns></returns>
        public override BaseForm GetParentForm()
        {
            return new ScreeningSelect();
        }
        #endregion


        public override void FormLoadEven(object sender, EventArgs e)
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
                        int.Parse(ConfigHelper.GetAppsettings("AnkleModerate")),
                        int.Parse(ConfigHelper.GetAppsettings("AnkleSerious"))
                    });
                }

                if (score <= 15)
                {
                    lblResult.Text = @"恭喜您，暂无明显足部功能障碍，请注意日常足部保健，预防足踝疾病的发生。如若
出现足踝部不适等问题，还请引起重视，及早就医，谢谢。";
                    _score = @"恭喜您，暂无明显足部功能障碍，
请注意日常足部保健，预防足踝疾病的
发生。如若出现足踝部不适等问题，还
请引起重视，及早就医，谢谢。" + "\r\n";

                    //判断是否有轻微异常
                    string strResult = AnalysisLightUnusual(questions);
                    lblResult.Text += strResult;
                    _score += printResult;
                }
                else if (score > 15 && score <= 30)
                {
                    lblResult.Text = @"可能异常。建议复查进一步确诊治疗，并多关注足踝部健康，注意选用合适的鞋袜，加强足踝部
肌群的锻炼，以及到专业机构选用适合的矫正器具，在专业医生的指导下进行正规的康复训练等，
防止病变继续发展而引起身体其他部位异常改变。";
                    _score = @"可能异常。建议复查进一步确诊治疗，并
多关注足踝部健康，注意选用合适的鞋袜
，加强足踝部肌群的锻炼，以及到专业机
构选用适合的矫正器具，在专业医生的指
导下进行正规的康复训练等，防止病变继
续发展而引起身体其他部位异常改变。";
                    TagUser(1732, "足踝筛查中危");
                }
                else
                {
                    lblResult.Text = @"异常。建议复查进一步确诊治疗，并多关注足踝部健康，注意选用合适的鞋袜，加强足踝部
肌群的锻炼，以及到专业机构选用选择合适的治疗手段（物理治疗、配置矫形鞋垫、矫形鞋或手
术治疗等），并在专业医生的指导下进行正规的康复训练，尽早进行干预，防止病变继续发展而
引起身体其他部位异常改变。";
                    _score = @"异常。建议复查进一步确诊治疗，并多关
注足踝部健康，注意选用合适的鞋袜，加
强足踝部肌群的锻炼，以及到专业机构选
用选择合适的治疗手段（物理治疗、配置
矫形鞋垫、矫形鞋或手术治疗等），并在
专业医生的指导下进行正规的康复训练，
尽早进行干预，防止病变继续发展而引起
身体其他部位异常改变。";
                    TagUser(1733, "足踝筛查高危");
                }

                _score = string.Format("本次筛查得分：{0}\r\n\r\n筛查结果:\r\n{1}", score, _score);

                lblResult.Text = string.Format("本次筛查得分：{0}\r\n筛查结果:{1}", score, lblResult.Text);
                
                if (!string.IsNullOrEmpty(LoginInfo.GetInstance().Name)) return;
                var number = string.Format("{0:d4}", Settings.Default.ScreenNumber);
                var saveXml = new SaveXml();
                saveXml.AddXmlElement(number, questions);

                lblVisitor.Text += number;
                lblVisitor.Visible = true;
            }
            catch (Exception ex)
            {
                _screenWebapiClient.AddErrorLog(new M_LogForAtm { Title = "筛查机客户端错误", Content = ex.ToString(), Description = "足踝筛查问卷" });
            }
        }

        private string AnalysisLightUnusual(IList<M_QuestionnaireResultDetail> questions)
        {
            StringBuilder sb = new StringBuilder();
            var question4 = questions.Where(p => p.QuestionCode.Equals(Code + ".4")).FirstOrDefault();
            var question5 = questions.Where(p => p.QuestionCode.Equals(Code + ".5")).FirstOrDefault();
            var question6 = questions.Where(p => p.QuestionCode.Equals(Code + ".6")).FirstOrDefault();
            if (question4 != null && question5 != null && question6 != null)
            {
                if (question4.QuestionResult.Contains("B") || question4.QuestionResult.Contains("C") ||
                    question4.QuestionResult.Contains("D") || question5.QuestionResult.Contains("B") ||
                    question5.QuestionResult.Contains("C") || question6.QuestionResult.Contains("B") ||
                    question6.QuestionResult.Contains("D"))
                {
                    sb.Append("\r\n轻微异常现象：");
                    printResult += "\r\n轻微异常现象：\r\n";
                }
            }
            if (question4 != null)
            {
                if (question4.QuestionResult.Contains("B"))
                {
                    sb.Append("拇外翻。");
                    printResult += "拇外翻。\r\n";
                }
                if (question4.QuestionResult.Contains("C"))
                {
                    sb.Append("扁平足，足弓塌陷。");
                    printResult += "扁平足，足弓塌陷。\r\n";
                }
                if (question4.QuestionResult.Contains("D"))
                {
                    sb.Append("高弓足。");
                    printResult += "高弓足。\r\n";
                }
            }
            if (question5 != null)
            {
                if (question5.QuestionResult.Contains("B"))
                {
                    sb.Append("O型腿。");
                    printResult += "O型腿。\r\n";
                }
                if (question5.QuestionResult.Contains("C"))
                {
                    sb.Append("X型腿。");
                    printResult += "X型腿。\r\n";
                }
            }
            if (question6 != null)
            {
                if (question6.QuestionResult.Contains("B"))
                {
                    sb.Append("八字脚、足内翻。");
                    printResult += "八字脚、足内翻。\r\n";
                }
                if (question6.QuestionResult.Contains("D"))
                {
                    sb.Append("八字脚、足外翻。");
                    printResult += "八字脚、足外翻。\r\n";
                }
            }
            return sb.ToString();
        }

        private static int CalculateScore(IList<M_QuestionnaireResultDetail> questions)
        {
            if (questions == null || !questions.Any()) return 0;
            return (int)questions.Sum(p => p.QuestionScore);
        }

        private void TagUser(int tag,string remark)
        {
            if (string.IsNullOrEmpty(LoginInfo.GetInstance().Name)) return;
            
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
            //如果没有超过最大行 并且 还存在一行数据 就开始打印 
            //string userName = LoginInfo.GetInstance().PatientAccount == ""
            //    ? "访客"
            //    : (LoginInfo.GetInstance().Name.Equals(LoginInfo.GetInstance().Phone)
            //        ? LoginInfo.GetInstance().PatientAccount
            //        : LoginInfo.GetInstance().Name);

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
            printTest += "\r\n筛查建议:\r\n";
            printTest += Tips + "\r\n";
            _streamToPrint = new StringReader(printTest); //从本地文件来打印 
            var fmt = new StringFormat();
            //fmt.LineAlignment = StringAlignment.Center;
            //fmt.FormatFlags = StringFormatFlags.LineLimit;
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