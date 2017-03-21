using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using MySql.Data;
using System.Windows.Forms;

namespace HeilsCareSystem
{
    class RegisterHandler
    {
        public void HandleMessage(Message m_message)
        {
            switch (m_message.GetMessageType())
            {
                case MessageType.MSG_REGISTER_USER:
                    RegisterUser(m_message);
                    break;
                case MessageType.MSG_SHOW_REGISTER_USER:
                    ShowRegisterForm(m_message);
                    break;
                default:
                    break;
            }
        }

        private void ShowRegisterForm(Message m_message)
        {
            //关闭登录窗口
            IntPtr ptrLoginForm = MainForm.FindWindow(null, "LoginForm");
            if (ptrLoginForm != IntPtr.Zero)
            {
                MainForm.PostMessage(ptrLoginForm, 0x0010, IntPtr.Zero, IntPtr.Zero);
            }
            Register m_register = new Register();
            m_register.ShowDialog();
        }

        private void RegisterUser(Message m_message)
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
            m_sqlCommand.CommandText = string.Format("INSERT INTO registerTable (phone, password) VALUES ({0},{1})", phoneNume, m_pass); //registerTable
            //SQL结果
            int registRes= m_sqlCommand.ExecuteNonQuery();//执行SQL语句
            m_sqlCon.Close();//关闭数据库

            if(registRes>0)
            {
                XYS.Remp.Screening.Public.CustomMessageBox m_res = new XYS.Remp.Screening.Public.CustomMessageBox("注册成功，请登录！");
                if(m_res.ShowDialog()==DialogResult.OK)
                {
                    //跳转到登录界面
                    MessageBox.Show("现在登录");
                }
                return;
            }
            else
            {
                XYS.Remp.Screening.Public.CustomMessageBox m_res = new XYS.Remp.Screening.Public.CustomMessageBox("账号已经存在，注册失败！");
                m_res.ShowDialog();
                return;
            }
            
            
        }
    }
}
