using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace HeilsCareSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm(int type=0)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            if(type==0)
            {
                return;
            }
            else if(type==1)
            {
                //从注册页面打开的本界面  关掉注册页面
                IntPtr ptrLoginForm = MainForm.FindWindow(null, "Register");
                if (ptrLoginForm != IntPtr.Zero)
                {
                    MainForm.PostMessage(ptrLoginForm, 0x0010, IntPtr.Zero, IntPtr.Zero);
                }
            }
            
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 登录账号相关
        /// </summary>
        double phoneNum;
        private void txtQ2_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void txtQ2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ2.Text))
            {
                if (!double.TryParse(txtQ2.Text, out phoneNum))
                {
                    var msgBox = new CustomMessageBox("请输入正确的号码！");
                    msgBox.ShowDialog();
                    txtQ2.Text = string.Empty;
                    txtQ2.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        private void txtQ2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ2.Text) && phoneNum > 0)
                txtQ2.Text = phoneNum.ToString();
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        string password;
        private void PasswordText_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void PasswordText_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordText.Text))
            {
                password = PasswordText.Text;
            }
        }

        private void PasswordText_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordText.Text))
                PasswordText.Text = password.ToString();
        }

        /// <summary>
        /// 登录按钮实现根据账号密码登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(phoneNum<0)
            {
                CustomMessageBox m_err = new CustomMessageBox("账号输入有误，请重新输入");
                m_err.ShowDialog();
                return;
            }

            if(string.IsNullOrEmpty(password))
            {
                CustomMessageBox m_err = new CustomMessageBox("密码输入有误，请重新输入");
                m_err.ShowDialog();
                return;
            }

            Message m_message = new Message(MessageType.MSG_USER_LOGIN_IN);
            m_message.AddDouble(phoneNum);
            m_message.AddString(password);
            MainForm.m_pMainWnd.m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        public void EmptyPassWord()
        {
            PasswordText.Text = "";
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Back_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Message m_message = new Message(MessageType.MSG_SHOW_REGISTER_USER);
            MainForm.m_pMainWnd.m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void Register_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }


    }
}
