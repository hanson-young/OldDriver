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
    public partial class QuestionSix : BaseForm
    {
        public QuestionSix()
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
            QuestionFive frmFive=new QuestionFive();
            frmFive.TopMost = false;
            frmFive.ShowDialog();
            Close();
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            //29
            M_QuestionnaireResultDetail question29 = new M_QuestionnaireResultDetail();
            string strResult24 = "";

            if (crdb29A.Checked) { strResult24 = "A,"; }
            if (crdb29B.Checked) { strResult24 = "B,"; }
            if (crdb29C.Checked) { strResult24 = "C,"; }
            if (crdb29D.Checked) { strResult24 = "D,"; }
            if (crdb29E.Checked) { strResult24 = "E,"; }

            question29.QuestionResult = strResult24;
            question29.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".29";
            question29.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question29, QuestionnaireCode.KangFuShouShangZhi);

            //30
            M_QuestionnaireResultDetail question30 = new M_QuestionnaireResultDetail();
            string strResult30 = "";

            if (crdb30A.Checked) { strResult30 = "A,"; }
            if (crdb30B.Checked) { strResult30 = "B,"; }
            if (crdb30C.Checked) { strResult30 = "C,"; }
            if (crdb30D.Checked) { strResult30 = "D,"; }
            if (crdb30E.Checked) { strResult30 = "E,"; }

            question30.QuestionResult = strResult30;
            question30.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".30";
            question30.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question30, QuestionnaireCode.KangFuShouShangZhi);

            //下一页
            Result frmResult=new Result();
            frmResult.TopMost = false;
            frmResult.ShowDialog();
            Close();
        }

        private void QuestionSix_Load(object sender, EventArgs e)
        {
            //29
            string answer29 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".29");
            if (answer29.Contains("A")) { crdb29A.Checked = true; }
            if (answer29.Contains("B")) { crdb29B.Checked = true; }
            if (answer29.Contains("C")) { crdb29C.Checked = true; }
            if (answer29.Contains("D")) { crdb29D.Checked = true; }
            if (answer29.Contains("E")) { crdb29E.Checked = true; }

            //30
            string answer30 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".30");
            if (answer30.Contains("A")) { crdb30A.Checked = true; }
            if (answer30.Contains("B")) { crdb30B.Checked = true; }
            if (answer30.Contains("C")) { crdb30C.Checked = true; }
            if (answer30.Contains("D")) { crdb30D.Checked = true; }
            if (answer30.Contains("E")) { crdb30E.Checked = true; }
        }
    }
}
