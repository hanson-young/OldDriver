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
    public partial class IpssTwo : BaseForm
    {
        public IpssTwo()
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
            IpssOne ipssOne = new IpssOne();
            ipssOne.TopMost = false;
            ipssOne.Show();
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
            question5.QuestionCode = QuestionnaireCode.Ipss + ".5";
            question5.PQuestionCode = QuestionnaireCode.Ipss + ".5";
            question5.QuestionType = 1;
            question5.QuestionScore = 0;
            question5.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question5, QuestionnaireCode.Ipss);

            //第六题
            M_QuestionnaireResultDetail question6 = new M_QuestionnaireResultDetail();
            string strResult6 = "";

            if (rbQ6A.Checked) { strResult6 = "A,"; }
            if (rbQ6B.Checked) { strResult6 = "B,"; }
            if (rbQ6C.Checked) { strResult6 = "C,"; }
            if (rbQ6D.Checked) { strResult6 = "D,"; }
            if (rbQ6E.Checked) { strResult6 = "E,"; }
            if (rbQ6F.Checked) { strResult6 = "F,"; }

            question6.QuestionResult = strResult6;
            question6.QuestionCode = QuestionnaireCode.Ipss + ".6";
            question6.PQuestionCode = QuestionnaireCode.Ipss + ".6";
            question6.QuestionType = 1;

            //打分
            if (strResult6.Contains("A")) { question6.QuestionScore = 0; }
            if (strResult6.Contains("B")) { question6.QuestionScore = 1; }
            if (strResult6.Contains("C")) { question6.QuestionScore = 2; }
            if (strResult6.Contains("D")) { question6.QuestionScore = 3; }
            if (strResult6.Contains("E")) { question6.QuestionScore = 4; }
            if (strResult6.Contains("F")) { question6.QuestionScore = 5; }
            
            question6.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question6, QuestionnaireCode.Ipss);

            //下一页
            IpssThree ipssThree = new IpssThree();
            ipssThree.TopMost = false;
            ipssThree.Show();
            Close();
        }

        private void IpssTwo_Load(object sender, EventArgs e)
        {
            string question5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".5");
            if (question5.Contains("A")) { rbQ5A.Checked = true; }
            if (question5.Contains("B")) { rbQ5B.Checked = true; }
            if (question5.Contains("C")) { rbQ5C.Checked = true; }

            string question6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Ipss, QuestionnaireCode.Ipss + ".6");
            if (question6.Contains("A")) { rbQ6A.Checked = true; }
            if (question6.Contains("B")) { rbQ6B.Checked = true; }
            if (question6.Contains("C")) { rbQ6C.Checked = true; }
            if (question6.Contains("D")) { rbQ6D.Checked = true; }
            if (question6.Contains("E")) { rbQ6E.Checked = true; }
            if (question6.Contains("F")) { rbQ6F.Checked = true; }
        }
    }
}
