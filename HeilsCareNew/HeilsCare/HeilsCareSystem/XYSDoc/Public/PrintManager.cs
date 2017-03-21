using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.Public
{
    public class PrintManager
    {
        
        private static int number = 2;

        public static void SetBtnPrint(bool isFirst,Button btn,Timer timer)
        {
            if (isFirst)
            {
                btn.Font = new Font("宋体", 15);
                btn.Text = "正在打印";
                btn.Enabled = false;
                timer.Start();
            }
            else
            {
                btn.Font = new Font("宋体", 15);
                btn.Text = "正在打印(" + number + ")";

                if (number <= 0)
                {
                    btn.Font = new Font("宋体", 24);
                    btn.Text = "打印结果";
                    btn.Enabled = true;
                    number = 2;
                    timer.Stop();
                    return;
                }
                number -= 1;
            }
        }
    }
}
