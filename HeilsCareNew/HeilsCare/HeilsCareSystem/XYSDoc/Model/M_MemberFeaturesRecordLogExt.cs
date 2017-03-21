using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_MemberFeaturesRecordLogExt
    {
        /// <summary>
        /// 操作医生id
        /// </summary>
        public virtual int OpID
        {
            get;
            set;
        }
        /// <summary>
        /// 操作医生
        /// </summary>
        public virtual string OpName
        {
            get;
            set;
        }
        /// <summary>
        /// 健康管理师名称
        /// </summary>
        public virtual string DoctorName
        {
            get;
            set;
        }
        /// <summary>
        /// 健康管理师ID
        /// </summary>
        public virtual Nullable<int> DoctorID
        {
            get;
            set;
        }
        /// <summary>
        /// 推广大使名称
        /// </summary>
        public virtual string DrName
        {
            get;
            set;
        }
        /// <summary>
        /// 推广大使ID
        /// </summary>
        public virtual Nullable<int> DrID
        {
            get;
            set;
        }
    }
}
