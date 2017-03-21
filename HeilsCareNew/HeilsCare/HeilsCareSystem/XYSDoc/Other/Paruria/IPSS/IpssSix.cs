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
    public partial class IpssSix : BaseForm
    {
        public IpssSix()
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
            IpssFive ipssFive=new IpssFive();
            ipssFive.TopMost = false;
            ipssFive.Show();
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //第13题
            M_QuestionnaireResultDetail question13 = new M_QuestionnaireResultDetail();
            string strResult13 = "";

            if (rbQ13A.Checked) { strResult13 = "A,"; }
            if (rbQ13B.Checked) { strResult13 = "B,"; }
            if (rbQ13C.Checked) { strResult13 = "C,"; }
            if (rbQ13D.Checked) { strResult13 = "D,"; }
            if (rbQ13E.Checked) { strResult13 = "E,"; }
            if (rbQ13F.Checked) { strResult13 = "F,"; }
            if (rbQ13G.Checked) { strResult13 = "G,"; }

            question13.QuestionResult = strResult13;
            question13.QuestionCode = QuestionnaireCode.Ipss + ".13";
            question13.PQuestionCode = QuestionnaireCode.Ipss + ".13";
            question13.QuestionType = 1;

            //打分
            if (strResult13.Contains("A")) { question13.QuestionScore = 0; }
            if (strResult13.Contains("B")) { question13.QuestionScore = 1; }
            if (strResult13.Contains("C")) { question13.QuestionScore = 2; }
            if (strResult13.Contains("D")) { question13.QuestionScore = 3; }
            if (strResult13.Contains("E")) { question13.QuestionScore = 4; }
            if (strResult13.Contains("F")) { question13.QuestionScore = 5; }
            if (strResult13.Contains("G")) { question13.QuestionScore = 6; }

            question13.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question13, QuestionnaireCode.Ipss);

            //下一页
            IpssResult ipssResult = new IpssResult();
            ipssResult.TopMost = false;
            ipssResult.Show();
            Close();
        }

        private void IpssSix_Load(object sender, EventArgs e)
        {
            string question13 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".13");
            if (question13.Contains("A")) { rbQ13A.Checked = true; }
            if (question13.Contains("B")) { rbQ13B.Checked = true; }
            if (question13.Contains("C")) { rbQ13C.Checked = true; }
            if (question13.Contains("D")) { rbQ13D.Checked = true; }
            if (question13.Contains("E")) { rbQ13E.Checked = true; }
            if (question13.Contains("F")) { rbQ13F.Checked = true; }
            if (question13.Contains("G")) { rbQ13G.Checked = true; }
        }
    }
}
