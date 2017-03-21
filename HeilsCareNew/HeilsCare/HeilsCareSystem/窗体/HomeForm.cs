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
    public partial class HomeForm : Form
    {
        private GyNastic m_gynastic = new GyNastic();
        private UserCenter m_userCenter = new UserCenter();
        private QuestionareOne m_questionareOne=new QuestionareOne();

        public HomeForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void button3_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void DoGyNasTic_Click(object sender, EventArgs e)
        {
            if (m_gynastic != null)
            {
                m_gynastic.ShowDialog();
                m_gynastic = null;
            }
            else
            {
                m_gynastic = new GyNastic();
                m_gynastic.ShowDialog();
                m_gynastic = null;
            }
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void btnSet_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void userCenter_Click(object sender, EventArgs e)
        {
            if (m_userCenter != null)
            {
                m_userCenter.ShowDialog();
                m_userCenter = null;
            }
            else
            {
                m_userCenter = new UserCenter();
                m_userCenter.ShowDialog();
                m_userCenter = null;
            }
        }

        private void Questionare_Click(object sender, EventArgs e)
        {
            if (m_questionareOne != null)
            {
                m_questionareOne.ShowDialog();
                m_questionareOne = null;
            }
            else
            {
                m_questionareOne = new QuestionareOne();
                m_questionareOne.ShowDialog();
                m_questionareOne = null;
            }
        }

    }
}
