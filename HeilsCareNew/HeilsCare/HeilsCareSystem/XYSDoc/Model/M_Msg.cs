using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XYS.Remp.Screening.Model
{
      [DataContract]
    public class M_Msg
    {
        /// <summary>
        ///是否成功
        /// </summary>
        [DataMember]
        public bool IsSuccss
        {
            set;
            get;
        }
          /// <summary>
          /// 返回消息
          /// </summary>
        [DataMember]
        public string Message
        { 
          get; 
          set; 
        }

          /// <summary>
          /// 会员Id
          /// </summary>
          [DataMember]
          public int PatientId { get; set; }
    }
}
