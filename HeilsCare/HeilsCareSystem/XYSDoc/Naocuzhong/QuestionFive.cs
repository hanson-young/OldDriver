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
    public partial class QuestionFive : BaseForm
    {
        public QuestionFive()
        {
            InitializeComponent();
        }
        private void AddResult(M_QuestionnaireResultDetail result, string questionCode, int questionType)
        {
            result.QuestionCode = questionCode;
            result.QuestionType = questionType;
            ClientInfo.AddQuestionToQuestionnaire(result, QuestionnaireCode.NaoCuZhong);

        }

        private void CaculateBMI()
        {
            float fBmi = 0;
            int iHight = 0;
            int iWeight = 0;

            if (int.TryParse(txt61.Text.Trim(), out iHight) && int.TryParse(txt62.Text.Trim(), out iWeight))
            {
                if (iHight > 0)
                    fBmi =((float)iWeight / (float)iHight /(float)iHight * 10000);
                txtBMI.Text = fBmi.ToString();
            }
        }

        private void CaculateYTB()
        {
            float fYTB = 0;
            int iYao = 0;
            int iTun = 0;

            if (int.TryParse(txt63.Text.Trim(), out iYao) && int.TryParse(txt64.Text.Trim(), out iTun))
            {
                if (iTun > 0)
                    fYTB = (float)iYao/ (float)iTun;
                txtYTB.Text = fYTB.ToString();
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
            if (rd1A.Checked)
                question1.QuestionResult = "A";
            if (rd1B.Checked)
                question1.QuestionResult = "B";
            AddResult(question1, QuestionnaireCode.NaoCuZhong + ".5", 1);

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            if (rd2A.Checked)
                question2.QuestionResult = "A";
            if (rd2B.Checked)
                question2.QuestionResult = "B";
            AddResult(question2, QuestionnaireCode.NaoCuZhong + ".6", 1);

            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            question3.QuestionResult = txt61.Text.Trim();
            AddResult(question3, QuestionnaireCode.NaoCuZhong + ".6.1", 3);

            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            question4.QuestionResult = txt62.Text.Trim();
            AddResult(question4, QuestionnaireCode.NaoCuZhong + ".6.2", 3);

            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();
            question5.QuestionResult = txt63.Text.Trim();
            AddResult(question5, QuestionnaireCode.NaoCuZhong + ".6.3", 3);

            M_QuestionnaireResultDetail question51 = new M_QuestionnaireResultDetail();
            question51.QuestionResult = txtBMI.Text.Trim();
            AddResult(question51, QuestionnaireCode.NaoCuZhong + ".6.3.1", 3);


            M_QuestionnaireResultDetail question6 = new M_QuestionnaireResultDetail();
            question6.QuestionResult = txt64.Text.Trim();
            AddResult(question6, QuestionnaireCode.NaoCuZhong + ".6.4", 3);

            M_QuestionnaireResultDetail question61 = new M_QuestionnaireResultDetail();
            question61.QuestionResult = txtYTB.Text.Trim();
            AddResult(question61, QuestionnaireCode.NaoCuZhong + ".6.4.1", 3);


            M_QuestionnaireResultDetail question7 = new M_QuestionnaireResultDetail();
            if (rd3A.Checked)
                question7.QuestionResult = "A";
            if (rd3B.Checked)
                question7.QuestionResult = "B";
            AddResult(question7, QuestionnaireCode.NaoCuZhong + ".7", 1);

            QuestionSix frmNext = new QuestionSix();
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
            QuestionFour frmBefore = new QuestionFour();
            frmBefore.TopMost = false;
            frmBefore.ShowDialog();
            this.Close();
        }

        private void QuestionFive_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".5");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6");
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6.1");
            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6.2");
            string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6.3");
            string answer51 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6.3.1");
            string answer6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6.4");
            string answer61 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".6.4.1");
            string answer7 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".7");

            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;

            if (answer2.Contains("A")) rd2A.Checked = true;
            if (answer2.Contains("B")) rd2B.Checked = true;

            txt61.Text = answer3;
            txt62.Text = answer4;
            txt63.Text = answer5;
            txt64.Text = answer6;
            txtBMI.Text = answer51;
            txtYTB.Text = answer61;

            if (answer7.Contains("A")) rd3A.Checked = true;
            if (answer7.Contains("B")) rd3B.Checked = true;

        }

        private void txt62_KeyUp(object sender, KeyEventArgs e)
        {
            this.CaculateBMI();
        }

        private void txt64_KeyUp(object sender, KeyEventArgs e)
        {
            CaculateYTB();
        }

        //private void txt62_Leave(object sender, EventArgs e)
        //{
        //    this.CaculateBMI();
        //}

        //private void txt64_Leave(object sender, EventArgs e)
        //{
        //    CaculateYTB();
        //}
    }
}
