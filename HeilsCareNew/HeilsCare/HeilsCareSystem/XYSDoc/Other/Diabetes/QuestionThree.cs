using System;
using System.Linq;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Diabetes
{
    public partial class QuestionThree : QuestionnaireBaseForm
    {
        public QuestionThree()
            : base(QuestionnaireCode.Diabetes, "糖尿病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                //new VM_Question(Code + ".5", rdoQ1Answer1, rdoQ1Answer2, rdoQ1Answer3, rdoQ1Answer4, rdoQ1Answer5,
                //    rdoQ1Answer6, rdoQ1Answer7, rdoQ1Answer8),
                new VM_Question(Code + ".5", new []{txtSBP},rdoQ1Answer1, rdoQ1Answer2, rdoQ1Answer3, rdoQ1Answer4, rdoQ1Answer5,
                    rdoQ1Answer6, rdoQ1Answer7, rdoQ1Answer8),
                new VM_Question(Code + ".6", rdoQ2Answer1, rdoQ2Answer2)
            };

            #region 控制不勾选

            rdoQ1Answer1.Enabled = false;
            rdoQ1Answer2.Enabled = false;
            rdoQ1Answer3.Enabled = false;
            rdoQ1Answer4.Enabled = false;
            rdoQ1Answer5.Enabled = false;
            rdoQ1Answer6.Enabled = false;
            rdoQ1Answer7.Enabled = false;
            rdoQ1Answer8.Enabled = false;

            #endregion
        }

        #region 获取父窗口

        /// <summary>
        ///     获取父窗口
        /// </summary>
        /// <returns></returns>
        public override BaseForm GetParentForm()
        {
            return new ScreenOtherSelect();
        }

        #endregion

        #region 上一页事件
        /// <summary>
        /// 上一页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnBefore_Click(object sender, EventArgs e)
        {
            //back to last question
            TurnToForm(new QuestionTwo());
        }
        #endregion

        #region 下一页加载事件

        /// <summary>
        ///     下一页加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnNext_Click(object sender, EventArgs e)
        {
            if (Question.Any(item => !item.IsUncheckedOrEmpty()))
            {
                //MessageBox.Show(@"请完成页面上的所有问题，再点击下一步");
                var msgBox = new CustomMessageBox("请完成页面上的所有问题，再点击下一步");
                msgBox.ShowDialog();
                return;
            }
            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to next question
            TurnToForm(new QuestionFour());
        }

        #endregion
        //数字小键盘
        private void txtSBP_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }
        //判断并选中
        double result = 0;
        private void txtSBP_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSBP.Text))
            {
                var isNum = double.TryParse(txtSBP.Text, out result);
                if (!isNum)
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtSBP.Text = string.Empty;
                    txtSBP.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                    return;
                }

                result = (int) result;

                if (result < 90) rdoQ1Answer1.Checked = true;
                if (result >= 90 && result <= 109) rdoQ1Answer2.Checked = true;
                if (result >= 110 && result <= 119) rdoQ1Answer3.Checked = true;
                if (result >= 120 && result <= 129) rdoQ1Answer4.Checked = true;
                if (result >= 130 && result <= 139) rdoQ1Answer5.Checked = true;
                if (result >= 140 && result <= 149) rdoQ1Answer6.Checked = true;
                if (result >= 150 && result <= 159) rdoQ1Answer7.Checked = true;
                if (result >= 160) rdoQ1Answer8.Checked = true;
            }
            else
            {
                rdoQ1Answer1.Checked = false;
                rdoQ1Answer2.Checked = false;
                rdoQ1Answer3.Checked = false;
                rdoQ1Answer4.Checked = false;
                rdoQ1Answer5.Checked = false;
                rdoQ1Answer6.Checked = false;
                rdoQ1Answer7.Checked = false;
                rdoQ1Answer8.Checked = false;
            }
            
        }

        private void txtSBP_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSBP.Text) && result>0)
               txtSBP.Text = result.ToString();
        }
    }
}
