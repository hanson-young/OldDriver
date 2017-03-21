using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HeilsCareSystem
{
    public partial class GyNastic : Form
    {

        private GynasticVideo m_gynasticVideo = new GynasticVideo();
        public gifLib m_gifLibs = new gifLib(); 

        public GyNastic()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            AnimateImage image1;
            image1 = new AnimateImage(Image.FromFile(System.Environment.CurrentDirectory + "\\首页打开体操.gif"));
            image1.OnFrameChanged += new EventHandler(image_OnFrameChanged);
            image1.m_imageAnonyName = "首页打开体操";
            m_gifLibs.AddAnimateImage(image1);

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);      

        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void image_OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void GyNastic_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_gifLibs.GetGifCount(); i++)
                lock (m_gifLibs.GetImageByindex(i).Image)
                {
                      m_gifLibs.GetImageByindex(i).Play();
                }
        }

        private void GyNastic_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; (i < m_gifLibs.GetGifCount() && !m_gifLibs.GetImageByindex(i).m_isStoped); i++)
                lock (m_gifLibs.GetImageByindex(i).Image)
                {
                    e.Graphics.DrawImage(m_gifLibs.GetImageByindex(i).Image, new Point(0, 0));
                }

            if(m_gifLibs.GetImageByindex(0).m_isStoped)
            {
                //显示操作按钮
                Video.Visible = true;
                Game.Visible = true;
            }

        }

        private void Video_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Game_Click(object sender, EventArgs e)
        {
            GynasticGame m_gynasticGame = new GynasticGame();
            m_gynasticGame.ShowDialog();
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Video_Click(object sender, EventArgs e)
        {
            if (m_gynasticVideo != null)
            {
                m_gynasticVideo.ShowDialog();
                m_gynasticVideo = null;
            }
            else
            {
                m_gynasticVideo = new GynasticVideo();
                m_gynasticVideo.ShowDialog();
                m_gynasticVideo = null;
            }
        }


    }
}
