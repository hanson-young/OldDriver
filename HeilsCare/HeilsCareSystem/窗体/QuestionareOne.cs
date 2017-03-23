using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeilsCareSystem
{
    public partial class QuestionareOne : Form
    {

        public gifLib m_gifLibs = new gifLib(); 
        public QuestionareOne(int type=0)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);      


            if (type==0)
            {
                AnimateImage image1;
                image1 = new AnimateImage(Image.FromFile(System.Environment.CurrentDirectory + "\\首页打开问卷.gif"));
                image1.OnFrameChanged += new EventHandler(image_OnFrameChanged);
                image1.m_imageAnonyName = "首页打开问卷";
                m_gifLibs.AddAnimateImage(image1);
                //return;
            }
            else if(type==2)
            {
                //从下一页来  需要关闭下一页
                IntPtr ptrLoginForm = MainForm.FindWindow(null, "QuestionareTwo");
                if (ptrLoginForm != IntPtr.Zero)
                {
                    MainForm.PostMessage(ptrLoginForm, 0x0010, IntPtr.Zero, IntPtr.Zero);
                }
                aechm.Visible = true;
                naocu.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }


        private void image_OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void QuestionareOne_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_gifLibs.GetGifCount(); i++)
                lock (m_gifLibs.GetImageByindex(i).Image)
                {
                    m_gifLibs.GetImageByindex(i).Play();
                }
        }

        private void QuestionareOne_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; (i < m_gifLibs.GetGifCount() && !m_gifLibs.GetImageByindex(i).m_isStoped); i++)
                lock (m_gifLibs.GetImageByindex(i).Image)
                {
                    e.Graphics.DrawImage(m_gifLibs.GetImageByindex(i).Image, new Point(0, 0));
                }

            if (m_gifLibs.GetGifCount()>0 && m_gifLibs.GetImageByindex(0).m_isStoped)
            {
                //显示操作按钮
                aechm.Visible = true;
                naocu.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
            }
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Back_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aechm_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void naocu_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Next_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Next_Click(object sender, EventArgs e)
        {

            QuestionareTwo m_qsTwo = new QuestionareTwo(1);
            m_qsTwo.ShowDialog();

        }




    }
}
