using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening.Zaoai.Weiai;

namespace XYS.Remp.Screening.Zaoai.Ganai
{
    public partial class QuestionC1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionC1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

                string questionResult = this.radCheckC05A.Checked ? "A" : radCheckC05B.Checked ? "B" : radCheckC05C.Checked?"C":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".C05";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiGanAi);
                if (radCheckC05B.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtC051.Text))
                    {
                        MessageBox.Show("请输入您的酒精摄入量!");
                        this.label2.ForeColor=Color.Red;
                        return;
                    }
                    string questionResultB = this.txtC051.Text;
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".C05.1";
                    questionB.QuestionType = 3; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiGanAi);
                }

                if (radCheckC05C.Checked)
                {
                    string questionResultC = this.radCheckC052A.Checked
                        ? "A"
                        : radCheckC052B.Checked ? "B" : radCheckC052C.Checked ? "C" : radCheckC052D.Checked?"D":"";
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiGanAi + ".C05.2";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiGanAi);
                }

            QuestionE1 questionE1 = new QuestionE1();
            questionE1.TopMost = false;
            questionE1.ShowDialog();
            //questionE1.Show();
            this.Close();
        }

        private void radCheckC05B_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlC051.Visible = true;
            this.pnlC052.Visible = false;
        }

        private void radCheckC05C_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlC051.Visible = false;
            this.pnlC052.Visible = true;
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

        private void QuestionC1_Load(object sender, EventArgs e)
        {
            string answerC05 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".C05");
            if (answerC05.Contains("A")) radCheckC05A.Checked = true;
            if (answerC05.Contains("B"))
            {
                radCheckC05B.Checked = true;
                pnlC051.Visible = true;
                string answerC051 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".C05.1");
                this.txtC051.Text = answerC051;
            }

            if (answerC05.Contains("C"))
            {
                radCheckC05C.Checked = true;
                pnlC052.Visible = true;
                string answerC052 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiGanAi, QuestionnaireCode.ZaoAiGanAi + ".C05.2");
                if (answerC052.Contains("A")) radCheckC052A.Checked = true;
                if (answerC052.Contains("B")) radCheckC052B.Checked = true;
                if (answerC052.Contains("C")) radCheckC052C.Checked = true;
                if (answerC052.Contains("D")) radCheckC052D.Checked = true;
            }
        }

        private void txtC051_KeyPress(object sender, KeyPressEventArgs e)
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

        private void radCheckC05A_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlC051.Visible = false;
            this.pnlC052.Visible = false;
        }
    }
}
