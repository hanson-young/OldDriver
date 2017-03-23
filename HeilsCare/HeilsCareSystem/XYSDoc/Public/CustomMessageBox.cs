using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Public
{
    public partial class CustomMessageBox : BaseForm
    {
        public CustomMessageBox(string content)
        {
            InitializeComponent();
            lblContent.Text=content;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
            //样式
            btnOk.BackColor = Color.FromArgb(44, 158, 41);
            btnOk.ForeColor = Color.White;
        }

        private void CustomMessageBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DimGray, 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}
