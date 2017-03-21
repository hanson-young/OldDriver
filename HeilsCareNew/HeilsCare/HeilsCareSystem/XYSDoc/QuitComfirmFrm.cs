using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening
{
    public partial class QuitComfirmFrm : BaseForm
    {
        //要去往的窗口
        private BaseForm _goToForm = null;
        //调用此窗口的窗口
        private BaseForm _questionForm = null;

        public QuitComfirmFrm(BaseForm goToFrm,BaseForm quesFrm)
        {
            InitializeComponent();

            _goToForm = goToFrm;
            _questionForm = quesFrm;
            btnContinue2.Visible = false;
        }

        public QuitComfirmFrm(BaseForm goToFrm, BaseForm quesFrm,string text)
        {
            InitializeComponent();

            _goToForm = goToFrm;
            _questionForm = quesFrm;
            lblTitle.Text = text;
            //btnQuit.Text = "放弃/下一位";
            btnQuit.Text = "回到主界面";
            btnContinue.Text = "放弃/其他筛查";
            btnContinue.Font=new Font("宋体",10,FontStyle.Bold);

            btnQuit2.DialogResult=DialogResult.Cancel;
            btnQuit2.DialogResult=DialogResult.Cancel;
            btnContinue.DialogResult=DialogResult.Cancel;
            btnContinue2.DialogResult=DialogResult.OK;
        }

        //结束/下一位
        private void btnQuit_Click(object sender, EventArgs e)
        {
            //
            if (_questionForm != null)
            {
                _questionForm.Close();
            }
            Close();
            return;
            //end


            //清空排尿异常一二题选择标识
            Properties.Settings.Default.QuesSelFlag = string.Empty;
            //清空问卷记录Id
            Properties.Settings.Default.QuestionnaireRecodId = 0;
            //清空同天内做的同份问卷记录Id
            Properties.Settings.Default.LastTimeQuestionnaireRecodId = 0;
            Properties.Settings.Default.Save();

            //清空登录信息
            ClientInfo.Logout();
            //回到登录界面

            BaseForm selectForm = null;
            int iWhichQuestion = Properties.Settings.Default.ScreenSet;
            switch (iWhichQuestion)
            {
                case 1://老年痴呆筛查
                    selectForm = new AD.FirstFrm();
                    break;
                case 2: //脑卒中筛查
                    selectForm = new Naocuzhong.FirstFrm();
                    break;
                case 3://早癌筛查
                    selectForm = new Zaoai.ScreeningZaoaiSelect();
                    break;
                case 4://工伤康复筛查
                    selectForm = new Kangfu.ScreeningSelect();
                    break;
                case 5:
                    selectForm = new Other.ScreenOtherSelect();
                    break;
                default:
                    break;
            }

            LoginFormNew loginFormNew = new LoginFormNew(selectForm);
            loginFormNew.Show();
            if (_questionForm != null)
            {
                _questionForm.Close();
            }
            Close();
        }
        //其他筛查
        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (_goToForm != null && _questionForm!=null)
            {
                //清空排尿异常一二题选择标识
                Properties.Settings.Default.QuesSelFlag = string.Empty;
                //清空问卷记录Id
                Properties.Settings.Default.QuestionnaireRecodId = 0;
                //清空同天内做的同份问卷记录Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = 0;
                Properties.Settings.Default.Save();
                //清空答题集合
                LoginInfo.GetInstance().Questionnairs.Clear();
                _goToForm.TopMost = false;
                _goToForm.Show();
                _questionForm.Close();
                Close();            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void QuitComfirmFrm_Load(object sender, EventArgs e)
        {
            #region 样式
            btnQuit.BackColor = Color.FromArgb(44, 158, 41);
            btnQuit.ForeColor = Color.White;
            btnContinue.BackColor = Color.FromArgb(1, 102, 172);
            btnContinue.ForeColor = Color.White;
            btnQuit2.BackColor = Color.FromArgb(170, 170, 170);
            btnQuit2.ForeColor = Color.White;
            btnContinue2.BackColor = Color.FromArgb(44, 158, 41);
            btnContinue2.ForeColor = Color.White;
            #endregion
        }

        private void QuitComfirmFrm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DimGray, 0, 0, this.Width - 1, this.Height - 1);
        }
    }
}
