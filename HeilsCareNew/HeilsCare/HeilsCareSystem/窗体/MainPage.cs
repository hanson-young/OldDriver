using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeilsCareSystem
{
    public partial class MainPage : Form
    {
        private GameOne gameOne = new GameOne();
        private Register m_Register = new Register();
        private LoginForm m_LoginForm = new LoginForm();
        private GameTwo m_gameTwo = new GameTwo();
        private GameThree m_gameThree = new GameThree();

        public MainPage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOutSideMode_Click(object sender, EventArgs e)
        {
            if (gameOne != null)
            {
                gameOne.ShowDialog();
                gameOne = null;
            }
            else
            {
                gameOne = new GameOne();
                gameOne.ShowDialog();
                gameOne = null;
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if(m_Register!=null)
            {
                m_Register.ShowDialog();
                m_Register = null;
            }
            else
            {
                m_Register = new Register();
                m_Register.ShowDialog();
                m_Register = null;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (m_LoginForm != null)
            {
                m_LoginForm.ShowDialog();
                m_LoginForm = null;
            }
            else
            {
                m_LoginForm = new LoginForm();
                m_LoginForm.ShowDialog();
                m_LoginForm = null;
            }
        }

        private void btnSet_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Register_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void btnOutSideMode_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        public LoginForm GetLoginForm()
        {
            return m_LoginForm;
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void GameTwo_Click(object sender, EventArgs e)
        {
            if (m_gameTwo != null)
            {
                m_gameTwo.ShowDialog();
                m_gameTwo = null;
            }
            else
            {
                m_gameTwo = new GameTwo();
                m_gameTwo.ShowDialog();
                m_gameTwo = null;
            }
        }

        private void GameTwo_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void thirdGame_Click(object sender, EventArgs e)
        {
            if (m_gameThree != null)
            {
                m_gameThree.ShowDialog();
                m_gameThree = null;
            }
            else
            {
                m_gameThree = new GameThree();
                m_gameThree.ShowDialog();
                m_gameThree = null;
            }
        }

        private void thirdGame_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }
    }
}
