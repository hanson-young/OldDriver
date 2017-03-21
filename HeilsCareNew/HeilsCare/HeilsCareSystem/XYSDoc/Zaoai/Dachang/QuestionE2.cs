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
    public partial class QuestionE2 : XYS.Remp.Screening.BaseForm
    {
        public QuestionE2()
        {
            InitializeComponent();
        }

        private void radCheckE08A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE08.Visible = true;
        }

        private void radCheckE08B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE08.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResult = radCheckE08A.Checked ? "A" : radCheckE08B.Checked?"B":"";
            M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiDaChangAi);
                if (radCheckE08A.Checked)
                {
                    //E08.1
                    string questionResultA = radCheckE081A.Checked ? "A" : radCheckE081B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiDaChangAi);

                    //E08.2
                    string questionResultB = radCheckE082A.Checked ? "A" : radCheckE082B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08.2";
                    questionB.QuestionType = 1; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiDaChangAi);

                    //E08.3
                    string questionResultC = radCheckE083A.Checked ? "A" : radCheckE083B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08.3";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiDaChangAi);

                    //E08.4
                    string questionResultD = radCheckE084A.Checked ? "A" : radCheckE084B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                    questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08.4";
                    questionD.QuestionType = 1; //单选
                    questionD.QuestionResult = questionResultD;
                    ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiDaChangAi);

                    //E08.5
                    string questionResultE = radCheckE085A.Checked ? "A" : radCheckE085B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionE = new M_QuestionnaireResultDetail();
                    questionE.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08.5";
                    questionE.QuestionType = 1; //单选
                    questionE.QuestionResult = questionResultE;
                    ClientInfo.AddQuestionToQuestionnaire(questionE, QuestionnaireCode.ZaoAiDaChangAi);

                    //E08.6
                    string questionResultF = radCheckE086A.Checked ? "A" : radCheckE086B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionF = new M_QuestionnaireResultDetail();
                    questionF.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08.6";
                    questionF.QuestionType = 1; //单选
                    questionF.QuestionResult = questionResultF;
                    ClientInfo.AddQuestionToQuestionnaire(questionF, QuestionnaireCode.ZaoAiDaChangAi);

                    //E08.7
                    string questionResultG = radCheckE087A.Checked ? "A" : radCheckE087B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionG = new M_QuestionnaireResultDetail();
                    questionG.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E08.7";
                    questionG.QuestionType = 1; //单选
                    questionG.QuestionResult = questionResultG;
                    ClientInfo.AddQuestionToQuestionnaire(questionG, QuestionnaireCode.ZaoAiDaChangAi);
                }


            QuestionE3 questionE3 = new QuestionE3();
            questionE3.TopMost = false;
            questionE3.ShowDialog();
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
            QuestionE1 questionE1 = new QuestionE1();
            questionE1.TopMost = false;
            questionE1.ShowDialog();
            this.Close();
        }

        private void QuestionE2_Load(object sender, EventArgs e)
        {
            string answerE08 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08");
            if (answerE08.Contains("A"))
            {
                this.pnlE08.Visible = true;
                radCheckE08A.Checked = true;
                string answerE081 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.1");
                string answerE082 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.2");
                string answerE083 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.3");
                string answerE084 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.4");
                string answerE085 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.5");
                string answerE086 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.6");
                string answerE087 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E08.7");

                if (answerE081.Contains("A")) radCheckE081A.Checked = true;
                if (answerE081.Contains("B")) radCheckE081B.Checked = true;

                if (answerE082.Contains("A")) radCheckE082A.Checked = true;
                if (answerE082.Contains("B")) radCheckE082B.Checked = true;

                if (answerE083.Contains("A")) radCheckE083A.Checked = true;
                if (answerE083.Contains("B")) radCheckE083B.Checked = true;

                if (answerE084.Contains("A")) radCheckE084A.Checked = true;
                if (answerE084.Contains("B")) radCheckE084B.Checked = true;

                if (answerE085.Contains("A")) radCheckE085A.Checked = true;
                if (answerE085.Contains("B")) radCheckE085B.Checked = true;

                if (answerE086.Contains("A")) radCheckE086A.Checked = true;
                if (answerE086.Contains("B")) radCheckE086B.Checked = true;

                if (answerE087.Contains("A")) radCheckE087A.Checked = true;
                if (answerE087.Contains("B")) radCheckE087B.Checked = true;
            }
            if (answerE08.Contains("B")) radCheckE08B.Checked = true;
        }
    }
}
