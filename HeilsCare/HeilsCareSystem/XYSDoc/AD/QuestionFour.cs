using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Player;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.AD
{
    public partial class QuestionFour : BaseForm
    {
        //ScreeningServiceClient client = new ScreeningServiceClient();
        ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        enum MouseState
        {
            None = 0,
            MouseLeftDown = 1,
            MouseRightDown = 2,
        }

        private MouseState _MouseState = MouseState.None;

        public QuestionFour()
        {
            InitializeComponent();
          
        }

          void picBox_MouseUp(object sender, MouseEventArgs e)
        {
            _MouseState = MouseState.None;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.Refresh();
            }
        }

        void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _MouseState = MouseState.MouseLeftDown;
                return;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _MouseState = MouseState.MouseRightDown;
                return;
            }
        }

        private Point pLast;
        void picBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_MouseState == MouseState.None)
            {
                pLast = new Point(e.X, e.Y);
                return;
            }

            if (_MouseState == MouseState.MouseLeftDown)
            {
                Console.WriteLine(e.X + ", " + e.Y);

                //Graphics g = picBox.CreateGraphics();
                //g.DrawLine(new Pen(Color.Red, 1), new Point(e.X - 1, e.Y - 1), new Point(e.X, e.Y));
                //g.Dispose();

                Pen pen = new Pen(Color.Red, 1);
                Point pCurrent = new Point(e.X, e.Y);
                Graphics g = picBox.CreateGraphics();
                g.DrawLine(pen, pLast, pCurrent);
                pLast = pCurrent;
                g.Dispose();
                return;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }

            string strResult = "";

            if (rdA.Checked) strResult += "A,";

            if (rdB.Checked) strResult += "B,";

            //if (chkC.Checked) strResult += "C,";

            //if (chkD.Checked) strResult += "D,";

            //if (chkE.Checked) strResult += "E,";

            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            question1.QuestionResult = strResult;

            question1.QuestionCode = QuestionnaireCode.NaoNianChiDai + ".4";
            question1.QuestionType = 2;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".4";
            //打分，1分，权重2.0
            if (strResult.Contains("A"))
            {
                question1.QuestionScore = 1; 
                question1.PQuestionWeightScore = 1 * 2;
            }
            else
            {
                question1.QuestionScore = 0;
                question1.PQuestionWeightScore = 0;
            }

            ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.NaoNianChiDai);

            //更新第四大题权重分
            //如果已登录
            if (LoginInfo.GetInstance().UserId > 0)
            {
                M_QuestionnaireUserDetail questionnaireUserDetail = ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.NaoNianChiDai);
                var results = screenWebapiClient.GetQuestionnaireResultDetails(questionnaireUserDetail.QuestionnaireRecodId);
                if (results != null && results.Any())
                {
                    decimal tempWeightScore = 0;
                    decimal tempScore = 0;
                    foreach (var item in results)
                    {
                        if (item.QuestionCode.Contains("301AD.4"))
                        {
                            tempScore += item.QuestionScore;
                        }
                    }
                    tempWeightScore = tempScore * 2;
                    foreach (var item in results)
                    {
                        if (item.QuestionCode.Contains("301AD.4"))
                        {
                            screenWebapiClient.UpdateQuestionnaireResultWeightScore(tempWeightScore, item.QuestionnaireResultDetailId);
                        }
                    }
                    //MessageBox.Show(tempWeightScore.ToString());
                }
            }
            

            QuestionFourB nextFrom = new QuestionFourB();
            nextFrom.TopMost = false;
            //nextFrom.Show();
            nextFrom.Show();
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

            QuestionThree frmBefore = new QuestionThree();
            frmBefore.TopMost = false;
            frmBefore.Show();
            this.Close();
        }

        private void QuestionFour_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".4");

            if (answer1.Contains("A")) rdA.Checked = true;

            if (answer1.Contains("B")) rdB.Checked = true;

            //if (answer1.Contains("C")) chkC.Checked = true;

            //if (answer1.Contains("D")) chkD.Checked = true;

            //if (answer1.Contains("E")) chkE.Checked = true;

        }

        //播放
        private WMPlayerForm wmPlayerForm = null;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState = FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_4_1.m4a");
        }

        private void QuestionFour_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
        }


    }
}
