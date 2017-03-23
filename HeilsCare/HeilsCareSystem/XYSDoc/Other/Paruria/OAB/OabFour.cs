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

namespace XYS.Remp.Screening.Other.Paruria.OAB
{
    public partial class OabFour : BaseForm
    {
        public OabFour()
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
            OabThree oabThree = new OabThree();
            oabThree.TopMost = false;
            oabThree.Show();
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
            question9.QuestionCode = QuestionnaireCode.Oab + ".9";
            question9.PQuestionCode = QuestionnaireCode.Oab + ".9";
            question9.QuestionType = 1;

            //打分
            if (strResult9.Contains("A")) { question9.QuestionScore = 1; }
            if (strResult9.Contains("B")) { question9.QuestionScore = 2; }
            if (strResult9.Contains("C")) { question9.QuestionScore = 3; }
            if (strResult9.Contains("D")) { question9.QuestionScore = 4; }
            if (strResult9.Contains("E")) { question9.QuestionScore = 5; }
            if (strResult9.Contains("F")) { question9.QuestionScore = 0; }

            question9.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question9, QuestionnaireCode.Oab);

            //下一页
            OabResult oabResult = new OabResult();
            oabResult.TopMost = false;
            oabResult.Show();
            Close();
        }

        private void OabFour_Load(object sender, EventArgs e)
        {
            string question9 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".9");
            if (question9.Contains("A")) { rbQ9A.Checked = true; }
            if (question9.Contains("B")) { rbQ9B.Checked = true; }
            if (question9.Contains("C")) { rbQ9C.Checked = true; }
            if (question9.Contains("D")) { rbQ9D.Checked = true; }
            if (question9.Contains("E")) { rbQ9E.Checked = true; }
            if (question9.Contains("F")) { rbQ9F.Checked = true; }
        }
    }
}
