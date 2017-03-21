using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Ruxian
{
    public partial class QuestionA2 :BaseForm
    {
        public QuestionA2()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResultA10 = this.radCheckA10A.Checked ? "A" : radCheckA10B.Checked?"B":"";
            M_QuestionnaireResultDetail questionA10 = new M_QuestionnaireResultDetail();
                questionA10.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".A10";
                questionA10.QuestionType = 1;//单选
                questionA10.QuestionResult = questionResultA10;
                ClientInfo.AddQuestionToQuestionnaire(questionA10, QuestionnaireCode.ZaoAiRuXianAi);

                string questionResult = this.radCheckB014A.Checked ? "A" : radCheckB014B.Checked ? "B" : radCheckB014C.Checked?"C":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".B01.4";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);

            QuestionC1 questionC1 = new QuestionC1();
            questionC1.TopMost = false;
            questionC1.ShowDialog();
            this.Close();
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

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionA1 questionA1 = new QuestionA1();
            questionA1.TopMost = false;
            questionA1.ShowDialog();
            this.Close();
        }

        private void QuestionA2_Load(object sender, EventArgs e)
        {
            string answerA10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".A10");
            if (answerA10.Contains("A")) radCheckA10A.Checked = true;
            if (answerA10.Contains("B")) radCheckA10B.Checked = true;

            string answerB14 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".B01.4");
            if (answerB14.Contains("A")) radCheckB014A.Checked = true;
            if (answerB14.Contains("B")) radCheckB014B.Checked = true;
            if (answerB14.Contains("C")) radCheckB014C.Checked = true;
        }
    }
}
