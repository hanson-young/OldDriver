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
    public partial class Register : Form
    {
        private int gender = -1;

        public Register()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;       
        }

        private void image_OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQ2_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }
        //判断
        double age = 0;
        private void txtQ2_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtQ2.Text))
            {
                if (!double.TryParse(txtQ2.Text, out age))
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtQ2.Text = string.Empty;
                    txtQ2.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        private void txtQ2_Leave(object sender, EventArgs e)
        {
             if (!string.IsNullOrEmpty(txtQ2.Text) && age>0)
               txtQ2.Text = age.ToString();
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        double phoneNumRes = 0;
        private void phoneNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(phoneNum.Text))
            {
                if (!double.TryParse(phoneNum.Text, out phoneNumRes))
                {
                    var msgBox = new CustomMessageBox("请输入正确的号码！");
                    msgBox.ShowDialog();
                    phoneNum.Text = string.Empty;
                    phoneNum.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                }
            }
        }

        private void phoneNum_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(phoneNum.Text) && phoneNumRes > 0)
                phoneNum.Text = phoneNumRes.ToString();
        }

        private void phoneNum_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        /// <summary>
        /// 第一次密码
        /// </summary>
        string sfistPassword;
        private void firstPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(firstPassword.Text))
            {
                sfistPassword = firstPassword.Text;
            }
        }

        private void firstPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firstPassword.Text) )
                firstPassword.Text = sfistPassword.ToString();
        }

        private void firstPassword_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        string sSecondPassword;
        private void secondPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(secondPassword.Text))
            {
                sSecondPassword = secondPassword.Text;
            }
        }

        private void secondPassword_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(secondPassword.Text))
                secondPassword.Text = sSecondPassword.ToString();
        }

        private void secondPassword_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //检测手机号是否为空
            if(phoneNumRes<=0)
            {
                CustomMessageBox m_err = new CustomMessageBox("手机号有误，请重新输入");
                m_err.ShowDialog();
                return;
            }
            //检测两次密码是否相同
            if(sfistPassword!=sSecondPassword)
            {
                CustomMessageBox m_err = new CustomMessageBox("两次密码不同，请重新输入");
                m_err.ShowDialog();
                firstPassword.Text = string.Empty;
                secondPassword.Text = string.Empty;
                return;
            }

            Message m_message = new Message(MessageType.MSG_REGISTER_USER);
            m_message.AddDouble(phoneNumRes);
            m_message.AddString(sfistPassword);
            MainForm.m_pMainWnd.m_sharedDataAndMethod.SendMessage(m_message);
        }

        private void Male_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void feMale_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void btnRegister_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Male_Click(object sender, EventArgs e)
        {
            this.Male.BackgroundImage = Image.FromFile(System.Environment.CurrentDirectory + @"\Male2.PNG");
            gender = 0;
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            this.btnRegister.BackgroundImage = Image.FromFile(System.Environment.CurrentDirectory + @"\完成注册x面.PNG");
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            this.btnRegister.BackgroundImage = Image.FromFile(System.Environment.CurrentDirectory + @"\完成注册x线.PNG");
        }

        private void Back_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DirectLogin_Click(object sender, EventArgs e)
        {
            //跳转到login界面 
            LoginForm m_loginForm = new LoginForm(1);
            m_loginForm.ShowDialog();
        }
       



    }
}
