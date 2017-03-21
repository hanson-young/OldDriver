using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Feiai
{
    public partial class QuestionE1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionE1()
        {
            InitializeComponent();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlC05.Visible = true;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlC05.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

                string questionResultE01 = radCheckE01A.Checked ? "A" : radCheckE01B.Checked?"B":"";
                M_QuestionnaireResultDetail questionE01 = new M_QuestionnaireResultDetail();
                questionE01.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E01";
                questionE01.QuestionType = 1; //单选
                questionE01.QuestionResult = questionResultE01;
                ClientInfo.AddQuestionToQuestionnaire(questionE01, QuestionnaireCode.ZaoAiFeiAi);
                if (radCheckE01A.Checked)
                {
                    if (string.IsNullOrEmpty(this.txtE011.Text))
                    {
                        MessageBox.Show("请输入您有哪种癌症病史!");
                        this.label10.ForeColor=Color.Red;
                        return;
                    }
                    string questionResultA = this.txtE011.Text;
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E01.1";
                    questionA.QuestionType = 3; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiFeiAi);
                }

                string questionResult = radCheckE05A.Checked ? "A" : radCheckE05B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E05";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiFeiAi);
                if (radCheckE05A.Checked)
                {
                    //E05.1
                    string questionResultA = radCheckE051A.Checked ? "A" : radCheckE051B.Checked ? "B" : "";
                    M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E05.1";
                    questionA.QuestionType = 1; //单选
                    questionA.QuestionResult = questionResultA;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiFeiAi);

                    //E05.2
                    string questionResultB = radCheckE052A.Checked ? "A" : radCheckE052B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                    questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E05.2";
                    questionB.QuestionType = 1; //单选
                    questionB.QuestionResult = questionResultB;
                    ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiFeiAi);

                    //E05.3
                    string questionResultC = radCheckE053A.Checked ? "A" : radCheckE053B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                    questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E05.3";
                    questionC.QuestionType = 1; //单选
                    questionC.QuestionResult = questionResultC;
                    ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiFeiAi);

                    //E05.4
                    string questionResultD = radCheckE054A.Checked ? "A" : radCheckE054B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionD = new M_QuestionnaireResultDetail();
                    questionD.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E05.4";
                    questionD.QuestionType = 1; //单选
                    questionD.QuestionResult = questionResultD;
                    ClientInfo.AddQuestionToQuestionnaire(questionD, QuestionnaireCode.ZaoAiFeiAi);

                    //E05.5
                    string questionResultE = radCheckE055A.Checked ? "A" : radCheckE055B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionE = new M_QuestionnaireResultDetail();
                    questionE.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E05.5";
                    questionE.QuestionType = 1; //单选
                    questionE.QuestionResult = questionResultE;
                    ClientInfo.AddQuestionToQuestionnaire(questionE, QuestionnaireCode.ZaoAiFeiAi);

                    //E05.6
                    string questionResultF = this.txtE056.Text;
                    M_QuestionnaireResultDetail questionF = new M_QuestionnaireResultDetail();
                    questionF.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E05.6";
                    questionF.QuestionType = 3; //单选
                    questionF.QuestionResult = questionResultF;
                    ClientInfo.AddQuestionToQuestionnaire(questionF, QuestionnaireCode.ZaoAiFeiAi);

                    //E09.7
                    string questionResultG = radCheckE097A.Checked ? "A" : radCheckE097B.Checked?"B":"";
                    M_QuestionnaireResultDetail questionG = new M_QuestionnaireResultDetail();
                    questionG.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".E09.7";
                    questionG.QuestionType = 1; //单选
                    questionG.QuestionResult = questionResultG;
                    ClientInfo.AddQuestionToQuestionnaire(questionG, QuestionnaireCode.ZaoAiFeiAi);

                }


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
            QuestionC3 questionC3 = new QuestionC3();
            questionC3.TopMost = false;
            questionC3.ShowDialog();
            this.Close();
        }

        private void QuestionE1_Load(object sender, EventArgs e)
        {
            string answerE01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E01");
            if (answerE01.Contains("A"))
            {
                radCheckE01A.Checked = true;
                pnlE011.Visible = true;
                string answerE011 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E01.1");
                this.txtE011.Text = answerE011;
            }
            if (answerE01.Contains("B")) radCheckE01B.Checked = true;

            string answerE05 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E05");
            if (answerE05.Contains("A"))
            {
                radCheckE05A.Checked = true;
                this.pnlC05.Visible = true;
                string answerE051 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E05.1");
                string answerE052 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E05.2");
                string answerE053 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E05.3");
                string answerE054 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E05.4");
                string answerE055 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E05.5");
                if (answerE051.Contains("A")) radCheckE051A.Checked = true;
                if (answerE051.Contains("B")) radCheckE051B.Checked = true;

                if (answerE052.Contains("A")) radCheckE052A.Checked = true;
                if (answerE052.Contains("B")) radCheckE052B.Checked = true;

                if (answerE053.Contains("A")) radCheckE053A.Checked = true;
                if (answerE053.Contains("B")) radCheckE053B.Checked = true;

                if (answerE054.Contains("A")) radCheckE054A.Checked = true;
                if (answerE054.Contains("B")) radCheckE054B.Checked = true;

                if (answerE055.Contains("A")) radCheckE055A.Checked = true;
                if (answerE055.Contains("B")) radCheckE055B.Checked = true;

                string answerE056 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E05.6");
                this.txtE056.Text = answerE056;

                string answerE097 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".E09.7");
                if (answerE097.Contains("A")) radCheckE097A.Checked = true;
                if (answerE097.Contains("B")) radCheckE097B.Checked = true;
            }
            if (answerE05.Contains("B"))
            {
                radCheckE05B.Checked = true;
            }
        }

        private void radCheckE01A_CheckedChanged(object sender, EventArgs e)
        {
            pnlE011.Visible = true;
            button1.Enabled = true;
        }

        private void radCheckE01B_CheckedChanged(object sender, EventArgs e)
        {
            pnlE011.Visible = false;
            button1.Enabled = true;
        }

        private void txtE011_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
