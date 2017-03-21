using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Public
{
    public class CusBtnStyleRadioButton : RadioButton
    {
        public CusBtnStyleRadioButton()
        {
            Paint += new PaintEventHandler(this.PaintHandler);
            CheckedChanged += new EventHandler(CheckedHandler);
            FlatStyle = FlatStyle.Flat;
            Appearance = Appearance.Button;
            BackColor = Color.White;
            //Padding = new Padding(10, 5, 10, 5);
        }

        private void CheckedHandler(object sender, EventArgs e)
        {
            RadioButton rButton = (RadioButton)sender;

            if (rButton.Checked)
            {
                rButton.FlatStyle = FlatStyle.Flat;
                rButton.FlatAppearance.BorderColor = Color.OrangeRed;
                rButton.ForeColor = Color.OrangeRed;
                rButton.BackColor = Color.White;
            }
            else
            {
                rButton.FlatStyle = FlatStyle.Flat;
                rButton.FlatAppearance.BorderColor = SystemColors.ControlText;
                rButton.ForeColor = SystemColors.ControlText;
                rButton.BackColor = Color.White;
            }
        }

        private void PaintHandler(object sender, PaintEventArgs e)
        {
            RadioButton rButton = (RadioButton)sender;

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias; //抗锯齿处理

            if (rButton.Checked)
            {
                //Point point1 = new Point(0, 0);
                //Point point2 = new Point(25, 0);
                //Point point3 = new Point(0, 25);
                //Point[] pntArr = { point1, point2, point3 };
                //g.FillPolygon(Brushes.OrangeRed, pntArr);

                //g.DrawLine(new Pen(Color.White,2),3,7,8,11);
                //g.DrawLine(new Pen(Color.White,2), 8, 11, 15, 2);

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
