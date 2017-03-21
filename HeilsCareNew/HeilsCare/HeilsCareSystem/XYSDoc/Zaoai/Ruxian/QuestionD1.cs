using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening.Zaoai.Weiai;

namespace XYS.Remp.Screening.Zaoai.Ruxian
{
    public partial class QuestionD1 :BaseForm
    {
        public QuestionD1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            string questionResultA = radCheckD01A.Checked ? "A" : radCheckD01B.Checked?"B":"";
            M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".D01";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiRuXianAi);

                string questionResult = radCheckD02A.Checked ? "A" : radCheckD02B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".D02";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);

            
            QuestionE1 questionE1 = new QuestionE1();
            questionE1.TopMost = false;
            questionE1.ShowDialog();
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
            QuestionC2 questionC2 = new QuestionC2();
            questionC2.TopMost = false;
            questionC2.ShowDialog();
            this.Close();
        }

        private void QuestionD1_Load(object sender, EventArgs e)
        {
            string answerD01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".D01");
            if (answerD01.Contains("A")) radCheckD01A.Checked = true;
            if (answerD01.Contains("B")) radCheckD01B.Checked = true;

            string answerD02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".D02");
            if (answerD02.Contains("A")) radCheckD02A.Checked = true;
            if (answerD02.Contains("B")) radCheckD02B.Checked = true;
        }
    }
}
