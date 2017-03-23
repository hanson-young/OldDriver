using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCareSystem
{
    public class SharedDataAndMethod
    {
        private InterActionHandler m_InterInterActionHandler = new InterActionHandler();
        private LoginHandler m_loginHandler = new LoginHandler();
        private SystemAdminHandler m_systemAdminHandler = new SystemAdminHandler();
        private GymnasicHandler m_GymnasicHandler = new GymnasicHandler();
        private RegisterHandler m_registerHandler = new RegisterHandler();


        public void SendMessage(Message m_message)
        {
            //界面消息处理
            if( m_message.GetMessageType()>= MessageType.MSG_INTERFACE_MIN && m_message.GetMessageType() <= MessageType.MSG_INTERFACE_MAX)
            {
                m_InterInterActionHandler.HandleMessage(m_message);
                return;
            }

            //注册消息
            if (m_message.GetMessageType() >= MessageType.MSG_REGISTER_MIN && m_message.GetMessageType() <= MessageType.MSG_REGISTER_MAX)
            {
                m_registerHandler.HandleMessage(m_message);
                return;
            }

            //登陆消息
            if (m_message.GetMessageType() >= MessageType.MSG_LOGIN_MIN && m_message.GetMessageType() <= MessageType.MSG_LOGIN_MAX)
            {
                m_loginHandler.HandleMessage(m_message);
                return;
            }

            //问卷消息
            if (m_message.GetMessageType() >= MessageType.MSG_QUESTIONAR_MIN && m_message.GetMessageType() <= MessageType.MSG_QUESTIONAR_MAX)
            {
                return;
            }


            //体感操消息
            if (m_message.GetMessageType() >= MessageType.MSG_GYMNASTIC_MIN && m_message.GetMessageType() <= MessageType.MSG_GYMNASTIC_MAX)
            {
                m_GymnasicHandler.HandleMessage(m_message);
                return;
            }


            //运动控制消息
            if (m_message.GetMessageType() >= MessageType.MSG_MOTION_MIN && m_message.GetMessageType() <= MessageType.MSG_MOTION_MAX)
            {
                return;
            }

            //系统管理消息
            if (m_message.GetMessageType() >= MessageType.MSG_SYSTEM_ADMIN_MIN && m_message.GetMessageType() <= MessageType.MSG_SYSTEM_ADMIN_MAX)
            {
                m_systemAdminHandler.HandleMessage(m_message);
                return;
            }
        }
    }
}
