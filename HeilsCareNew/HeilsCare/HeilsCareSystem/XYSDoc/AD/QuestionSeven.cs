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
    public partial class QuestionSeven : BaseForm
    {
        public QuestionSeven()
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

            if (chkF.Checked) strResult += "F,";

            if (chkG.Checked) strResult += "G,";

            if (chkH.Checked) strResult += "H,";

            if (chkI.Checked) strResult += "I,";

            if (chkJ.Checked) strResult += "J,";


            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            question1.QuestionResult = strResult;

            question1.QuestionCode = QuestionnaireCode.NaoNianChiDai + ".7";
            question1.QuestionType = 2;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".7";

            //打分
            //第七题，辨认1词记1分，共10分，权重1.4
            int tempScore = 0;
            if (strResult.Contains("A")) tempScore += 1;
            if (strResult.Contains("B")) tempScore += 1;
            if (strResult.Contains("C")) tempScore += 1;
            if (strResult.Contains("D")) tempScore += 1;
            if (strResult.Contains("E")) tempScore += 1;
            if (strResult.Contains("F")) tempScore += 1;
            if (strResult.Contains("G")) tempScore += 1;
            if (strResult.Contains("H")) tempScore += 1;
            if (strResult.Contains("I")) tempScore += 1;
            if (strResult.Contains("J")) tempScore += 1;

            question1.QuestionScore = tempScore;//(decimal)(tempScore*1.4);
            question1.PQuestionWeightScore = (decimal)(tempScore * 1.4);

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);

            QuestionEight eight = new QuestionEight();
            eight.TopMost = false;
            //eight.Show();
            eight.Show();
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

            QuestionSix frmBefore = new QuestionSix();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionSeven_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".7");

            if (answer1.Contains("A")) chkA.Checked = true;

            if (answer1.Contains("B")) chkB.Checked = true;

            if (answer1.Contains("C")) chkC.Checked = true;

            if (answer1.Contains("D")) chkD.Checked = true;

            if (answer1.Contains("E")) chkE.Checked = true;

            if (answer1.Contains("F")) chkF.Checked = true;

            if (answer1.Contains("G")) chkG.Checked = true;

            if (answer1.Contains("H")) chkH.Checked = true;

            if (answer1.Contains("I")) chkI.Checked = true;

            if (answer1.Contains("J")) chkJ.Checked = true;
        }

        int iCounter = 120;
        private void tmCounter_Tick(object sender, EventArgs e)
        {
            
            if (iCounter <= 0)
            {
                return;
            }
            else
            {
                iCounter--;
                lblCounter.Text = iCounter.ToString();
            }
        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_7.m4a");
        }

        private void QuestionSeven_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }


    }
}
