using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Zaoai.Weiai
{
    public partial class QuestionA1 :BaseForm
    {
        public QuestionA1()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlQuestionOne.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlQuestionOne.Visible = false;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {

                string questionResultA = "";
                if (radCheckA03A.Checked) questionResultA = "A";
                if (radCheckA03B.Checked) questionResultA = "B";
                M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".A03";
                questionA.QuestionType = 1;//单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiWeiAi);



                string questionResultB = this.radCheckA09A.Checked ? "A" : radCheckA09B.Checked?"B":"";
                M_QuestionnaireResultDetail questionB = new M_QuestionnaireResultDetail();
                questionB.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".A09";
                questionB.QuestionType = 1; //单选
                questionB.QuestionResult = questionResultB;
                ClientInfo.AddQuestionToQuestionnaire(questionB, QuestionnaireCode.ZaoAiWeiAi);


            if (radCheckA09A.Checked)
            {
                string strResult = "";

                if (chk1.Checked) strResult += "A,";
                if (chk2.Checked) strResult += "B,";
                if (chk3.Checked) strResult += "C,";
                if (chk4.Checked) strResult += "D,";
                if (chk5.Checked) strResult += "E,";
                if (chk6.Checked) strResult += "F,";
                if (chk7.Checked) strResult += "G,";
                if (chk8.Checked) strResult += "H";
                var question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiWeiAi + ".A09.1";
                question.QuestionType = 2; //单选
                question.QuestionResult = strResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiWeiAi);
            }

            var questionB1=new QuestionB1();
            questionB1.TopMost = false;
            questionB1.ShowDialog();
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

        private void QuestionA1_Load(object sender, EventArgs e)
        {
              M_QuestionnaireUserDetail questionnaire = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiWeiAi);

            if (questionnaire == null) return;

            IList<M_QuestionnaireResultDetail> questions = questionnaire.Questions;
            string answerA03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiWeiAi, QuestionnaireCode.ZaoAiWeiAi + ".A03");
            if (answerA03.Contains("A")) radCheckA03A.Checked =true;
            if (answerA03.Contains("B")) radCheckA03B.Checked = true;

            var a09 = questions.Where(c => c.QuestionCode.Contains("A09")).ToList();
            if (a09.Count > 0)
            {
                foreach (var item in a09)
                {
                    if (item.QuestionCode == QuestionnaireCode.ZaoAiWeiAi + ".A09")
                    {
                        if (item.QuestionResult.Contains("A")) radCheckA09A.Checked = true;
                        if (item.QuestionResult.Contains("B")) radCheckA09B.Checked = true;
                        continue;
                    }

                    if (item.QuestionCode == QuestionnaireCode.ZaoAiWeiAi + ".A09.1")
                    {
                        if (item.QuestionResult.Contains("A")) chk1.Checked = true;
                        if (item.QuestionResult.Contains("B")) chk2.Checked = true;

                        if (item.QuestionResult.Contains("C")) chk3.Checked = true;
                        if (item.QuestionResult.Contains("D")) chk4.Checked = true;

                        if (item.QuestionResult.Contains("E")) chk5.Checked = true;
                        if (item.QuestionResult.Contains("F")) chk6.Checked = true;

                        if (item.QuestionResult.Contains("G")) chk7.Checked = true;
                        if (item.QuestionResult.Contains("H")) chk8.Checked = true;
       
                    }
                }
            }

        }
    }
}
