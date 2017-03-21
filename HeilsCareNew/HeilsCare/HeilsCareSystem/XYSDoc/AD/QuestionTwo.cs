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
    public partial class QuestionTwo : BaseForm
    {
        public QuestionTwo()
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
            //第二题，每答对一项记1分，共3分，权重2.0
            int tempScore = 0;
            string strResult1 = "";

            if (rd1A.Checked) strResult1 = "A,";
            if (rd1B.Checked) strResult1 = "B,";

            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
            question1.QuestionResult = strResult1;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".2";
            if (strResult1.Contains("A"))
            {
                question1.QuestionScore = 1; //1*2;
                tempScore += 1;
            }
            else
            {
                question1.QuestionScore = 0;
            }
            //AddResult(question1, QuestionnaireCode.NaoNianChiDai + ".2.1");


            string strResult2 = "";
            if (rd2A.Checked) strResult2 = "A,";
            if (rd2B.Checked) strResult2 = "B,";

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            question2.QuestionResult = strResult2;
            question2.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".2";
            if (strResult2.Contains("A"))
            {
                question2.QuestionScore = 1; //1*2;
                tempScore += 1;
            }
            else
            {
                question2.QuestionScore = 0;
            }
            //AddResult(question2, QuestionnaireCode.NaoNianChiDai + ".2.2");

            string strResult3 = "";
            if (rd3A.Checked) strResult3 = "A,";
            if (rd3B.Checked) strResult3 = "B,";

            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();
            question3.QuestionResult = strResult3;
            question3.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".2";
            if (strResult3.Contains("A"))
            {
                question3.QuestionScore = 1; //1*2;
                tempScore += 1;
            }
            else
            {
                question3.QuestionScore = 0;
            }
            //AddResult(question3, QuestionnaireCode.NaoNianChiDai + ".2.3");

            //计算所属大题加权分，保存答案
            decimal weightScore = tempScore*2;

            question1.PQuestionWeightScore = weightScore;
            AddResult(question1, QuestionnaireCode.NaoNianChiDai + ".2.1");

            question2.PQuestionWeightScore = weightScore;
            AddResult(question2, QuestionnaireCode.NaoNianChiDai + ".2.2");

            question3.PQuestionWeightScore = weightScore;
            AddResult(question3, QuestionnaireCode.NaoNianChiDai + ".2.3");

            QuestionThree frmNext = new QuestionThree();
            frmNext.TopMost = false;
            //frmNext.Show();
            frmNext.Show();
            this.Close();
        }

        private void AddResult(M_QuestionnaireResultDetail result, string questionCode)
        {
            result.QuestionCode = questionCode;
            result.QuestionType = 2;
            ClientInfo.AddQuestionToQuestionnaire(result, QuestionnaireCode.NaoNianChiDai);

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

            QuestionOne frmBefore = new QuestionOne();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionTwo_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".2.1");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".2.2");
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".2.3");

            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;

            if (answer2.Contains("A")) rd2A.Checked = true;
            if (answer2.Contains("B")) rd2B.Checked = true;

            if (answer3.Contains("A")) rd3A.Checked = true;
            if (answer3.Contains("B")) rd3B.Checked = true;

        }

        int iCount = 0;
        private void tmerPic_Tick(object sender, EventArgs e)
        {
            iCount++;
            if (iCount >= 10)
            {
                picOne.Visible = false;
                picTwo.Visible = false;
                picThree.Visible = false;
            }
        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_2.m4a");
        }

        private void QuestionTwo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }
    }
}
