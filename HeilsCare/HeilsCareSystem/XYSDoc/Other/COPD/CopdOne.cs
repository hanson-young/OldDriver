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

namespace XYS.Remp.Screening.Other.COPD
{
    public partial class CopdOne : BaseForm
    {
        public CopdOne()
        {
            InitializeComponent();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreenOtherSelect screenOtherSelect = new ScreenOtherSelect();
            screenOtherSelect.TopMost = false;
            screenOtherSelect.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //上一页
        private void btnBefore_Click(object sender, EventArgs e)
        {
            btnBack_Click(this, e);
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //第一题
            M_QuestionnaireResultDetail question1=new M_QuestionnaireResultDetail();
            string strResult1 = "";
            if (rbQ1A.Checked) { strResult1 = "A,"; }
            if (rbQ1B.Checked) { strResult1 = "B,"; }

            question1.QuestionResult = strResult1;
            question1.QuestionCode = QuestionnaireCode.Copd + ".1";
            question1.PQuestionCode = QuestionnaireCode.Copd + ".1";
            question1.QuestionType = 1;
            question1.QuestionScore = strResult1.Contains("A") ? 20 : 0;
            question1.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.Copd);

            //第二题
            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            string strResult2 = "";
            if (rbQ2A.Checked) { strResult2 = "A,"; }
            if (rbQ2B.Checked) { strResult2 = "B,"; }

            question2.QuestionResult = strResult2;
            question2.QuestionCode = QuestionnaireCode.Copd + ".2";
            question2.PQuestionCode = QuestionnaireCode.Copd + ".2";
            question2.QuestionType = 1;
            question2.QuestionScore = strResult2.Contains("A") ? 20 : 0;
            question2.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.Copd);

            //下一页
            var copdTwo=new CopdTwo();
            copdTwo.TopMost = false;
            copdTwo.Show();
            Close();
        }
        //加载
        private void CopdOne_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".1");
            if (answer1.Contains("A")) { rbQ1A.Checked = true; }
            if (answer1.Contains("B")) { rbQ1B.Checked = true; }

            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".2");
            if (answer2.Contains("A")) { rbQ2A.Checked = true; }
            if (answer2.Contains("B")) { rbQ2B.Checked = true; }
        }

    }
}
