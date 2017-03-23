using System;
using System.Linq;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Diabetes
{
    public partial class QuestionOne : QuestionnaireBaseForm
    {
        public QuestionOne()
            : base(QuestionnaireCode.Diabetes, "糖尿病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                //new VM_Question(Code + ".1", rdoQ1Answer1, rdoQ1Answer2, rdoQ1Answer3, rdoQ1Answer4, rdoQ1Answer5,
                //    rdoQ1Answer6, rdoQ1Answer7, rdoQ1Answer8, rdoQ1Answer9),
                new VM_Question(Code + ".1", new []{txtAge},rdoQ1Answer1, rdoQ1Answer2, rdoQ1Answer3, rdoQ1Answer4, rdoQ1Answer5,
                    rdoQ1Answer6, rdoQ1Answer7, rdoQ1Answer8, rdoQ1Answer9),
               new VM_Question(Code + ".2", rdoQ2Answer1, rdoQ2Answer2)
            };

            //第一题选项不勾选
            rdoQ1Answer1.Enabled = false;
            rdoQ1Answer2.Enabled = false;
            rdoQ1Answer3.Enabled = false;
            rdoQ1Answer4.Enabled = false;
            rdoQ1Answer5.Enabled = false;
            rdoQ1Answer6.Enabled = false;
            rdoQ1Answer7.Enabled = false;
            rdoQ1Answer8.Enabled = false;
            rdoQ1Answer9.Enabled = false;
        }

        #region 获取父窗口
        /// <summary>
        /// 获取父窗口
        /// </summary>
        /// <returns></returns>
        public override BaseForm GetParentForm()
        {
            return new ScreenOtherSelect();
        }
        #endregion

        #region 下一页加载事件
        /// <summary>
        /// 下一页加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnNext_Click(object sender, EventArgs e)
        {
            if (Question.Any(item => !item.IsUncheckedOrEmpty()))
            {
                var msgBox = new CustomMessageBox("请完成页面上的所有问题，再点击下一步！");
                msgBox.ShowDialog();
                return;
            }
            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to next question
            TurnToForm(new QuestionTwo());
        }
        #endregion

        //数字键盘
        private void txtAge_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }
        //判断并选中
        double age = 0;
        private void txtAge_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAge.Text))
            {
                var result = double.TryParse(txtAge.Text, out age);
                if (!result)
                {
                    var msgBox = new CustomMessageBox("请输入正确的数字！");
                    msgBox.ShowDialog();
                    txtAge.Text = string.Empty;
                    txtAge.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                    return;
                }
                if (age < 0 || age > 150)
                {
                    var msgBox = new CustomMessageBox("请输入合理的年龄范围！");
                    msgBox.ShowDialog();
                    txtAge.Text = string.Empty;
                    txtAge.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                    return;
                }
                if (age <= 24) rdoQ1Answer1.Checked = true;
                if (age >= 25 && age <= 34) rdoQ1Answer2.Checked = true;
                if (age >= 35 && age <= 39) rdoQ1Answer3.Checked = true;
                if (age >= 40 && age <= 44) rdoQ1Answer4.Checked = true;
                if (age >= 45 && age <= 49) rdoQ1Answer5.Checked = true;
                if (age >= 50 && age <= 54) rdoQ1Answer6.Checked = true;
                if (age >= 55 && age <= 59) rdoQ1Answer7.Checked = true;
                if (age >= 60 && age <= 64) rdoQ1Answer8.Checked = true;
                if (age >= 65) rdoQ1Answer9.Checked = true;
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

        private void txtAge_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAge.Text) && age>0)
                txtAge.Text = age.ToString();
        }
    }
}