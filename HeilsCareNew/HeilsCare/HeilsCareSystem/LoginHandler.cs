using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZedGraph;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;
using System.Windows.Forms;

namespace HeilsCareSystem
{
    class LoginHandler
    {
        public void HandleMessage(Message m_message)
        {
            switch (m_message.GetMessageType())
            {
                case MessageType.MSG_LOGIN_SHOW_USER_INFO:
                    ShowUerInfo(m_message);
                    break;
                case MessageType.MSG_LOGIN_OUT:
                    LogOut(m_message);
                    break;
                case MessageType.MSG_SHOW_HISTROTY_DATA:
                    ShowUserHistoryData(m_message);
                    break;
                case MessageType.MSG_USER_LOGIN_IN:
                    DoLogin(m_message);
                    break;
                default:
                    break;
            }
        }

        private void LogOut(Message m_message)
        {
            XYS.Remp.Screening.Public.ClientInfo.Logout();
            MainFormOld.m_isLegalUser = false;
            MainFormOld.m_pMainWnd.userInfo.Text = "    " ;
            MainFormOld.m_pMainWnd.LoginPanel.Visible = true;
            MainFormOld.m_pMainWnd.LogOutPanel.Visible = false;
            MainFormOld.m_pMainWnd.BloodPressure.Visible = false;
            //MainForm.m_pMainWnd.WelcomLogo.Visible = true;
            //MainFormOld.m_pMainWnd.FlashPlayer.Visible = true;
        }

        private void ShowUerInfo(Message m_message)
        {
            string username = m_message.GetString();
            MainFormOld.m_pMainWnd.userInfo.Text="欢迎您:"+username;
            MainFormOld.m_pMainWnd.LoginPanel.Visible = false;
            MainFormOld.m_pMainWnd.LogOutPanel.Visible = true;
           // MainFormOld.m_pMainWnd.FlashPlayer.Visible = false;
        }

        private void ShowUserHistoryData(Message m_message)
        {
            string m_userName = m_message.GetString();
            //根据username从数据库中得到历史数据
            //MainForm.m_pMainWnd.WelcomLogo.Visible = false;
            MainFormOld.m_pMainWnd.BloodPressure.Visible = true;
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.XAxis.ScaleFontSpec.Size = 20;//设置x轴的文字大小.
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.YAxis.ScaleFontSpec.Size = 20;//设置y轴的文字大小.
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.XAxis.TitleFontSpec.Size = 20;
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.YAxis.TitleFontSpec.Size = 20;
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.XAxis.Title="日期";
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.YAxis.Title = "血压";
            MainFormOld.m_pMainWnd.BloodPressure.IsShowPointValues = true;
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.FontSpec.Size = 20;
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.Title = "血压变化曲线";

            //MainForm.m_pMainWnd.BloodPressure.GraphPane.YAxis.major = true;//设置虚线.
            //MainForm.m_pMainWnd.BloodPressure.GraphPane.Chart.Border.IsVisible = false;//图表区域的边框设置.
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.Legend.IsVisible = false;//图表的注释标签显示设置项目.

            double[] x = new double[100];
            double[] y = new double[100];
            int i;
            for (i = 0; i < 100; i++)
            {
                x[i] = (double)i / 100.0 * Math.PI * 2.0;
                y[i] = Math.Sin(x[i]);
            }
            MainFormOld.m_pMainWnd.BloodPressure.GraphPane.AddCurve("Sine Wave", x, y, Color.Red, SymbolType.Square);
            MainFormOld.m_pMainWnd.BloodPressure.AxisChange();
            MainFormOld.m_pMainWnd.BloodPressure.Invalidate();
        }

        private void DoLogin(Message m_message)
        {
            string phoneNume = m_message.GetDouble().ToString();
            string m_pass = m_message.GetString();
            //SQL连接
            MySqlConnection m_sqlCon = new MySqlConnection();
            m_sqlCon.ConnectionString = "server=localhost;database=heilscare;uid=root;pwd=heils";
            try
            {
                m_sqlCon.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接出错！ \r\n " + e.ToString());
                throw;
            }
            //SQL指令
            MySqlCommand m_sqlCommand = new MySqlCommand();
            m_sqlCommand.Connection = m_sqlCon;
            m_sqlCommand.CommandType = CommandType.Text;
            m_sqlCommand.CommandText = string.Format("select * from registerTable where phone='{0}' and password='{1}'", phoneNume, m_pass); //registerTable
            //SQL结果
            //SQL结果
            int count= Convert.ToInt32(m_sqlCommand.ExecuteScalar());//执行SQL语句
            m_sqlCon.Close();//关闭数据库

            if (count > 0)
            {
                //登录成功，关闭登录窗口
                IntPtr ptrLoginForm = MainForm.FindWindow(null, "LoginForm");
                if (ptrLoginForm != IntPtr.Zero)
                {
                    MainForm.PostMessage(ptrLoginForm, 0x0010, IntPtr.Zero, IntPtr.Zero);
                }
                XYS.Remp.Screening.Public.CustomMessageBox m_res = new XYS.Remp.Screening.Public.CustomMessageBox("登录成功！");
                if (m_res.ShowDialog() == DialogResult.OK)
                {
                    //跳转到登录后的界面
                    //MessageBox.Show("现在登录是登录后的界面");\
                    if (MainForm.m_pMainWnd.m_homePage!=null)
                    {
                        MainForm.m_pMainWnd.m_homePage.ShowDialog();
                        MainForm.m_pMainWnd.m_homePage = null;
                    }
                    else
                    {
                        MainForm.m_pMainWnd.m_homePage = new HomeForm();
                        MainForm.m_pMainWnd.m_homePage.ShowDialog();
                        MainForm.m_pMainWnd.m_homePage = null;
                    }
                   
                }
                return;
            }
            else
            {
                XYS.Remp.Screening.Public.CustomMessageBox m_res = new XYS.Remp.Screening.Public.CustomMessageBox("账号密码错误，登录失败！");
                m_res.ShowDialog();
                return;
            }
        }


    }
}
