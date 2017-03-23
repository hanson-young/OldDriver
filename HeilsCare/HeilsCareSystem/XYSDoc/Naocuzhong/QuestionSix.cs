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

namespace XYS.Remp.Screening.Naocuzhong
{
    public partial class QuestionSix : BaseForm
    {
        public QuestionSix()
        {
            InitializeComponent();
        }

        private void AddResult(M_QuestionnaireResultDetail result, string questionCode, int questionType)
        {
            result.QuestionCode = questionCode;
            result.QuestionType = questionType;
            ClientInfo.AddQuestionToQuestionnaire(result, QuestionnaireCode.NaoCuZhong);

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
            if (rd1A.Checked)
                question1.QuestionResult = "A,";
            if (rd1B.Checked)
                question1.QuestionResult = "B,";
            AddResult(question1, QuestionnaireCode.NaoCuZhong + ".8", 1);

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            if (rd2A.Checked)
                question2.QuestionResult = "A,";
            if (rd2B.Checked)
                question2.QuestionResult = "B,";
            AddResult(question2, QuestionnaireCode.NaoCuZhong + ".9", 1);

            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            if (chkA.Checked)
                question3.QuestionResult += "A,";
            if (chkB.Checked)
                question3.QuestionResult += "B,";
            AddResult(question3, QuestionnaireCode.NaoCuZhong + ".9.1", 2);

            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            if (rd3A.Checked)
                question4.QuestionResult = "A,";
            if (rd3B.Checked)
                question4.QuestionResult = "B,";
            if (rd3C.Checked)
                question4.QuestionResult = "C,";
            AddResult(question4, QuestionnaireCode.NaoCuZhong + ".9.2", 1);

            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();
            if (rd4A.Checked)
                question5.QuestionResult = "A,";
            if (rd4B.Checked)
                question5.QuestionResult = "B,";
            if (rd4C.Checked)
                question5.QuestionResult = "C,";
            AddResult(question5, QuestionnaireCode.NaoCuZhong + ".9.3", 1);


            QuestionSeven frmNext = new QuestionSeven();
            frmNext.TopMost = false;
            frmNext.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FirstFrm frmMain = new FirstFrm();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new FirstFrm(), this);
            quitComfirmFrm.ShowDialog();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            QuestionFive frmBefore = new QuestionFive();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }

        private void QuestionSix_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".8");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".9");
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".9.1");
            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".9.2");
            string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".9.3");

            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;

            if (answer2.Contains("A")) rd2A.Checked = true;
            if (answer2.Contains("B")) rd2B.Checked = true;

            if (answer3.Contains("A")) chkA.Checked = true;
            if (answer3.Contains("B")) chkB.Checked = true;

            if (answer4.Contains("A")) rd3A.Checked = true;
            if (answer4.Contains("B")) rd3B.Checked = true;
            if (answer4.Contains("C")) rd3C.Checked = true;

            if (answer5.Contains("A")) rd4A.Checked = true;
            if (answer5.Contains("B")) rd4B.Checked = true;
            if (answer5.Contains("C")) rd4C.Checked = true;
        }

        private void rd2A_CheckedChanged(object sender, EventArgs e)
        {
            if (rd2A.Checked)
                pYes.Visible = true;
            else
                pYes.Visible = false;
        }
    }
}
