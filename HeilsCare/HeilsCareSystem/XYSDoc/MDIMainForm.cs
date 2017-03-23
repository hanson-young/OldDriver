using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening
{
    public partial class MDIMainForm : BaseForm
    {
        public MDIMainForm()
        {
            InitializeComponent();
          
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
        }

        private void MDIMainForm_Load(object sender, EventArgs e)
        {
            //int iWhichQuestion = Properties.Settings.Default.ScreenSet;
            //switch (iWhichQuestion)
            //{
            //    case 1: //301老年痴呆筛查
            //        AD.FirstFrm frmAdFirst = new AD.FirstFrm();
            //        frmAdFirst.Show();
            //        frmAdFirst.TopMost = false;
            //        break;
            //    case 2://市二院脑卒中筛查
            //        Naocuzhong.FirstFrm naoFirst = new Naocuzhong.FirstFrm();
            //        naoFirst.Show();
            //        naoFirst.TopMost = false;
            //        break;
            //    case 3: //人民医院早癌筛查
            //        Zaoai.ScreeningZaoaiSelect frmZaoAi = new Zaoai.ScreeningZaoaiSelect();
            //        frmZaoAi.Show();
            //        frmZaoAi.TopMost = false;
            //        break;
            //    case 4://工伤康复筛查
            //        Kangfu.ScreeningSelect frmKangfu = new Kangfu.ScreeningSelect();
            //        frmKangfu.Show();
            //        frmKangfu.TopMost = false;
            //        break;
            //    default:
            //        break;
            //}

            //Program.frmMain.TopMost = false;
           // Program.frmMain.Show();
        }


        int iBackDoor = 0;
        private void MDIMainForm_DoubleClick(object sender, EventArgs e)
        {
            iBackDoor++;
            if (iBackDoor>=5)
            {
                //if (Program.frmMain!=null)
                //    Program.frmMain.Show();
            }
        }
    }
}
