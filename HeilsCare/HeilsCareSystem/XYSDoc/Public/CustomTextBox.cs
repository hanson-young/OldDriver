using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Public
{
    public class CustomTextBox:TextBox
    {
        public CustomTextBox()
        {
            this.BorderStyle = BorderStyle.None;
            // BackColor也可以自己设置
            //this.BackColor = SystemColors.Control;
            //水平居中对齐
            TextAlign = HorizontalAlignment.Center;
        }

        private int WM_PAINT = 0x000F;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Pen pen = new Pen(Brushes.LightSeaGreen, 2.5f);
                using (Graphics g = this.CreateGraphics())
                {
                    g.DrawLine(pen, new Point(0, this.Size.Height - 1), new Point(this.Size.Width, this.Size.Height - 1));
                }
            }
        }
    }
}
