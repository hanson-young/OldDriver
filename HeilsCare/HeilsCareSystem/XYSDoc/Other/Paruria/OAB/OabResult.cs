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

namespace XYS.Remp.Screening.Other.Paruria.OAB
{
    public partial class OabResult : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;
        //打印得分
        private string printScore = string.Empty;
        //打印结果
        private string printResult = string.Empty;

        public OabResult()
        {
            InitializeComponent();
        }

        //private ScreeningServiceClient client = new ScreeningServiceClient();
        private ScreenWebapiClient screenWebapiClient = new ScreenWebapiClient();

        private void OabResult_Load(object sender, EventArgs e)
        {
            try
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.Oab);

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

                //计算得分（1-5题不记分数）
                //总分
                decimal score = 0;
                //尿急得分
                decimal eightScore = 0;

                //第六题
                string answer6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".6");
                if (answer6.Contains("B")) { score += 1; }
                if (answer6.Contains("C")) { score += 2; }

                //第七题
                string answer7 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".7");
                if (answer7.Contains("B")) { score += 1; }
                if (answer7.Contains("C")) { score += 2; }
                if (answer7.Contains("D")) { score += 3; }

                //第八题
                string answer8 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".8");
                if (answer8.Contains("A"))
                {
                    score += 1;
                    eightScore += 1;
                }
                if (answer8.Contains("B"))
                {
                    score += 2;
                    eightScore += 2;
                }
                if (answer8.Contains("C"))
                {
                    score += 3;
                    eightScore += 3;
                }
                if (answer8.Contains("D"))
                {
                    score += 4;
                    eightScore += 4;
                }
                if (answer8.Contains("E"))
                {
                    score += 5;
                    eightScore += 5;
                }

                //第九题
                string answer9 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".9");
                if (answer9.Contains("A"))
                {
                    score += 1;
                }
                if (answer9.Contains("B"))
                {
                    score += 2;
                }
                if (answer9.Contains("C"))
                {
                    score += 3;
                }
                if (answer9.Contains("D"))
                {
                    score += 4;
                }
                if (answer9.Contains("E"))
                {
                    score += 5;
                }

                lblResult.Text = "本次筛查得分：" + score;

                printScore = "本次筛查得分：" + score;

                //将本次问卷的得分更新
                if (questionnaireUserDetail != null && !string.IsNullOrEmpty(LoginInfo.GetInstance().Name))
                {
                    ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaireUserDetail, score,new List<int>
                    {
                        int.Parse(ConfigHelper.GetAppsettings("OabLight")),
                        int.Parse(ConfigHelper.GetAppsettings("OabModerate")),
                        int.Parse(ConfigHelper.GetAppsettings("OabSerious"))
                    });
                }

                //各分数区间结果
                //0<=总分<=3 或 尿急得分在2分或以下，正常
                if ((score >= 0 && score <= 3) || eightScore <= 2)
                {
                    //lblResult.Text += "，正常";

                    lblSuggest.Text = "暂未发现您有膀胱过度活动症的相关症状，如有疑问，请到专业医疗机构进行详细检查。";

                    printResult = @"筛查结果：暂未发现您有膀胱过度活动
症的相关症状，如有疑问，请到专业医
疗机构进行详细检查。";
                }
                //3<总得分≤5（且尿急的得分在3分或以上），轻度
                if (score > 3 && score <= 5 && eightScore >= 3)
                {
                    //lblResult.Text += "，轻度";

                    lblSuggest.Text = "初步筛查您的情况为轻度的膀胱过度活动症，你对病症仍有所疑虑，可以考虑应用排尿日记记录您的日常排尿状况，并到专业医疗机构进行复查。";

                    printResult = @"筛查结果：初步筛查您的情况为轻度的
膀胱过度活动症，你对病症仍有所疑虑
，可以考虑应用排尿日记记录您的日常
排尿状况，并到专业医疗机构进行复查
。";

                    //给用户打标签
                    if (!LoginInfo.GetInstance().Name.Equals(""))
                    {
                        new PatientRecordsManager().UpdatePatientAllRecords(1903, "膀胱过度活动症筛查轻度");
                    }
                }
                //6≤总得分≤11（且尿急的得分在3分或以上），中度
                if (score >= 6 && score <= 11 && eightScore >= 3)
                {
                    //lblResult.Text += "，中度";

                    lblSuggest.Text = "初步筛查您的情况为中度的膀胱过度活动症，建议进一步复查确诊，在复查前记录排尿日记以供医生作为确诊依据，并到专业机构选用选择合适的治疗手段（药物治疗,行为治疗等），防止OAB膀胱过度活动症对病人生活质量带来的困扰。";

                    printResult = @"筛查结果：初步筛查您的情况为中度的
膀胱过度活动症，建议进一步复查确诊
，在复查前记录排尿日记以供医生作为
确诊依据，并到专业机构选用选择合适
的治疗手段（药物治疗,行为治疗等），
防止OAB膀胱过度活动症对病人生活质
量带来的困扰。";

                    //给用户打标签
                    if (!LoginInfo.GetInstance().Name.Equals(""))
                    {
                        new PatientRecordsManager().UpdatePatientAllRecords(1904, "膀胱过度活动症筛查中度");
                    }
                }
                //总得分≥12（且尿急的得分在3分或以上），重度
                if (score >= 12 && eightScore >= 3)
                {
                    //lblResult.Text += "，重度";

                    lblSuggest.Text = "初步筛查您的情况为重度的膀胱过度活动症，建议进一步复查确诊，在复查前记录排尿日记以供医生作为确诊依据，并到专业机构选用选择合适的治疗手段（药物治疗，行为治疗等），防止病变引起的并发症。";

                    printResult = @"筛查结果：初步筛查您的情况为重度的
膀胱过度活动症，建议进一步复查确诊
，在复查前记录排尿日记以供医生作为
确诊依据，并到专业机构选用选择合适
的治疗手段（药物治疗,行为治疗等），
防止病变引起的并发症。";

                    //给用户打标签
                    if (!LoginInfo.GetInstance().Name.Equals(""))
                    {
                        new PatientRecordsManager().UpdatePatientAllRecords(1905, "膀胱过度活动症筛查重度");
                    }
                }
            }
            catch (Exception ex)
            {
                screenWebapiClient.AddErrorLog(new M_LogForAtm { Title = "筛查机客户端错误", Content = ex.ToString(), Description = "膀胱过度活动症筛查问卷" });
            }
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
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
            printTest += "\r\n"+printResult + "\r\n";
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
        //按钮置灰
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }

        private string PrintString()
        {
            return @"疾病知识介绍:
OAB是膀胱过度活动症的简称，表现为
膀胱在控制排尿方面出现了问题，即会
出现尿急、尿频、夜尿或急迫性尿失禁
。但它并不是一种老龄化的自然现象。
之所以会发生OAB，主要是因为膀胱的
过度活动，即膀胱的肌肉更容易受到各
种刺激而出现频繁地不自主收缩，从而
导致尿急、尿频、夜尿和急迫性尿失禁
的发生。";
        }

        //重写，禁止调用父类的此事件
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //base.OnMouseDoubleClick(e);
        }
    }
}
