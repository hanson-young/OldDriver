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
    public partial class QuestionSeven : BaseForm
    {
        public QuestionSeven()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            if (rdA.Checked) question1.QuestionResult = "A,";
            if (rdB.Checked) question1.QuestionResult = "B,";
            //打分
            question1.QuestionScore = !string.IsNullOrEmpty(question1.QuestionResult) ? (question1.QuestionResult.Contains("A") ? 10 : 0) : 0;

            AddResult(question1, QuestionnaireCode.KangFuJiZhu + ".4");

            Result frmNext = new Result();
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

        private void QuestionSeven_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".4");

            if (answer1.Contains("A")) rdA.Checked = true;
            if (answer1.Contains("B")) rdB.Checked = true;
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionSix frmBefore = new QuestionSix();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
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
    }
}
