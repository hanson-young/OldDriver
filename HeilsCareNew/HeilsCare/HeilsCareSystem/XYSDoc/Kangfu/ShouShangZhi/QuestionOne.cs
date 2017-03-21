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

namespace XYS.Remp.Screening.Kangfu.ShouShangZhi
{
    public partial class QuestionOne : BaseForm
    {
        public QuestionOne()
        {
            InitializeComponent();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreeningSelect frmMain = new ScreeningSelect();
            frmMain.TopMost = false;
            frmMain.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //上一步
        private void btnBefore_Click(object sender, EventArgs e)
        {
            btnBack_Click(this, e);
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            //第一题
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
            string strResult1 = "";

            if (crdb1A.Checked){strResult1 = "A,";}
            if (crdb1B.Checked){strResult1 = "B,";}
            if (crdb1C.Checked){strResult1 = "C,";}
            if (crdb1D.Checked){strResult1 = "D,";}
            if (crdb1E.Checked){strResult1 = "E,";}

            question1.QuestionResult = strResult1;
            question1.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".1";
            question1.QuestionType = 1;
            //打分


            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.KangFuShouShangZhi);

            //第二题
            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            string strResult2 = "";

            if (crdb2A.Checked) { strResult2 = "A,"; }
            if (crdb2B.Checked) { strResult2 = "B,"; }
            if (crdb2C.Checked) { strResult2 = "C,"; }
            if (crdb2D.Checked) { strResult2 = "D,"; }
            if (crdb2E.Checked) { strResult2 = "E,"; }

            question2.QuestionResult = strResult2;
            question2.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".2";
            question2.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.KangFuShouShangZhi);

            //第三题
            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            string strResult3 = "";

            if (crdb3A.Checked) { strResult3 = "A,"; }
            if (crdb3B.Checked) { strResult3 = "B,"; }
            if (crdb3C.Checked) { strResult3 = "C,"; }
            if (crdb3D.Checked) { strResult3 = "D,"; }
            if (crdb3E.Checked) { strResult3 = "E,"; }

            question3.QuestionResult = strResult3;
            question3.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".3";
            question3.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question3, QuestionnaireCode.KangFuShouShangZhi);

            //第四题
            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            string strResult4 = "";

            if (crdb4A.Checked) { strResult4 = "A,"; }
            if (crdb4B.Checked) { strResult4 = "B,"; }
            if (crdb4C.Checked) { strResult4 = "C,"; }
            if (crdb4D.Checked) { strResult4 = "D,"; }
            if (crdb4E.Checked) { strResult4 = "E,"; }

            question4.QuestionResult = strResult4;
            question4.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".4";
            question4.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question4, QuestionnaireCode.KangFuShouShangZhi);

            //第五题
            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();
            string strResult5 = "";

            if (crdb5A.Checked) { strResult5 = "A,"; }
            if (crdb5B.Checked) { strResult5 = "B,"; }
            if (crdb5C.Checked) { strResult5 = "C,"; }
            if (crdb5D.Checked) { strResult5 = "D,"; }
            if (crdb5E.Checked) { strResult5 = "E,"; }

            question5.QuestionResult = strResult5;
            question5.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".5";
            question5.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question5, QuestionnaireCode.KangFuShouShangZhi);

            //第二页
            QuestionTwo frmTwo=new QuestionTwo();
            frmTwo.TopMost = false;
            frmTwo.ShowDialog();
            //frmTwo.Show();
            Close();
        }
        //加载
        private void QuestionOne_Load(object sender, EventArgs e)
        {
            //1
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".1");
            if (answer1.Contains("A")) { crdb1A.Checked = true; }
            if (answer1.Contains("B")) { crdb1B.Checked = true; }
            if (answer1.Contains("C")) { crdb1C.Checked = true; }
            if (answer1.Contains("D")) { crdb1D.Checked = true; }
            if (answer1.Contains("E")) { crdb1E.Checked = true; }

            //2
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".2");
            if (answer2.Contains("A")) { crdb2A.Checked = true; }
            if (answer2.Contains("B")) { crdb2B.Checked = true; }
            if (answer2.Contains("C")) { crdb2C.Checked = true; }
            if (answer2.Contains("D")) { crdb2D.Checked = true; }
            if (answer2.Contains("E")) { crdb2E.Checked = true; }

            //3
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".3");
            if (answer3.Contains("A")) { crdb3A.Checked = true; }
            if (answer3.Contains("B")) { crdb3B.Checked = true; }
            if (answer3.Contains("C")) { crdb3C.Checked = true; }
            if (answer3.Contains("D")) { crdb3D.Checked = true; }
            if (answer3.Contains("E")) { crdb3E.Checked = true; }

            //4
            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".4");
            if (answer4.Contains("A")) { crdb4A.Checked = true; }
            if (answer4.Contains("B")) { crdb4B.Checked = true; }
            if (answer4.Contains("C")) { crdb4C.Checked = true; }
            if (answer4.Contains("D")) { crdb4D.Checked = true; }
            if (answer4.Contains("E")) { crdb4E.Checked = true; }

            //5
            string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".5");
            if (answer5.Contains("A")) { crdb5A.Checked = true; }
            if (answer5.Contains("B")) { crdb5B.Checked = true; }
            if (answer5.Contains("C")) { crdb5C.Checked = true; }
            if (answer5.Contains("D")) { crdb5D.Checked = true; }
            if (answer5.Contains("E")) { crdb5E.Checked = true; }
        }
    }
}
