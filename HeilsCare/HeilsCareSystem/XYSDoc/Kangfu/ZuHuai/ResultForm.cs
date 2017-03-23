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

namespace XYS.Remp.Screening.Kangfu.ZuHuai
{
    public partial class ResultForm : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器
        //问卷答题时间
        private DateTime answerTime;
        //用于打印
        private string strResultPrint = string.Empty;
        //用于显示打印得分
        private string _score = string.Empty;

        //private ScreeningServiceClient client = new ScreeningServiceClient();
        private ScreenWebapiClient screenWebapiClient = new ScreenWebapiClient();

        public ResultForm()
        {
            InitializeComponent();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {

            //计算得分：

            M_QuestionnaireUserDetail questionnaire = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.KangFuZuHuai);

            //问卷答题时间
            answerTime = questionnaire.AnswerTime;

            IList<M_QuestionnaireResultDetail> questions = questionnaire.Questions;

            //将登录人与活动关联
            if (!LoginInfo.GetInstance().Name.Equals(""))
            {
                new CottageActivityManager().AddPToCActivity();
            }

            int score = 0;

            #region 计算每题得分
            if (questions != null && questions.Count > 0)
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    M_QuestionnaireResultDetail result = questions[i];

                    int tempScore = 0;

                    string answer = result.QuestionResult;

                    //第一题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".1")
                    {

                        if (answer.Contains("A") || (answer.Contains("B")) || answer.Contains("C") || answer.Contains("D"))
                        {
                            score += 15;
                        }
                        else if (answer.Contains("E"))
                        {
                            score += 5;
                        }

                    }// end 第一题

                    //第二题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".2")
                    {

                        if (answer.Contains("A"))
                        {
                            tempScore += 3;
                        }
                        if (answer.Contains("B"))
                        {
                            tempScore += 2;
                        }
                        if (answer.Contains("C"))
                        {
                            tempScore += 5;
                        }

                        if (tempScore > 5) tempScore = 5;

                        score += tempScore;

                    }//end 第二题

                    //第三题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".3")
                    {
                        if (answer.Contains("A"))
                        {
                            score += 5;
                        }
                    }

                    //第四题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".4")
                    {
                        if (answer.Contains("A") || answer.Contains("B") || answer.Contains("C"))
                        {
                            score += 15;
                        }
                    }

                    //第五题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".5")
                    {
                        if (answer.Contains("A") || answer.Contains("B"))
                        {
                            score += 5;
                        }
                    }

                    //第六题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".6")
                    {
                        if (answer.Contains("A") || answer.Contains("B") || answer.Contains("C"))
                        {
                            score += 10;
                        }
                    }

                    //第七题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".7")
                    {
                        tempScore = 0;
                        if (answer.Contains("A"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("B"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("C"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("D"))
                        {
                            tempScore += 5;
                        }
                        if (tempScore > 10) tempScore = 10;

                        score += tempScore;
                    }

                    //第八题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".8")
                    {
                        tempScore = 0;
                        if (answer.Contains("A"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("B"))
                        {
                            tempScore += 3;
                        }
                        if (answer.Contains("C"))
                        {
                            tempScore += 3;
                        }
                        if (answer.Contains("D"))
                        {
                            tempScore += 2;
                        }
                        if (answer.Contains("E"))
                        {
                            tempScore += 2;
                        }
                        if (tempScore > 10) tempScore = 10;

                        score += tempScore;
                    }

                    //第九题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".9")
                    {
                        if (answer.Contains("A"))
                        {
                            score += 5;
                        }
                        if (answer.Contains("B"))
                        {
                            score += 3;
                        }
                    }

                    //第10题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".10")
                    {
                        if (answer.Contains("B"))
                        {
                            score += 5;
                        }
                        if (answer.Contains("C"))
                        {
                            score += 10;
                        }
                        if (answer.Contains("D"))
                        {
                            score += 15;
                        }
                    }

                }// end for


            }// end  if (questions != null && questions.Count > 0)
            #endregion;

            ShowResult(score);

            //更新本次问卷得分
            M_QuestionnaireUserDetail userDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.KangFuZuHuai);
            if (userDetail != null && !string.IsNullOrEmpty(LoginInfo.GetInstance().Name))
            {
                int result = screenWebapiClient.UpdateQuestionUserScoreStatus(userDetail.QuestionnaireRecodId, score, 1);
            }

            //将游客的结果保存为xml
            if (LoginInfo.GetInstance().Name.Equals(""))
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
                saveXml.AddXmlElement(number, questions);

                //游客编号
                lblVisitor.Text += number;
                lblVisitor.Visible = true;
            }

        }// end  private void ResultForm_Load(object sender, EventArgs e)

        private void ShowResult(int score)
        {
            if (score <= 15)
            {
                lblResult.Text += @"恭喜您，暂无明显足部功能障碍，请注意日常足部保健。本次得分：" + score;

                strResultPrint += @"恭喜您，暂无明显足部功能障碍，请注
意日常足部保健。";
                _score = "本次筛查得分：" + score;
            }

            if (score > 15 && score <= 30)
            {
                lblResult.Text += @"建议您关注足部健康，注意选用合适的鞋，加强足部肌群的锻炼。";
                lblResult.Text += @"本次得分：" + score;

                strResultPrint += @"建议您关注足部健康，注意选用合适的
鞋，加强足部肌群的锻炼。";
                _score = "本次筛查得分：" + score;

                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    //给用户打标签
                    List<M_MemberFeaturesRecord> array = new List<M_MemberFeaturesRecord>
                    {
                        new M_MemberFeaturesRecord() { CreateID = Properties.Settings.Default.DoctorId, CreateTime = DateTime.Now, MFItemID = 1732, PatientID = LoginInfo.GetInstance().UserId } 
                    };

                    M_MemberFeaturesRecordLogExt recordLogExt = new M_MemberFeaturesRecordLogExt();
                    recordLogExt.DoctorID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DoctorName = Properties.Settings.Default.DoctorName;
                    recordLogExt.DrID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DrName = Properties.Settings.Default.DoctorName;
                    recordLogExt.OpID = Properties.Settings.Default.DoctorId;
                    recordLogExt.OpName = Properties.Settings.Default.DoctorName;

                    int cARecordId = Properties.Settings.Default.SetIsCustomer
                        ? 0
                        : Properties.Settings.Default.CARecordID;

                    screenWebapiClient.UpdateMemberAllRecords(LoginInfo.GetInstance().UserId, array, recordLogExt, cARecordId, "足部筛查");
                }

            }

            if (score > 30)
            {
                lblResult.Text += @"建议尽快进行足部专科检查，选择合适的治疗手段";
                lblResult.Text += @"（物理治疗、配置矫形鞋垫、矫形鞋或手术治疗）尽早干预，防止病变继续加重。本次得分：" + score;

                strResultPrint += @"建议尽快进行足部专科检查，选择合适
的治疗手段（物理治疗、配置矫形鞋垫、
矫形鞋或手术治疗）尽早干预，防止病
变继续加重。";
                _score = "本次筛查得分：" + score;

                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    //给用户打标签
                    List<M_MemberFeaturesRecord> array = new List<M_MemberFeaturesRecord>
                    {
                        new M_MemberFeaturesRecord() { CreateID = Properties.Settings.Default.DoctorId, CreateTime = DateTime.Now, MFItemID = 1733, PatientID = LoginInfo.GetInstance().UserId } 
                    };

                    M_MemberFeaturesRecordLogExt recordLogExt = new M_MemberFeaturesRecordLogExt();
                    recordLogExt.DoctorID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DoctorName = Properties.Settings.Default.DoctorName;
                    recordLogExt.DrID = Properties.Settings.Default.DoctorId;
                    recordLogExt.DrName = Properties.Settings.Default.DoctorName;
                    recordLogExt.OpID = Properties.Settings.Default.DoctorId;
                    recordLogExt.OpName = Properties.Settings.Default.DoctorName;

                    int cARecordId = Properties.Settings.Default.SetIsCustomer
                        ? 0
                        : Properties.Settings.Default.CARecordID;

                    screenWebapiClient.UpdateMemberAllRecords(LoginInfo.GetInstance().UserId, array, recordLogExt, cARecordId, "足部筛查");
                }

            }

        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmSelect = new ScreeningSelect();
            frmSelect.TopMost = false;
            frmSelect.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this);
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
            PrintManager.SetBtnPrint(true, btnPrint, timerPrint);
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

            printTest += "\r\n" + _score + "\r\n";
            printTest += "筛查结果:\r\n" + strResultPrint + "\r\n";
            printTest += "筛查时间:" + answerTime + "\r\n";
            printTest += "\r\n" + PrintString() + "\r\n";

            //if (panel1.Visible)//如果有建议提醒
            //{
            //printTest += "\n筛查建议:\r\n";
            //printTest += PrintString();
            //}
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

        //健康小贴士
        private string PrintString()
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
        //按钮置灰
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }
    }
}
