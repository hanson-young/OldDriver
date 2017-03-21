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

namespace XYS.Remp.Screening.Zaoai.Feiai
{
    public partial class QuestionA1 :BaseForm
    {
        public QuestionA1()
        {
            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlA091.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.pnlA091.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

                string questionResultA = this.rabCheckA03A.Checked ? "A" : rabCheckA03B.Checked?"B":"";
                M_QuestionnaireResultDetail questionA = new M_QuestionnaireResultDetail();
                questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".A03";
                questionA.QuestionType = 1; //单选
                questionA.QuestionResult = questionResultA;
                ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiFeiAi);

                string questionResult = this.rabCheckA09A.Checked ? "A" : rabCheckA09B.Checked?"B":"";
                M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();
                question.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".A09";
                question.QuestionType = 1; //单选
                question.QuestionResult = questionResult;
                ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.ZaoAiFeiAi);
                if (rabCheckA09A.Checked)
                {
                    string strResult = "";

                    if (cbCheckA.Checked) strResult += "A,";
                    if (cbCheckB.Checked) strResult += "B,";
                    if (cbCheckC.Checked) strResult += "C,";
                    if (cbCheckD.Checked) strResult += "D,";
                    if (cbCheckE.Checked) strResult += "E,";
                    if (cbCheckF.Checked) strResult += "F,";
                    if (cbCheckG.Checked) strResult += "G,";
                    if (cbCheckH.Checked) strResult += "H";
                    var questionC = new M_QuestionnaireResultDetail();
                    questionA.QuestionCode = Public.QuestionnaireCode.ZaoAiFeiAi + ".A09.1";
                    questionA.QuestionType = 2; //多选
                    questionA.QuestionResult = strResult;
                    ClientInfo.AddQuestionToQuestionnaire(questionA, QuestionnaireCode.ZaoAiFeiAi);
                }

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

        private void QuestionA1_Load(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail questionnaire = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.ZaoAiFeiAi);

            if (questionnaire == null) return;

            IList<M_QuestionnaireResultDetail> questions = questionnaire.Questions;
            string answerA03 = ClientInfo.GetAnswerByCode(QuestionnaireCode.ZaoAiFeiAi, QuestionnaireCode.ZaoAiFeiAi + ".A03");
            if (answerA03.Contains("A")) rabCheckA03A.Checked = true;
            if (answerA03.Contains("B")) rabCheckA03B.Checked = true;

            var a09 = questions.Where(c => c.QuestionCode.Contains("A09")).ToList();
            if (a09.Count > 0)
            {
                foreach (var item in a09)
                {
                    if (item.QuestionCode == QuestionnaireCode.ZaoAiFeiAi + ".A09")
                    {
                        if (item.QuestionResult.Contains("A")) rabCheckA09A.Checked = true;
                        if (item.QuestionResult.Contains("B")) rabCheckA09B.Checked = true;
                        continue;
                    }

                    if (item.QuestionCode == QuestionnaireCode.ZaoAiFeiAi + ".A09.1")
                    {
                        if (item.QuestionResult.Contains("A")) cbCheckA.Checked = true;
                        if (item.QuestionResult.Contains("B")) cbCheckB.Checked = true;

                        if (item.QuestionResult.Contains("C")) cbCheckC.Checked = true;
                        if (item.QuestionResult.Contains("D")) cbCheckD.Checked = true;

                        if (item.QuestionResult.Contains("E")) cbCheckE.Checked = true;
                        if (item.QuestionResult.Contains("F")) cbCheckF.Checked = true;

                        if (item.QuestionResult.Contains("G")) cbCheckG.Checked = true;
                        if (item.QuestionResult.Contains("H")) cbCheckH.Checked = true;

                    }
                }
            }
        }
    }
}
