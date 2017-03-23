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
    public partial class QuestionE1 : BaseForm
    {
        public QuestionE1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResult = radCheckE01A.Checked ? "A" : radCheckE01B.Checked?"B":"";
            M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".E01";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);
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
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".E01.1";
                    questionA.QuestionType =3; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiRuXianAi);
                }
 
            QuestionW1 questionW1 = new QuestionW1();
            questionW1.TopMost = false;
            questionW1.ShowDialog();
            this.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE01.Visible = true;
            button1.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlE01.Visible = false;
            button1.Enabled = true;
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
            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".E01");
            if (answerE01.Contains("A"))
            {
                pnlE01.Visible = true;
                radCheckE01A.Checked = true;
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".E01.1");
                this.txtE011.Text = answerE011;
            }
            if (answerE01.Contains("B")) radCheckE01B.Checked = true;
        }

        private void txtE011_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.button1.Enabled = true;
        }

        private void txtE011_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
