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
    public partial class QuestionFive : BaseForm
    {
        public QuestionFive()
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
            QuestionFour frmFour=new QuestionFour();
            frmFour.TopMost = false;
            frmFour.ShowDialog();
            Close();
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            //24
            M_QuestionnaireResultDetail question24 = new M_QuestionnaireResultDetail();
            string strResult24 = "";

            if (crdb24A.Checked) { strResult24 = "A,"; }
            if (crdb24B.Checked) { strResult24 = "B,"; }
            if (crdb24C.Checked) { strResult24 = "C,"; }
            if (crdb24D.Checked) { strResult24 = "D,"; }
            if (crdb24E.Checked) { strResult24 = "E,"; }

            question24.QuestionResult = strResult24;
            question24.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".24";
            question24.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question24, QuestionnaireCode.KangFuShouShangZhi);

            //25
            M_QuestionnaireResultDetail question25 = new M_QuestionnaireResultDetail();
            string strResult25 = "";

            if (crdb25A.Checked) { strResult25 = "A,"; }
            if (crdb25B.Checked) { strResult25 = "B,"; }
            if (crdb25C.Checked) { strResult25 = "C,"; }
            if (crdb25D.Checked) { strResult25 = "D,"; }
            if (crdb25E.Checked) { strResult25 = "E,"; }

            question25.QuestionResult = strResult25;
            question25.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".25";
            question25.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question25, QuestionnaireCode.KangFuShouShangZhi);

            //26
            M_QuestionnaireResultDetail question26 = new M_QuestionnaireResultDetail();
            string strResult26 = "";

            if (crdb26A.Checked) { strResult26 = "A,"; }
            if (crdb26B.Checked) { strResult26 = "B,"; }
            if (crdb26C.Checked) { strResult26 = "C,"; }
            if (crdb26D.Checked) { strResult26 = "D,"; }
            if (crdb26E.Checked) { strResult26 = "E,"; }

            question26.QuestionResult = strResult26;
            question26.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".26";
            question26.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question26, QuestionnaireCode.KangFuShouShangZhi);

            //27
            M_QuestionnaireResultDetail question27 = new M_QuestionnaireResultDetail();
            string strResult27 = "";

            if (crdb27A.Checked) { strResult27 = "A,"; }
            if (crdb27B.Checked) { strResult27 = "B,"; }
            if (crdb27C.Checked) { strResult27 = "C,"; }
            if (crdb27D.Checked) { strResult27 = "D,"; }
            if (crdb27E.Checked) { strResult27 = "E,"; }

            question27.QuestionResult = strResult27;
            question27.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".27";
            question27.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question27, QuestionnaireCode.KangFuShouShangZhi);

            //28
            M_QuestionnaireResultDetail question28 = new M_QuestionnaireResultDetail();
            string strResult28 = "";

            if (crdb28A.Checked) { strResult28 = "A,"; }
            if (crdb28B.Checked) { strResult28 = "B,"; }
            if (crdb28C.Checked) { strResult28 = "C,"; }
            if (crdb28D.Checked) { strResult28 = "D,"; }
            if (crdb28E.Checked) { strResult28 = "E,"; }

            question28.QuestionResult = strResult28;
            question28.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".28";
            question28.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question28, QuestionnaireCode.KangFuShouShangZhi);

            
            //第六页
            QuestionSix frmSix=new QuestionSix();
            frmSix.TopMost = false;
            frmSix.ShowDialog();
            Close();
        }

        private void QuestionFive_Load(object sender, EventArgs e)
        {
            //24
            string answer24 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".24");
            if (answer24.Contains("A")) { crdb24A.Checked = true; }
            if (answer24.Contains("B")) { crdb24B.Checked = true; }
            if (answer24.Contains("C")) { crdb24C.Checked = true; }
            if (answer24.Contains("D")) { crdb24D.Checked = true; }
            if (answer24.Contains("E")) { crdb24E.Checked = true; }

            //25
            string answer25 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".25");
            if (answer25.Contains("A")) { crdb25A.Checked = true; }
            if (answer25.Contains("B")) { crdb25B.Checked = true; }
            if (answer25.Contains("C")) { crdb25C.Checked = true; }
            if (answer25.Contains("D")) { crdb25D.Checked = true; }
            if (answer25.Contains("E")) { crdb25E.Checked = true; }

            //26
            string answer26 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".26");
            if (answer26.Contains("A")) { crdb26A.Checked = true; }
            if (answer26.Contains("B")) { crdb26B.Checked = true; }
            if (answer26.Contains("C")) { crdb26C.Checked = true; }
            if (answer26.Contains("D")) { crdb26D.Checked = true; }
            if (answer26.Contains("E")) { crdb26E.Checked = true; }

            //27
            string answer27 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".27");
            if (answer27.Contains("A")) { crdb27A.Checked = true; }
            if (answer27.Contains("B")) { crdb27B.Checked = true; }
            if (answer27.Contains("C")) { crdb27C.Checked = true; }
            if (answer27.Contains("D")) { crdb27D.Checked = true; }
            if (answer27.Contains("E")) { crdb27E.Checked = true; }

            //22
            string answer28 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".28");
            if (answer28.Contains("A")) { crdb28A.Checked = true; }
            if (answer28.Contains("B")) { crdb28B.Checked = true; }
            if (answer28.Contains("C")) { crdb28C.Checked = true; }
            if (answer28.Contains("D")) { crdb28D.Checked = true; }
            if (answer28.Contains("E")) { crdb28E.Checked = true; }
        }
    }
}
