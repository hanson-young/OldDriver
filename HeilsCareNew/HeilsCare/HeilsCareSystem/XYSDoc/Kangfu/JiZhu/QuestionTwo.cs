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
    public partial class QuestionTwo : BaseForm
    {
        public QuestionTwo()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {


            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            if (rd1A.Checked) question1.QuestionResult = "A,";
            if (rd1B.Checked) question1.QuestionResult = "B,";
            //打分
            question1.QuestionScore =!string.IsNullOrEmpty(question1.QuestionResult) ?(question1.QuestionResult.Contains("A") ? 10 : 0):0;

            AddResult(question1, QuestionnaireCode.KangFuJiZhu + ".2.A.1");


            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();

            if (rd2A.Checked) question2.QuestionResult = "A,";
            if (rd2B.Checked) question2.QuestionResult = "B,";
            //打分
            question2.QuestionScore = !string.IsNullOrEmpty(question2.QuestionResult) ? (question2.QuestionResult.Contains("A") ? 10 : 0) : 0;

            AddResult(question2, QuestionnaireCode.KangFuJiZhu + ".2.A.2");

            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();

            if (rd3A.Checked) question3.QuestionResult = "A,";
            if (rd3B.Checked) question3.QuestionResult = "B,";
            //打分
            question3.QuestionScore = !string.IsNullOrEmpty(question3.QuestionResult) ? (question3.QuestionResult.Contains("A") ? 10 : 0) : 0;
            
            AddResult(question3, QuestionnaireCode.KangFuJiZhu + ".2.A.3");

            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();

            if (rd4A.Checked) question4.QuestionResult = "A,";
            if (rd4B.Checked) question4.QuestionResult = "B,";
            //打分
            question4.QuestionScore = !string.IsNullOrEmpty(question4.QuestionResult) ? (question4.QuestionResult.Contains("A") ? 10 : 0) : 0;

            AddResult(question4, QuestionnaireCode.KangFuJiZhu + ".2.A.4");

            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();

            if (rd5A.Checked) question5.QuestionResult = "A,";
            if (rd5B.Checked) question5.QuestionResult = "B,";
            //打分
            question5.QuestionScore = !string.IsNullOrEmpty(question5.QuestionResult) ? (question5.QuestionResult.Contains("A") ? 10 : 0) : 0;

            AddResult(question5, QuestionnaireCode.KangFuJiZhu + ".2.A.5");


            QuestionThree frmNext = new QuestionThree();
            frmNext.TopMost = false;
            //frmNext.Show();
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

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionOne frmBefore = new QuestionOne();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }

        private void QuestionTwo_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".2.A.1");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".2.A.2");
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".2.A.3");
            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".2.A.4");
            string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".2.A.5");

            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;

            if (answer2.Contains("A")) rd2A.Checked = true;
            if (answer2.Contains("B")) rd2B.Checked = true;

            if (answer3.Contains("A")) rd3A.Checked = true;
            if (answer3.Contains("B")) rd3B.Checked = true;

            if (answer4.Contains("A")) rd4A.Checked = true;
            if (answer4.Contains("B")) rd4B.Checked = true;

            if (answer5.Contains("A")) rd5A.Checked = true;
            if (answer5.Contains("B")) rd5B.Checked = true;

        }
    }
}
