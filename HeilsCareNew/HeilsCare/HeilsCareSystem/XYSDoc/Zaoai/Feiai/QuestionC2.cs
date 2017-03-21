using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Feiai
{
    public partial class QuestionC2 : XYS.Remp.Screening.BaseForm
    {
        public QuestionC2()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl03.Visible = true;
            this.pnlC033.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl03.Visible = true;
            this.pnlC033.Visible = false;
        }

        private void radCheckC03A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl03.Visible = false;
            this.pnlC033.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (radCheckC03A.Checked)
            {
                string questionResult = "A";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiFeiAi);
            }

            if (radCheckC03B.Checked)
            {
                string questionResult = "B";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiFeiAi);

                string resultChildA = radCheckC031A.Checked ? "A" : radCheckC031B.Checked?"B":"";
                M_QuestionnaireResultDetail questionChildA = new M_QuestionnaireResultDetail();
                questionChildA.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03.1";
                questionChildA.QuestionType = 1; //单选
                questionChildA.QuestionResult = resultChildA;
                ClientInfo.AddQuestionToQuestionnaire(questionChildA, QuestionnaireCode.ZaoAiFeiAi);

                //string resultChildB = radCheckC032A.Checked ? "A" : radCheckC032B.Checked ? "B" : "";
                string resultChildB = radCheckC032A.Checked ? "A" : radCheckC032B.Checked ? "B" : radCheckC032C.Checked?"C":radCheckC032D.Checked?"D":"";
                M_QuestionnaireResultDetail questionChildB = new M_QuestionnaireResultDetail();
                questionChildB.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03.2";
                questionChildB.QuestionType = 1; //单选
                questionChildB.QuestionResult = resultChildB;
                ClientInfo.AddQuestionToQuestionnaire(questionChildB, QuestionnaireCode.ZaoAiFeiAi);
            }

            if (radCheckC03C.Checked)
            {
                string questionResult = "C";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiFeiAi);

                string resultChildA = radCheckC031A.Checked ? "A" : radCheckC031B.Checked?"B":"";
                M_QuestionnaireResultDetail questionChildA = new M_QuestionnaireResultDetail();
                questionChildA.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03.1";
                questionChildA.QuestionType = 1; //单选
                questionChildA.QuestionResult = resultChildA;
                ClientInfo.AddQuestionToQuestionnaire(questionChildA, QuestionnaireCode.ZaoAiFeiAi);

                string resultChildB = radCheckC032A.Checked ? "A" : radCheckC032B.Checked ? "B" : radCheckC032C.Checked?"C":radCheckC032D.Checked?"D":"";
                M_QuestionnaireResultDetail questionChildB = new M_QuestionnaireResultDetail();
                questionChildB.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03.2";
                questionChildB.QuestionType = 1; //单选
                questionChildB.QuestionResult = resultChildB;
                ClientInfo.AddQuestionToQuestionnaire(questionChildB, QuestionnaireCode.ZaoAiFeiAi);

                string resultChildC = radCheckC033A.Checked ? "A" : radCheckC033B.Checked ? "B" : "";
                M_QuestionnaireResultDetail questionChildC = new M_QuestionnaireResultDetail();
                questionChildC.QuestionCode = QuestionnaireCode.ZaoAiFeiAi + ".C03.3";
                questionChildC.QuestionType = 1; //单选
                questionChildC.QuestionResult = resultChildC;
                ClientInfo.AddQuestionToQuestionnaire(questionChildC, QuestionnaireCode.ZaoAiFeiAi);
            }

            QuestionC3 questionC3 = new QuestionC3();
            questionC3.TopMost = false;
            questionC3.ShowDialog();
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningZaoaiSelect frmMain = new ScreeningZaoaiSelect();
            frmMain.TopMost = false;
            frmMain.Show();
            Close();
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
            QuestionC1 questionC1 = new QuestionC1();
            questionC1.TopMost = false;
            questionC1.ShowDialog();
            Close();
        }

        private void QuestionC2_Load(object sender, EventArgs e)
        {
            string answerC03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C03");
            if (answerC03.Contains("A")) radCheckC03A.Checked = true;
            if (answerC03.Contains("B"))
            {
                radCheckC03B.Checked = true;
                pnl03.Visible = true;
                pnlC033.Visible = false;
                string answerC031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C03.1");
                string answerC032 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C03.2");
                if (answerC031.Contains("A")) radCheckC031A.Checked = true;
                if (answerC031.Contains("B")) radCheckC031B.Checked = true;

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

                string answerC031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C03.1");
                string answerC032 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C03.2");
                string answerC033 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C03.3");
                if (answerC031.Contains("A")) radCheckC031A.Checked = true;
                if (answerC031.Contains("B")) radCheckC031B.Checked = true;

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
