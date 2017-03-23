using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_APIReturnMsg
    {
        public int ErrorCode { get; set; }
        public string ErrorMsg { get; set; }
        public object ReturnData { get; set; }
    }
}
