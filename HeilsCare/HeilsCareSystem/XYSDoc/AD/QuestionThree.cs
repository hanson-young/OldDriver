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
    public partial class QuestionThree : BaseForm
    {
        public QuestionThree()
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

            string strResult = "";

            if (chkA.Checked) strResult += "A,";

            if (chkB.Checked) strResult += "B,";

            if (chkC.Checked) strResult += "C,";

            if (chkD.Checked) strResult += "D,";

            if (chkE.Checked) strResult += "E,";

            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            question1.QuestionResult = strResult;

            question1.QuestionCode = QuestionnaireCode.NaoNianChiDai + ".3";
            question1.QuestionType = 2;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".3";
            //第三题，每答对一项记1分，共5分，权重1.8
            int tempScore = 0;
            if (strResult.Contains("A")) tempScore += 1;

            if (strResult.Contains("B")) tempScore += 1;

            if (strResult.Contains("C")) tempScore += 1;

            if (strResult.Contains("D")) tempScore += 1;

            if (strResult.Contains("E")) tempScore += 1;

            question1.QuestionScore = tempScore;
            question1.PQuestionWeightScore = (decimal)(tempScore * 1.8);

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);

            QuestionFour form = new QuestionFour();
            form.TopMost = false;
            //form.Show();
            form.Show();
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

            QuestionTwo frmBefore = new QuestionTwo();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionThree_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".3");

            if (answer1.Contains("A")) chkA.Checked = true;
            if (answer1.Contains("B")) chkB.Checked = true;
            if (answer1.Contains("C")) chkC.Checked = true;
            if (answer1.Contains("D")) chkD.Checked = true;
            if (answer1.Contains("E")) chkE.Checked = true;

        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_3.m4a");
        }

        private void QuestionThree_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }
    }
}
