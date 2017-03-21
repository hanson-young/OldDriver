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
    public partial class CopdThree : BaseForm
    {
        public CopdThree()
        {
            InitializeComponent();
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            var screenOtherSelect = new ScreenOtherSelect();
            screenOtherSelect.TopMost = false;
            screenOtherSelect.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            var quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //上一页
        private void btnBefore_Click(object sender, EventArgs e)
        {
            var copdTwo = new CopdTwo();
            copdTwo.TopMost = false;
            copdTwo.Show();
            Close();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //第五题
            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();
            string strResult5 = "";
            if (rbQ5A.Checked) { strResult5 = "A,"; }
            if (rbQ5B.Checked) { strResult5 = "B,"; }

            question5.QuestionResult = strResult5;
            question5.QuestionCode = QuestionnaireCode.Copd + ".5";
            question5.PQuestionCode = QuestionnaireCode.Copd + ".5";
            question5.QuestionType = 1;
            question5.QuestionScore = strResult5.Contains("A")?20:0;
            question5.PQuestionWeightScore = 0;

            ClientInfo.AddQuestionToQuestionnaire(question5, QuestionnaireCode.Copd);

            //下一页
            var copdResult = new CopdResult();
            copdResult.TopMost = false;
            copdResult.Show();
            Close();
        }
        //加载
        private void CopdThree_Load(object sender, EventArgs e)
        {
            string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Copd, QuestionnaireCode.Copd + ".5");
            if (answer5.Contains("A")) { rbQ5A.Checked = true; }
            if (answer5.Contains("B")) { rbQ5B.Checked = true; }
        }

    }
}
