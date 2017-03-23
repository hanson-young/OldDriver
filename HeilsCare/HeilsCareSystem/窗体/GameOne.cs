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
    public partial class GameOne : Form
    {

        public gifLib m_gifLibs = new gifLib(); 
        public GameOne()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            AnimateImage image1;
            image1 = new AnimateImage(Image.FromFile(System.Environment.CurrentDirectory + "\\游戏方块1x1088.gif"));
            image1.OnFrameChanged += new EventHandler(image_OnFrameChanged);
            image1.m_imageAnonyName = "方块动图";
            m_gifLibs.AddAnimateImage(image1);


            AnimateImage image2;
            image2 = new AnimateImage(Image.FromFile(System.Environment.CurrentDirectory + "\\游戏过渡页面动图1x1088.gif"));
            image2.OnFrameChanged += new EventHandler(image_OnFrameChanged);
            image2.m_imageAnonyName = "卡通动图";
            m_gifLibs.AddAnimateImage(image2);

            AnimateImage image3;
            image3 = new AnimateImage(Image.FromFile(System.Environment.CurrentDirectory + "\\游戏文字x1088.gif"));
            image3.OnFrameChanged += new EventHandler(image_OnFrameChanged);
            image3.m_imageAnonyName = "文字动图";
            m_gifLibs.AddAnimateImage(image3);

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);      

        }


        private void image_OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void GameOne_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_gifLibs.GetGifCount(); i++)
                lock (m_gifLibs.GetImageByindex(i).Image)
                {
                    if (m_gifLibs.GetImageByindex(i).m_imageAnonyName != "文字动图")
                        m_gifLibs.GetImageByindex(i).Play();

                    if (m_gifLibs.GetImageByindex(i).m_imageAnonyName == "方块动图")
                    {
                        System.Timers.Timer t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；
                        t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
                        t.AutoReset = false;//设置是执行一次（false）还是一直执行(true)；
                        t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
                    }

                }
        }

        private void GameOne_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < m_gifLibs.GetGifCount(); i++)
                lock (m_gifLibs.GetImageByindex(i).Image)
                {
                    e.Graphics.DrawImage(m_gifLibs.GetImageByindex(i).Image, new Point(0, 0));
                }
        }

        public void theout(object source, System.Timers.ElapsedEventArgs e)
        {
            m_gifLibs.GetImageByName("文字动图").Play();
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }
    

    }
}
