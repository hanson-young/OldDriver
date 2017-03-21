using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Public
{
    public class CusBtnStyleCheckBox : CheckBox
    {
        public CusBtnStyleCheckBox()
        {
            Paint += new PaintEventHandler(this.PaintHandler);
            CheckedChanged += new EventHandler(CheckedHandler);
            FlatStyle = FlatStyle.Flat;
            Appearance = Appearance.Button;
            BackColor = Color.White;
            //Padding = new Padding(5, 1, 5, 1);
        }

        private void CheckedHandler(object sender, EventArgs e)
        {
            CheckBox cBox = (CheckBox)sender;

            if (cBox.Checked)
            {
                cBox.FlatStyle = FlatStyle.Flat;
                cBox.FlatAppearance.BorderColor = Color.OrangeRed;
                cBox.ForeColor = Color.OrangeRed;
                cBox.BackColor = Color.White;
            }
            else
            {
                cBox.FlatStyle = FlatStyle.Flat;
                cBox.FlatAppearance.BorderColor = SystemColors.ControlText;
                cBox.ForeColor = SystemColors.ControlText;
                cBox.BackColor = Color.White;
            }
        }

        private void PaintHandler(object sender, PaintEventArgs e)
        {
            CheckBox cBox = (CheckBox)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias; //抗锯齿处理

            if (cBox.Checked)
            {
                Point point1 = new Point(0, 0);
                Point point2 = new Point(18, 0);
                Point point3 = new Point(0, 18);
                Point[] pntArr = { point1, point2, point3 };
                g.FillPolygon(Brushes.OrangeRed, pntArr);

                g.DrawLine(new Pen(Color.White, 2), 2, 6, 5, 10);
                g.DrawLine(new Pen(Color.White, 2), 5, 10, 11, 2);
            }
        }
    }
}
