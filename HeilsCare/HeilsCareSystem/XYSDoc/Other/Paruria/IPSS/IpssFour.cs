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
    public partial class IpssFour : BaseForm
    {
        public IpssFour()
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
            IpssThree ipssThree = new IpssThree();
            ipssThree.TopMost = false;
            ipssThree.Show();
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //第九题
            M_QuestionnaireResultDetail question9 = new M_QuestionnaireResultDetail();
            string strResult9 = "";

            if (rbQ9A.Checked) { strResult9 = "A,"; }
            if (rbQ9B.Checked) { strResult9 = "B,"; }
            if (rbQ9C.Checked) { strResult9 = "C,"; }
            if (rbQ9D.Checked) { strResult9 = "D,"; }
            if (rbQ9E.Checked) { strResult9 = "E,"; }
            if (rbQ9F.Checked) { strResult9 = "F,"; }

            question9.QuestionResult = strResult9;
            question9.QuestionCode = QuestionnaireCode.Ipss + ".9";
            question9.PQuestionCode = QuestionnaireCode.Ipss + ".9";
            question9.QuestionType = 1;

            //打分
            if (strResult9.Contains("A")) { question9.QuestionScore = 0; }
            if (strResult9.Contains("B")) { question9.QuestionScore = 1; }
            if (strResult9.Contains("C")) { question9.QuestionScore = 2; }
            if (strResult9.Contains("D")) { question9.QuestionScore = 3; }
            if (strResult9.Contains("E")) { question9.QuestionScore = 4; }
            if (strResult9.Contains("F")) { question9.QuestionScore = 5; }

            question9.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question9, QuestionnaireCode.Ipss);

            //第十题
            M_QuestionnaireResultDetail question10 = new M_QuestionnaireResultDetail();
            string strResult10 = "";

            if (rbQ10A.Checked) { strResult10 = "A,"; }
            if (rbQ10B.Checked) { strResult10 = "B,"; }
            if (rbQ10C.Checked) { strResult10 = "C,"; }
            if (rbQ10D.Checked) { strResult10 = "D,"; }
            if (rbQ10E.Checked) { strResult10 = "E,"; }
            if (rbQ10F.Checked) { strResult10 = "F,"; }

            question10.QuestionResult = strResult10;
            question10.QuestionCode = QuestionnaireCode.Ipss + ".10";
            question10.PQuestionCode = QuestionnaireCode.Ipss + ".10";
            question10.QuestionType = 1;

            //打分
            if (strResult10.Contains("A")) { question10.QuestionScore = 0; }
            if (strResult10.Contains("B")) { question10.QuestionScore = 1; }
            if (strResult10.Contains("C")) { question10.QuestionScore = 2; }
            if (strResult10.Contains("D")) { question10.QuestionScore = 3; }
            if (strResult10.Contains("E")) { question10.QuestionScore = 4; }
            if (strResult10.Contains("F")) { question10.QuestionScore = 5; }

            question10.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question10, QuestionnaireCode.Ipss);

            //下一页
            IpssFive ipssFive = new IpssFive();
            ipssFive.TopMost = false;
            ipssFive.Show();
            Close();
        }

        private void IpssFour_Load(object sender, EventArgs e)
        {
            string question9 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".9");
            if (question9.Contains("A")) { rbQ9A.Checked = true; }
            if (question9.Contains("B")) { rbQ9B.Checked = true; }
            if (question9.Contains("C")) { rbQ9C.Checked = true; }
            if (question9.Contains("D")) { rbQ9D.Checked = true; }
            if (question9.Contains("E")) { rbQ9E.Checked = true; }
            if (question9.Contains("F")) { rbQ9F.Checked = true; }

            string question10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".10");
            if (question10.Contains("A")) { rbQ10A.Checked = true; }
            if (question10.Contains("B")) { rbQ10B.Checked = true; }
            if (question10.Contains("C")) { rbQ10C.Checked = true; }
            if (question10.Contains("D")) { rbQ10D.Checked = true; }
            if (question10.Contains("E")) { rbQ10E.Checked = true; }
            if (question10.Contains("F")) { rbQ10F.Checked = true; }
        }


    }
}
