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

namespace XYS.Remp.Screening.Kangfu.LunYi
{
    public partial class QuestionThree : BaseForm
    {
        public QuestionThree()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            string strResult = "";

            if (rdA.Checked) strResult = "A,";

            if (rdB.Checked) strResult = "B,";

            question1.QuestionResult = strResult;
            question1.QuestionCode = QuestionnaireCode.KangFuLunYi + ".3";
            question1.QuestionType = 1;
            //打分
            question1.QuestionScore = strResult.Contains("B") ? 10 : 0;

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.KangFuLunYi);

            QuestionFour frmNext = new QuestionFour();
            frmNext.TopMost = false;
            frmNext.ShowDialog();

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

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionTwo frmBefore = new QuestionTwo();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }

        private void QuestionThree_Load(object sender, EventArgs e)
        {
            string answer = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuLunYi, QuestionnaireCode.KangFuLunYi + ".3");

            if (answer.Contains("A")) rdA.Checked = true;
            if (answer.Contains("B")) rdB.Checked = true;

        }
    }
}
