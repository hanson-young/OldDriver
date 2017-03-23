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
    public partial class QuestionFour : BaseForm
    {
        public QuestionFour()
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
                question1.QuestionResult = "A";
            if (rd1B.Checked)
                question1.QuestionResult = "B";
            if (rd1C.Checked)
                question1.QuestionResult = "C";

            AddResult(question1, QuestionnaireCode.NaoCuZhong + ".4", 1);

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();

            if (chkA.Checked) question2.QuestionResult += "A,";
            if (chkB.Checked) question2.QuestionResult += "B,";
            if (chkC.Checked) question2.QuestionResult += "C,";
            if (chkD.Checked) question2.QuestionResult += "D,";
            if (chkE.Checked) question2.QuestionResult += "E,";
            if (chkF.Checked) question2.QuestionResult += "F,";
            if (chkG.Checked) question2.QuestionResult += "G,";

            AddResult(question2, QuestionnaireCode.NaoCuZhong + ".4.1", 2);


            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            if (rd2A.Checked)
                question3.QuestionResult = "A";
            if (rd2B.Checked)
                question3.QuestionResult = "B";
            AddResult(question3, QuestionnaireCode.NaoCuZhong + ".4.2", 1);

            QuestionFive frmNext = new QuestionFive();
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
            QuestionThree frmBefore = new QuestionThree();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }

        private void QuestionFour_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".4");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".4.1");
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".4.2");
            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".4.3");


            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;
            if (answer1.Contains("C")) rd1C.Checked = true;

            if (answer2.Contains("A")) chkA.Checked = true;
            if (answer2.Contains("B")) chkB.Checked = true;
            if (answer2.Contains("C")) chkC.Checked = true;
            if (answer2.Contains("D")) chkD.Checked = true;
            if (answer2.Contains("E")) chkE.Checked = true;
            if (answer2.Contains("F")) chkF.Checked = true;
            if (answer2.Contains("G")) chkG.Checked = true;

            if (answer3.Contains("A")) rd2A.Checked = true;
            if (answer3.Contains("B")) rd2B.Checked = true;

        }

        private void rd1A_CheckedChanged(object sender, EventArgs e)
        {
            if (rd1A.Checked)
                pYes.Visible = true;
            else
                pYes.Visible = false;
        }
    }
}
