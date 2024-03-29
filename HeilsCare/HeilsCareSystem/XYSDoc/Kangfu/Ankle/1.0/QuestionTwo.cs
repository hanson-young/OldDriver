﻿using System;
using System.Linq;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu.Ankle._1._0
{
    public partial class QuestionTwo : QuestionnaireBaseForm
    {
        public QuestionTwo()
            : base(QuestionnaireCode.KangFuAnkle, "足踝疾病筛查")
        {
            InitializeComponent();
            Question = new[]
            {
                new VM_Question(Code + ".4", ckbQ1Answer1, ckbQ1Answer2, ckbQ1Answer3, ckbQ1Answer4){Max = 15},
                new VM_Question(Code + ".5", rdoQ2Answer1, rdoQ2Answer2, rdoQ2Answer3){Max = 10}
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
            TurnToForm(new QuestionThree());
        }
        #endregion

        #region 上一页加载事件
        /// <summary>
        /// 上一页加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void btnBefore_Click(object sender, EventArgs e)
        {
            //back to last form
            TurnToForm(new QuestionOne());
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
