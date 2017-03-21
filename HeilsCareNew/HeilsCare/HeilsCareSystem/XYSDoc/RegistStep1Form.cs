using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Services;


namespace XYS.Remp.Screening
{
    public partial class RegistStep1Form : XYS.Remp.Screening.BaseForm
    {
        //手机号码
        string pattern = "^1\\d{10}$";
        //匹配固定电话
        string phone = "^(0[0-9]{2,3}\\-)?([2-9][0-9]{6,7})+(\\-[0-9]{1,4})?$";
        //小灵通
        string xiaoLt = "^0[0-9]{9,11}$";

        //ScreeningServiceClient client = new ScreeningServiceClient();

        ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        /// <summary>
        /// 生成账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        private string CreateAccount(string account)
        {
            //client = new ScreeningServiceClient();
            screenWebapiClient = new ScreenWebapiClient();

            string prototype = account;
            string result = string.Empty;
            //存在则生成账号
            Random random = new Random();
            int number = random.Next(100, 999);

            account += "-" + number;
            bool had = screenWebapiClient.GetUserInfoByAccount(account);
            //client.Close();
            if (had)
            {
                result = CreateAccount(prototype);
            }
            else
            {
                result = account;
            }
            return result;
        }

        public RegistStep1Form(string account,string mobile,string password)
        {
            InitializeComponent();
            txtPhone.Text = mobile.Trim();
            txtAccount.Text = account.Trim();
            txtPwd.Text = password.Trim();

            #region 是否需要生成账号

            if (!string.IsNullOrEmpty(mobile))
            {
                //判断账号是否存在,此时mobile和账号相同
                //bool isSucess = client.GetUserInfoByAccount(mobile);
                bool isSucess = screenWebapiClient.GetUserInfoByAccount(mobile);
                if (isSucess)
                {
                    //存在则生成
                    txtAccount.Text = CreateAccount(mobile);
                }
                else
                {
                    txtAccount.Text = mobile;
                }
            }
            #endregion


            if (!string.IsNullOrEmpty(mobile))
            {
                //截取密码
                //手机
                if (Regex.IsMatch(txtPhone.Text, pattern, RegexOptions.IgnoreCase))
                {
                    txtPwd.Text = !string.IsNullOrEmpty(txtPhone.Text) ? txtPhone.Text.Substring(5, 6) : "";
                }
                //固话
                if (Regex.IsMatch(txtPhone.Text, phone, RegexOptions.IgnoreCase))
                {
                    if (!string.IsNullOrEmpty(txtPhone.Text))
                    {
                        if (txtPhone.Text.Contains('-') && txtPhone.Text.Length == 13)
                        {
                            txtPwd.Text = txtPhone.Text.Substring(7, 6);
                        }
                        else if (txtPhone.Text.Contains('-') && txtPhone.Text.Length == 12)
                        {
                            txtPwd.Text = txtPhone.Text.Substring(6, 6);
                        }
                        else if (txtPhone.Text.Length == 8)
                        {
                            txtPwd.Text = txtPhone.Text.Substring(2, 6);
                        }
                        else if (txtPhone.Text.Length == 7)
                        {
                            txtPwd.Text = txtPhone.Text.Substring(1, 6);
                        }
                    }
                }
                //小灵通
                if (Regex.IsMatch(txtPhone.Text, xiaoLt, RegexOptions.IgnoreCase))
                {
                    if (!string.IsNullOrEmpty(txtPhone.Text))
                    {
                        if (txtPhone.Text.Length == 8)
                        {
                            txtPwd.Text = txtPhone.Text.Substring(2, 6);
                        }
                        else if (txtPhone.Text.Length == 7)
                        {
                            txtPwd.Text = txtPhone.Text.Substring(0, 6);
                        }
                    }
                }
            }
        }

        //private ScreeningServiceClient _client = null;
        //private void btnGetCode_Click(object sender, EventArgs e)
        //{
        //    string mobile = this.txtPhone.Text;
        //    if (string.IsNullOrEmpty(mobile))
        //    {
        //        //MessageBox.Show("请输入手机号!");
        //        lblMsg.Text = "请输入手机号!";
        //        return;
        //    }

        //    string _Pattern = "^1\\d{10}$";

        //    if (!Regex.IsMatch(mobile, _Pattern, RegexOptions.IgnoreCase))
        //    {
        //        //MessageBox.Show("请输入正确格式的手机号码!");
        //        lblMsg.Text = "请输入正确格式的手机号码!";
        //        return;
        //    }
        //    _client = new ScreeningServiceClient();
        //    M_Msg message = _client.GetSmsValidCode(mobile);
        //    if (message.IsSuccss)
        //    {
        //        //MessageBox.Show("发送验证码成功!");
        //        lblMsg.Text = "发送验证码成功!";
        //        txtCode.Focus();
        //    }
        //}

        private void btnNext_Click(object sender, EventArgs e)
        {
            //client = new ScreeningServiceClient();
            //string code = this.txtCode.Text;
            string mobile = this.txtPhone.Text.Trim();

            //账号、密码
            string account = this.txtAccount.Text.Trim();
            string pwd = this.txtPwd.Text.Trim();
            //string password = this.txtPassword.Text;

            if (string.IsNullOrEmpty(mobile))
            {
                //MessageBox.Show("请输入手机号!");
                lblMsg.Text = "请您输入手机号!";
                return;
            }

            

            if (!Regex.IsMatch(mobile, pattern, RegexOptions.IgnoreCase) && !Regex.IsMatch(mobile, phone, RegexOptions.IgnoreCase) && !Regex.IsMatch(mobile, xiaoLt, RegexOptions.IgnoreCase))
            {
                lblMsg.Text = "请您输入正确的手机号码、固定电话或小灵通!";
                return;
            }

            if (string.IsNullOrEmpty(account))
            {
                //MessageBox.Show("请输入账号！");
                lblMsg.Text = "请您输入账号！";
                return;
            }

            if (string.IsNullOrEmpty(pwd))
            {
                //MessageBox.Show("请输入密码！");
                lblMsg.Text = "请您输入密码！";
                return;
            }

            //if (string.IsNullOrEmpty(password))
            //{
            //    //MessageBox.Show("请输入确认密码");
            //    lblMsg.Text = "请输入确认密码！";
            //    return;
            //}

            //if (pwd != password)
            //{
            //    //MessageBox.Show("两次密码输入不同,请重新输入确认密码");
            //    lblMsg.Text = "两次密码输入不同,请重新输入确认密码！";
            //    this.txtPassword.Text = "";
            //    return;
            //}


            //bool isSucess = client.GetUserInfoByAccount(account);
            bool isSucess = screenWebapiClient.GetUserInfoByAccount(account);
            if (isSucess)
            {
                //MessageBox.Show("账号已存在");
                lblMsg.Text = "登录账号已存在";
                return;
            }
            else
            {
                var registStep3Form = new registSetp3(account, pwd, mobile);
                registStep3Form.TopMost = false;
                registStep3Form.Show();
                this.Close();
            }

            //if (string.IsNullOrEmpty(code))
            //{
            //    //MessageBox.Show("请输入验证码!");
            //    lblMsg.Text = "请输入验证码!";
            //    return;
            //}
         
            //if (cbCheck.Checked)
            //{
                //_client = new ScreeningServiceClient();
                //M_Msg result=_client.CheckSmsValidCode(mobile, code);
                //if (result.IsSuccss)
                //{
                    //去往第二个页面
                    //RegistStep2Form registStep2Form = new RegistStep2Form(mobile);
                    //registStep2Form.TopMost = false;
                    //registStep2Form.Show();
                    //this.Close();

                //}
                //else
                //{
                //    //MessageBox.Show("验证码验证失败!");
                //    lblMsg.Text = "验证码验证失败!";
                //}
            //}
            //else
            //{
            //    MessageBox.Show("您是否同意注册条款?");
            //    lblMsg.Text = "您是否同意注册条款?";
            //    return;
            //}
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //LoginForm frmMain = new LoginForm();
            //frmMain.Show();
            //this.Close();

            //LoginFormNew loginFormNew = new LoginFormNew();
            //loginFormNew.Show();
            Close();

        }

        private void cbCheck_CheckedChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = true;
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            //client = new ScreeningServiceClient();

            string mobile = this.txtPhone.Text.Trim();
            if (string.IsNullOrEmpty(mobile))
            {
                lblMsg.Text = "请您输入手机号!";
                return;
            }

            if (!Regex.IsMatch(mobile, pattern, RegexOptions.IgnoreCase) && !Regex.IsMatch(mobile, phone, RegexOptions.IgnoreCase) && !Regex.IsMatch(mobile, xiaoLt, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("请您输入正确的手机号码、固定电话或小灵通!");
                return;
            }

            txtPhone.Text = mobile;

            #region 是否需要生成账号

            //判断账号是否存在,此时mobile和账号相同
            //bool isSucess = client.GetUserInfoByAccount(mobile);
            bool isSucess = screenWebapiClient.GetUserInfoByAccount(mobile);
            if (isSucess)
            {
                //存在则生成
                txtAccount.Text = CreateAccount(mobile);
            }
            else
            {
                txtAccount.Text = mobile;
            }

            #endregion

            //txtAccount.Text = txtPhone.Text;
            //截取密码
            //手机
            if (Regex.IsMatch(mobile, pattern, RegexOptions.IgnoreCase))
            {
                txtPwd.Text = !string.IsNullOrEmpty(mobile) ? txtPhone.Text.Substring(5, 6) : "";
            }
            //固话
            if (Regex.IsMatch(mobile, phone, RegexOptions.IgnoreCase))
            {
                if (!string.IsNullOrEmpty(mobile))
                {
                    if (mobile.Contains('-') && mobile.Length == 13)
                    {
                        txtPwd.Text = mobile.Substring(7, 6);
                    }
                    else if (mobile.Contains('-') && mobile.Length == 12)
                    {
                        txtPwd.Text = mobile.Substring(6, 6);
                    }
                    else if (mobile.Length == 8)
                    {
                        txtPwd.Text = mobile.Substring(2, 6);
                    }
                    else if (mobile.Length == 7)
                    {
                        txtPwd.Text = mobile.Substring(1, 6);
                    }
                }
            }
            //小灵通
            if (Regex.IsMatch(mobile, xiaoLt, RegexOptions.IgnoreCase))
            {
                if (!string.IsNullOrEmpty(mobile))
                {
                    if (mobile.Length == 8)
                    {
                        txtPwd.Text = mobile.Substring(2, 6);
                    }
                    else if (mobile.Length == 7)
                    {
                        txtPwd.Text = mobile.Substring(0, 6);
                    }
                }
            }


            lblMsg.Text = "";
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////数字0~9所对应的keychar为48~57，小数点是46，Backspace是8  
            //e.Handled = true;
            ////输入0-9和Backspace del 有效  
            //if ((e.KeyChar >= 47 && e.KeyChar <= 58) || e.KeyChar == 8)
            //{
            //    e.Handled = false;
            //}
        }
    }
}
