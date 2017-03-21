using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XYS.Remp.Screening.Model
{
    [DataContract]
    public class M_QuestionnaireUserDetail
    {
        /// <summary>
        /// 记录ID
        /// </summary>
        [DataMember]
        public int QuestionnaireRecodId
        {
            set;
            get;
        }
        /// <summary>
        /// 问卷Code
        /// </summary>
        [DataMember]
        public string QuestionnaireCode
        {
            set;
            get;
        }
        /// <summary>
        /// 会员ID
        /// </summary>
        [DataMember]
        public int PatientId
        {
            set;
            get;
        }
        /// <summary>
        /// 问卷状态（0：未完成 1：已完成）
        /// </summary>
        [DataMember]
        public int QuestionnaireStatus
        {
            set;
            get;
        }
        /// <summary>
        /// 答题时间
        /// </summary>
        [DataMember]
        public DateTime AnswerTime
        {
            set;
            get;
        }

        /// <summary>
        /// 问卷名称
        /// </summary>
        [DataMember]
        public string QuestionnaireName { get; set; }

        /// <summary>
        /// 问卷分数
        /// </summary>
        [DataMember]
        public decimal QuestionnaireScore { get; set; }

        /// <summary>
        /// 活动Id
        /// </summary>
        [DataMember]
        public int ActivityId { get; set; }

        /// <summary>
        /// 问卷类型
        /// </summary>
        [DataMember]
        public sbyte QuestionnaireType { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [DataMember]
        public string ActivityName { get; set; }

        /// <summary>
        /// 家庭成员ID
        /// </summary>
        [DataMember]
        public int FamilyMemberID { get; set; }

        /// <summary>
        /// 会员Id
        /// </summary>
        public int UserId
        {
            set;
            get;
        }

        /// <summary>
        /// 题目集合
        /// </summary>
        public IList<M_QuestionnaireResultDetail> Questions
        {
            set;
            get;
        }

        /// <summary>
        /// 问卷同步状态
        /// </summary>
        [DataMember]
        public sbyte QuestionnaireSyncStatus { get; set; }
    }
}
