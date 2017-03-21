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
    public partial class IpssFive : BaseForm
    {
        public IpssFive()
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
            IpssFour ipssFour = new IpssFour();
            ipssFour.TopMost = false;
            ipssFour.Show();
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //第十一题
            M_QuestionnaireResultDetail question11 = new M_QuestionnaireResultDetail();
            string strResult11 = "";

            if (rbQ11A.Checked) { strResult11 = "A,"; }
            if (rbQ11B.Checked) { strResult11 = "B,"; }
            if (rbQ11C.Checked) { strResult11 = "C,"; }
            if (rbQ11D.Checked) { strResult11 = "D,"; }
            if (rbQ11E.Checked) { strResult11 = "E,"; }
            if (rbQ11F.Checked) { strResult11 = "F,"; }

            question11.QuestionResult = strResult11;
            question11.QuestionCode = QuestionnaireCode.Ipss + ".11";
            question11.PQuestionCode = QuestionnaireCode.Ipss + ".11";
            question11.QuestionType = 1;

            //打分
            if (strResult11.Contains("A")) { question11.QuestionScore = 0; }
            if (strResult11.Contains("B")) { question11.QuestionScore = 1; }
            if (strResult11.Contains("C")) { question11.QuestionScore = 2; }
            if (strResult11.Contains("D")) { question11.QuestionScore = 3; }
            if (strResult11.Contains("E")) { question11.QuestionScore = 4; }
            if (strResult11.Contains("F")) { question11.QuestionScore = 5; }

            question11.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question11, QuestionnaireCode.Ipss);

            //第十二题
            M_QuestionnaireResultDetail question12 = new M_QuestionnaireResultDetail();
            string strResult12 = "";

            if (rbQ12A.Checked) { strResult12 = "A,"; }
            if (rbQ12B.Checked) { strResult12 = "B,"; }
            if (rbQ12C.Checked) { strResult12 = "C,"; }
            if (rbQ12D.Checked) { strResult12 = "D,"; }
            if (rbQ12E.Checked) { strResult12 = "E,"; }
            if (rbQ12F.Checked) { strResult12 = "F,"; }

            question12.QuestionResult = strResult12;
            question12.QuestionCode = QuestionnaireCode.Ipss + ".12";
            question12.PQuestionCode = QuestionnaireCode.Ipss + ".12";
            question12.QuestionType = 1;

            //打分
            if (strResult12.Contains("A")) { question12.QuestionScore = 0; }
            if (strResult12.Contains("B")) { question12.QuestionScore = 1; }
            if (strResult12.Contains("C")) { question12.QuestionScore = 2; }
            if (strResult12.Contains("D")) { question12.QuestionScore = 3; }
            if (strResult12.Contains("E")) { question12.QuestionScore = 4; }
            if (strResult12.Contains("F")) { question12.QuestionScore = 5; }

            question12.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question12, QuestionnaireCode.Ipss);

            //下一页
            IpssSix ipssSix = new IpssSix();
            ipssSix.TopMost = false;
            ipssSix.Show();
            Close();
        }

        private void IpssFive_Load(object sender, EventArgs e)
        {
            string question11 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".11");
            if (question11.Contains("A")) { rbQ11A.Checked = true; }
            if (question11.Contains("B")) { rbQ11B.Checked = true; }
            if (question11.Contains("C")) { rbQ11C.Checked = true; }
            if (question11.Contains("D")) { rbQ11D.Checked = true; }
            if (question11.Contains("E")) { rbQ11E.Checked = true; }
            if (question11.Contains("F")) { rbQ11F.Checked = true; }

            string question12 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".12");
            if (question12.Contains("A")) { rbQ12A.Checked = true; }
            if (question12.Contains("B")) { rbQ12B.Checked = true; }
            if (question12.Contains("C")) { rbQ12C.Checked = true; }
            if (question12.Contains("D")) { rbQ12D.Checked = true; }
            if (question12.Contains("E")) { rbQ12E.Checked = true; }
            if (question12.Contains("F")) { rbQ12F.Checked = true; }
        }
    }
}
