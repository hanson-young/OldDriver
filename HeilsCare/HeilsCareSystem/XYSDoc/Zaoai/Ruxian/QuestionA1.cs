using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Ruxian
{
    public partial class QuestionA1 :BaseForm
    {
        public QuestionA1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            string questionResultA07 = this.radCheckA.Checked ? "A" : radCheckB.Checked ? "B" : radCheckC.Checked ? "C" : radCheckD.Checked ? "D" : radCheckE.Checked ? "E" : radCheckF.Checked?"F":"";
            M_QuestionnaireResultDetail questionA07 = new M_QuestionnaireResultDetail();
                questionA07.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".A07";
                questionA07.QuestionType = 1;//单选
                questionA07.QuestionResult = questionResultA07;
                ClientInfo.AddQuestionToQuestionnaire(questionA07, QuestionnaireCode.ZaoAiRuXianAi);

                string questionResultA08 = this.radCheckA08A.Checked ? "A" : radCheckA08B.Checked?"B":"";
                M_QuestionnaireResultDetail questionA08 = new M_QuestionnaireResultDetail();
                questionA08.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".A08";
                questionA08.QuestionType = 1;//单选
                questionA08.QuestionResult = questionResultA08;
                ClientInfo.AddQuestionToQuestionnaire(questionA08, QuestionnaireCode.ZaoAiRuXianAi);

                string questionResult = this.radCheckA09A.Checked ? "A" : radCheckA09B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".A09";
                question.QuestionType = 1;//单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);
                if (radCheckA09A.Checked)
                {
                    string questionResultA = "";
                    if (cbCheckA.Checked) questionResultA += "A,";
                    if (cbCheckB.Checked) questionResultA += "B,";
                    if (cbCheckC.Checked) questionResultA += "C,";
                    if (cbCheckD.Checked) questionResultA += "D,";
                    if (cbCheckE.Checked) questionResultA += "E,";
                    if (cbCheckF.Checked) questionResultA += "F,";
                    if (cbCheckG.Checked) questionResultA += "G,";
                    if (cbCheckH.Checked) questionResultA += "H,";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".A09.1";
                    questionA.QuestionType = 2;//单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiRuXianAi);
                }
            
            QuestionA2 questionA2 = new QuestionA2();
            questionA2.TopMost = false;
            questionA2.ShowDialog();
            //questionA2.Show();
            this.Close();
        }

        private void radCheckA09A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlQuestionOne.Visible = true;
        }

        private void radCheckA09B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlQuestionOne.Visible = false;
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

        private void QuestionA1_Load(object sender, EventArgs e)
        {
            string answerA07 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".A07");
            if (answerA07.Contains("A")) radCheckA.Checked = true;
            if (answerA07.Contains("B")) radCheckB.Checked = true;
            if (answerA07.Contains("C")) radCheckC.Checked = true;
            if (answerA07.Contains("D")) radCheckD.Checked = true;
            if (answerA07.Contains("E")) radCheckE.Checked = true;
            if (answerA07.Contains("F")) radCheckF.Checked = true;

            string answerA08 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".A08");
            if (answerA08.Contains("A")) radCheckA08A.Checked = true;
            if (answerA08.Contains("B")) radCheckA08B.Checked = true;

            string answerA09 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".A09");
            if (answerA09.Contains("A"))
            {
                radCheckA09A.Checked = true;
                pnlQuestionOne.Visible = true;

                string answerA091 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".A09.1");

                if (answerA091.Contains("A")) cbCheckA.Checked = true;
                if (answerA091.Contains("B")) cbCheckB.Checked = true;

                if (answerA091.Contains("C")) cbCheckC.Checked = true;
                if (answerA091.Contains("D")) cbCheckD.Checked = true;

                if (answerA091.Contains("E")) cbCheckE.Checked = true;
                if (answerA091.Contains("F")) cbCheckF.Checked = true;

                if (answerA091.Contains("G")) cbCheckG.Checked = true;
                if (answerA091.Contains("H")) cbCheckH.Checked = true;
            }
            if (answerA09.Contains("B")) radCheckA09B.Checked = true;
        }
    }
}
