using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace XYS.Remp.Screening.Public
{
    public class CustomRadioButton : RadioButton
    {
        // Fields 
        private Color checkColor;

        public CustomRadioButton()
        {
            this.checkColor = this.ForeColor;
            this.Paint += new PaintEventHandler(this.PaintHandler);

            this.TextChanged += CustomRadioButton_TextChanged;
        }

        int iBreak = 0;
        private void CustomRadioButton_TextChanged(object sender, EventArgs e)
        {
            if (iBreak > 0)
                return;
            else
            {
                iBreak++;
                //this.Text = "  " + this.Text;

            }
        }

        [Description("The color used to display the check painted in the RadioButton")]
        public Color CheckColor
        {
            get
            {
                return checkColor;
            }
            set
            {
                checkColor = value;
                this.Invalidate();
            }
        }

        private void PaintHandler(object sender, PaintEventArgs e)
        {

            RadioButton rButton = (RadioButton)sender;
            Graphics g = e.Graphics;
            Rectangle radioButtonrect = new Rectangle(0, 8, 18, 18);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //抗锯齿处理 

            //圆饼背景 
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillEllipse(brush, radioButtonrect);
            }


            if (rButton.Checked)
            {
                radioButtonrect.Inflate(-2, -2);//矩形内缩2单位 
                g.FillEllipse(Brushes.Black, radioButtonrect);
                radioButtonrect.Inflate(2, 2);//还原 
            }

            //圆形边框 
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawEllipse(pen, radioButtonrect);
            }

            #region;
            /*
            if (this.Checked)
            {
                Point pt = new Point();

                if (this.CheckAlign == ContentAlignment.BottomCenter)
                {
                    pt.X = (this.Width / 2) - 3;
                    pt.Y = this.Height - 9;
                }
                if (this.CheckAlign == ContentAlignment.BottomLeft)
                {
                    pt.X = 4;
                    pt.Y = this.Height - 9;
                }
                if (this.CheckAlign == ContentAlignment.BottomRight)
                {
                    pt.X = this.Width - 9;
                    pt.Y = this.Height - 9;
                }
                if (this.CheckAlign == ContentAlignment.MiddleCenter)
                {
                    pt.X = (this.Width / 2) - 3;
                    pt.Y = (this.Height / 2) - 3;
                }
                if (this.CheckAlign == ContentAlignment.MiddleLeft)
                {
                    pt.X = 4;
                    pt.Y = (this.Height / 2) - 3;
                }
                if (this.CheckAlign == ContentAlignment.MiddleRight)
                {
                    pt.X = this.Width - 9;
                    pt.Y = (this.Height / 2) - 3;
                }
                if (this.CheckAlign == ContentAlignment.TopCenter)
                {
                    pt.X = (this.Width / 2) - 3;
                    pt.Y = 4;
                }
                if (this.CheckAlign == ContentAlignment.TopLeft)
                {
                    pt.X = 4;
                    pt.Y = 4;
                }
                if (this.CheckAlign == ContentAlignment.TopRight)
                {
                    pt.X = this.Width - 9;
                    pt.Y = 4;
                }

                DrawCheck(pe.Graphics, this.checkColor, pt);
                */
            #endregion;
        }
  

        //public void DrawCheck(Graphics g, Color c, Point pt)
        //{
        //    Pen pen = new Pen(this.checkColor);
        //    g.DrawLine(pen, pt.X, pt.Y + 1, pt.X + 3, pt.Y + 1);
        //    g.DrawLine(pen, pt.X, pt.Y + 2, pt.X + 3, pt.Y + 2);
        //    g.DrawLine(pen, pt.X + 1, pt.Y, pt.X + 1, pt.Y + 3);
        //    g.DrawLine(pen, pt.X + 2, pt.Y, pt.X + 2, pt.Y + 3);

        //}
    }
}
