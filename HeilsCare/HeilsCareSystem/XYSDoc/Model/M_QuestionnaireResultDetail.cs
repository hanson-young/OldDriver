using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XYS.Remp.Screening.Model
{
    [DataContract]
    public class M_QuestionnaireResultDetail
    {
        /// <summary>
        ///记录ID
        /// </summary>
       [DataMember]
        public int QuestionnaireResultDetailId
        {
            set;
            get;
        }

        /// <summary>
        /// 用户回答问卷记录ID（关联用户记录表）
        /// </summary>
        [DataMember]
        public int QuestionUserId { get; set; }

        /// <summary>
        /// 问题编码
        /// </summary>
       [DataMember]
        public string QuestionCode
        {
            set;
            get;
        }
        /// <summary>
        /// 类型ID：0-选项，1-单选题，2-多选题，3-填空题
        /// </summary>
       [DataMember]
        public int QuestionType
        {
            set;
            get;
        }
        /// <summary>
        /// 用户ID
        /// </summary>
       [DataMember]
        public int PatientId
        {
            set;
            get;
        }
        /// <summary>
        /// 问题答案
        /// </summary>
        [DataMember]
        public string QuestionResult
        {
            set;
            get;
        }

        /// <summary>
        /// 题目分数
        /// </summary>
        [DataMember]
        public decimal QuestionScore { get; set; }

        /// <summary>
        /// 所属大题的加权分
        /// </summary>
        [DataMember]
        public decimal PQuestionWeightScore { get; set; }

        /// <summary>
        /// 所属大题的编码
        /// </summary>
        [DataMember]
        public string PQuestionCode { get; set; }

        /// <summary>
        /// 家庭成员ID
        /// </summary>
        [DataMember]
        public int FamilyMemberID { get; set; }
    }
}
