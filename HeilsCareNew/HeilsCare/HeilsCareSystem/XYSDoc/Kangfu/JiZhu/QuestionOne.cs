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
    public partial class QuestionOne : BaseForm
    {
        public QuestionOne()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string strResult = "";

            if (rdA.Checked) strResult += "A,";

            if (rdB.Checked) strResult += "B,";

            M_QuestionnaireResultDetail question = new M_QuestionnaireResultDetail();

            question.QuestionCode = Public.QuestionnaireCode.KangFuJiZhu + ".1";
            question.QuestionType = 1;
            question.QuestionResult = strResult;
            //打分
            question.QuestionScore = strResult.Contains("A") ? 10 : 0;

            ClientInfo.AddQuestionToQuestionnaire(question, QuestionnaireCode.KangFuJiZhu);
            QuestionTwo frmNext = new QuestionTwo();
            //frmNext.ShowDialog();
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

        private void QuestionOne_Load(object sender, EventArgs e)
        {
            string answer = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuJiZhu, QuestionnaireCode.KangFuJiZhu + ".1");

            if (answer.Contains("A")) rdA.Checked = true;
            if (answer.Contains("B")) rdB.Checked = true;
        }
    }
}
