using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Diabetes
{
    public partial class QuestionSix : QuestionnaireBaseForm
    {
        public QuestionSix()
            : base(QuestionnaireCode.Diabetes, "糖尿病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                //因中途加入一题，原第10题code不变，题目文字改为第11题
                new VM_Question(Code + ".10", ckbQ2Answer1, ckbQ2Answer2, ckbQ2Answer3, ckbQ2Answer4)
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
            TurnToForm(new QuestionFive());
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
                MessageBox.Show(@"请完成页面上的所有问题，再点击下一步");
                btnNext.Enabled = true;
                return;
            }
            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to next question
            TurnToForm(new Result());
        }

        #endregion
    }
}
