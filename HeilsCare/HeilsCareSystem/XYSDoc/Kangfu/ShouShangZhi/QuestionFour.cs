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
    public partial class QuestionFour : BaseForm
    {
        public QuestionFour()
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
            QuestionThree frmThree=new QuestionThree();
            frmThree.TopMost = false;
            frmThree.ShowDialog();
            Close();
        }
        //下一步
        private void btnNext_Click(object sender, EventArgs e)
        {
            //18
            M_QuestionnaireResultDetail question18 = new M_QuestionnaireResultDetail();
            string strResult18 = "";

            if (crdb18A.Checked) { strResult18 = "A,"; }
            if (crdb18B.Checked) { strResult18 = "B,"; }
            if (crdb18C.Checked) { strResult18 = "C,"; }
            if (crdb18D.Checked) { strResult18 = "D,"; }
            if (crdb18E.Checked) { strResult18 = "E,"; }

            question18.QuestionResult = strResult18;
            question18.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".18";
            question18.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question18, QuestionnaireCode.KangFuShouShangZhi);

            //19
            M_QuestionnaireResultDetail question19 = new M_QuestionnaireResultDetail();
            string strResult19 = "";

            if (crdb19A.Checked) { strResult19 = "A,"; }
            if (crdb19B.Checked) { strResult19 = "B,"; }
            if (crdb19C.Checked) { strResult19 = "C,"; }
            if (crdb19D.Checked) { strResult19 = "D,"; }
            if (crdb19E.Checked) { strResult19 = "E,"; }

            question19.QuestionResult = strResult19;
            question19.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".19";
            question19.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question19, QuestionnaireCode.KangFuShouShangZhi);

            //20
            M_QuestionnaireResultDetail question20 = new M_QuestionnaireResultDetail();
            string strResult20 = "";

            if (crdb20A.Checked) { strResult20 = "A,"; }
            if (crdb20B.Checked) { strResult20 = "B,"; }
            if (crdb20C.Checked) { strResult20 = "C,"; }
            if (crdb20D.Checked) { strResult20 = "D,"; }
            if (crdb20E.Checked) { strResult20 = "E,"; }

            question20.QuestionResult = strResult20;
            question20.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".20";
            question20.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question20, QuestionnaireCode.KangFuShouShangZhi);

            //21
            M_QuestionnaireResultDetail question21 = new M_QuestionnaireResultDetail();
            string strResult21 = "";

            if (crdb21A.Checked) { strResult21 = "A,"; }
            if (crdb21B.Checked) { strResult21 = "B,"; }
            if (crdb21C.Checked) { strResult21 = "C,"; }
            if (crdb21D.Checked) { strResult21 = "D,"; }
            if (crdb21E.Checked) { strResult21 = "E,"; }

            question21.QuestionResult = strResult21;
            question21.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".21";
            question21.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question21, QuestionnaireCode.KangFuShouShangZhi);

            //22
            M_QuestionnaireResultDetail question22 = new M_QuestionnaireResultDetail();
            string strResult22 = "";

            if (crdb22A.Checked) { strResult22 = "A,"; }
            if (crdb22B.Checked) { strResult22 = "B,"; }
            if (crdb22C.Checked) { strResult22 = "C,"; }
            if (crdb22D.Checked) { strResult22 = "D,"; }
            if (crdb22E.Checked) { strResult22 = "E,"; }

            question22.QuestionResult = strResult22;
            question22.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".22";
            question22.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question22, QuestionnaireCode.KangFuShouShangZhi);

            //23
            M_QuestionnaireResultDetail question23 = new M_QuestionnaireResultDetail();
            string strResult23 = "";

            if (crdb23A.Checked) { strResult23 = "A,"; }
            if (crdb23B.Checked) { strResult23 = "B,"; }
            if (crdb23C.Checked) { strResult23 = "C,"; }
            if (crdb23D.Checked) { strResult23 = "D,"; }
            if (crdb23E.Checked) { strResult23 = "E,"; }

            question23.QuestionResult = strResult23;
            question23.QuestionCode = QuestionnaireCode.KangFuShouShangZhi + ".23";
            question23.QuestionType = 1;

            ClientInfo.AddQuestionToQuestionnaire(question23, QuestionnaireCode.KangFuShouShangZhi);

            //第五页
            QuestionFive frmFive=new QuestionFive();
            frmFive.TopMost = false;
            frmFive.ShowDialog();
            Close();
        }
        //加载
        private void QuestionFour_Load(object sender, EventArgs e)
        {
            //18
            string answer18 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".18");
            if (answer18.Contains("A")) { crdb18A.Checked = true; }
            if (answer18.Contains("B")) { crdb18B.Checked = true; }
            if (answer18.Contains("C")) { crdb18C.Checked = true; }
            if (answer18.Contains("D")) { crdb18D.Checked = true; }
            if (answer18.Contains("E")) { crdb18E.Checked = true; }

            //19
            string answer19 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".19");
            if (answer19.Contains("A")) { crdb19A.Checked = true; }
            if (answer19.Contains("B")) { crdb19B.Checked = true; }
            if (answer19.Contains("C")) { crdb19C.Checked = true; }
            if (answer19.Contains("D")) { crdb19D.Checked = true; }
            if (answer19.Contains("E")) { crdb19E.Checked = true; }

            //20
            string answer20 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".20");
            if (answer20.Contains("A")) { crdb20A.Checked = true; }
            if (answer20.Contains("B")) { crdb20B.Checked = true; }
            if (answer20.Contains("C")) { crdb20C.Checked = true; }
            if (answer20.Contains("D")) { crdb20D.Checked = true; }
            if (answer20.Contains("E")) { crdb20E.Checked = true; }

            //21
            string answer21 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".21");
            if (answer21.Contains("A")) { crdb21A.Checked = true; }
            if (answer21.Contains("B")) { crdb21B.Checked = true; }
            if (answer21.Contains("C")) { crdb21C.Checked = true; }
            if (answer21.Contains("D")) { crdb21D.Checked = true; }
            if (answer21.Contains("E")) { crdb21E.Checked = true; }

            //22
            string answer22 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".22");
            if (answer22.Contains("A")) { crdb22A.Checked = true; }
            if (answer22.Contains("B")) { crdb22B.Checked = true; }
            if (answer22.Contains("C")) { crdb22C.Checked = true; }
            if (answer22.Contains("D")) { crdb22D.Checked = true; }
            if (answer22.Contains("E")) { crdb22E.Checked = true; }

            //23
            string answer23 = ClientInfo.GetAnswerByCode(QuestionnaireCode.KangFuShouShangZhi,
                QuestionnaireCode.KangFuShouShangZhi + ".23");
            if (answer23.Contains("A")) { crdb23A.Checked = true; }
            if (answer23.Contains("B")) { crdb23B.Checked = true; }
            if (answer23.Contains("C")) { crdb23C.Checked = true; }
            if (answer23.Contains("D")) { crdb23D.Checked = true; }
            if (answer23.Contains("E")) { crdb23E.Checked = true; }
        }
    }
}
