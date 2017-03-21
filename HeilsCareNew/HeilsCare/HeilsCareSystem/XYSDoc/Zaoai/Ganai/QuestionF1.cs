using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Ganai
{
    public partial class QuestionF1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionF1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

                string questionResult = this.radCheckF01A.Checked ? "A" : radCheckF01B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".F01";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiGanAi);
                if (radCheckF01A.Checked)
                {
                    //F01.1
                    string questionResultA = this.radCheckF011A.Checked ? "A" : radCheckF011B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".F01.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiGanAi);

                    //F01.2
                    string questionResultB = this.radCheckF012A.Checked ? "A" : radCheckF012B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".F01.2";
                    questionB.QuestionType = 1; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiGanAi);

                    //F01.3
                    string questionResultC = this.radCheckF013A.Checked ? "A" : radCheckF013B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".F01.3";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiGanAi);

                    //F01.4
                    string questionResultD = this.radCheckF014A.Checked ? "A" : radCheckF014B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                    questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".F01.4";
                    questionD.QuestionType = 1; //单选
                    questionD.QuestionResult = questionResultD;
                    ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiGanAi);

                    //F01.5
                    string questionResultE = this.radCheckF015A.Checked ? "A" : radCheckF015B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionE = new M_QuestionnaireResultDetail();
                    questionE.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".F01.5";
                    questionE.QuestionType = 1; //单选
                    questionE.QuestionResult = questionResultE;
                    ClientInfo.AddQuestionToQuestionnaire(questionE, QuestionnaireCode.ZaoAiGanAi);

                    //F01.6
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
                    if (cbCheckK.Checked) questionResultF += "K";
                    M_QuestionnaireResultDetail questionF = new M_QuestionnaireResultDetail();
                    questionF.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".F01.6";
                    questionF.QuestionType = 2; //单选
                    questionF.QuestionResult = questionResultF;
                    ClientInfo.AddQuestionToQuestionnaire(questionF, QuestionnaireCode.ZaoAiGanAi);
                }


            GanaiResult ganaiResult = new GanaiResult();
            ganaiResult.TopMost = false;
            ganaiResult.ShowDialog();
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
            string answerF01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".F01");
            if (answerF01.Contains("A"))
            {
                radCheckF01A.Checked = true;
                this.pnlF01.Visible = true;
                string answerF011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".F01.1");
                if(answerF011.Contains("A")) radCheckF011A.Checked = true;
                if (answerF011.Contains("B")) radCheckF011B.Checked = true;

                string answerF012 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".F01.2");
                if (answerF012.Contains("A")) radCheckF012A.Checked = true;
                if (answerF012.Contains("B")) radCheckF012B.Checked = true;

                string answerF013= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".F01.3");
                if (answerF013.Contains("A")) radCheckF013A.Checked = true;
                if (answerF013.Contains("B")) radCheckF013B.Checked = true;

                string answerF014 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".F01.4");
                if (answerF014.Contains("A")) radCheckF014A.Checked = true;
                if (answerF014.Contains("B")) radCheckF014B.Checked = true;

                string answerF015= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".F01.5");
                if (answerF015.Contains("A")) radCheckF015A.Checked = true;
                if (answerF015.Contains("B")) radCheckF015B.Checked = true;

                string answerF16 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".F01.6");
                if (answerF16.Contains("A")) cbCheckA.Checked = true;
                if (answerF16.Contains("B")) cbCheckB.Checked = true;
                if (answerF16.Contains("C")) cbCheckC.Checked = true;
                if (answerF16.Contains("D")) cbCheckD.Checked = true;
                if (answerF16.Contains("E")) cbCheckE.Checked = true;
                if (answerF16.Contains("F")) cbCheckF.Checked = true;
                if (answerF16.Contains("G")) cbCheckG.Checked = true;
                if (answerF16.Contains("H")) cbCheckH.Checked = true;
                if (answerF16.Contains("I")) cbCheckI.Checked = true;
                if (answerF16.Contains("J")) cbCheckJ.Checked = true;
                if (answerF16.Contains("K")) cbCheckK.Checked = true;
            }
            if (answerF01.Contains("B")) radCheckF01B.Checked = true;
        }
    }
}
