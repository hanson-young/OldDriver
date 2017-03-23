using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Public
{
    public class QuestionnaireUserDetail
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        public int QuestionnaireRecodId
        {
            set;
            get;
        }
        /// <summary>
        /// 会员Id
        /// </summary>
        public int UserId
        {
            set;
            get;
        }
        /// <summary>
        /// 问卷Code
        /// </summary>
        public string QuestionnaireCode
        {
            set;
            get;
        }

        /// <summary>
        /// 问卷状态（0：未完成 1：已完成）
        /// </summary>
        public int QuestionnaireStatus
        {
            set;
            get;
        }

        /// <summary>
        /// 题目集合
        /// </summary>
        public IList<QuestionnaireResultDetail> Questions
        {
            set;
            get;
        }

        /// <summary>
        /// 问卷名称
        /// </summary>
        public string QuestionnaireName { get; set; }

        /// <summary>
        /// 问卷分数
        /// </summary>
        public decimal QuestionnaireScore { get; set; }

        /// <summary>
        /// 活动Id
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// 问卷类型
        /// </summary>
        public sbyte QuestionnaireType { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string ActivityName { get; set; }

        /// <summary>
        /// 家庭成员ID
        /// </summary>
        public int FamilyMemberID { get; set; }

        /// <summary>
        /// 问卷回答时间
        /// </summary>
        public DateTime AnswerTime { get; set; }
    }
}
