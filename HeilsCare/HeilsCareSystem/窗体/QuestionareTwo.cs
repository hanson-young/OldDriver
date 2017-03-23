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
    public partial class QuestionareTwo : Form
    {

        public QuestionareTwo(int type=0)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);      

            if(type==0)
            {
                
            }
            else if(type==1)
            {
                //从上一页来
                IntPtr ptrLoginForm = MainForm.FindWindow(null, "QuestionareOne");
                if (ptrLoginForm != IntPtr.Zero)
                {
                    MainForm.PostMessage(ptrLoginForm, 0x0010, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }

        private void QuestionareOne_Load(object sender, EventArgs e)
        {
           
        }

        private void QuestionareOne_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Pre_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Next_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Next_Click(object sender, EventArgs e)
        {
            QuestionareThree m_qsThree = new QuestionareThree(1);
            m_qsThree.ShowDialog();
        }

        private void Pre_Click(object sender, EventArgs e)
        {
            QuestionareOne m_qsOne = new QuestionareOne(2);
            m_qsOne.ShowDialog();
        }




    }
}
