using System;
using System.Linq;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Ankle._1._0
{
    public partial class QuestionOne : QuestionnaireBaseForm
    {
        public QuestionOne()
            : base(QuestionnaireCode.KangFuAnkle, "足踝疾病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                new VM_Question(Code + ".1", ckbQ1Answer1, ckbQ1Answer2, ckbQ1Answer3, ckbQ1Answer4, ckbQ1Answer5,
                    ckbQ1Answer6){Max = 15},
                new VM_Question(Code+".2",ckbQ2Answer1,ckbQ2Answer2,ckbQ2Answer3,ckbQ2Answer4){Max = 5}, 
                new VM_Question(Code+".3",rdoQ3AnswerYes,rdoQ3AnswerNo){Max = 5}, 
            };
        }

        #region 获取父窗口
        /// <summary>
        /// 获取父窗口
        /// </summary>
        /// <returns></returns>
        public override BaseForm GetParentForm()
        {
            return new ScreeningSelect();
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
            //to do save user's answer 
            base.btnNext_Click(sender, e);
            //turn to next question
            TurnToForm(new QuestionTwo());
        }
        #endregion

        #region 保存答案事件
        /// <summary>
        /// 保存答案事件
        /// </summary>
        public override void SavaAnswer()
        {
            if (Question == null || !Question.Any()) return;
            foreach (var item in Question)
            {
                var detail = item.ToResultDetail();
                if (detail == null) return;
                if (detail.QuestionScore > item.Max)
                {
                    detail.QuestionScore = item.Max;
                }
                ClientInfo.AddQuestionToQuestionnaire(detail, Code);
            }
        } 
        #endregion
    }
}
