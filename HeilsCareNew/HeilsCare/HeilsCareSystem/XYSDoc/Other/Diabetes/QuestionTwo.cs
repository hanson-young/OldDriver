using System;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Diabetes
{
    public partial class QuestionTwo : QuestionnaireBaseForm
    {
        public QuestionTwo()
            : base(QuestionnaireCode.Diabetes, "糖尿病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                //new VM_Question(Code + ".3",rdoQ1Answer1, rdoQ1Answer2, rdoQ1Answer3, rdoQ1Answer4, rdoQ1Answer5),
                new VM_Question(Code + ".3",new []{txtBMI,txtWeight,txtHeight},rdoQ1Answer1, rdoQ1Answer2, rdoQ1Answer3, rdoQ1Answer4, rdoQ1Answer5),
                //new VM_Question(Code + ".4", rdoQ2Answer1, rdoQ2Answer2, rdoQ2Answer3, rdoQ2Answer4, rdoQ2Answer5,
                //    rdoQ2Answer6, rdoQ2Answer7, rdoQ2Answer8, rdoQ2Answer9, rdoQ2Answer10, rdoQ2Answer11, rdoQ2Answer12)
                new VM_Question(Code + ".4",new []{txtWaistSize}, rdoQ2Answer1, rdoQ2Answer2, rdoQ2Answer3, rdoQ2Answer4, rdoQ2Answer5,
                    rdoQ2Answer6, rdoQ2Answer7, rdoQ2Answer8, rdoQ2Answer9, rdoQ2Answer10, rdoQ2Answer11, rdoQ2Answer12)
            };

            #region 控制选项不勾选
            rdoQ1Answer1.Enabled = false;
            rdoQ1Answer2.Enabled = false;
            rdoQ1Answer3.Enabled = false;
            rdoQ1Answer4.Enabled = false;
            rdoQ1Answer5.Enabled = false;

            rdoQ2Answer7.Enabled = false;
            rdoQ2Answer8.Enabled = false;
            rdoQ2Answer9.Enabled = false;
            rdoQ2Answer10.Enabled = false;
            rdoQ2Answer11.Enabled = false;
            rdoQ2Answer12.Enabled = false;
            rdoQ2Answer1.Enabled = false;
            rdoQ2Answer2.Enabled = false;
            rdoQ2Answer3.Enabled = false;
            rdoQ2Answer4.Enabled = false;
            rdoQ2Answer5.Enabled = false;
            rdoQ2Answer6.Enabled = false;
            #endregion
        }

        #region 窗口加载事件
        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void FormLoadEven(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                var answer = ClientInfo.GetAnswerByCode(Code, Code + ".2");
                if (!string.IsNullOrEmpty(answer.Trim()) && !answer.Contains("B")) return;

                rdoQ2Answer7.Visible =
                    rdoQ2Answer8.Visible =
                        rdoQ2Answer9.Visible =
                            rdoQ2Answer10.Visible =
                                rdoQ2Answer11.Visible =
                                    rdoQ2Answer12.Visible = true;
                if (!answer.Contains("B")) return;
                rdoQ2Answer1.Visible =
                    rdoQ2Answer2.Visible =
                        rdoQ2Answer3.Visible =
                            rdoQ2Answer4.Visible =
                                rdoQ2Answer5.Visible =
                                    rdoQ2Answer6.Visible = false;

            }));
            base.FormLoadEven(sender, e);
        }
        #endregion

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
            TurnToForm(new QuestionOne());
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
                var msgBox = new CustomMessageBox("请完成页面上的所有问题，再点击下一步！");
                msgBox.ShowDialog();
                return;
            }
            CalcBmi();

            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to next question
            TurnToForm(new QuestionThree());
        }

        #endregion

        //计算BMI
        double weight = 0;
        double height = 0;
        private void CalcBmi()
        {
            if (string.IsNullOrEmpty(txtWeight.Text))
            {
                var msgBox = new CustomMessageBox("请输入体重！");
                msgBox.ShowDialog();
                return;
            }
            if (string.IsNullOrEmpty(txtHeight.Text))
            {
                var msgBox = new CustomMessageBox("请输入身高！");
                msgBox.ShowDialog();
                return;
            }
            bool weightResult = double.TryParse(txtWeight.Text, out weight);
            if (!weightResult)
            {
                var msgBox = new CustomMessageBox("请输入正确的数字！");
                msgBox.ShowDialog();
                txtWeight.Text = string.Empty;
                txtWeight.Focus();
                return;
            }
            bool heightResult = double.TryParse(txtHeight.Text, out height);
            if (!heightResult)
            {
                var msgBox = new CustomMessageBox("请输入正确的数字！");
                msgBox.ShowDialog();
                txtHeight.Text = string.Empty;
                txtHeight.Focus();
                return;
            }
            weight = Math.Round(weight, 1);
            height = Math.Round(height, 2);
            if (height == 0)
            {
                var msgBox = new CustomMessageBox("身高不能为0！");
                msgBox.ShowDialog();
                txtHeight.Text = string.Empty;
                txtHeight.Focus();
                return;
            }

            txtWeight.Text = weight.ToString();
            txtHeight.Text = height.ToString();

            double bmi = Math.Round((weight / (height * height)), 1);
            txtBMI.Text = bmi.ToString();

            //判断并选中
            if (bmi < 18.5) rdoQ1Answer1.Checked = true;
            if (bmi >= 18.5 && bmi <= 21.9) rdoQ1Answer2.Checked = true;
            if (bmi >= 22 && bmi <= 23.9) rdoQ1Answer3.Checked = true;
            if (bmi >= 24 && bmi <= 29.9) rdoQ1Answer4.Checked = true;
            if (bmi >= 30) rdoQ1Answer5.Checked = true;
        }

        private void btnCalcBmi_Click(object sender, EventArgs e)
        {
            CalcBmi();
        }
        //数字小键盘
        private void txtWeight_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void txtHeight_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }

        private void txtWaistSize_Click(object sender, EventArgs e)
        {
            ProcessManager.KillProcessByName("TabTip");
            CustomNumKeyboard.GetInstance(sender).ShowDialog();
        }
        //判断并选中
        double waistSize = 0;
        private void txtWaistSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWaistSize.Text))
            {
                bool result = double.TryParse(txtWaistSize.Text, out waistSize);
                if (!result)
                {
                    var msgBox = new CustomMessageBox("请填写正确的数字！");
                    msgBox.ShowDialog();
                    txtWaistSize.Text = string.Empty;
                    txtWaistSize.Focus();
                    CustomNumKeyboard.GetInstance(sender).CloseKeyboard();
                    return;
                }

                if (rdoQ2Answer7.Visible == true)
                {
                    if (waistSize < 70) rdoQ2Answer7.Checked = true;
                    if (waistSize >= 70 && waistSize <= 74.9) rdoQ2Answer8.Checked = true;
                    if (waistSize >= 75 && waistSize <= 79.9) rdoQ2Answer9.Checked = true;
                    if (waistSize >= 80 && waistSize <= 84.9) rdoQ2Answer10.Checked = true;
                    if (waistSize >= 85 && waistSize <= 89.9) rdoQ2Answer11.Checked = true;
                    if (waistSize >= 90) rdoQ2Answer12.Checked = true;
                }
                if (rdoQ2Answer1.Visible == true)
                {
                    if (waistSize < 75) rdoQ2Answer1.Checked = true;
                    if (waistSize >= 75 && waistSize <= 79.9) rdoQ2Answer2.Checked = true;
                    if (waistSize >= 80 && waistSize <= 84.9) rdoQ2Answer3.Checked = true;
                    if (waistSize >= 85 && waistSize <= 89.9) rdoQ2Answer4.Checked = true;
                    if (waistSize >= 90 && waistSize <= 94.9) rdoQ2Answer5.Checked = true;
                    if (waistSize >= 95) rdoQ2Answer6.Checked = true;
                }
            }
            else
            {
                rdoQ2Answer7.Checked =  false;
                rdoQ2Answer8.Checked =  false;
                rdoQ2Answer9.Checked =  false;
                rdoQ2Answer10.Checked = false;
                rdoQ2Answer11.Checked = false;
                rdoQ2Answer12.Checked = false;
                rdoQ2Answer1.Checked =  false;
                rdoQ2Answer2.Checked =  false;
                rdoQ2Answer3.Checked =  false;
                rdoQ2Answer4.Checked =  false;
                rdoQ2Answer5.Checked =  false;
                rdoQ2Answer6.Checked =  false;
            }
        }

        private void txtWaistSize_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtWaistSize.Text) && waistSize>0)
               txtWaistSize.Text = waistSize.ToString();
        }
    }
}