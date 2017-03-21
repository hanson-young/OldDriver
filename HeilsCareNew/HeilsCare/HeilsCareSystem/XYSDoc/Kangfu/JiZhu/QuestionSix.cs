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

namespace XYS.Remp.Screening.Kangfu.JiZhu
{
    public partial class QuestionSix : BaseForm
    {
        public QuestionSix()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            if (rd1A.Checked) question1.QuestionResult = "A,";
            if (rd1B.Checked) question1.QuestionResult = "B,";
            //打分
            question1.QuestionScore = !string.IsNullOrEmpty(question1.QuestionResult) ? (question1.QuestionResult.Contains("A") ? 10 : 0) : 0;

            AddResult(question1, QuestionnaireCode.KangFuJiZhu + ".3.C.1");


            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();

            if (rd2A.Checked) question2.QuestionResult = "A,";
            if (rd2B.Checked) question2.QuestionResult = "B,";
            //打分
            question2.QuestionScore = !string.IsNullOrEmpty(question2.QuestionResult) ? (question2.QuestionResult.Contains("A") ? 10 : 0) : 0;

            AddResult(question2, QuestionnaireCode.KangFuJiZhu + ".3.C.2");

            QuestionSeven frmNext = new QuestionSeven();
            frmNext.TopMost = false;
            frmNext.ShowDialog();

            this.Close();
        }

        private void AddResult(M_QuestionnaireResultDetail result, string questionCode)
        {
            result.QuestionCode = questionCode;
            result.QuestionType = 1;
            ClientInfo.AddQuestionToQuestionnaire(result, QuestionnaireCode.KangFuJiZhu);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmMain = new ScreeningSelect();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this);
            quitComfirmFrm.ShowDialog();
        }

        private void QuestionSix_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".3.C.1");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".3.C.2");

            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;

            if (answer2.Contains("A")) rd2A.Checked = true;
            if (answer2.Contains("B")) rd2B.Checked = true;
           
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionFive frmBefore = new QuestionFive();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }
    }
}
