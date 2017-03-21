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
    public partial class QuestionC2 :BaseForm
    {
        public QuestionC2()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (radCheckC04A.Checked || radCheckC04B.Checked)
            {
                string questionResult = radCheckC04A.Checked?"A":"B";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".C04";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiWeiAi);

                if (radCheckC04B.Checked)
                {
                    string questionResultChild = this.radCheckC041A.Checked ? "A" : radCheckC041B.Checked ? "B" : this.radCheckC041C.Checked ? "C" : radCheckC041D.Checked?"D":"";
                    M_QuestionnaireResultDetail questionChild = new M_QuestionnaireResultDetail();
                    questionChild.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".C04.1";
                    questionChild.QuestionType = 1; //单选
                    questionChild.QuestionResult = questionResultChild;
                    ClientInfo.AddQuestionToQuestionnaire(questionChild, QuestionnaireCode.ZaoAiWeiAi);
                }

            }

            if (radCheckC05A.Checked)
            {
                string questionResult = "A";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".C05";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiWeiAi);
            }

            if (radCheckC05B.Checked)
            {
                string questionResultA = "B";
                M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".C05";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);

                //文本框必填
                if (string.IsNullOrEmpty(txtC051.Text))
                {
                    MessageBox.Show("请输入酒精摄入量!");
                    label4.ForeColor = Color.Red;
                    return;
                }
                string questionResultB = this.txtC051.Text;
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".C05.1";
                questionB.QuestionType = 3; //填空题
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiWeiAi);

            }

            if (radCheckC05C.Checked)
            {
                string questionResultA = "C";
                M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".C05";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);

                string questionResultB = this.radCheckC052A.Checked ? "A" : radCheckC052B.Checked ? "B" : this.radCheckC052C.Checked ? "C" : radCheckC052D.Checked?"D":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".C05.2";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiWeiAi);
            }
            QuestionD1 questionD1 = new QuestionD1();
            questionD1.TopMost = false;
            questionD1.ShowDialog();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl04.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl04.Visible = true;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl05.Visible = true;
            this.pnlC052.Visible = false;
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlC052.Visible = true;
            this.pnl05.Visible = false;
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

        private void QuestionC2_Load(object sender, EventArgs e)
        {
            string answerC04 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".C04");
            string answerC05 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".C05");
            if (answerC04.Contains("A")) radCheckC04A.Checked = true;
            if (answerC04.Contains("B"))
            {
                radCheckC04B.Checked = true;
                this.pnl04.Visible = true;
                string answerC041 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".C04.1");
                if (answerC041.Contains("A")) radCheckC041A.Checked = true;
                if (answerC041.Contains("B")) radCheckC041B.Checked = true;
                if (answerC041.Contains("C")) radCheckC041C.Checked = true;
                if (answerC041.Contains("D")) radCheckC041D.Checked = true;
            }

            if (answerC05.Contains("A")) radCheckC05A.Checked = true;
            if (answerC05.Contains("B"))
            {
                radCheckC05B.Checked = true;
                this.pnl05.Visible = true;
                this.pnlC052.Visible = false;
                string answerC051 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".C05.1");
                this.txtC051.Text = answerC051;
            }

            if (answerC05.Contains("C"))
            {
                radCheckC05C.Checked = true;
                this.pnl05.Visible = false;
                this.pnlC052.Visible = true;
                string answerC052 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".C05.2");
                if (answerC052.Contains("A")) radCheckC052A.Checked = true;
                if (answerC052.Contains("B")) radCheckC052B.Checked = true;
                if (answerC052.Contains("C")) radCheckC052C.Checked = true;
                if (answerC052.Contains("D")) radCheckC052D.Checked = true;
            }
        }

        private void txtC051_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void radCheckC05A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnl05.Visible = false;
            this.pnlC052.Visible = false;
        }

        private void txtC051_KeyUp(object sender, KeyEventArgs e)
        {
            btnNext.Enabled = true;
        }

        
    }
}
