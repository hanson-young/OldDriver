using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_CottageActivity
    {
        /// <summary>
        /// 小屋活动ID
        /// </summary>
        public int CActivityID { get; set; }

        /// <summary>
        /// 活动开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 活动主题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 小屋Id
        /// </summary>
        public int OrgID { get; set; }

        /// <summary>
        /// 小屋名称
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// 活动结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 活动地点
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 是否开始（标记是否可选）
        /// </summary>
        public string StartFlag { get; set; }
    }
}
