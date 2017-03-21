using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeilsCareSystem
{
    partial class GymnasicHandler
    {

        private void ShowForm(Message m_message)
        {
            GymnasticForm gymnastic = new GymnasticForm();
            gymnastic.ShowDialog();
            // MessageBox.Show("few");
        }
    }
}
