using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Player;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.AD
{
    public partial class QuestionOne : BaseForm
    {
        public QuestionOne()
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
            //当前日期
            DateTime dateNow = DateTime.Today;

            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
            question1.QuestionResult = cbxWeek.Text;
            question1.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".1";
            //计算得分，权重0.8
            //判断星期
            DayOfWeek week = dateNow.DayOfWeek;
            string todayWeek = week.ToString();

            int tempScore = 0;

            switch (todayWeek)
            {
                case "Monday":
                    todayWeek = "星期一";
                    break;
                case "Tuesday":
                    todayWeek = "星期二";
                    break;
                case "Wednesday":
                    todayWeek = "星期三";
                    break;
                case "Thursday":
                    todayWeek = "星期四";
                    break;
                case "Friday":
                    todayWeek = "星期五";
                    break;
                case "Saturday":
                    todayWeek = "星期六";
                    break;
                case "Sunday":
                    todayWeek = "星期日";
                    break;
            }
            if (todayWeek.Equals(cbxWeek.Text))
            {
                question1.QuestionScore = 1; //Convert.ToDecimal(1*0.8);
                tempScore += 1;
            }
            else
            {
                question1.QuestionScore = 0;
            }
            //AddResult(question1, QuestionnaireCode.NaoNianChiDai + ".1.1");


            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            question2.QuestionResult = cbxDay1.Text;
            question2.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".1";
            //判断日期
            int tempDay = 0;
            int.TryParse(cbxDay1.Text, out tempDay);
            if (tempDay == dateNow.Day)
            {
                question2.QuestionScore = 1; //Convert.ToDecimal(1*0.8);
                tempScore += 1;
            }
            else
            {
                question2.QuestionScore = 0;
            }
            //AddResult(question2, QuestionnaireCode.NaoNianChiDai + ".1.2");

           // QuestionnaireResultDetail question3 = new QuestionnaireResultDetail();
           //// question3.QuestionResult = cbxDay2.Text;
           // AddResult(question3, QuestionnaireCode.NaoNianChiDai + ".1.3");

            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            question4.QuestionResult = cbxMonth.Text;
            question4.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".1";
            //判断月份
            if (cbxMonth.Text.Trim() == dateNow.Month.ToString())
            {
                question4.QuestionScore = 1; //Convert.ToDecimal(1*0.8);
                tempScore += 1;
            }
            else
            {
                question4.QuestionScore = 0;
            }
            //AddResult(question4, QuestionnaireCode.NaoNianChiDai + ".1.4");

            M_QuestionnaireResultDetail question5 = new M_QuestionnaireResultDetail();
            question5.QuestionResult = cbxSeason.Text;
            question5.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".1";
            //判断季节
            string strSeason = "";
            ChineseLunisolarCalendar season = new ChineseLunisolarCalendar();
            switch (season.GetMonth(dateNow))
            {
                case 1:
                case 2:
                case 3:
                    strSeason = "春";
                    break;
                case 4:
                case 5:
                case 6:
                    strSeason = "夏";
                    break;
                case 7:
                case 8:
                case 9:
                    strSeason = "秋";
                    break;
                case 10:
                case 11:
                case 12:
                    strSeason = "冬";
                    break;
            }
            if (cbxSeason.Text.Equals(strSeason))
            {
                question5.QuestionScore = 1; //Convert.ToDecimal(1*0.8);
                tempScore += 1;
            }
            else
            {
                question5.QuestionScore = 0;
            }
            //AddResult(question5, QuestionnaireCode.NaoNianChiDai + ".1.5");

            M_QuestionnaireResultDetail question6 = new M_QuestionnaireResultDetail();
            question6.QuestionResult = cbxYear.Text;
            question6.PQuestionCode = QuestionnaireCode.NaoNianChiDai + ".1";
            //判断年
            if (dateNow.Year.ToString() == cbxYear.Text)
            {
                question6.QuestionScore = 1;//Convert.ToDecimal(1*0.8);
                tempScore += 1;
            }
            else
            {
                question6.QuestionScore = 0;
            }
            //AddResult(question6, QuestionnaireCode.NaoNianChiDai + ".1.6");

            //计算所属大题加权分,保存答案
            decimal weightScore = Convert.ToDecimal(tempScore*0.8);

            question1.PQuestionWeightScore = weightScore;
            AddResult(question1, QuestionnaireCode.NaoNianChiDai + ".1.1");

            question2.PQuestionWeightScore = weightScore;
            AddResult(question2, QuestionnaireCode.NaoNianChiDai + ".1.2");

            question4.PQuestionWeightScore = weightScore;
            AddResult(question4, QuestionnaireCode.NaoNianChiDai + ".1.4");

            question5.PQuestionWeightScore = weightScore;
            AddResult(question5, QuestionnaireCode.NaoNianChiDai + ".1.5");

            question6.PQuestionWeightScore = weightScore;
            AddResult(question6, QuestionnaireCode.NaoNianChiDai + ".1.6");


            QuestionTwo frmTwo = new QuestionTwo();
            frmTwo.TopMost = false;
            frmTwo.Show();
            this.Close();
        }
        private void AddResult(M_QuestionnaireResultDetail result, string questionCode)
        {
            result.QuestionCode = questionCode;
            result.QuestionType = 3;
            ClientInfo.AddQuestionToQuestionnaire(result, QuestionnaireCode.NaoNianChiDai);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //停止播放
            if (wmPlayerForm != null)
            {
                wmPlayerForm.Stop();
            }
            FirstFrm frmMain = new FirstFrm();
            frmMain.TopMost = false;
            frmMain.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //ClientInfo.Logout();
            //btnBack_Click(this, e);

            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new FirstFrm(),this);
            quitComfirmFrm.ShowDialog();
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            btnBack_Click(this, e);
        }

        private void QuestionOne_Load(object sender, EventArgs e)
        {
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.1");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.2");
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.3");
            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.4");
            string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.5");
            string answer6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoNianChiDai, QuestionnaireCode.NaoNianChiDai + ".1.6");

            BindYear();
            cbxWeek.Text = answer1;
            cbxDay1.Text = answer2;
            //cbxDay2.Text = answer3;
            cbxMonth.Text = answer4;
            cbxSeason.Text = answer5;
            cbxYear.Text = answer6;

        }

        private void BindYear()
        {
            int yearNow = DateTime.Now.Year;
            cbxYear.Items.Clear();

            for (int i = -5; i <= 5; i++)
            {
                cbxYear.Items.Add(yearNow + i);
            }
        }

        private WMPlayerForm wmPlayerForm = null;
        //播放文件
        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            //wmPlayerForm = new WMPlayerForm();
            wmPlayerForm.Show();
            wmPlayerForm.WindowState=FormWindowState.Minimized;
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_1.m4a");
        }

        private void QuestionOne_FormClosing(object sender, FormClosingEventArgs e)
        {
            //停止播放
            if (wmPlayerForm!=null)
            {
                wmPlayerForm.Stop();
            }
        }
    }
}
