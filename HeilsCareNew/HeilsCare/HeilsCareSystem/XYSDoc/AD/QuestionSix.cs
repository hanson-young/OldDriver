using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Player;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.AD
{
    public partial class QuestionSix : BaseForm
    {
        public QuestionSix()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }

            //保存答题信息
            //权重分
            decimal weightScore = 0;
            decimal tempSum = 0;

            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
            question1.QuestionScore= CalculateScore(rd1A, rd1B, rd1C, rd1D, question1, QuestionnaireCode.NaoNianChiDai + ".6.1");
            tempSum += question1.QuestionScore;

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            question2.QuestionScore = CalculateScore(rd2A, rd2B, rd2C, rd2D, question2,
                QuestionnaireCode.NaoNianChiDai + ".6.2");
            tempSum += question2.QuestionScore;

            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            question3.QuestionScore = CalculateScore(rd3A, rd3B, rd3C, rd3D, question3,
                QuestionnaireCode.NaoNianChiDai + ".6.3");
            tempSum += question3.QuestionScore;

            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            question4.QuestionScore = CalculateScore(rd4A, rd4B, rd4C, rd4D, question4,
                QuestionnaireCode.NaoNianChiDai + ".6.4");
            tempSum += question4.QuestionScore;

            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();
            question5.QuestionScore=CalculateScore(rd5A, rd5B, rd5C, rd5D, question5, QuestionnaireCode.NaoNianChiDai + ".6.5");
            tempSum += question5.QuestionScore;

            M_QuestionnaireResultDetail question6 = new M_QuestionnaireResultDetail();
            question6.QuestionScore=CalculateScore(rd6A, rd6B, rd6C, rd6D, question6, QuestionnaireCode.NaoNianChiDai + ".6.6");
            tempSum += question6.QuestionScore;

            M_QuestionnaireResultDetail question7 = new M_QuestionnaireResultDetail();
            question7.QuestionScore=CalculateScore(rd7A, rd7B, rd7C, rd7D, question7, QuestionnaireCode.NaoNianChiDai + ".6.7");
            tempSum += question7.QuestionScore;

            M_QuestionnaireResultDetail question8 = new M_QuestionnaireResultDetail();
            question8.QuestionScore = CalculateScore(rd8A, rd8B, rd8C, rd8D, question8, QuestionnaireCode.NaoNianChiDai + ".6.8");
            tempSum += question8.QuestionScore;

            M_QuestionnaireResultDetail question9 = new M_QuestionnaireResultDetail();
            question9.QuestionScore=CalculateScore(rd9A, rd9B, rd9C, rd9D, question9, QuestionnaireCode.NaoNianChiDai + ".6.9");
            tempSum += question9.QuestionScore;

            M_QuestionnaireResultDetail question10 = new M_QuestionnaireResultDetail();
            question10.QuestionScore = CalculateScore(rd10A, rd10B, rd10C, rd10D, question10, QuestionnaireCode.NaoNianChiDai + ".6.10");
            tempSum += question10.QuestionScore;

            //计算第六大题权重分
            weightScore = tempSum * Convert.ToDecimal(-0.8);

            //赋值并保存
            question1.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);

            question2.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.NaoNianChiDai);

            question3.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question3, QuestionnaireCode.NaoNianChiDai);

            question4.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question4, QuestionnaireCode.NaoNianChiDai);

            question5.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question5, QuestionnaireCode.NaoNianChiDai);

            question6.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question6, QuestionnaireCode.NaoNianChiDai);

            question7.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question7, QuestionnaireCode.NaoNianChiDai);

            question8.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question8, QuestionnaireCode.NaoNianChiDai);

            question9.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question9, QuestionnaireCode.NaoNianChiDai);

            question10.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question10, QuestionnaireCode.NaoNianChiDai);


            //AddResult(rd1A, rd1B, rd1C, rd1D, QuestionnaireCode.NaoNianChiDai + ".6.1");
            //AddResult(rd2A, rd2B, rd2C, rd2D, QuestionnaireCode.NaoNianChiDai + ".6.2");
            //AddResult(rd3A, rd3B, rd3C, rd3D, QuestionnaireCode.NaoNianChiDai + ".6.3");
            //AddResult(rd4A, rd4B, rd4C, rd4D, QuestionnaireCode.NaoNianChiDai + ".6.4");
            //AddResult(rd5A, rd5B, rd5C, rd5D, QuestionnaireCode.NaoNianChiDai + ".6.5");
            //AddResult(rd6A, rd6B, rd6C, rd6D, QuestionnaireCode.NaoNianChiDai + ".6.6");
            //AddResult(rd7A, rd7B, rd7C, rd7D, QuestionnaireCode.NaoNianChiDai + ".6.7");
            //AddResult(rd8A, rd8B, rd8C, rd8D, QuestionnaireCode.NaoNianChiDai + ".6.8");
            //AddResult(rd9A, rd9B, rd9C, rd9D, QuestionnaireCode.NaoNianChiDai + ".6.9");
            //AddResult(rd10A, rd10B, rd10C, rd10D, QuestionnaireCode.NaoNianChiDai + ".6.10");

            //跳转第七个页面
            QuestionSeven seven = new QuestionSeven();
            seven.TopMost = false;
            //seven.Show();
            seven.Show();
            this.Close();
        }

        //计算分数
        private decimal CalculateScore(RadioButton rdA, RadioButton rdB, RadioButton rdC, RadioButton rdD, M_QuestionnaireResultDetail resultDetail, string questionCode)
        {
            //打分
            //第六题，选择（1）自己可以做，记1分；（2）有些困难，记2分；（3）需要帮助，记3分；（4）根本无法做，记4分，最高40分，权重-0.8
            if (rdA.Checked) resultDetail.QuestionResult = "A,";
            if (rdB.Checked) resultDetail.QuestionResult = "B,";
            if (rdC.Checked) resultDetail.QuestionResult = "C,";
            if (rdD.Checked) resultDetail.QuestionResult = "D,";

            //如果不选择，则默认选择 A
            if (string.IsNullOrEmpty(resultDetail.QuestionResult))
            {
                resultDetail.QuestionResult = "A,";
            }

            resultDetail.QuestionCode = questionCode;
            resultDetail.QuestionType = 1;
            resultDetail.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".6";

            decimal score = 0;

            if (!string.IsNullOrEmpty(resultDetail.QuestionResult) && resultDetail.QuestionResult.Contains("A"))
            {
                score = 1;
            }
            if (!string.IsNullOrEmpty(resultDetail.QuestionResult) && resultDetail.QuestionResult.Contains("B"))
            {
                score = 2;
            }
            if (!string.IsNullOrEmpty(resultDetail.QuestionResult) && resultDetail.QuestionResult.Contains("C"))
            {
                score = 3;
            }
            if (!string.IsNullOrEmpty(resultDetail.QuestionResult) && resultDetail.QuestionResult.Contains("D"))
            {
                score = 4;
            }
            return score;
        }

        //private void AddResult(RadioButton rdA,RadioButton rdB, RadioButton rdC,RadioButton rdD, string questionCode)
        //{
        //    QuestionnaireResultDetail question = new QuestionnaireResultDetail();

        //    if (rdA.Checked) question.QuestionResult = "A,";
        //    if (rdB.Checked) question.QuestionResult = "B,";
        //    if (rdC.Checked) question.QuestionResult = "C,";
        //    if (rdD.Checked) question.QuestionResult = "D,";

        //    question.QuestionCode = questionCode;
        //    question.QuestionType = 1;
        //    question.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".6";
        //    //打分
        //    //第六题，选择（1）自己可以做，记1分；（2）有些困难，记2分；（3）需要帮助，记3分；（4）根本无法做，记4分，最高40分，权重-0.8
        //    if (!string.IsNullOrEmpty(question.QuestionResult) && question.QuestionResult.Contains("A"))
        //    {
        //        question.QuestionScore = 1;//(decimal)(1*-0.8);
        //        question.PQuestionWeightScore = (decimal)(1 * -0.8);
        //    }
        //    if (!string.IsNullOrEmpty(question.QuestionResult) && question.QuestionResult.Contains("B"))
        //    {
        //        question.QuestionScore = 2;//(decimal)(2 * -0.8);
        //        question.PQuestionWeightScore = (decimal)(2 * -0.8);
        //    }
        //    if (!string.IsNullOrEmpty(question.QuestionResult) && question.QuestionResult.Contains("C"))
        //    {
        //        question.QuestionScore = 3;//(decimal)(3 * -0.8);
        //        question.PQuestionWeightScore = (decimal)(3 * -0.8);
        //    }
        //    if (!string.IsNullOrEmpty(question.QuestionResult) && question.QuestionResult.Contains("D"))
        //    {
        //        question.QuestionScore = 4;//(decimal)(4 * -0.8);
        //        question.PQuestionWeightScore = (decimal)(4 * -0.8);
        //    }

        //    ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.NaoNianChiDai);

        //}

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

        private void btnBefore_Click(object sender, EventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
            QuestionFive frmBefore = new QuestionFive();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionSix_Load(object sender, EventArgs e)
        {
            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.1", rd1A, rd1B, rd1C, rd1D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.2", rd2A, rd2B, rd2C, rd2D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.3", rd3A, rd3B, rd3C, rd3D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.4", rd4A, rd4B, rd4C, rd4D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.5", rd5A, rd5B, rd5C, rd5D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.6", rd6A, rd6B, rd6C, rd6D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.7", rd7A, rd7B, rd7C, rd7D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.8", rd8A, rd8B, rd8C, rd8D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.9", rd9A, rd9B, rd9C, rd9D);

            ShowResult(QuestionnaireCode.NaoNianChiDai + ".6.10", rd10A, rd10B, rd10C, rd10D);

        }

        private void ShowResult(string questionCode,RadioButton rdA,RadioButton rdB,RadioButton rdC,RadioButton rdD)
        {
            string answer = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, questionCode);

            if (answer.Contains("A")) rdA.Checked = true;

            if (answer.Contains("B")) rdB.Checked = true;

            if (answer.Contains("C")) rdC.Checked = true;

            if (answer.Contains("D")) rdD.Checked = true;

        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_6.m4a");
        }

        private void QuestionSix_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }
    }
}
