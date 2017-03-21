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
    public partial class QuestionEight : BaseForm
    {
        public QuestionEight()
        {
            InitializeComponent();
            //richTextBox1.Select(48,5);
            //richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.Select(57, 3);
            //richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.Select(72, 5);
            //richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.Select(81, 3);
            //richTextBox1.SelectionColor = Color.Red;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }

            string strResult = "";

            if (rdPaobuA.Checked) strResult += "A,";
            if (rdPaobuB.Checked) strResult += "B,";
            if (rdAipaiC.Checked) strResult += "C,";
            if (rdAipaiD.Checked) strResult += "D,";
            if (rdLiliangE.Checked) strResult += "E,";
            if (rdLiliangF.Checked) strResult += "F,";
            if (rdJinshuG.Checked) strResult += "G,";
            if (rdJinshuH.Checked) strResult += "H,";
            if (rdYouxiI.Checked) strResult += "I,";
            if (rdYouxiJ.Checked) strResult += "J,";
            if (rdDaoliK.Checked) strResult += "K,";
            if (rdDaoliL.Checked) strResult += "L,";
            if (rdJiaoliuM.Checked) strResult += "M,";
            if (rdJiaoliuN.Checked) strResult += "N,";
            if (rdXingzhuangO.Checked) strResult += "O,";
            if (rdXingzhuangP.Checked) strResult += "P,";
            if (rdGuanxiQ.Checked) strResult += "Q,";
            if (rdGuanxiR.Checked) strResult += "R,";
            if (rdJiankangS.Checked) strResult += "S,";
            if (rdJiankangT.Checked) strResult += "T,";

            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            question1.QuestionResult = strResult;

            question1.QuestionCode = QuestionnaireCode.NaoNianChiDai + ".8";
            question1.QuestionType = 2;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".8";

            //打分
            //第八题，辨认1词记1分，共10分，权重0.2
            int tempScore = 0;
            if (strResult.Contains("B")) tempScore += 1;
            if (strResult.Contains("D")) tempScore += 1;
            if (strResult.Contains("E")) tempScore += 1;
            if (strResult.Contains("H")) tempScore += 1;
            if (strResult.Contains("I")) tempScore += 1;
            if (strResult.Contains("K")) tempScore += 1;
            if (strResult.Contains("N")) tempScore += 1;
            if (strResult.Contains("O")) tempScore += 1;
            if (strResult.Contains("R")) tempScore += 1;
            if (strResult.Contains("T")) tempScore += 1;

            question1.QuestionScore = tempScore;
            question1.PQuestionWeightScore = (decimal)(tempScore * 0.2);

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);

            QuestionNine night = new QuestionNine();
            night.TopMost = false;
            //night.Show();
            night.Show();
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
            QuestionSeven frmBefore = new QuestionSeven();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionEight_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".8");

            if (answer1.Contains("A")) rdPaobuA.Checked = true;
            if (answer1.Contains("B")) rdPaobuB.Checked = true;
            if (answer1.Contains("C")) rdAipaiC.Checked = true;
            if (answer1.Contains("D")) rdAipaiD.Checked = true;
            if (answer1.Contains("E")) rdLiliangE.Checked = true;
            if (answer1.Contains("F")) rdLiliangF.Checked = true;
            if (answer1.Contains("G")) rdJinshuG.Checked = true;
            if (answer1.Contains("H")) rdJinshuH.Checked = true;
            if (answer1.Contains("I")) rdYouxiI.Checked = true;
            if (answer1.Contains("J")) rdYouxiJ.Checked = true;
            if (answer1.Contains("K")) rdDaoliK.Checked = true;
            if (answer1.Contains("L")) rdDaoliL.Checked = true;
            if (answer1.Contains("M")) rdJiaoliuM.Checked = true;
            if (answer1.Contains("N")) rdJiaoliuN.Checked = true;
            if (answer1.Contains("O")) rdXingzhuangO.Checked = true;
            if (answer1.Contains("P")) rdXingzhuangP.Checked = true;
            if (answer1.Contains("Q")) rdGuanxiQ.Checked = true;
            if (answer1.Contains("R")) rdGuanxiR.Checked = true;
            if (answer1.Contains("S")) rdJiankangS.Checked = true;
            if (answer1.Contains("T")) rdJiankangT.Checked = true;
        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\AD-8-2.m4a");
        }

        private void QuestionEight_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            FirstFrm frmMain = new FirstFrm();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }


    }
}
