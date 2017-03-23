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
    public partial class QuestionNine : BaseForm
    {
        public QuestionNine()
        {
            InitializeComponent();

            //richTextBox1.Select(57,5);
            //richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.Select(66,3);
            //richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.Select(81,5);
            //richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.Select(90, 3);
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

            if (rdFuwuA.Checked) strResult += "A,";
            if (rdFuwuB.Checked) strResult += "B,";
            if (rdLianheC.Checked) strResult += "C,";
            if (rdLianheD.Checked) strResult += "D,";
            if (rdCaichanE.Checked) strResult += "E,";
            if (rdCaichanF.Checked) strResult += "F,";
            if (rdTounaiG.Checked) strResult += "G,";
            if (rdTounaiH.Checked) strResult += "H,";
            if (rdGequI.Checked) strResult += "I,";
            if (rdGequJ.Checked) strResult += "J,";
            if (rdXiaoxiK.Checked) strResult += "K,";
            if (rdXiaoxiL.Checked) strResult += "L,";
            if (rdTuxiangM.Checked) strResult += "M,";
            if (rdTuxiangN.Checked) strResult += "N,";
            if (rdTianqiO.Checked) strResult += "O,";
            if (rdTianqiP.Checked) strResult += "P,";
            if (rdShangxueQ.Checked) strResult += "Q,";
            if (rdShangxueR.Checked) strResult += "R,";
            if (rdShenyinS.Checked) strResult += "S,";
            if (rdShenyinT.Checked) strResult += "T,";


            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            question1.QuestionResult = strResult;

            question1.QuestionCode = QuestionnaireCode.NaoNianChiDai + ".9";
            question1.QuestionType = 2;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".9";
            //打分
            //第九题，辨认1词记1分，共10分，权重1.4
            int tempScore = 0;
            if (strResult.Contains("A")) tempScore += 1;
            if (strResult.Contains("D")) tempScore += 1;
            if (strResult.Contains("E")) tempScore += 1;
            if (strResult.Contains("H")) tempScore += 1;
            if (strResult.Contains("J")) tempScore += 1;
            if (strResult.Contains("K")) tempScore += 1;
            if (strResult.Contains("N")) tempScore += 1;
            if (strResult.Contains("O")) tempScore += 1;
            if (strResult.Contains("Q")) tempScore += 1;
            if (strResult.Contains("T")) tempScore += 1;

            question1.QuestionScore = tempScore;
            question1.PQuestionWeightScore = (decimal)(tempScore * 1.4);

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);

            Result result = new Result();
            result.TopMost = false;
            //result.Show();
            result.Show();
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
            QuestionEight frmBefore = new QuestionEight();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionNine_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".9");

            if (answer1.Contains("A")) rdFuwuA.Checked = true;
            if (answer1.Contains("B")) rdFuwuB.Checked = true;
            if (answer1.Contains("C")) rdLianheC.Checked = true;
            if (answer1.Contains("D")) rdLianheD.Checked = true;
            if (answer1.Contains("E")) rdCaichanE.Checked = true;
            if (answer1.Contains("F")) rdCaichanF.Checked = true;
            if (answer1.Contains("G")) rdTounaiG.Checked = true;
            if (answer1.Contains("H")) rdTounaiH.Checked = true;
            if (answer1.Contains("I")) rdGequI.Checked = true;
            if (answer1.Contains("J")) rdGequJ.Checked = true;

            if (answer1.Contains("K")) rdXiaoxiK.Checked = true;
            if (answer1.Contains("L")) rdXiaoxiL.Checked = true;
            if (answer1.Contains("M")) rdTuxiangM.Checked = true;
            if (answer1.Contains("N")) rdTuxiangN.Checked = true;
            if (answer1.Contains("O")) rdTianqiO.Checked = true;
            if (answer1.Contains("P")) rdTianqiP.Checked = true;
            if (answer1.Contains("Q")) rdShangxueQ.Checked = true;
            if (answer1.Contains("R")) rdShangxueR.Checked = true;
            if (answer1.Contains("S")) rdShenyinS.Checked = true;
            if (answer1.Contains("T")) rdShenyinT.Checked = true;
        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\AD-9-2.m4a");
        }

        private void QuestionNine_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }
    }
}
