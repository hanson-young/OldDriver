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
    public partial class QuestionB2 :BaseForm
    {
        public QuestionB2()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
                string questionResultA = this.radCheckB19A.Checked ? "A" : radCheckB19B.Checked ? "B" :radCheckB19C.Checked?"C":"";
                M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".B01.9";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);

                string questionResultB = this.radCheckB110A.Checked ? "A" : radCheckB110B.Checked ? "B" :radCheckB110C.Checked?"C":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".B01.10";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiWeiAi);


            QuestionC1 questionC1 = new QuestionC1();
            questionC1.TopMost = false;
            questionC1.ShowDialog();
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
            QuestionB1 questionB1 = new QuestionB1();
            questionB1.TopMost = false;
            questionB1.ShowDialog();
            this.Close();
        }

        private void QuestionB2_Load(object sender, EventArgs e)
        {
            string answerB019 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".B01.9");
            string answerB0110 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".B01.10");

            if (answerB019.Contains("A")) radCheckB19A.Checked = true;
            if (answerB019.Contains("B")) radCheckB19B.Checked = true;
            if (answerB019.Contains("C")) radCheckB19C.Checked = true;

            if (answerB0110.Contains("A")) radCheckB110A.Checked = true;
            if (answerB0110.Contains("B")) radCheckB110B.Checked = true;
            if (answerB0110.Contains("C")) radCheckB110C.Checked = true;
        }
    }
}
