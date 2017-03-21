using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Player;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.AD
{
    public partial class QuestionFive : BaseForm
    {
        public QuestionFive()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
            //第五题，每答对一项记1分，共2分，权重1.4
            int tempScore = 0;

            string strResult = "";

            if (rd1A.Checked) strResult += "A,";
            if (rd1B.Checked) strResult += "B,";

            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            question1.QuestionResult = strResult;

            question1.QuestionCode = QuestionnaireCode.NaoNianChiDai + ".5.1";
            question1.QuestionType = 1;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".5";
            if (strResult.Contains("A"))
            {
                question1.QuestionScore = 1; //(decimal) (1*1.4);
                tempScore += 1;
            }
            else
            {
                question1.QuestionScore = 0;
            }

            //ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);


            if (rd2A.Checked) strResult = "A,";
            if (rd2B.Checked) strResult = "B,";

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();

            question2.QuestionResult = strResult;

            question2.QuestionCode = QuestionnaireCode.NaoNianChiDai + ".5.2";
            question2.QuestionType = 1;
            question2.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".5";

            if (strResult.Contains("A"))
            {
                question2.QuestionScore = 1; //(decimal) (1*1.4);
                tempScore += 1;
            }
            else
            {
                question2.QuestionScore = 0;
            }

            //ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.NaoNianChiDai);

            //计算所属大题加权分，保存答案
            decimal weightScore = Convert.ToDecimal(tempScore * 1.4);

            question1.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);

            question2.PQuestionWeightScore = weightScore;
            ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.NaoNianChiDai);

            QuestionSix six = new QuestionSix();
            six.TopMost = false;
            //six.Show();
            six.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FirstFrm frmMain = new FirstFrm();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new FirstFrm(), this);
            quitComfirmFrm.ShowDialog();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
            QuestionFourC frmBefore = new QuestionFourC();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionFive_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".5.1");

            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".5.2");

            if (answer1.Contains("A")) rd1A.Checked = true;

            if (answer1.Contains("B")) rd1B.Checked = true;

            if (answer2.Contains("A")) rd2A.Checked = true;

            if (answer2.Contains("B")) rd2B.Checked = true;
        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_5.m4a");
        }

        private void QuestionFive_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }
    }
}
