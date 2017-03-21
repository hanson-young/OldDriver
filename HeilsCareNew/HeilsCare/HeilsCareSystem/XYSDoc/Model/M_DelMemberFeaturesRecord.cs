using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    /// <summary>
    /// 用于删除会员特性标签
    /// </summary>
    public class M_DelMemberFeaturesRecord
    {
        /// <summary>
        /// 活动Id
        /// </summary>
        public int CActivityId { get; set; }
        /// <summary>
        /// 会员Id
        /// </summary>
        public int PatientId { get; set; }
        /// <summary>
        /// 问卷所涉及标签Id列表
        /// </summary>
        public List<int> MfItemsIds { get; set; }
        /// <summary>
        /// 操作医生Id
        /// </summary>
        public int UpdateId { get; set; }
        /// <summary>
        /// 操作医生姓名
        /// </summary>
        public string UpdateName { get; set; }
    }
}
