using System;
using System.Linq;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Diabetes
{
    public partial class QuestionFive : QuestionnaireBaseForm
    {
        public QuestionFive()
            : base(QuestionnaireCode.Diabetes, "糖尿病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                //因中途加入一题，原第8题code不变，题目文字改为第9题
                new VM_Question(Code + ".8", ckbQ2Answer1, ckbQ2Answer2, ckbQ2Answer3, ckbQ2Answer4),
                //因中途加入一题，原第9题code不变，题目文字改为第10题
                new VM_Question(Code + ".9", ckbQ1Answer1, ckbQ1Answer2, ckbQ1Answer3, ckbQ1Answer4)
            };
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
            TurnToForm(new QuestionFour());
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

                btnNext.Enabled = true;
                return;
            }
            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to next question
            TurnToForm(new QuestionSix());
        }

        #endregion
    }
}