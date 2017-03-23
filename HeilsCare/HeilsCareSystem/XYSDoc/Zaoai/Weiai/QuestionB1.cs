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
    public partial class QuestionB1 :BaseForm
    {
        public QuestionB1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

                string questionResultA = this.radCheckB13A.Checked ? "A" : radCheckB13B.Checked ? "B" : radCheckB13C.Checked?"C":"";
                M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".B01.3";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);

                string questionResultB = this.radCheckB15A.Checked ? "A" : radCheckB15B.Checked ? "B" : radCheckB15C.Checked?"C":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".B01.5";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiWeiAi);

                string questionResultC = this.radCheckB16A.Checked ? "A" : radCheckB16B.Checked ? "B" : radCheckB16C.Checked?"C":"";
                M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".B01.6";
                questionC.QuestionType = 1; //单选
                questionC.QuestionResult = questionResultC;
                ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiWeiAi);


                string questionResultD = this.radCheckB17A.Checked ? "A" : radCheckB17B.Checked ? "B" : radCheckB17C.Checked?"C":"";
                M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".B01.7";
                questionD.QuestionType = 1; //单选
                questionD.QuestionResult = questionResultD;
                ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiWeiAi);


            QuestionB2 questionB2 = new QuestionB2();
            questionB2.TopMost = false;
            questionB2.ShowDialog();
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
            string answerB013 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".B01.3");
            string answerB015 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".B01.5");
            string answerB016 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".B01.6");
            string answerB017 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".B01.7");
            if (answerB013.Contains("A")) radCheckB13A.Checked = true;
            if (answerB013.Contains("B")) radCheckB13B.Checked = true;
            if (answerB013.Contains("C")) radCheckB13C.Checked = true;

            if (answerB015.Contains("A")) radCheckB15A.Checked = true;
            if (answerB015.Contains("B")) radCheckB15B.Checked = true;
            if (answerB015.Contains("C")) radCheckB15C.Checked = true;

            if (answerB016.Contains("A")) radCheckB16A.Checked = true;
            if (answerB016.Contains("B")) radCheckB16B.Checked = true;
            if (answerB016.Contains("C")) radCheckB16C.Checked = true;

            if (answerB017.Contains("A")) radCheckB17A.Checked = true;
            if (answerB017.Contains("B")) radCheckB17B.Checked = true;
            if (answerB017.Contains("C")) radCheckB17C.Checked = true;
        }
    }
}
