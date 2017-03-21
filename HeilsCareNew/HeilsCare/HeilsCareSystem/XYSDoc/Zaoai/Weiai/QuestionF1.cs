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
    public partial class QuestionF1 :BaseForm
    {
        public QuestionF1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResult = radCheckF01A.Checked ? "A" : radCheckF01B.Checked?"B":"";
            M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiWeiAi);
                if (radCheckF01A.Checked)
                {
                    string questionResultA = radCheckF011A.Checked ? "A" : radCheckF011B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultB = radCheckF012A.Checked ? "A" : radCheckF012B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01.2";
                    questionB.QuestionType = 1; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultC = radCheckF013A.Checked ? "A" : radCheckF013B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01.3";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultD = radCheckF014A.Checked ? "A" : radCheckF014B.Checked ? "B" : "";
                    M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                    questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01.4";
                    questionD.QuestionType = 1; //单选
                    questionD.QuestionResult = questionResultD;
                    ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultE = radCheckF015A.Checked ? "A" : radCheckF015B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionE = new M_QuestionnaireResultDetail();
                    questionE.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01.5";
                    questionE.QuestionType = 1; //单选
                    questionE.QuestionResult = questionResultE;
                    ClientInfo.AddQuestionToQuestionnaire(questionE, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultF = "";
                    if (cbCheckA.Checked) questionResultF += "A,";
                    if (cbCheckB.Checked) questionResultF += "B,";
                    if (cbCheckC.Checked) questionResultF += "C,";
                    if (cbCheckD.Checked) questionResultF += "D,";
                    if (cbCheckE.Checked) questionResultF += "E,";
                    if (cbCheckF.Checked) questionResultF += "F,";
                    if (cbCheckG.Checked) questionResultF += "G,";
                    if (cbCheckH.Checked) questionResultF += "H,";
                    if (cbCheckI.Checked) questionResultF += "I,";
                    if (cbCheckJ.Checked) questionResultF += "J,";
                    if (cbCheckK.Checked) questionResultF += "K,";
                    M_QuestionnaireResultDetail questionF = new M_QuestionnaireResultDetail();
                    questionF.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01.2.1";
                    questionF.QuestionType = 2; //多选
                    questionF.QuestionResult = questionResultF;
                    ClientInfo.AddQuestionToQuestionnaire(questionF, QuestionnaireCode.ZaoAiWeiAi);

                    string questionResultG = "";
                    if (cbCheckF13A.Checked) questionResultG += "A,";
                    if (cbCheckF13B.Checked) questionResultG += "B,";
                    if (cbCheckF13C.Checked) questionResultG += "C,";
                    if (cbCheckF13D.Checked) questionResultG += "D,";
                    if (cbCheckF13E.Checked) questionResultG += "E,";
                    if (cbCheckF13F.Checked) questionResultG += "F,";
                    if (cbCheckF13G.Checked) questionResultG += "G,";
                    if (cbCheckF13H.Checked) questionResultG += "H,";
                    if (cbCheckF13I.Checked) questionResultG += "I,";
                    if (cbCheckF13J.Checked) questionResultG += "J,";
                    if (cbCheckF13K.Checked) questionResultG += "K,";
                    M_QuestionnaireResultDetail questionG = new M_QuestionnaireResultDetail();
                    questionG.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".F01.3.1";
                    questionG.QuestionType = 2; //多选
                    questionG.QuestionResult = questionResultG;
                    ClientInfo.AddQuestionToQuestionnaire(questionG, QuestionnaireCode.ZaoAiWeiAi);

                }

            
            
            
            var weiAiResultForm = new WeiAiResultForm();
            weiAiResultForm.TopMost = false;
            weiAiResultForm.ShowDialog();
            this.Close();
        }

        private void radCheckF01A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF01.Visible = true;
        }

        private void radCheckF01B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF01.Visible = false;
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

        private void QuestionF1_Load(object sender, EventArgs e)
        {
            string answerF01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01");
            if (answerF01.Contains("A"))
            {
                radCheckF01A.Checked = true;
                this.pnlF01.Visible = true;
                string answerF11 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01.1");
                string answerF12 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01.2");
                string answerF13 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01.3");
                string answerF14 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01.4");
                string answerF15 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01.5");
                string answerF121 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01.2.1");
                string answerF131 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".F01.3.1");

                if (answerF11.Contains("A")) radCheckF011A.Checked = true;
                if (answerF11.Contains("B")) radCheckF011B.Checked = true;

                if (answerF12.Contains("A")) radCheckF012A.Checked = true;
                if (answerF12.Contains("B")) radCheckF012B.Checked = true;

                if (answerF13.Contains("A")) radCheckF013A.Checked = true;
                if (answerF13.Contains("B")) radCheckF013B.Checked = true;

                if (answerF14.Contains("A")) radCheckF014A.Checked = true;
                if (answerF14.Contains("B")) radCheckF014B.Checked = true;

                if (answerF15.Contains("A")) radCheckF015A.Checked = true;
                if (answerF15.Contains("B")) radCheckF015B.Checked = true;

                if (answerF121.Contains("A")) cbCheckA.Checked = true;
                if (answerF121.Contains("B")) cbCheckB.Checked = true;
                if (answerF121.Contains("C")) cbCheckC.Checked = true;
                if (answerF121.Contains("D")) cbCheckD.Checked = true;
                if (answerF121.Contains("E")) cbCheckE.Checked = true;
                if (answerF121.Contains("F")) cbCheckF.Checked = true;
                if (answerF121.Contains("G")) cbCheckG.Checked = true;
                if (answerF121.Contains("H")) cbCheckH.Checked = true;
                if (answerF121.Contains("I")) cbCheckI.Checked = true;
                if (answerF121.Contains("J")) cbCheckJ.Checked = true;
                if (answerF121.Contains("K")) cbCheckK.Checked = true;

                if (answerF131.Contains("A")) cbCheckF13A.Checked = true;
                if (answerF131.Contains("B")) cbCheckF13B.Checked = true;
                if (answerF131.Contains("C")) cbCheckF13C.Checked = true;
                if (answerF131.Contains("D")) cbCheckF13D.Checked = true;
                if (answerF131.Contains("E")) cbCheckF13E.Checked = true;
                if (answerF131.Contains("F")) cbCheckF13F.Checked = true;
                if (answerF131.Contains("G")) cbCheckF13G.Checked = true;
                if (answerF131.Contains("H")) cbCheckF13H.Checked = true;
                if (answerF131.Contains("I")) cbCheckF13I.Checked = true;
                if (answerF131.Contains("J")) cbCheckF13J.Checked = true;
                if (answerF131.Contains("K")) cbCheckF13K.Checked = true;

            }

            if (answerF01.Contains("B")) radCheckF01B.Checked = true;
        }

        private void radCheckF013A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF13.Visible = true;
        }

        private void radCheckF013B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF13.Visible = false;
        }

        private void radCheckF012A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF12.Visible = true;
        }

        private void radCheckF012B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF12.Visible = false;
        }
    }
}
