using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Services;

namespace XYS.Remp.Screening
{
    public partial class RegistStep2Form : XYS.Remp.Screening.BaseForm
    {
        private string phone = "";
        public RegistStep2Form(string mobile)
        {
            InitializeComponent();
            phone = mobile;
            this.txtAccount.Text = phone;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string account = this.txtAccount.Text;
            string pwd = this.txtPwd.Text;
            string password = this.txtPassword.Text;
            if (string.IsNullOrEmpty(account))
            {
                //MessageBox.Show("请输入账号！");
                lblMsg.Text = "请输入账号！";
                return;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                //MessageBox.Show("请输入密码！");
                lblMsg.Text = "请输入密码！";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                //MessageBox.Show("请输入确认密码");
                lblMsg.Text = "请输入确认密码！";
                return;
            }

            if (pwd != password)
            {
                //MessageBox.Show("两次密码输入不同,请重新输入确认密码");
                lblMsg.Text = "两次密码输入不同,请重新输入确认密码！";
                this.txtPassword.Text = "";
                return;
            }

            ScreeningServiceClient client = new ScreeningServiceClient();
           bool isSucess= client.GetUserInfoByAccount(txtAccount.Text);
            if (isSucess)
            {
                //MessageBox.Show("账号已存在");
                lblMsg.Text = "账号已存在";
                return;
            }
            else
            {
                var registStep3Form = new registSetp3(account, pwd,"");
                registStep3Form.TopMost = false;
                registStep3Form.Show();
                this.Close();
            }
        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            var registStep1Form = new RegistStep1Form("","","");
            registStep1Form.TopMost = false;
            registStep1Form.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm frmMain = new LoginForm();
            frmMain.Show();
            this.Close();
        }
    }
}
