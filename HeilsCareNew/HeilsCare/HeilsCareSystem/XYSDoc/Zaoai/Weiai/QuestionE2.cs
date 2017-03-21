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
    public partial class QuestionE2 :BaseForm
    {
        public QuestionE2()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (radCheckE06A.Checked || radCheckE06B.Checked)
            {
                string questionResult = radCheckE06A.Checked ? "A" : radCheckE06B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiWeiAi);

                if (radCheckE06A.Checked)
                {
                    string questionResultA = radCheckE061A.Checked ? "A" : radCheckE061B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);

                    //string questionResultB = radCheckE061A.Checked ? "A" : "B";
                    //QuestionnaireResultDetail questionB = new QuestionnaireResultDetail();
                    //questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.1";
                    //questionB.QuestionType = 1; //单选
                    //questionB.QuestionResult = questionResultB;
                    //ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultC = radCheckE062A.Checked ? "A" : radCheckE062B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.2";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultD = radCheckE063A.Checked ? "A" : radCheckE063B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                    questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.3";
                    questionD.QuestionType = 1; //单选
                    questionD.QuestionResult = questionResultD;
                    ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultE = radCheckE064A.Checked ? "A" : radCheckE064B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionE = new M_QuestionnaireResultDetail();
                    questionE.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.4";
                    questionE.QuestionType = 1; //单选
                    questionE.QuestionResult = questionResultE;
                    ClientInfo.AddQuestionToQuestionnaire(questionE, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultF = radCheckE065A.Checked ? "A" : radCheckE065B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionF = new M_QuestionnaireResultDetail();
                    questionF.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.5";
                    questionF.QuestionType = 1; //单选
                    questionF.QuestionResult = questionResultF;
                    ClientInfo.AddQuestionToQuestionnaire(questionF, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultG = radCheckE066A.Checked ? "A" : radCheckE066B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionG = new M_QuestionnaireResultDetail();
                    questionG.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.6";
                    questionG.QuestionType = 1; //单选
                    questionG.QuestionResult = questionResultG;
                    ClientInfo.AddQuestionToQuestionnaire(questionG, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultH = radCheckE067A.Checked ? "A" : radCheckE067B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionH = new M_QuestionnaireResultDetail();
                    questionH.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.7";
                    questionH.QuestionType = 1; //单选
                    questionH.QuestionResult = questionResultH;
                    ClientInfo.AddQuestionToQuestionnaire(questionH, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultI = radCheckE068A.Checked ? "A" : radCheckE068B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionI = new M_QuestionnaireResultDetail();
                    questionI.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E06.8";
                    questionI.QuestionType = 1; //单选
                    questionI.QuestionResult = questionResultI;
                    ClientInfo.AddQuestionToQuestionnaire(questionI, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResult095 = radCheckE095A.Checked ? "A" : radCheckE095B.Checked?"B":"";
                    M_QuestionnaireResultDetail question095 = new M_QuestionnaireResultDetail();
                    question095.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E09.5";
                    question095.QuestionType = 1; //单选
                    question095.QuestionResult = questionResult095;
                    ClientInfo.AddQuestionToQuestionnaire(question095, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResult096 = radCheckE096A.Checked ? "A" : radCheckE096B.Checked?"B":"";
                    M_QuestionnaireResultDetail question096 = new M_QuestionnaireResultDetail();
                    question096.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E09.6";
                    question096.QuestionType = 1; //单选
                    question096.QuestionResult = questionResult096;
                    ClientInfo.AddQuestionToQuestionnaire(question096, QuestionnaireCode.ZaoAiWeiAi);
                }
            }
          
            
            QuestionF1 questionF1 = new QuestionF1();
            questionF1.TopMost = false;
            questionF1.ShowDialog();
            this.Close();
        }

        private void radCheckE06A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl06.Visible = true;
        }

        private void radCheckE06B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl06.Visible = false;
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
            var questionE1 = new QuestionE1();
            questionE1.TopMost = false;
            questionE1.ShowDialog();
            this.Close();
        }

        private void QuestionE2_Load(object sender, EventArgs e)
        {
            string answerE06 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06");
            if (answerE06.Contains("A"))
            {
                this.pnl06.Visible = true;
                radCheckE06A.Checked = true;
                string answerE061 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.1");
                string answerE062 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.2");
                string answerE063 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.3");
                string answerE064= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.4");
                string answerE065 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.5");
                string answerE066 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.6");
                string answerE067 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.7");
                string answerE068 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E06.8");
                string answerE095 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E09.5");
                string answerE096 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E09.6");

                if (answerE061.Contains("A")) radCheckE061A.Checked = true;
                if (answerE061.Contains("B")) radCheckE061B.Checked = true;

                if (answerE062.Contains("A")) radCheckE062A.Checked = true;
                if (answerE062.Contains("B")) radCheckE062B.Checked = true;

                if (answerE063.Contains("A")) radCheckE063A.Checked = true;
                if (answerE063.Contains("B")) radCheckE063B.Checked = true;

                if (answerE064.Contains("A")) radCheckE064A.Checked = true;
                if (answerE064.Contains("B")) radCheckE064B.Checked = true;

                if (answerE065.Contains("A")) radCheckE065A.Checked = true;
                if (answerE065.Contains("B")) radCheckE065B.Checked = true;

                if (answerE066.Contains("A")) radCheckE066A.Checked = true;
                if (answerE066.Contains("B")) radCheckE066B.Checked = true;

                if (answerE067.Contains("A")) radCheckE067A.Checked = true;
                if (answerE067.Contains("B")) radCheckE067B.Checked = true;

                if (answerE068.Contains("A")) radCheckE068A.Checked = true;
                if (answerE068.Contains("B")) radCheckE068B.Checked = true;

                if (answerE095.Contains("A")) radCheckE095A.Checked = true;
                if (answerE095.Contains("B")) radCheckE095B.Checked = true;

                if (answerE096.Contains("A")) radCheckE096A.Checked = true;
                if (answerE096.Contains("B")) radCheckE096B.Checked = true;
            }
            if (answerE06.Contains("B")) radCheckE06B.Checked = true;
        }
    }
}
