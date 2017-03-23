using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Player
{
    public partial class WMPlayerTest : Form
    {
        public WMPlayerTest()
        {
            InitializeComponent();
        }

        private WMPlayerForm wmPlayerForm=null;

        private void btnPlay_Click(object sender, EventArgs e)
        {
            wmPlayerForm = WMPlayerForm.GetInstance();
            wmPlayerForm.Show();
            wmPlayerForm.Play(@"Resources\Sound\AD\ad_1.m4a");
        }

        private void WMPlayerTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            wmPlayerForm = null;
        }
    }
}
