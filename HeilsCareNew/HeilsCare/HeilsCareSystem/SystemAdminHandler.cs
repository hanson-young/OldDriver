using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCareSystem
{
    partial class SystemAdminHandler
    {
        public void HandleMessage(Message m_message)
        {
            switch (m_message.GetMessageType())
            {
                case MessageType.MSG_SYSTEM_ADMIN_MENU:
                    ShowAdminMenu(m_message);
                    break;
                default:
                    break;
            }
        }

    }
}
