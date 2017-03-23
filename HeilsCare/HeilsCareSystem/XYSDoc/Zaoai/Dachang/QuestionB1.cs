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
    public partial class QuestionB1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionB1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //B01.4
            string questionResultA = this.radCheckB014A.Checked ? "A" : radCheckB014B.Checked ? "B" : radCheckB014C.Checked?"C":"";
            M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".B01.4";
                questionA.QuestionType = 1;//单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiDaChangAi);

            //B01.5
                string questionResultB = this.radCheckB015A.Checked ? "A" : radCheckB015B.Checked ? "B" : radCheckB015C.Checked?"C":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".B01.5";
                questionB.QuestionType = 1;//单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiDaChangAi);

            //B01.6
                string questionResultC = this.radCheckB016A.Checked ? "A" : radCheckB016B.Checked ? "B" : radCheckB016C.Checked?"C":"";
                M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".B01.6";
                questionC.QuestionType = 1;//单选
                questionC.QuestionResult = questionResultC;
                ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiDaChangAi);

            //B01.7
                string questionResultD = this.radCheckB017A.Checked ? "A" : radCheckB017B.Checked ? "B" : radCheckB017C.Checked?"C":"";
                M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".B01.7";
                questionD.QuestionType = 1;//单选
                questionD.QuestionResult = questionResultD;
                ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiDaChangAi);

            //B01.8
                string questionResultE = this.radCheckB018A.Checked ? "A" : radCheckB018B.Checked ? "B" : radCheckB018C.Checked?"C":"";
                M_QuestionnaireResultDetail questionE = new M_QuestionnaireResultDetail();
                questionE.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".B01.8";
                questionE.QuestionType = 1;//单选
                questionE.QuestionResult = questionResultE;
                ClientInfo.AddQuestionToQuestionnaire(questionE, QuestionnaireCode.ZaoAiDaChangAi);

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

        private void QuestionB1_Load(object sender, EventArgs e)
        {
            string answerB14= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".B01.4");
            string answerB15= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".B01.5");
            string answerB16 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".B01.6");
            string answerB17 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".B01.7");
            string answerB18 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".B01.8");
            if (answerB14.Contains("A")) radCheckB014A.Checked = true;
            if (answerB14.Contains("B")) radCheckB014B.Checked = true;
            if (answerB14.Contains("C")) radCheckB014C.Checked = true;

            if (answerB15.Contains("A")) radCheckB015A.Checked = true;
            if (answerB15.Contains("B")) radCheckB015B.Checked = true;
            if (answerB15.Contains("C")) radCheckB015C.Checked = true;

            if (answerB16.Contains("A")) radCheckB016A.Checked = true;
            if (answerB16.Contains("B")) radCheckB016B.Checked = true;
            if (answerB16.Contains("C")) radCheckB016C.Checked = true;

            if (answerB17.Contains("A")) radCheckB017A.Checked = true;
            if (answerB17.Contains("B")) radCheckB017B.Checked = true;
            if (answerB17.Contains("C")) radCheckB017C.Checked = true;

            if (answerB18.Contains("A")) radCheckB018A.Checked = true;
            if (answerB18.Contains("B")) radCheckB018B.Checked = true;
            if (answerB18.Contains("C")) radCheckB018C.Checked = true;
        }
    }
}
