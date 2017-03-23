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
    public partial class QuestionW4 :BaseForm
    {
        public QuestionW4()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
               string questionResultA = radCheckW13A.Checked ? "A" : radCheckW13B.Checked?"B":"";
               M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W13";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiRuXianAi);

                string questionResultB = radCheckW14A.Checked ? "A" : radCheckW14B.Checked?"B":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W14";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiRuXianAi);

            RuxianResult ruxianResult = new RuxianResult();
            ruxianResult.TopMost = false;
            ruxianResult.ShowDialog();
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
            QuestionW3 questionW3 = new QuestionW3();
            questionW3.TopMost = false;
            questionW3.ShowDialog();
            this.Close();
        }

        private void QuestionW4_Load(object sender, EventArgs e)
        {
            string answerW13 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W13");
            if (answerW13.Contains("A")) radCheckW13A.Checked = true;
            if (answerW13.Contains("B")) radCheckW13B.Checked = true;

            string answerW14 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W14");
            if (answerW14.Contains("A")) radCheckW14A.Checked = true;
            if (answerW14.Contains("B")) radCheckW14B.Checked = true;
        }
    }
}
