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

namespace XYS.Remp.Screening.Other.Paruria.IPSS
{
    public partial class IpssOne : BaseForm
    {
        public IpssOne()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreenOtherSelect screenOtherSelect = new ScreenOtherSelect();
            screenOtherSelect.TopMost = false;
            screenOtherSelect.Show();
            Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            Other.Paruria.Paruria paruria = new Other.Paruria.Paruria();
            paruria.TopMost = false;
            paruria.Show();
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //第3题
            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            string strResult3 = "";

            if (rbQ3A.Checked) { strResult3 = "A,"; }
            if (rbQ3B.Checked) { strResult3 = "B,"; }

            question3.QuestionResult = strResult3;
            question3.QuestionCode = QuestionnaireCode.Ipss + ".3";
            question3.PQuestionCode = QuestionnaireCode.Ipss + ".3";
            question3.QuestionType = 1;
            question3.QuestionScore = 0;
            question3.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question3, QuestionnaireCode.Ipss);

            //第四题
            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            string strResult4 = "";

            if (rbQ4A.Checked) { strResult4 = "A,"; }
            if (rbQ4B.Checked) { strResult4 = "B,"; }
            if (rbQ4C.Checked) { strResult4 = "C,"; }
            if (rbQ4D.Checked) { strResult4 = "D,"; }

            question4.QuestionResult = strResult4;
            question4.QuestionCode = QuestionnaireCode.Ipss + ".4";
            question4.PQuestionCode = QuestionnaireCode.Ipss + ".4";
            question4.QuestionType = 1;
            question4.QuestionScore = 0;
            question4.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question4, QuestionnaireCode.Ipss);

            //下一页
            IpssTwo ipssTwo = new IpssTwo();
            ipssTwo.TopMost = false;
            ipssTwo.Show();
            Close();
        }

        private void IpssOne_Load(object sender, EventArgs e)
        {
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".3");
            if (answer3.Contains("A")) { rbQ3A.Checked = true; }
            if (answer3.Contains("B")) { rbQ3B.Checked = true; }

            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".4");
            if (answer4.Contains("A")) { rbQ4A.Checked = true; }
            if (answer4.Contains("B")) { rbQ4B.Checked = true; }
            if (answer4.Contains("C")) { rbQ4C.Checked = true; }
            if (answer4.Contains("D")) { rbQ4D.Checked = true; }
        }
    }
}
