using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_PatientExtendInfo
    {
        public int PatientID { get; set; }
        public int RelationtID { get; set; }
        public string PatientName { get; set; }
        public string PatientRelName { get; set; }
        public string PatientAccount { get; set; }
    }
}
