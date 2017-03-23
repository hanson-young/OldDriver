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
    public partial class UserCenter : Form
    {
        public UserCenter()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
