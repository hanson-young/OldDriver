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
    public partial class OabThree : BaseForm
    {
        public OabThree()
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
            OabTwo oabTwo = new OabTwo();
            oabTwo.TopMost = false;
            oabTwo.Show();
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //第七题
            M_QuestionnaireResultDetail question7 = new M_QuestionnaireResultDetail();
            string strResult7 = "";

            if (rbQ7A.Checked) { strResult7 = "A,"; }
            if (rbQ7B.Checked) { strResult7 = "B,"; }
            if (rbQ7C.Checked) { strResult7 = "C,"; }
            if (rbQ7D.Checked) { strResult7 = "D,"; }

            question7.QuestionResult = strResult7;
            question7.QuestionCode = QuestionnaireCode.Oab + ".7";
            question7.PQuestionCode = QuestionnaireCode.Oab + ".7";
            question7.QuestionType = 1;

            //打分
            if (strResult7.Contains("A")) { question7.QuestionScore = 0; }
            if (strResult7.Contains("B")) { question7.QuestionScore = 1; }
            if (strResult7.Contains("C")) { question7.QuestionScore = 2; }
            if (strResult7.Contains("D")) { question7.QuestionScore = 3; }

            question7.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question7, QuestionnaireCode.Oab);

            //第八题
            M_QuestionnaireResultDetail question8 = new M_QuestionnaireResultDetail();
            string strResult8 = "";

            if (rbQ8A.Checked) { strResult8 = "A,"; }
            if (rbQ8B.Checked) { strResult8 = "B,"; }
            if (rbQ8C.Checked) { strResult8 = "C,"; }
            if (rbQ8D.Checked) { strResult8 = "D,"; }
            if (rbQ8E.Checked) { strResult8 = "E,"; }
            if (rbQ8F.Checked) { strResult8 = "F,"; }

            question8.QuestionResult = strResult8;
            question8.QuestionCode = QuestionnaireCode.Oab + ".8";
            question8.PQuestionCode = QuestionnaireCode.Oab + ".8";
            question8.QuestionType = 1;

            //打分
            if (strResult8.Contains("A")) { question8.QuestionScore = 1; }
            if (strResult8.Contains("B")) { question8.QuestionScore = 2; }
            if (strResult8.Contains("C")) { question8.QuestionScore = 3; }
            if (strResult8.Contains("D")) { question8.QuestionScore = 4; }
            if (strResult8.Contains("E")) { question8.QuestionScore = 5; }
            if (strResult8.Contains("F")) { question8.QuestionScore = 0; }

            question8.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question8, QuestionnaireCode.Oab);

            //下一页
            OabFour oabFour=new OabFour();
            oabFour.TopMost = false;
            oabFour.Show();
            Close();
        }

        private void OabThree_Load(object sender, EventArgs e)
        {
            string question7 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".7");
            if (question7.Contains("A"))  { rbQ7A.Checked=true;}
            if (question7.Contains("B")) { rbQ7B.Checked = true; }
            if (question7.Contains("C")) { rbQ7C.Checked = true; }
            if (question7.Contains("D")) { rbQ7D.Checked = true; }

            string question8 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".8");
            if (question8.Contains("A")) { rbQ8A.Checked = true; }
            if (question8.Contains("B")) { rbQ8B.Checked = true; }
            if (question8.Contains("C")) { rbQ8C.Checked = true; }
            if (question8.Contains("D")) { rbQ8D.Checked = true; }
            if (question8.Contains("E")) { rbQ8E.Checked = true; }
            if (question8.Contains("F")) { rbQ8F.Checked = true; }
        }


    }
}
