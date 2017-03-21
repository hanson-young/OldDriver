using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    /// <summary>
    /// 会员特性记录
    /// </summary>
    public class M_MemberFeaturesRecord
    {

        public int CreateID
        {
            get;
            set;
        }

        public System.DateTime CreateTime
        {
            get;
            set;
        }

        public int MFItemID
        {
            get;
            set;
        }

        public int PatientID
        {
            get;
            set;
        }

        public int RecordID
        {
            get;
            set;
        }
    }
}
