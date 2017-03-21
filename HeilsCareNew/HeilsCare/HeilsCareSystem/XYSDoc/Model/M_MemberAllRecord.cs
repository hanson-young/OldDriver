using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_MemberAllRecord
    {
        public int PatientId { get; set; }

        public List<M_MemberFeaturesRecord> MemberFeaturesRecordList { get; set; }

        public M_MemberFeaturesRecordLogExt MemberFeaturesRecordLogExt { get; set; }

        public int CARecordID { get; set; }

        public string Remark { get; set; }
    }
}
