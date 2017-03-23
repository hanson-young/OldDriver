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
    public partial class OabTwo : BaseForm
    {
        public OabTwo()
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
            OabOne oabOne=new OabOne();
            oabOne.TopMost = false;
            oabOne.Show();
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //第五题
            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();
            string strResult5 = "";

            if (rbQ5A.Checked) { strResult5 = "A,"; }
            if (rbQ5B.Checked) { strResult5 = "B,"; }
            if (rbQ5C.Checked) { strResult5 = "C,"; }

            question5.QuestionResult = strResult5;
            question5.QuestionCode = QuestionnaireCode.Oab + ".5";
            question5.PQuestionCode = QuestionnaireCode.Oab + ".5";
            question5.QuestionType = 1;
            question5.QuestionScore = 0;
            question5.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question5, QuestionnaireCode.Oab);

            //第六题
            M_QuestionnaireResultDetail question6 = new M_QuestionnaireResultDetail();
            string strResult6 = "";

            if (rbQ6A.Checked) { strResult6 = "A,"; }
            if (rbQ6B.Checked) { strResult6 = "B,"; }
            if (rbQ6C.Checked) { strResult6 = "C,"; }

            question6.QuestionResult = strResult6;
            question6.QuestionCode = QuestionnaireCode.Oab + ".6";
            question6.PQuestionCode = QuestionnaireCode.Oab + ".6";
            question6.QuestionType = 1;

            //打分
            if (strResult6.Contains("B"))
            {
                question6.QuestionScore = 1;
            }
            else if (strResult6.Contains("C"))
            {
                question6.QuestionScore = 2;
            }
            else
            {
                question6.QuestionScore = 0;
            }
            question6.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question6, QuestionnaireCode.Oab);

            //下一页
            OabThree oabThree=new OabThree();
            oabThree.TopMost = false;
            oabThree.Show();
            Close();
        }

        private void OabTwo_Load(object sender, EventArgs e)
        {
            string question5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".5");
            if (question5.Contains("A")) { rbQ5A.Checked = true; }
            if (question5.Contains("B")) { rbQ5B.Checked = true; }
            if (question5.Contains("C")) { rbQ5C.Checked = true; }

            string question6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Oab, QuestionnaireCode.Oab + ".6");
            if (question6.Contains("A")) { rbQ6A.Checked = true; }
            if (question6.Contains("B")) { rbQ6B.Checked = true; }
            if (question6.Contains("C")) { rbQ6C.Checked = true; }
        }
    }
}
