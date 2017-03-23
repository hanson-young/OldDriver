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
    public partial class QuestionC1 : XYS.Remp.Screening.BaseForm
    {
        public QuestionC1()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
                string questionResultA = this.radCheckC01A.Checked ? "A" : radCheckC01B.Checked?"B":"";
                M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".C01";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiFeiAi);

                string questionResultB = this.radCheckC02A.Checked
                    ? "A"
                    : radCheckC02B.Checked ? "B" : radCheckC02C.Checked ? "C" : radCheckC02D.Checked?"D":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".C02";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiFeiAi);

            QuestionC2 questionC2 = new QuestionC2();
            questionC2.TopMost = false;
            questionC2.ShowDialog();
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
            //btnBack_Click(this, e);'
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningZaoaiSelect(), this);
            quitComfirmFrm.ShowDialog();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionA1 questionA1 = new QuestionA1();
            questionA1.TopMost = false;
            questionA1.ShowDialog();
            this.Close();
        }

        private void QuestionC1_Load(object sender, EventArgs e)
        {
            string answerC01 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C01");
            if (answerC01.Contains("A")) radCheckC01A.Checked = true;
            if (answerC01.Contains("B")) radCheckC01B.Checked = true;

            string answerC02 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".C02");
            if (answerC02.Contains("A")) radCheckC02A.Checked = true;
            if (answerC02.Contains("B")) radCheckC02B.Checked = true;
            if (answerC02.Contains("C")) radCheckC02C.Checked = true;
            if (answerC02.Contains("D")) radCheckC02D.Checked = true;
        }
    }
}
