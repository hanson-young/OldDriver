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
    public partial class QuestionW2 : XYS.Remp.Screening.BaseForm
    {
        public QuestionW2()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlW08.Visible = true;
            button1.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlW08.Visible = false;
            button1.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResult = radCheckW08A.Checked ? "A" : radCheckW08B.Checked?"B":"";
            M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W08";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiRuXianAi);
                if (radCheckW08A.Checked)
                {
                    string questionResultA = radCheckW081A.Checked ? "A" : radCheckW081B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultA))
                    {
                        MessageBox.Show("请选择是否您的二级内血缘亲属");
                        return;
                    }
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W08.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiRuXianAi);

                    string questionResultB = radCheckW082A.Checked ? "A" : radCheckW082B.Checked?"B":"";
                    if (string.IsNullOrEmpty(questionResultB))
                    {
                        MessageBox.Show("请选择是否您的一级内血缘亲属");
                        return;
                    }
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W08.2";
                    questionB.QuestionType = 1; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiRuXianAi);
                }

            
            QuestionW3 questionW3 = new QuestionW3();
            questionW3.TopMost = false;
            questionW3.ShowDialog();
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
            QuestionW1 questionW1 = new QuestionW1();
            questionW1.TopMost = false;
            questionW1.ShowDialog();
            this.Close();
        }

        private void QuestionW2_Load(object sender, EventArgs e)
        {
               string answerW08 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W08");
            if (answerW08.Contains("A"))
            {
                this.pnlW08.Visible = true;
                radCheckW08A.Checked = true;
                    string answerW081 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W08.1");
                   string answerW082 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W08.2");
                if (answerW081.Contains("A")) radCheckW081A.Checked = true;
                if (answerW081.Contains("B")) radCheckW081B.Checked = true;

                if (answerW082.Contains("A")) radCheckW082A.Checked = true;
                if (answerW082.Contains("B")) radCheckW082B.Checked = true;
            }
            if (answerW08.Contains("B")) radCheckW08B.Checked = true;
        }

        private void radCheckW081A_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
