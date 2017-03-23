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
    public partial class QuestionW3 : BaseForm
    {
        public QuestionW3()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            string questionResultA = radCheckW10A.Checked ? "A" : radCheckW10B.Checked?"B":"";
            M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W10";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiRuXianAi);



                string questionResultB = radCheckW11A.Checked ? "A" : radCheckW11B.Checked?"B":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W11";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiRuXianAi);

                string questionResultC = radCheckW12A.Checked ? "A" : radCheckW12B.Checked?"B":"";
                M_QuestionnaireResultDetail questionC = new M_QuestionnaireResultDetail();
                questionC.QuestionCode = Public.QuestionnaireCode.ZaoAiRuXianAi + ".W12";
                questionC.QuestionType = 1; //单选
                questionC.QuestionResult = questionResultC;
                ClientInfo.AddQuestionToQuestionnaire(questionC, QuestionnaireCode.ZaoAiRuXianAi);

            QuestionW4 questionW4 = new QuestionW4();
            questionW4.TopMost = false;
            questionW4.ShowDialog();
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
            var  questionW2 = new QuestionW2();
            questionW2.TopMost = false;
            questionW2.ShowDialog();
            this.Close();
        }

        private void QuestionW3_Load(object sender, EventArgs e)
        {
            string answerW10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W10");
            if (answerW10.Contains("A")) radCheckW10A.Checked = true;
            if (answerW10.Contains("B")) radCheckW10B.Checked = true;

            string answerW11 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W11");
            if (answerW11.Contains("A")) radCheckW11A.Checked = true;
            if (answerW11.Contains("B")) radCheckW11B.Checked = true;

            string answerW12= ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiRuXianAi, QuestionnaireCode.ZaoAiRuXianAi + ".W12");
            if (answerW12.Contains("A")) radCheckW12A.Checked = true;
            if (answerW12.Contains("B")) radCheckW12B.Checked = true;
        }
    }
}
