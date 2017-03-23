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
    public partial class SettingS : Form
    {
        public SettingS()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void mainExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mainExit_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void btnHandle_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void Back_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private void btnWifi_Paint(object sender, PaintEventArgs e)
        {
            MainForm.m_pMainWnd.HideFocusCues((Control)sender);
        }

        private bool wifiOn = true;
        private void btnWifi_Click(object sender, EventArgs e)
        {
            if(wifiOn)
            {
                wifiOn = !wifiOn;
                btnWifi.BackgroundImage = Image.FromFile(System.Environment.CurrentDirectory + @"\关.PNG");
            }
            else
            {
                wifiOn = !wifiOn;
                btnWifi.BackgroundImage = Image.FromFile(System.Environment.CurrentDirectory + @"\开.PNG");
            }
        }

        private bool m_isHandle = true;
        private void btnHandle_Click(object sender, EventArgs e)
        {
            if (m_isHandle)
            {
                m_isHandle = !m_isHandle;
                btnHandle.BackgroundImage = Image.FromFile(System.Environment.CurrentDirectory + @"\关.PNG");
            }
            else
            {
                m_isHandle = !m_isHandle;
                btnHandle.BackgroundImage = Image.FromFile(System.Environment.CurrentDirectory + @"\开.PNG");
            }
        }
    }
}
