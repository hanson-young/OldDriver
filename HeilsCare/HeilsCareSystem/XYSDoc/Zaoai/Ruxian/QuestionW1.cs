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
    public partial class QuestionW1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionW1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResultA = radCheckW03A.Checked ? "A" : radCheckW03B.Checked?"B":"";
            M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W03";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiRuXianAi);
                if (radCheckW03A.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtAge.Text))
                    {
                        MessageBox.Show("请输入您的年龄!");
                        this.label4.ForeColor=Color.Red;
                        return;
                    }
                    string questionResultB = this.txtAge.Text;
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W03.1";
                    questionB.QuestionType = 3; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiRuXianAi);
                }

                string questionResultC = radCheckW04A.Checked ? "A" : radCheckW04B.Checked?"B":"";
                M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W04";
                questionC.QuestionType = 1; //单选
                questionC.QuestionResult = questionResultC;
                ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiRuXianAi);

            if (radCheckW04A.Checked)
            {
                string questionResult = radCheckW041A.Checked ? "A" : radCheckW041B.Checked ? "B" : "";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W04.1";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);
            }


                string questionResultD = radCheckW06A.Checked ? "A" : radCheckW06B.Checked?"B":"";
                M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W06";
                questionD.QuestionType = 1; //单选
                questionD.QuestionResult = questionResultD;
                ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiRuXianAi);

            
            QuestionW2 questionW2 = new QuestionW2();
            questionW2.TopMost = false;
            questionW2.ShowDialog();
            this.Close();
        }

        private void radCheckW03A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlW03.Visible = true;
        }

        private void radCheckW03B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlW03.Visible = false;
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

        private void QuestionW1_Load(object sender, EventArgs e)
        {
                string answerW03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W03");
            if (answerW03.Contains("A"))
            {
                this.radCheckW03A.Checked = true;
                this.pnlW03.Visible = true;
                string answerW031 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W03.1");
                this.txtAge.Text = answerW031;
            }
            if (answerW03.Contains("B")) radCheckW03B.Checked = true;

            string answerW04 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W04");
            if (answerW04.Contains("A"))
            {
                radCheckW04A.Checked = true;
                this.pnlW041.Visible = true;
                string answerW041 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W04.1");
                if (answerW041.Contains("A")) radCheckW041A.Checked = true;
                if (answerW041.Contains("B")) radCheckW041B.Checked = true;
            }
            if (answerW04.Contains("B")) radCheckW04B.Checked = true;

            string answerW06 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W06");
            if (answerW06.Contains("A")) radCheckW06A.Checked = true;
            if (answerW06.Contains("B")) radCheckW06B.Checked = true;
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.button1.Enabled = true;
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }

        }

        private void radCheckW04A_CheckedChanged(object sender, EventArgs e)
        {
            pnlW041.Visible = true;
        }

        private void radCheckW04B_CheckedChanged(object sender, EventArgs e)
        {
            pnlW041.Visible = false;
        }
    }
}
