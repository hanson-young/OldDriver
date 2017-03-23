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
    public partial class QuestionE2 : XYS.Remp.Screening.BaseForm
    {
        public QuestionE2()
        {
            InitializeComponent();
        }

        private void radCheckE071A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl0711.Visible = true;
            this.button1.Enabled = true;
        }

        private void radCheckE071B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl0711.Visible = false;
            this.button1.Enabled = true;
        }

        private void radCheckE072A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE0721.Visible = true;
            this.button1.Enabled = true;
        }

        private void radCheckE072B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE0721.Visible = false;
            this.button1.Enabled = true;
        }

        private void radCheckE073A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE0731.Visible = true;
            this.button1.Enabled = true;
        }

        private void radCheckE073B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE0731.Visible = false;
            this.button1.Enabled = true;
        }

        private void radCheckE074A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE0741.Visible = true;
            this.button1.Enabled = true;
        }

        private void radCheckE074B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE0741.Visible = false;
            this.button1.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            string questionResultE071 = this.radCheckE071A.Checked ? "A" : radCheckE071B.Checked?"B":"";
            M_QuestionnaireResultDetail questionE071 = new M_QuestionnaireResultDetail();
                questionE071.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.1";
                questionE071.QuestionType = 1; //单选
                questionE071.QuestionResult = questionResultE071;
                ClientInfo.AddQuestionToQuestionnaire(questionE071, QuestionnaireCode.ZaoAiGanAi);
                if (radCheckE071A.Checked)
                {
                    string questionResultA = this.radCheckE0711A.Checked ? "A" : radCheckE0711B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultA))
                    {
                        MessageBox.Show("是否超过5年？");
                        return;
                    }
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.1.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiGanAi);
                }



                string questionResultE072 = this.radCheckE072A.Checked ? "A" : radCheckE072B.Checked?"B":"";
                M_QuestionnaireResultDetail questionE072 = new M_QuestionnaireResultDetail();
                questionE072.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.2";
                questionE072.QuestionType = 1; //单选
                questionE072.QuestionResult = questionResultE072;
                ClientInfo.AddQuestionToQuestionnaire(questionE072, QuestionnaireCode.ZaoAiGanAi);

                if (radCheckE072A.Checked)
                {
                    string questionResultA = this.radCheckE0721A.Checked ? "A" : radCheckE0721B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultA))
                    {
                        MessageBox.Show("是否超过5年？");
                        return;
                    }
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.2.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiGanAi);
                }


                string questionResultE073 = this.radCheckE073A.Checked ? "A" : radCheckE073B.Checked?"B":"";
                M_QuestionnaireResultDetail questionE073 = new M_QuestionnaireResultDetail();
                questionE073.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.3";
                questionE073.QuestionType = 1; //单选
                questionE073.QuestionResult = questionResultE073;
                ClientInfo.AddQuestionToQuestionnaire(questionE073, QuestionnaireCode.ZaoAiGanAi);

                if (radCheckE073A.Checked)
                {
                    string questionResultA = this.radCheckE0731A.Checked ? "A" : radCheckE0731B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultA))
                    {
                        MessageBox.Show("是否超过5年？");
                        return;
                    }
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.3.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiGanAi);
                }

                string questionResultE074 = this.radCheckE074A.Checked ? "A" : radCheckE074B.Checked?"B":"";
                M_QuestionnaireResultDetail questionE074 = new M_QuestionnaireResultDetail();
                questionE074.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.4";
                questionE074.QuestionType = 1; //单选
                questionE074.QuestionResult = questionResultE074;
                ClientInfo.AddQuestionToQuestionnaire(questionE074, QuestionnaireCode.ZaoAiGanAi);

                if (radCheckE074A.Checked)
                {
                    string questionResultA = this.radCheckE0741A.Checked ? "A" : radCheckE0741B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultA))
                    {
                        MessageBox.Show("是否超过5年？");
                        return;
                    }
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.4.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiGanAi);
                }


     
                string questionResultE075 = this.radCheckE075A.Checked
                    ? "A"
                    : radCheckE075B.Checked ? "B" : radCheckE075C.Checked ? "C" : radCheckE075D.Checked ? "D" : radCheckE075E.Checked?"E":"";
                M_QuestionnaireResultDetail questionE075 = new M_QuestionnaireResultDetail();
                questionE075.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E07.5";
                questionE075.QuestionType = 1; //单选
                questionE075.QuestionResult = questionResultE075;
                ClientInfo.AddQuestionToQuestionnaire(questionE075, QuestionnaireCode.ZaoAiGanAi);


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
            QuestionE1 questionE1 = new QuestionE1();
            questionE1.TopMost = false;
            questionE1.ShowDialog();
            this.Close();
        }

        private void QuestionE2_Load(object sender, EventArgs e)
        {
            string answerE071 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.1");
            if (answerE071.Contains("A"))
            {
                radCheckE071A.Checked = true;
                string answerE0711 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.1.1");
                if (answerE0711.Contains("A")) radCheckE0711A.Checked = true;
                if (answerE0711.Contains("B")) radCheckE0711B.Checked = true;
            }
            if (answerE071.Contains("B")) radCheckE071B.Checked = true;

            string answerE072 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.2");
            if (answerE072.Contains("A"))
            {
                radCheckE072A.Checked = true;
                string answerE0712 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.2.1");
                if (answerE0712.Contains("A")) radCheckE0721A.Checked = true;
                if (answerE0712.Contains("B")) radCheckE0721B.Checked = true;
            }
            if (answerE072.Contains("B")) radCheckE072B.Checked = true;

            string answerE073 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.3");
            if (answerE073.Contains("A"))
            {
                radCheckE073A.Checked = true;
                string answerE0731 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.3.1");
                if (answerE0731.Contains("A")) radCheckE0731A.Checked = true;
                if (answerE0731.Contains("B")) radCheckE0731B.Checked = true;
            }
            if (answerE073.Contains("B")) radCheckE073B.Checked = true;

            string answerE074 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.4");
            if (answerE074.Contains("A"))
            {
                radCheckE074A.Checked = true;
                string answerE0741 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.4.1");
                if (answerE0741.Contains("A")) radCheckE0741A.Checked = true;
                if (answerE0741.Contains("B")) radCheckE0741B.Checked = true;
            }
            if (answerE074.Contains("B")) radCheckE074B.Checked = true;

            string answerE075 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E07.5");
            if (answerE075.Contains("A")) radCheckE075A.Checked = true;
            if (answerE075.Contains("B")) radCheckE075B.Checked = true;
            if (answerE075.Contains("C")) radCheckE075C.Checked = true;
            if (answerE075.Contains("D")) radCheckE075D.Checked = true;
            if (answerE075.Contains("E")) radCheckE075E.Checked = true;
        }

        private void radCheckE0711A_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }
    }
}
