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
    public partial class QuestionC1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionC1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (radCheckC03A.Checked)
            {
                string questionResult = "A";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);
            }

            if (radCheckC03B.Checked)
            {
                string questionResult = "B";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);

                string resultChildA = this.radCheckC031A.Checked ? "A" : radCheckC031B.Checked ? "B" : this.radCheckC031C.Checked ? "C" : radCheckC031D.Checked?"D":"";
                M_QuestionnaireResultDetail questionChildA = new M_QuestionnaireResultDetail();
                questionChildA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03.1";
                questionChildA.QuestionType = 1; //单选
                questionChildA.QuestionResult = resultChildA;
                ClientInfo.AddQuestionToQuestionnaire(questionChildA, QuestionnaireCode.ZaoAiRuXianAi);

                string resultChildB = this.radCheckC032A.Checked ? "A" : radCheckC032B.Checked ? "B" : this.radCheckC032C.Checked ? "C" : radCheckC032D.Checked?"D":"";
                M_QuestionnaireResultDetail questionChildB = new M_QuestionnaireResultDetail();
                questionChildB.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03.2";
                questionChildB.QuestionType = 1; //单选
                questionChildB.QuestionResult = resultChildB;
                ClientInfo.AddQuestionToQuestionnaire(questionChildB, QuestionnaireCode.ZaoAiRuXianAi);
            }

            if (radCheckC03C.Checked)
            {
                string questionResult = "C";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);

                string resultChildA = this.radCheckC031A.Checked ? "A" : radCheckC031B.Checked ? "B" : this.radCheckC031C.Checked ? "C" : radCheckC031D.Checked?"D":"";
                M_QuestionnaireResultDetail questionChildA = new M_QuestionnaireResultDetail();
                questionChildA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03.1";
                questionChildA.QuestionType = 1; //单选
                questionChildA.QuestionResult = resultChildA;
                ClientInfo.AddQuestionToQuestionnaire(questionChildA, QuestionnaireCode.ZaoAiRuXianAi);

                string resultChildB = this.radCheckC032A.Checked ? "A" : radCheckC032B.Checked ? "B" : this.radCheckC032C.Checked ? "C" : radCheckC032D.Checked?"D":"";
                M_QuestionnaireResultDetail questionChildB = new M_QuestionnaireResultDetail();
                questionChildB.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03.2";
                questionChildB.QuestionType = 1; //单选
                questionChildB.QuestionResult = resultChildB;
                ClientInfo.AddQuestionToQuestionnaire(questionChildB, QuestionnaireCode.ZaoAiRuXianAi);

                string resultChildC = this.radCheckC033A.Checked ? "A" : radCheckC033B.Checked ? "B" : "";
                M_QuestionnaireResultDetail questionChildC = new M_QuestionnaireResultDetail();
                questionChildC.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".C03.3";
                questionChildC.QuestionType = 1; //单选
                questionChildC.QuestionResult = resultChildC;
                ClientInfo.AddQuestionToQuestionnaire(questionChildC, QuestionnaireCode.ZaoAiRuXianAi);
            }


            QuestionC2 questionC2 = new QuestionC2();
            questionC2.TopMost = false;
            questionC2.ShowDialog();
            this.Close();
        }

        private void radCheckC03A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl03.Visible = false;
            this.pnlC033.Visible = false;
        }

        private void radCheckC03B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl03.Visible = true;
            this.pnlC033.Visible = false;
        }

        private void radCheckC03C_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl03.Visible = true;
            this.pnlC033.Visible = true;
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
            QuestionA2 questionA2 = new QuestionA2();
            questionA2.TopMost = false;
            questionA2.ShowDialog();
            this.Close();
        }

        private void QuestionC1_Load(object sender, EventArgs e)
        {
            string answerC03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".C03");
            if (answerC03.Contains("A")) radCheckC03A.Checked = true;
            if (answerC03.Contains("B"))
            {
                radCheckC03B.Checked = true;
                pnl03.Visible = true;
                pnlC033.Visible = false;
                string answerC031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".C03.1");
                string answerC032 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".C03.2");
                if (answerC031.Contains("A")) radCheckC031A.Checked = true;
                if (answerC031.Contains("B")) radCheckC031B.Checked = true;
                if (answerC031.Contains("C")) radCheckC031C.Checked = true;
                if (answerC031.Contains("D")) radCheckC031D.Checked = true;

                if (answerC032.Contains("A")) radCheckC032A.Checked = true;
                if (answerC032.Contains("B")) radCheckC032B.Checked = true;
                if (answerC032.Contains("C")) radCheckC032C.Checked = true;
                if (answerC032.Contains("D")) radCheckC032D.Checked = true;
            }
            if (answerC03.Contains("C"))
            {
                radCheckC03C.Checked = true;
                pnl03.Visible = true;
                pnlC033.Visible = true;

                string answerC031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".C03.1");
                string answerC032 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".C03.2");
                string answerC033 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".C03.3");
                if (answerC031.Contains("A")) radCheckC031A.Checked = true;
                if (answerC031.Contains("B")) radCheckC031B.Checked = true;
                if (answerC031.Contains("C")) radCheckC031C.Checked = true;
                if (answerC031.Contains("D")) radCheckC031D.Checked = true;

                if (answerC032.Contains("A")) radCheckC032A.Checked = true;
                if (answerC032.Contains("B")) radCheckC032B.Checked = true;
                if (answerC032.Contains("C")) radCheckC032C.Checked = true;
                if (answerC032.Contains("D")) radCheckC032D.Checked = true;

                if (answerC033.Contains("A")) radCheckC033A.Checked = true;
                if (answerC033.Contains("B")) radCheckC033B.Checked = true;
            }
        }
    }
}
