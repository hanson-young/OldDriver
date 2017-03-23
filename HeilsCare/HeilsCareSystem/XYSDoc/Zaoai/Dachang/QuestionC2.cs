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
    public partial class QuestionC2 : XYS.Remp.Screening.BaseForm
    {
        public QuestionC2()
        {
            InitializeComponent();
        }

        private void radCheckC04A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl04.Visible = false;
        }

        private void radCheckC04B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl04.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResult = this.radCheckC04A.Checked ? "A" : radCheckC04B.Checked?"B":"";
            M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".C04";
                question.QuestionType = 1;//单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiDaChangAi);
                if (radCheckC04B.Checked)
                {
                    string questionResultA = this.radCheckC041A.Checked ? "A" : this.radCheckC041B.Checked ? "B" : this.radCheckC041C.Checked ? "C" : radCheckC041D.Checked?"D":"";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".C04.1";
                    questionA.QuestionType = 1;//单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiDaChangAi);
                }
            QuestionD1 questionD1 = new QuestionD1();
            questionD1.TopMost = false;
            questionD1.ShowDialog();
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
            QuestionC1 questionC1 = new QuestionC1();
            questionC1.TopMost = false;
            questionC1.ShowDialog();
            this.Close();
        }

        private void QuestionC2_Load(object sender, EventArgs e)
        {
            string answerC04 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".C04");
            if (answerC04.Contains("A")) radCheckC04A.Checked = true;
            if (answerC04.Contains("B"))
            {
                this.pnl04.Visible = true;
                radCheckC04B.Checked = true;
                string answerC041 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".C04.1");
                if (answerC041.Contains("A")) radCheckC041A.Checked = true;
                if (answerC041.Contains("B")) radCheckC041B.Checked = true;
                if (answerC041.Contains("C")) radCheckC041C.Checked = true;
                if (answerC041.Contains("D")) radCheckC041D.Checked = true;
            }
        }
    }
}
