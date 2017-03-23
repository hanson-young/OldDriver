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
    public partial class QuestionareThree : Form
    {

        public QuestionareThree(int type=0)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);      

            if(type==0)
            {
                return;
            }
            else if(type==1)
            {
                //从上一页来
                IntPtr ptrLoginForm = MainForm.FindWindow(null, "QuestionareTwo");
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




    }
}
