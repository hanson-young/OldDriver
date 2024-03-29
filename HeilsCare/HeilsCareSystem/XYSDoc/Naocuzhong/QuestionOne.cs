﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Naocuzhong
{
    public partial class QuestionOne : BaseForm
    {
        public QuestionOne()
        {
            InitializeComponent();
        }
        private void AddResult(M_QuestionnaireResultDetail result, string questionCode, int questionType)
        {
            result.QuestionCode = questionCode;
            result.QuestionType = questionType;
            ClientInfo.AddQuestionToQuestionnaire(result, QuestionnaireCode.NaoCuZhong);

        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();

            if (rd1A.Checked)
                question1.QuestionResult = "A,";
            if (rd1B.Checked)
                question1.QuestionResult = "B,";
            //question1.QuestionResult = rd1A.Checked ? "A," : "B,";
            AddResult(question1, QuestionnaireCode.NaoCuZhong + ".1",1);

            M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
            //question2.QuestionResult =dtpConfirm.Value.ToString() ;
            question2.QuestionResult = cbxYear.Text + "/" + cbxMonth.Text + "/" + cbxDay.Text+" "+DateTime.Now.TimeOfDay;
            AddResult(question2, QuestionnaireCode.NaoCuZhong + ".1.1", 3);

            M_QuestionnaireResultDetail question3 = new M_QuestionnaireResultDetail();

            if (rd2A.Checked)
                question3.QuestionResult = "A,";
            if (rd2B.Checked)
                question3.QuestionResult = "B,";

            //question3.QuestionResult = rd2A.Checked ? "A," : "B,";
            AddResult(question3, QuestionnaireCode.NaoCuZhong + ".1.2", 1);

            M_QuestionnaireResultDetail question4 = new M_QuestionnaireResultDetail();
            question4.QuestionResult = txtBlood.Text;
            AddResult(question4, QuestionnaireCode.NaoCuZhong + ".1.3", 3);

            QuestionTwo frmNext = new QuestionTwo();
            frmNext.TopMost = false;
            frmNext.ShowDialog();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FirstFrm frmMain = new FirstFrm();
            frmMain.TopMost = false;
            //frmMain.ShowDialog();
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
            btnBack_Click(this, e);
        }

        private void QuestionOne_Load(object sender, EventArgs e)
        {
            BindYear();
            BindMonth();
            BindDay();
            string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".1");
            string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".1.1");
            string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".1.2");
            string answer4 = ClientInfo.GetAnswerByCode(QuestionnaireCode.NaoCuZhong, QuestionnaireCode.NaoCuZhong + ".1.3");

            if (answer1.Contains("A")) rd1A.Checked = true;
            if (answer1.Contains("B")) rd1B.Checked = true;

            DateTime dateConfirm;
            DateTime.TryParse(answer2,out dateConfirm);
            //if (dateConfirm > DateTime.MinValue) dtpConfirm.Value = dateConfirm.Date;

            if (dateConfirm > DateTime.MinValue)
            {
                cbxYear.SelectedIndex = cbxYear.Items.IndexOf(dateConfirm.Year);
                cbxMonth.SelectedIndex = cbxMonth.Items.IndexOf(dateConfirm.Month);
                cbxDay.SelectedIndex = cbxDay.Items.IndexOf(dateConfirm.Day);
            }

            if (answer3.Contains("A")) rd2A.Checked = true;
            if (answer3.Contains("B")) rd2B.Checked = true;

            txtBlood.Text = answer4;
        }

        private void rd1A_CheckedChanged(object sender, EventArgs e)
        {
            if (rd1A.Checked) pYes.Visible = true;

            if (rd1B.Checked) pYes.Visible = false;

            pBlood.Visible = true;
        }

        private void BindYear()
        {
            int yearNow = DateTime.Now.Year;
            cbxYear.Items.Clear();

            for (int i = -5; i <= 5; i++)
            {
                cbxYear.Items.Add(yearNow + i);
            }

            cbxYear.SelectedIndex = cbxYear.Items.IndexOf(yearNow);
        }

        private void BindMonth()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbxMonth.Items.Add(i);
            }

            int month = DateTime.Now.Month;

            cbxMonth.SelectedIndex = cbxMonth.Items.IndexOf(month);
        }

        private void BindDay()
        {
            int day = DateTime.Now.Day;

            cbxDay.SelectedIndex = cbxDay.Items.IndexOf(day);
        }

        private void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(cbxYear.Text);
            int month = Convert.ToInt32(cbxMonth.Text);

            int days = DateTime.DaysInMonth(year,month);
            cbxDay.Items.Clear();
            for (int i = 1; i <= days; i++)
            {
                cbxDay.Items.Add(i);
            }
        }
    }
}
