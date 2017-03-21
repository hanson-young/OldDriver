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
    public partial class QuestionE1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionE1()
        {
            InitializeComponent();
        }

        private void radCheckE01A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE011.Visible = true;
        }

        private void radCheckE01B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE011.Visible = false;
        }

        private void radCheckE02A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE021.Visible = true;
            this.button1.Enabled = true;
        }

        private void radCheckE02B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE021.Visible = false;
            this.button1.Enabled = true;
        }

        private void radCheckE03A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE031.Visible = true;
            this.button1.Enabled = true;
        }

        private void radCheckE03B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE031.Visible = false;
            this.button1.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            string questionResultE01 = this.radCheckE01A.Checked ? "A" : radCheckE01B.Checked?"B":"";
            M_QuestionnaireResultDetail questionE01 = new M_QuestionnaireResultDetail();
                questionE01.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E01";
                questionE01.QuestionType = 1; //单选
                questionE01.QuestionResult = questionResultE01;
                ClientInfo.AddQuestionToQuestionnaire(questionE01, QuestionnaireCode.ZaoAiGanAi);

                if (radCheckE01A.Checked)
                {

                    if (string.IsNullOrEmpty(this.txtE011.Text))
                    {
                        MessageBox.Show("请输入您的癌症病史!");
                        this.label6.ForeColor=Color.Red;
                        return;
                    }
                    string questionResultA = this.txtE011.Text;
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E01.1";
                    questionA.QuestionType = 3; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiGanAi);
                }

                string questionResult = this.radCheckE02A.Checked ? "A" : radCheckE02B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E02";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiGanAi);

                if (radCheckE02A.Checked)
                {
                    string questionResultB = this.radCheckE021A.Checked ? "A" : radCheckE021B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultB))
                    {
                        MessageBox.Show("请选择您的检测结果");
                        return;
                    }
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E02.1";
                    questionB.QuestionType = 1; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiGanAi);
                }

                string questionResultE03 = this.radCheckE03A.Checked ? "A" : radCheckE03B.Checked?"B":"";
                M_QuestionnaireResultDetail questionE03 = new M_QuestionnaireResultDetail();
                questionE03.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E03";
                questionE03.QuestionType = 1; //单选
                questionE03.QuestionResult = questionResultE03;
                ClientInfo.AddQuestionToQuestionnaire(questionE03, QuestionnaireCode.ZaoAiGanAi);
                if (radCheckE03A.Checked)
                {
                    string questionResultC = this.radCheckE031A.Checked ? "A" : radCheckE031B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultC))
                    {
                        MessageBox.Show("请选择您的检测结果");
                        return;
                    }
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".E03.1";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiGanAi);
                }



            QuestionE2 questionE2 = new QuestionE2();
            questionE2.TopMost = false;
            questionE2.ShowDialog();
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
            var questionC1 = new QuestionC1();
            questionC1.TopMost = false;
            questionC1.ShowDialog();
            this.Close();
        }

        private void QuestionE1_Load(object sender, EventArgs e)
        {
            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E01");
            if (answerE01.Contains("A"))
            {
                radCheckE01A.Checked = true;
                pnlE011.Visible = true;
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E01.1");
                this.txtE011.Text = answerE011;
            }
            if (answerE01.Contains("B")) radCheckE01B.Checked = true;

            string answerE02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E02");
            if (answerE02.Contains("A"))
            {
                radCheckE02A.Checked = true;
                pnlE021.Visible = true;
                string answerE021 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E02.1");
                if (answerE021.Contains("A")) radCheckE021A.Checked = true;
                if (answerE021.Contains("B")) radCheckE021B.Checked = true;
            }
            if (answerE02.Contains("B")) radCheckE02B.Checked = true;

            string answerE03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E03");
            if (answerE03.Contains("A"))
            {
                radCheckE03A.Checked = true;
                pnlE031.Visible = true;
                string answerE031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".E03.1");
                if (answerE031.Contains("A")) radCheckE031A.Checked = true;
                if (answerE031.Contains("B")) radCheckE031B.Checked = true;
            }
            if (answerE03.Contains("B")) radCheckE03B.Checked = true;
        }

        private void txtE011_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void radCheckE021A_CheckedChanged(object sender, EventArgs e)
        {
            this.button1.Enabled = true;
        }


    }
}
