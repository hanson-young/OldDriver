using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Dachang
{
    public partial class QuestionE3 : XYS.Remp.Screening.BaseForm
    {
        public QuestionE3()
        {
            InitializeComponent();
        }

        private void radCheckE09A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE09.Visible = true;
        }

        private void radCheckE09B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE09.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            string questionResultE09 = radCheckE09A.Checked ? "A" : radCheckE09B.Checked?"B":"";
            M_QuestionnaireResultDetail questionE09 = new M_QuestionnaireResultDetail();
                questionE09.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E09";
                questionE09.QuestionType = 1; //单选
                questionE09.QuestionResult = questionResultE09;
                ClientInfo.AddQuestionToQuestionnaire(questionE09, QuestionnaireCode.ZaoAiDaChangAi);
                if (radCheckE09A.Checked)
                {
                    string questionResultA = radCheckE091A.Checked ? "A" : radCheckE091B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E09.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiDaChangAi);

                    string questionResultB = radCheckE092A.Checked ? "A" : radCheckE092B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E09.2";
                    questionB.QuestionType = 1; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiDaChangAi);

                    string questionResultC = radCheckE093A.Checked ? "A" : radCheckE093B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E09.3";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiDaChangAi);

                    string questionResultD = radCheckE094A.Checked ? "A" : radCheckE094B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                    questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E09.4";
                    questionD.QuestionType = 1; //单选
                    questionD.QuestionResult = questionResultD;
                    ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiDaChangAi);

                    string questionResultE = radCheckE095A.Checked ? "A" : radCheckE095B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionE = new M_QuestionnaireResultDetail();
                    questionE.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E09.5";
                    questionE.QuestionType = 1; //单选
                    questionE.QuestionResult = questionResultE;
                    ClientInfo.AddQuestionToQuestionnaire(questionE, QuestionnaireCode.ZaoAiDaChangAi);
                }

                string questionResultE10 = radCheckE10A.Checked ? "A" : radCheckE10B.Checked?"B":"";
                M_QuestionnaireResultDetail questionE10 = new M_QuestionnaireResultDetail();
                questionE10.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E10";
                questionE10.QuestionType = 1; //单选
                questionE10.QuestionResult = questionResultE10;
                ClientInfo.AddQuestionToQuestionnaire(questionE10, QuestionnaireCode.ZaoAiDaChangAi);

            QuestionF1 questionF1 = new QuestionF1();
            questionF1.TopMost = false;
            questionF1.ShowDialog();
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
            QuestionE2 questionE2 = new QuestionE2();
            questionE2.TopMost = false;
            questionE2.ShowDialog();
            this.Close();
        }

        private void QuestionE3_Load(object sender, EventArgs e)
        {
            string answerE09 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09");
            if (answerE09.Contains("A"))
            {
                radCheckE09A.Checked = true;
                string answerE091 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.1");
                string answerE092 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.2");
                string answerE093 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.3");
                string answerE094 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.4");
                string answerE095= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E09.5");

                if (answerE091.Contains("A")) radCheckE091A.Checked = true;
                if (answerE091.Contains("B")) radCheckE091B.Checked = true;

                if (answerE092.Contains("A")) radCheckE092A.Checked = true;
                if (answerE092.Contains("B")) radCheckE092B.Checked = true;

                if (answerE093.Contains("A")) radCheckE093A.Checked = true;
                if (answerE093.Contains("B")) radCheckE093B.Checked = true;

                if (answerE094.Contains("A")) radCheckE094A.Checked = true;
                if (answerE094.Contains("B")) radCheckE094B.Checked = true;

                if (answerE095.Contains("A")) radCheckE095A.Checked = true;
                if (answerE095.Contains("B")) radCheckE095B.Checked = true;
            }
            if (answerE09.Contains("B")) radCheckE09B.Checked = true;

            string answerE10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E10");
            if (answerE10.Contains("A")) radCheckE10A.Checked = true;
            if (answerE10.Contains("B")) radCheckE10B.Checked = true;
        }
    
    }
}
