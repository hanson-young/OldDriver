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
    public partial class QuestionareFour : Form
    {

        public QuestionareFour()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);      

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
