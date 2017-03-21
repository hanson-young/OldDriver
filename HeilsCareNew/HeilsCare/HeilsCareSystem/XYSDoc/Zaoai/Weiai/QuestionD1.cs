using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Weiai
{
    public partial class QuestionD1 :BaseForm
    {
        public QuestionD1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
                string questionResultD01 =this.radCheckD01A.Checked?"A":radCheckD01B.Checked?"B":"";
                M_QuestionnaireResultDetail questionD01 = new M_QuestionnaireResultDetail();
                questionD01.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".D01";
                questionD01.QuestionType = 1; //单选
                questionD01.QuestionResult = questionResultD01;
                ClientInfo.AddQuestionToQuestionnaire(questionD01, QuestionnaireCode.ZaoAiWeiAi);

                string questionResultD02 = this.radCheckD02A.Checked ? "A" : radCheckD02B.Checked?"B":"";
                M_QuestionnaireResultDetail questionD02 = new M_QuestionnaireResultDetail();
                questionD02.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".D02";
                questionD02.QuestionType = 1; //单选
                questionD02.QuestionResult = questionResultD02;
                ClientInfo.AddQuestionToQuestionnaire(questionD02, QuestionnaireCode.ZaoAiWeiAi);

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
            string answerD01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".D01");
            string answerD02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".D02");
            if (answerD01.Contains("A")) radCheckD01A.Checked = true;
            if (answerD01.Contains("B")) radCheckD01B.Checked = true;

            if (answerD02.Contains("A")) radCheckD02A.Checked = true;
            if (answerD02.Contains("B")) radCheckD02B.Checked = true;
        }
    }
}
