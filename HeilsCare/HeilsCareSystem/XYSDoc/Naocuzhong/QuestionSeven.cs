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
    public partial class QuestionSeven : BaseForm
    {
        public QuestionSeven()
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
            AddResult(question1, QuestionnaireCode.NaoCuZhong + ".10", 1);

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            if (rd2A.Checked)
                question2.QuestionResult = "A,";
            if (rd2B.Checked)
                question2.QuestionResult = "B,";
            if (rd2C.Checked)
                question2.QuestionResult = "C,";
            AddResult(question2, QuestionnaireCode.NaoCuZhong + ".10.1", 1);

            ResultFrm result = new ResultFrm();
            result.TopMost = false;
            result.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FirstFrm frmMain = new FirstFrm();
            frmMain.TopMost = false;
            frmMain.ShowDialog();
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
            QuestionSix frmBefore = new QuestionSix();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }

        private void QuestionSeven_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".10");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".10.1");

            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;

            if (answer2.Contains("A")) rd2A.Checked = true;
            if (answer2.Contains("B")) rd2B.Checked = true;
            if (answer2.Contains("C")) rd2C.Checked = true;
        }

        private void rd1A_CheckedChanged(object sender, EventArgs e)
        {
            if (rd1A.Checked)
            {
                pYes.Visible = true;
            }
            else
            {
                pYes.Visible = false;
            }
        }
    }
}
