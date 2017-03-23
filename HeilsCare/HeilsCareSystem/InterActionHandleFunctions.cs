using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using XYS.Remp.Screening;
using System.IO;
using DevComponents.DotNetBar;
using System.Drawing;


namespace HeilsCareSystem
{
    partial class InterActionHandler
    {
        public void GetPeopleCount(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_PEOPLE_COUNT)
            {
                return;
            }
            //SQL连接
            MySqlConnection m_sqlCon = new MySqlConnection();
            m_sqlCon.ConnectionString = "server=localhost;database=heilscare;uid=root;pwd=1139143281";
            try
            {
                m_sqlCon.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("数据库连接出错！ \r\n "+e.ToString());
                throw;
            }
            //SQL指令
            MySqlCommand m_sqlCommand = new MySqlCommand();
            m_sqlCommand.Connection = m_sqlCon;
            m_sqlCommand.CommandType = CommandType.Text;
            m_sqlCommand.CommandText = "SELECT * FROM UserTable where id=1";
            //SQL结果
            MySqlDataReader m_sqlReader = m_sqlCommand.ExecuteReader();//执行SQL语句

            while (m_sqlReader.Read())
            {
                MessageBox.Show(m_sqlReader["Name"].ToString());
            }

            m_sqlReader.Close();//关闭执行
            m_sqlCon.Close();//关闭数据库
        }

        public void ShowRegisterForm(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_REGISTER)
            {
                return;
            }
            RegistStep1Form resStep1Form = new RegistStep1Form("", "", "");
            //resStep1Form.TopMost = false;
            resStep1Form.Show();
        }

        public void UpdateMainFrameUI(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_UPDATE_UI)
            {
                return;
            }
           // MainForm mainForm = (MainForm)Control.FromHandle(Process.GetCurrentProcess().MainWindowHandle);
            if (MainFormOld.m_pMainWnd != null)
            {
                MainFormOld.m_pMainWnd.metroTileItemProfessionalVideo.Enabled = MainFormOld.m_isLegalUser;
                MainFormOld.m_pMainWnd.metroTileItemGym.Enabled = MainFormOld.m_isLegalUser;
                MainFormOld.m_pMainWnd.metroTileItemmotion.Enabled = MainFormOld.m_isLegalUser;
                MainFormOld.m_pMainWnd.metroTileItemSystemAdmin.Enabled = MainFormOld.m_isLegalUser;
                MainFormOld.m_pMainWnd.m_MainFramemetroTileItemKangFuCao.Enabled = MainFormOld.m_isLegalUser;
                MainFormOld.m_pMainWnd.metroTileItemLoQuestionaire.Enabled = MainFormOld.m_isLegalUser;
            }
        }

        public void InitializeDevice(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_REGISTER_ID_CARD_INITIALIZE)
            {
                return;
            }
            CVRSDK.InitializeDevice();
            if(CVRSDK.iRetCOM==1 && CVRSDK.iRetUSB==1)
            {
                MainFormOld.m_pMainWnd.m_isReadIdCard = true;
                Message newMessage = new Message(MessageType.MSG_REGISTER_ID_CARD_READ_PROCESS);
                MainFormOld.m_pMainWnd.m_sharedDataAndMethod.SendMessage(newMessage);
            }
            return;
        }

        public delegate CVRSDK.CardInfo ReadCardHandler();
        public void StartReadProcess(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_REGISTER_ID_CARD_READ_PROCESS)
            {
                return;
            }
            ReadCardHandler mc = new ReadCardHandler(CVRSDK.ReadCard);
            IAsyncResult result = mc.BeginInvoke(null, null);
            CVRSDK.CardInfo m_cardInfo = mc.EndInvoke(result);//用于接收返回值 
            MessageBox.Show(m_cardInfo.address);
        }

        private void ShowLoginForm(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_LOGIN)
                return;
            LoginFormNew m_loginInForm=new LoginFormNew();
            m_loginInForm.ShowDialog();
        }

        private void MAINFORMCLOSING(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_CLOSE_FORM)
                return;
        }

        private void ShowQuestionOne(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_INTERFACE_QUESTIONARE_ONE)
                return;
            RadialMenuContainer menuContainer = null;
            if (MainFormOld.m_pMainWndTemp.metroTileItemLoQuestionaire.SubItems.Count == 0)
            {
                menuContainer = new RadialMenuContainer();
                menuContainer.Font = new Font(MainFormOld.m_pMainWndTemp.Font.FontFamily, 15);
                //   五角星  
                //   主页
                //    X
                //    √
                //    返回
                //    问号 ？
                //    完成
                //    红旗
                // \uf040  笔
                menuContainer.SubItems.Add(CreateItem("痴呆", ""));
                menuContainer.SubItems.Add(CreateItem("早癌", "\uf040"));
                menuContainer.SubItems.Add(CreateItem("脑卒中", ""));
                menuContainer.SubItems.Add(CreateItem("工伤康复", "\uf040"));
                menuContainer.SubItems.Add(CreateItem("其他", ""));
                //menuContainer.SubItems.Add(CreateItem("狐臭", "\uf02e"));
                menuContainer.Diameter = 280;
                MainFormOld.m_pMainWndTemp.metroTileItemLoQuestionaire.SubItems.Add(menuContainer);
            }
            else
                menuContainer = (RadialMenuContainer)MainFormOld.m_pMainWndTemp.metroTileItemLoQuestionaire.SubItems[0];
            menuContainer.MenuLocation = new Point(Control.MousePosition.X - menuContainer.Diameter / 2, Control.MousePosition.Y - menuContainer.Diameter / 2);
            menuContainer.Expanded = true;
            
        }
        private void RadialMenuItemClick(object sender, EventArgs e)
        {
            RadialMenuItem item = sender as RadialMenuItem;
            if (item != null && !string.IsNullOrEmpty(item.Text))
            {
                //MessageBox.Show(string.Format("{0} Menu item clicked: {1}\r\n", DateTime.Now, item.Text));
                string m_string = item.Text;
                if (m_string == "痴呆")
                {
                    XYS.Remp.Screening.AD.FirstFrm m_firstForm = new XYS.Remp.Screening.AD.FirstFrm();
                    m_firstForm.Show();
                }
                else if (m_string == "早癌")
                {
                    XYS.Remp.Screening.Zaoai.ScreeningZaoaiSelect m_firstForm = new XYS.Remp.Screening.Zaoai.ScreeningZaoaiSelect();
                    m_firstForm.Show();
                }
                else if (m_string == "脑卒中")
                {
                    XYS.Remp.Screening.Naocuzhong.FirstFrm m_firstForm = new XYS.Remp.Screening.Naocuzhong.FirstFrm();
                    m_firstForm.Show();
                }
                else if(m_string=="工伤康复")
                {
                    XYS.Remp.Screening.Kangfu.ScreeningSelect m_firstForm = new XYS.Remp.Screening.Kangfu.ScreeningSelect();
                    m_firstForm.Show();
                }
                else if(m_string=="其他")
                {
                    XYS.Remp.Screening.Other.ScreenOtherSelect m_firstForm= new XYS.Remp.Screening.Other.ScreenOtherSelect();
                    m_firstForm.Show();
                }
            }
        }

        private BaseItem CreateItem(string text, string symbol)
        {
            RadialMenuItem item = new RadialMenuItem();
            item.Click += new EventHandler(RadialMenuItemClick);
            item.Text = text;
            item.Symbol = symbol;
            return item;
        }

    }
}
