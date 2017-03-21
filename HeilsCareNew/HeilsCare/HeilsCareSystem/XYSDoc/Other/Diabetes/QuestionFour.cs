using System;
using System.Linq;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Diabetes
{
    public partial class QuestionFour : QuestionnaireBaseForm
    {
        public QuestionFour()
            : base(QuestionnaireCode.Diabetes, "糖尿病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                //新加入一题，code为6.1，题目文字为第7题
                new VM_Question(Code+".6.1",rdoQ2Answer1,rdoQ2Answer2,rdoQ2Answer3,rdoQ2Answer4),
                //因中途加入一题，原第7题code不变，题目文字改为第8题
                new VM_Question(Code + ".7", rdoQ1Answer1, rdoQ1Answer2, rdoQ1Answer3, rdoQ1Answer4)
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
        ///     上一页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnBefore_Click(object sender, EventArgs e)
        {
            //back to last question
            TurnToForm(new QuestionThree());
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
            TurnToForm(new QuestionFive());
        }

        #endregion
    }
}