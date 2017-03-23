using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Public
{
    public class QuestionnaireResultDetail
    {

        /// <summary>
        /// 答题的题目记录ID
        /// </summary>
        public int QuestionResultId
        {
            get;
            set;
        }

        /// <summary>
        /// 用户回答问卷记录ID（关联用户记录表）
        /// </summary>
        public int QuestionUserId
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 用户（会员）ID
        /// </summary>
        public int PatientId
        {
            get;
            set;
        }

        /// <summary>
        /// 问题编码
        /// </summary>
        public string QuestionCode
        {
            set;
            get;
        }
        /// <summary>
        /// 类型ID：0-选项，1-单选题，2-多选题，3-填空题
        /// </summary>
        public int QuestionType
        {
            set;
            get;
        }

        /// <summary>
        /// 问题答案
        /// </summary>
        public string QuestionResult
        {
            set;
            get;
        }

        /// <summary>
        /// 题目分数
        /// </summary>
        public decimal QuestionScore { get; set; }

        /// <summary>
        /// 所属大题的加权分
        /// </summary>
        public decimal PQuestionWeightScore { get; set; }

        /// <summary>
        /// 所属大题的编码
        /// </summary>
        public string PQuestionCode { get; set; }

        /// <summary>
        /// 家庭成员ID
        /// </summary>
        public int FamilyMemberID { get; set; }
    }
}
