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
    public partial class QuestionE1 : BaseForm
    {
        public QuestionE1()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE01.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE01.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl04.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl04.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
                string questionResultE01 = radCheckE01A.Checked?"A":radCheckE01B.Checked?"B":"";
                M_QuestionnaireResultDetail questionE01 = new M_QuestionnaireResultDetail();
                questionE01.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E01";
                questionE01.QuestionType = 1; //单选
                questionE01.QuestionResult = questionResultE01;
                ClientInfo.AddQuestionToQuestionnaire(questionE01, QuestionnaireCode.ZaoAiWeiAi);

                if (radCheckE01A.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtE011.Text))
                    {
                        MessageBox.Show("请输入您有哪种癌症病史!");
                        this.label4.ForeColor=Color.Red;
                        return;
                    }
                    string questionResultA = this.txtE011.Text;
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E01.1";
                    questionA.QuestionType = 3; //填空
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);
                }
                string questionResult = radCheckE04A.Checked?"A":radCheckE04B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E04";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiWeiAi);

                if (radCheckE04A.Checked)
                {
                    string questionResultA = radCheckE041A.Checked ? "A" : radCheckE041B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".E04.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);
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
            QuestionD1 questionD1 = new QuestionD1();
            questionD1.TopMost = false;
            questionD1.ShowDialog();
            this.Close();
        }

        private void QuestionE1_Load(object sender, EventArgs e)
        {
            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E01");
            string answerE04 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E04");
            if (answerE01.Contains("A"))
            {
                radCheckE01A.Checked = true;
                this.pnlE01.Visible = true;
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E01.1");
                this.txtE011.Text = answerE011;
            }
            if (answerE01.Contains("B")) radCheckE01B.Checked = true;

            if (answerE04.Contains("A"))
            {
                radCheckE04A.Checked = true;
                this.pnl04.Visible = true;
                string answerE041 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".E04.1");
                if (answerE041.Contains("A")) radCheckE041A.Checked = true;
                if (answerE041.Contains("B")) radCheckE041B.Checked = true;
            }
            if (answerE04.Contains("B")) radCheckE04B.Checked = true;
        }

        private void txtE011_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.button1.Enabled = true;
        }
    }
}
