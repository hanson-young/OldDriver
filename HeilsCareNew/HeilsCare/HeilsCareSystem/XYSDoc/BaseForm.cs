using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening
{
    public partial class BaseForm : Form
    {


        public BaseForm()
        {
            InitializeComponent();
            formTimer = new Timer() { Interval = 50 };
            formTimer.Tick += new EventHandler(formTimer_Tick);
            //base.Opacity = 0;
            this.FormBorderStyle = FormBorderStyle.None;

        }

        private Timer formTimer = null;


        /// <summary>
        /// 获取Opacity属性
        /// </summary>
        //[DefaultValue(0)]
        //[Browsable(false)]
        //public new double Opacity
        //{
        //    get { return base.Opacity; }
        //    set { base.Opacity = 0; }
        //}


        private void formTimer_Tick(object sender, EventArgs e)
        {
            //if (this.Opacity >= 1)
            //{
            //    formTimer.Stop();
            //}
            //else
            //{
            //    base.Opacity += 0.2;
            //}
        }


        private void BaseForm_Shown(object sender, EventArgs e)
        {
            formTimer.Start();
        }

        private int iBackDoor = 0;

        private void BaseForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            iBackDoor++;
            if (iBackDoor >= 5)
            {
                //if (Program.frmMain != null)
                //{
                //    Program.frmMain.Show();
                //    this.Close();
                //}



            }
        }

        private void RecursionCustomControl(Control.ControlCollection controls)
        {
            if (controls.Count > 0)
            {
                string name = controls[0].Parent.Text;
                if (name != "早癌筛查" && name != "ScreeningSelect" && name != "FirstFrm" && name != "LoginForm" && name != "注册第一步" && name != "注册第二步" && name != "注册第三步" && name != "DaChangResult" && name != "FeiaiResult" && name != "Result" && name != "ResultForm" && name != "RestulFrm" && !name.Equals("GanaiResult") && name != "RuxianResult" && name != "WeiAiResultForm" && name != "Paruria")
                {
                    foreach (Control controlChild in controls)
                    {
                        // 加入事件
                        if (controlChild.GetType().Name == "Button")
                        {
                            Button tb = (Button)controlChild;
                            if (!tb.Name.Equals("btnPlay") && !tb.Name.Equals("btnPrint") && !tb.Name.Equals("btnPrintPreview") && !tb.Name.Equals("btnExit") && !tb.Name.Equals("btnNext") && !tb.Name.Equals("btnBefore") && !tb.Name.Equals("btnZuHuai") && !tb.Name.Equals("btnJiZhu") && !tb.Name.Equals("btnLunYi") && !tb.Name.Equals("btnShouShangZhi") && !tb.Name.Equals("btnParuria") && !tb.Name.Equals("btnDiabetes") && !tb.Name.Equals("btnCopd") && !tb.Name.Equals("btnThah") && !tb.Name.Equals("btnWeiAi") && !tb.Name.Equals("btnRuXian") && !tb.Name.Equals("btnGaNai") && !tb.Name.Equals("btnFeiAi") && !tb.Name.Equals("btnDaChang") && !tb.Name.Equals("btnCalcBmi"))
                            {
                                tb.Click += new System.EventHandler(btnNext_Click);
                            }

                        }

                        if (controlChild.GetType().Name == "Panel")
                        {

                            RecursionCustomControl(controlChild.Controls);
                        }
                    }
                }
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Enabled = false;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            RecursionCustomControl(this.Controls);
        }
    }
}

