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
    public partial class QuestionThree : BaseForm
    {
        public QuestionThree()
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
            QuestionTwo frmTwo=new QuestionTwo();
            frmTwo.TopMost = false;
            frmTwo.ShowDialog();
            Close();
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            //12
            M_QuestionnaireResultDetail question12 = new M_QuestionnaireResultDetail();
            string strResult12 = "";

            if (crdb12A.Checked) { strResult12 = "A,"; }
            if (crdb12B.Checked) { strResult12 = "B,"; }
            if (crdb12C.Checked) { strResult12 = "C,"; }
            if (crdb12D.Checked) { strResult12 = "D,"; }
            if (crdb12E.Checked) { strResult12 = "E,"; }

            question12.QuestionResult = strResult12;
            question12.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".12";
            question12.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question12, QuestionnaireCode.KangFuShouShangZhi);

            //13
            M_QuestionnaireResultDetail question13 = new M_QuestionnaireResultDetail();
            string strResult13 = "";

            if (crdb13A.Checked) { strResult13 = "A,"; }
            if (crdb13B.Checked) { strResult13 = "B,"; }
            if (crdb13C.Checked) { strResult13 = "C,"; }
            if (crdb13D.Checked) { strResult13 = "D,"; }
            if (crdb13E.Checked) { strResult13 = "E,"; }

            question13.QuestionResult = strResult13;
            question13.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".13";
            question13.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question13, QuestionnaireCode.KangFuShouShangZhi);

            //14
            M_QuestionnaireResultDetail question14 = new M_QuestionnaireResultDetail();
            string strResult14 = "";

            if (crdb14A.Checked) { strResult14 = "A,"; }
            if (crdb14B.Checked) { strResult14 = "B,"; }
            if (crdb14C.Checked) { strResult14 = "C,"; }
            if (crdb14D.Checked) { strResult14 = "D,"; }
            if (crdb14E.Checked) { strResult14 = "E,"; }

            question14.QuestionResult = strResult14;
            question14.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".14";
            question14.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question14, QuestionnaireCode.KangFuShouShangZhi);

            //15
            M_QuestionnaireResultDetail question15 = new M_QuestionnaireResultDetail();
            string strResult15 = "";

            if (crdb15A.Checked) { strResult15 = "A,"; }
            if (crdb15B.Checked) { strResult15 = "B,"; }
            if (crdb15C.Checked) { strResult15 = "C,"; }
            if (crdb15D.Checked) { strResult15 = "D,"; }
            if (crdb15E.Checked) { strResult15 = "E,"; }

            question15.QuestionResult = strResult15;
            question15.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".15";
            question15.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question15, QuestionnaireCode.KangFuShouShangZhi);

            //16
            M_QuestionnaireResultDetail question16 = new M_QuestionnaireResultDetail();
            string strResult16 = "";

            if (crdb16A.Checked) { strResult16 = "A,"; }
            if (crdb16B.Checked) { strResult16 = "B,"; }
            if (crdb16C.Checked) { strResult16 = "C,"; }
            if (crdb16D.Checked) { strResult16 = "D,"; }
            if (crdb16E.Checked) { strResult16 = "E,"; }

            question16.QuestionResult = strResult16;
            question16.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".16";
            question16.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question16, QuestionnaireCode.KangFuShouShangZhi);

            //17
            M_QuestionnaireResultDetail question17 = new M_QuestionnaireResultDetail();
            string strResult17 = "";

            if (crdb17A.Checked) { strResult17 = "A,"; }
            if (crdb17B.Checked) { strResult17 = "B,"; }
            if (crdb17C.Checked) { strResult17 = "C,"; }
            if (crdb17D.Checked) { strResult17 = "D,"; }
            if (crdb17E.Checked) { strResult17 = "E,"; }

            question17.QuestionResult = strResult17;
            question17.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".17";
            question17.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question17, QuestionnaireCode.KangFuShouShangZhi);

            //第四页
            QuestionFour frmFour=new QuestionFour();
            frmFour.TopMost = false;
            frmFour.ShowDialog();
            Close();
        }
        //加载
        private void QuestionThree_Load(object sender, EventArgs e)
        {
            //12
            string answer12 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".12");
            if (answer12.Contains("A")) { crdb12A.Checked = true; }
            if (answer12.Contains("B")) { crdb12B.Checked = true; }
            if (answer12.Contains("C")) { crdb12C.Checked = true; }
            if (answer12.Contains("D")) { crdb12D.Checked = true; }
            if (answer12.Contains("E")) { crdb12E.Checked = true; }

            //13
            string answer13 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".13");
            if (answer13.Contains("A")) { crdb13A.Checked = true; }
            if (answer13.Contains("B")) { crdb13B.Checked = true; }
            if (answer13.Contains("C")) { crdb13C.Checked = true; }
            if (answer13.Contains("D")) { crdb13D.Checked = true; }
            if (answer13.Contains("E")) { crdb13E.Checked = true; }

            //14
            string answer14 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".14");
            if (answer14.Contains("A")) { crdb14A.Checked = true; }
            if (answer14.Contains("B")) { crdb14B.Checked = true; }
            if (answer14.Contains("C")) { crdb14C.Checked = true; }
            if (answer14.Contains("D")) { crdb14D.Checked = true; }
            if (answer14.Contains("E")) { crdb14E.Checked = true; }

            //15
            string answer15 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".15");
            if (answer15.Contains("A")) { crdb15A.Checked = true; }
            if (answer15.Contains("B")) { crdb15B.Checked = true; }
            if (answer15.Contains("C")) { crdb15C.Checked = true; }
            if (answer15.Contains("D")) { crdb15D.Checked = true; }
            if (answer15.Contains("E")) { crdb15E.Checked = true; }

            //16
            string answer16 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".16");
            if (answer16.Contains("A")) { crdb16A.Checked = true; }
            if (answer16.Contains("B")) { crdb16B.Checked = true; }
            if (answer16.Contains("C")) { crdb16C.Checked = true; }
            if (answer16.Contains("D")) { crdb16D.Checked = true; }
            if (answer16.Contains("E")) { crdb16E.Checked = true; }

            //17
            string answer17 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".17");
            if (answer17.Contains("A")) { crdb17A.Checked = true; }
            if (answer17.Contains("B")) { crdb17B.Checked = true; }
            if (answer17.Contains("C")) { crdb17C.Checked = true; }
            if (answer17.Contains("D")) { crdb17D.Checked = true; }
            if (answer17.Contains("E")) { crdb17E.Checked = true; }
        }
    }
}
