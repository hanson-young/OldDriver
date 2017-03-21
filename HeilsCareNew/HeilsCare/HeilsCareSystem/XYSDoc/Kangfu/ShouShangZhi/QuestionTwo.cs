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
    public partial class QuestionTwo : BaseForm
    {
        public QuestionTwo()
        {
            InitializeComponent();
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
            QuestionOne frmOne=new QuestionOne();
            frmOne.TopMost = false;
            frmOne.ShowDialog();
            Close();
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            //6
            M_QuestionnaireResultDetail question6 = new M_QuestionnaireResultDetail();
            string strResult6 = "";

            if (crdb6A.Checked) { strResult6 = "A,"; }
            if (crdb6B.Checked) { strResult6 = "B,"; }
            if (crdb6C.Checked) { strResult6 = "C,"; }
            if (crdb6D.Checked) { strResult6 = "D,"; }
            if (crdb6E.Checked) { strResult6 = "E,"; }

            question6.QuestionResult = strResult6;
            question6.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".6";
            question6.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question6, QuestionnaireCode.KangFuShouShangZhi);

            //7
            M_QuestionnaireResultDetail question7 = new M_QuestionnaireResultDetail();
            string strResult7 = "";

            if (crdb7A.Checked) { strResult7 = "A,"; }
            if (crdb7B.Checked) { strResult7 = "B,"; }
            if (crdb7C.Checked) { strResult7 = "C,"; }
            if (crdb7D.Checked) { strResult7 = "D,"; }
            if (crdb7E.Checked) { strResult7 = "E,"; }

            question7.QuestionResult = strResult7;
            question7.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".7";
            question7.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question7, QuestionnaireCode.KangFuShouShangZhi);

            //8
            M_QuestionnaireResultDetail question8 = new M_QuestionnaireResultDetail();
            string strResult8 = "";

            if (crdb8A.Checked) { strResult8 = "A,"; }
            if (crdb8B.Checked) { strResult8 = "B,"; }
            if (crdb8C.Checked) { strResult8 = "C,"; }
            if (crdb8D.Checked) { strResult8 = "D,"; }
            if (crdb8E.Checked) { strResult8 = "E,"; }

            question8.QuestionResult = strResult8;
            question8.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".8";
            question8.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question8, QuestionnaireCode.KangFuShouShangZhi);

            //9
            M_QuestionnaireResultDetail question9 = new M_QuestionnaireResultDetail();
            string strResult9 = "";

            if (crdb9A.Checked) { strResult9 = "A,"; }
            if (crdb9B.Checked) { strResult9 = "B,"; }
            if (crdb9C.Checked) { strResult9 = "C,"; }
            if (crdb9D.Checked) { strResult9 = "D,"; }
            if (crdb9E.Checked) { strResult9 = "E,"; }

            question9.QuestionResult = strResult9;
            question9.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".9";
            question9.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question9, QuestionnaireCode.KangFuShouShangZhi);

            //10
            M_QuestionnaireResultDetail question10 = new M_QuestionnaireResultDetail();
            string strResult10 = "";

            if (crdb10A.Checked) { strResult10 = "A,"; }
            if (crdb10B.Checked) { strResult10 = "B,"; }
            if (crdb10C.Checked) { strResult10 = "C,"; }
            if (crdb10D.Checked) { strResult10 = "D,"; }
            if (crdb10E.Checked) { strResult10 = "E,"; }

            question10.QuestionResult = strResult10;
            question10.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".10";
            question10.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question10, QuestionnaireCode.KangFuShouShangZhi);

            //11
            M_QuestionnaireResultDetail question11 = new M_QuestionnaireResultDetail();
            string strResult11 = "";

            if (crdb11A.Checked) { strResult11 = "A,"; }
            if (crdb11B.Checked) { strResult11 = "B,"; }
            if (crdb11C.Checked) { strResult11 = "C,"; }
            if (crdb11D.Checked) { strResult11 = "D,"; }
            if (crdb11E.Checked) { strResult11 = "E,"; }

            question11.QuestionResult = strResult11;
            question11.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".11";
            question11.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question11, QuestionnaireCode.KangFuShouShangZhi);

            //第三页
            QuestionThree frmThree=new QuestionThree();
            frmThree.TopMost = false;
            frmThree.ShowDialog();
            Close();
        }
        //加载
        private void QuestionTwo_Load(object sender, EventArgs e)
        {
            //6
            string answer6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".6");
            if (answer6.Contains("A")) { crdb6A.Checked = true; }
            if (answer6.Contains("B")) { crdb6B.Checked = true; }
            if (answer6.Contains("C")) { crdb6C.Checked = true; }
            if (answer6.Contains("D")) { crdb6D.Checked = true; }
            if (answer6.Contains("E")) { crdb6E.Checked = true; }

            //7
            string answer7 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".7");
            if (answer7.Contains("A")) { crdb7A.Checked = true; }
            if (answer7.Contains("B")) { crdb7B.Checked = true; }
            if (answer7.Contains("C")) { crdb7C.Checked = true; }
            if (answer7.Contains("D")) { crdb7D.Checked = true; }
            if (answer7.Contains("E")) { crdb7E.Checked = true; }

            //8
            string answer8 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".8");
            if (answer8.Contains("A")) { crdb8A.Checked = true; }
            if (answer8.Contains("B")) { crdb8B.Checked = true; }
            if (answer8.Contains("C")) { crdb8C.Checked = true; }
            if (answer8.Contains("D")) { crdb8D.Checked = true; }
            if (answer8.Contains("E")) { crdb8E.Checked = true; }

            //9
            string answer9 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".9");
            if (answer9.Contains("A")) { crdb9A.Checked = true; }
            if (answer9.Contains("B")) { crdb9B.Checked = true; }
            if (answer9.Contains("C")) { crdb9C.Checked = true; }
            if (answer9.Contains("D")) { crdb9D.Checked = true; }
            if (answer9.Contains("E")) { crdb9E.Checked = true; }

            //10
            string answer10 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".10");
            if (answer10.Contains("A")) { crdb10A.Checked = true; }
            if (answer10.Contains("B")) { crdb10B.Checked = true; }
            if (answer10.Contains("C")) { crdb10C.Checked = true; }
            if (answer10.Contains("D")) { crdb10D.Checked = true; }
            if (answer10.Contains("E")) { crdb10E.Checked = true; }

            //11
            string answer11 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".11");
            if (answer11.Contains("A")) { crdb11A.Checked = true; }
            if (answer11.Contains("B")) { crdb11B.Checked = true; }
            if (answer11.Contains("C")) { crdb11C.Checked = true; }
            if (answer11.Contains("D")) { crdb11D.Checked = true; }
            if (answer11.Contains("E")) { crdb11E.Checked = true; }
        }
    }
}
