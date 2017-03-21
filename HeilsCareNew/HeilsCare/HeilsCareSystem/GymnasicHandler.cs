using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCareSystem
{
    partial class GymnasicHandler
    {
        public void HandleMessage(Message m_message)
        {
            switch (m_message.GetMessageType())
            {
                case MessageType.MSG_GYMNASTIC_SHOW_FORM:
                    ShowForm(m_message);
                    break;
                default:
                    break;
            }
        }

    }
}
