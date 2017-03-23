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

        private void btnNext_Click(object sender, EventArgs e)
        {
            string questionResultE01 = radCheckE01A.Checked ? "A" : radCheckE01B.Checked?"B":"";
            M_QuestionnaireResultDetail questionE01 = new M_QuestionnaireResultDetail();
                questionE01.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E01";
                questionE01.QuestionType = 1; //单选
                questionE01.QuestionResult = questionResultE01;
                ClientInfo.AddQuestionToQuestionnaire(questionE01, QuestionnaireCode.ZaoAiDaChangAi);

                if (radCheckE01A.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtE011.Text))
                    {
                        MessageBox.Show("请输入您的癌症病史!");
                        this.label4.ForeColor=Color.Red;
                        return;
                    }
                    string questionResultA = this.txtE011.Text;
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E01.1";
                    questionA.QuestionType = 3; //填空
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiDaChangAi);
                }

                string questionResultB = radCheckE074A.Checked ? "A" : radCheckE074B.Checked?"B":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E07.4";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiDaChangAi);

                string questionResultC = radCheckE078A.Checked ? "A" : radCheckE078B.Checked?"B":"";
                M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E07.8";
                questionC.QuestionType = 1; //单选
                questionC.QuestionResult = questionResultC;
                ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiDaChangAi);

                string questionResultD = radCheckE079A.Checked ? "A" : radCheckE079B.Checked?"B":"";
                M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiDaChangAi + ".E07.9";
                questionD.QuestionType = 1; //单选
                questionD.QuestionResult = questionResultD;
                ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiDaChangAi);


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
            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E01");
            if (answerE01.Contains("A"))
            {
                radCheckE01A.Checked = true;
                this.pnlE01.Visible = true;
                string answerE11 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E01.1");
                this.txtE011.Text = answerE11;
            }
            if (answerE01.Contains("B")) radCheckE01B.Checked = true;

            string answerE74 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E07.4");
            string answerE78= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E07.8");
            string answerE79 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiDaChangAi, QuestionnaireCode.ZaoAiDaChangAi + ".E07.9");
            if (answerE74.Contains("A")) radCheckE074A.Checked = true;
            if (answerE74.Contains("B")) radCheckE074B.Checked = true;

            if (answerE78.Contains("A")) radCheckE078A.Checked = true;
            if (answerE78.Contains("B")) radCheckE078B.Checked = true;

            if (answerE79.Contains("A")) radCheckE079A.Checked = true;
            if (answerE79.Contains("B")) radCheckE079B.Checked = true;
        }

        private void txtE011_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.button1.Enabled = true;
        }
    }
}
