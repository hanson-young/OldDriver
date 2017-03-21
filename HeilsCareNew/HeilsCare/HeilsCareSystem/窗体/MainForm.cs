using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;  
using HeilsCareSystem;
using System.Reflection;
using System.Runtime.InteropServices;

namespace HeilsCareSystem
{
    public partial class MainForm : Form
    {      
        public string BaseDirectory = System.Environment.CurrentDirectory;
        public static bool m_bIsCheckedUpdate = false;
        public SharedDataAndMethod m_sharedDataAndMethod = new SharedDataAndMethod();
        public static MainForm m_pMainWnd = new MainForm();
        public static MainForm m_pMainWndTemp = new MainForm();
        private MainPage m_mainPage = new MainPage();
        public HomeForm m_homePage = new HomeForm();
        private SettingS m_settrings = new SettingS();
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string a, string b);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);


        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void image_OnFrameChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if(m_settrings!=null)
            {
                m_settrings.ShowDialog();
            }
        }

        private void btnOutSideMode_Click(object sender, EventArgs e)
        {
            if(m_mainPage!=null)
            {
                m_mainPage.ShowDialog();
            }
        }

        private void btnInsideMode_Click(object sender, EventArgs e)
        {
            if (m_mainPage != null)
            {
                m_mainPage.ShowDialog();
            }
        }

        public void HideFocusCues(Control control)
        {
            Type vType = typeof(Control);
            FieldInfo vFieldInfo = vType.GetField("uiCuesState",
             BindingFlags.Instance | BindingFlags.Public |
             BindingFlags.NonPublic | BindingFlags.Static |
             BindingFlags.FlattenHierarchy);
            vFieldInfo.SetValue(control, 15);
        }

        private void btnOutSideMode_Paint(object sender, PaintEventArgs e)
        {
            HideFocusCues((Control)sender);
        }

        private void btnInsideMode_Paint(object sender, PaintEventArgs e)
        {
            HideFocusCues((Control)sender);
        }

        private void btnSet_Paint(object sender, PaintEventArgs e)
        {
            HideFocusCues((Control)sender);
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            HideFocusCues((Control)sender);
        }
       
        public MainPage GetMainPage()
        {
            return m_mainPage;
        }

        private void mainExit_Paint_1(object sender, PaintEventArgs e)
        {
            HideFocusCues((Control)sender);
        }

    }
}
