using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;


namespace XYS.Remp.Screening.Public
{
    public class CustomerCheckBox:CheckBox
    {
        public CustomerCheckBox()
        {
            this.Paint += new PaintEventHandler(this.PaintHandler);

            this.TextChanged += CustomerCheckBox_TextChanged;

        }

        int iBreak = 0;
        private void CustomerCheckBox_TextChanged(object sender, EventArgs e)
        {
            if (iBreak > 0)
                return;
            else
            {
                iBreak++;
                //this.Text = "  " + this.Text;
                
            }
            
        }

        private void PaintHandler(object sender, PaintEventArgs e)
        {

            CheckBox rButton = (CheckBox)sender;
            Graphics g = e.Graphics;
            Rectangle radioButtonrect = new Rectangle(0, 8, 18, 18);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //抗锯齿处理 

            //圆饼背景 
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                g.FillRectangle(brush, radioButtonrect);
            }


            if (rButton.Checked)
            {
                radioButtonrect.Inflate(-2, -2);//矩形内缩2单位 
                g.FillRectangle(Brushes.Black, radioButtonrect);
                radioButtonrect.Inflate(2, 2);//还原 
            }

            //圆形边框 
            using (Pen pen = new Pen(Color.Black))
            {
                g.DrawRectangle(pen, radioButtonrect);
            }

        }
    }
}
