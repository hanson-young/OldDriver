using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XYS.Remp.Screening
{
    public partial class MainfrmConfirmSave : BaseForm
    {
        public delegate void SaveHandler();

        public SaveHandler saveHandler;

        public MainfrmConfirmSave(RadioButton rbLoginMode,string loginAccount,string activityName,string questionnaireName,string cottageName,string activityAdress,DateTime? activityStartDate,DateTime? activityEndDate)
        {
            InitializeComponent();

            lblLoginMode.Text = rbLoginMode.Text;
            lblQuestionnaireName.Text = questionnaireName;
            
            if (rbLoginMode.Name.Equals("rbOperator"))
            {
                lblActivityName.Text = activityName;
                lblLoginAccount.Text = loginAccount;
                lblCottageName.Text = cottageName;
                lblAdress.Text = activityAdress;
                lblStartDate.Text = activityStartDate.HasValue ? (Convert.ToDateTime(activityStartDate).ToString("yyyy-MM-dd HH:mm:ss").CompareTo(DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss")) == 0 ? String.Empty : Convert.ToDateTime(activityStartDate).ToString("yyyy-MM-dd HH:mm:ss")) : string.Empty;
                lblEndDate.Text = activityEndDate.HasValue ? (Convert.ToDateTime(activityEndDate).ToString("yyyy-MM-dd HH:mm:ss").CompareTo(DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss")) == 0 ? string.Empty : Convert.ToDateTime(activityEndDate).ToString("yyyy-MM-dd HH:mm:ss")) : string.Empty;
            }
            else
            {
                lblActivityName.Visible = false;
                lblLoginAccount.Visible = false;
                lblCottageName.Visible = false;
                lblAdress.Visible = false;
                lblStartDate.Visible = false;
                lblEndDate.Visible = false;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (saveHandler!=null)
            {
                saveHandler();
                Close();
            }
        }

        private void MainfrmConfirmSave_Load(object sender, EventArgs e)
        {
            #region 样式
            btnStart.BackColor = Color.FromArgb(44, 158, 41);
            btnStart.ForeColor = Color.White;
            btnCancel.BackColor = Color.FromArgb(1, 102, 172);
            btnCancel.ForeColor = Color.White;
            btnCancel2.BackColor = Color.FromArgb(170, 170, 170);
            btnCancel2.ForeColor = Color.White;
            
            #endregion
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainfrmConfirmSave_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DimGray, 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}
