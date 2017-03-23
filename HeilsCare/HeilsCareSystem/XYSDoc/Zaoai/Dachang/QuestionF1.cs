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
    public partial class QuestionF1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionF1()
        {
            InitializeComponent();
        }

        private void radCheckF01A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF01.Visible = true;
        }

        private void radCheckF01B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlF01.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResult = radCheckF01A.Checked ? "A" : radCheckF01B.Checked?"B":"";
            var question = new M_QuestionnaireResultDetail();
                question.QuestionCode = QuestionnaireCode.ZaoAiDaChangAi + ".F01";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiDaChangAi);
                if (radCheckF01A.Checked)
                {
                    string questionResultA = radCheckF011A.Checked ? "A" : radCheckF011B.Checked?"B":"";
                    var questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = QuestionnaireCode.ZaoAiDaChangAi + ".F01.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiDaChangAi);

                    string questionResultB = "";
                    if (cbCheckA.Checked) questionResultB += "A,";
                    if (cbCheckB.Checked) questionResultB += "B,";
                    if (cbCheckC.Checked) questionResultB += "C,";
                    if (cbCheckD.Checked) questionResultB += "D,";
                    if (cbCheckE.Checked) questionResultB += "E,";
                    if (cbCheckF.Checked) questionResultB += "F,";
                    if (cbCheckG.Checked) questionResultB += "G,";
                    if (cbCheckH.Checked) questionResultB += "H,";
                    if (cbCheckI.Checked) questionResultB += "I,";
                    if (cbCheckJ.Checked) questionResultB += "J,";
                    if (cbCheckK.Checked) questionResultB += "K";
                    var questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = QuestionnaireCode.ZaoAiDaChangAi + ".F01.2";
                    questionB.QuestionType = 2; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiDaChangAi);
                }

            DaChangResult daChangResult = new DaChangResult();
            daChangResult.TopMost = false;
            daChangResult.ShowDialog();
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
            QuestionE3 questionE3 = new QuestionE3();
            questionE3.TopMost = false;
            questionE3.ShowDialog();
            this.Close();
        }

        private void QuestionF1_Load(object sender, EventArgs e)
        {
            string answerF01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".F01");
            if (answerF01.Contains("A"))
            {
                this.pnlF01.Visible = true;
                radCheckF01A.Checked = true;
                string answerF011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".F01.1");
                if (answerF011.Contains("A")) radCheckF011A.Checked = true;
                if (answerF011.Contains("B")) radCheckF011B.Checked = true;
                string answerF012 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".F01.2");
                if (answerF012.Contains("A")) cbCheckA.Checked = true;
                if (answerF012.Contains("B")) cbCheckB.Checked = true;
                if (answerF012.Contains("C")) cbCheckC.Checked = true;
                if (answerF012.Contains("D")) cbCheckD.Checked = true;
                if (answerF012.Contains("E")) cbCheckE.Checked = true;
                if (answerF012.Contains("F")) cbCheckF.Checked = true;
                if (answerF012.Contains("G")) cbCheckG.Checked = true;
                if (answerF012.Contains("H")) cbCheckH.Checked = true;
                if (answerF012.Contains("I")) cbCheckI.Checked = true;
                if (answerF012.Contains("J")) cbCheckJ.Checked = true;
                if (answerF012.Contains("K")) cbCheckK.Checked = true;
            }
            if (answerF01.Contains("B")) radCheckF01B.Checked = true;
        }
    }
}
