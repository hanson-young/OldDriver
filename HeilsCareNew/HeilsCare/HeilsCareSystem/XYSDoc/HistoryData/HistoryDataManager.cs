using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening.HistoryData
{
    public partial class HistoryDataManager : Form
    {
        public HistoryDataManager()
        {
            InitializeComponent();
        }

        private void btnJizhu_Click(object sender, EventArgs e)
        {
            KangfuJizhu jizhu=new KangfuJizhu();
            int result= jizhu.UpdateHistoryData();
            if (result > 0)
            {
                MessageBox.Show("更新成功！");
            }
        }

        private void btnZuhuai_Click(object sender, EventArgs e)
        {
            KangfuZuHuai zuHuai=new KangfuZuHuai();
            int result= zuHuai.UpdateHistoryData();
            if (result > 0)
            {
                MessageBox.Show("更新成功！");
            }
        }

        private void HistoryDataManager_Load(object sender, EventArgs e)
        {
            btnJizhu.Enabled = false;
            btnZuhuai.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = ConfigurationManager.AppSettings["hisDataManagePwd"];
            if (!string.IsNullOrEmpty(txtPwd.Text) && txtPwd.Text.Equals(pwd))
            {
                btnJizhu.Enabled = true;
                btnZuhuai.Enabled = true;
            }
        }
    }
}
