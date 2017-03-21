using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XYS.Remp.Screening.Model
{
      [DataContract]
    public class M_User
    {
        /// <summary>
        /// 用户姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 会员账号
        /// </summary>
        [DataMember]
        public string PatientAccount { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Pwd { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
         [DataMember]
         public string Mobie { get; set; }

          /// <summary>
          /// 身份证号码
          /// </summary>
         [DataMember]
         public string CrardNo { get; set; }

          /// <summary>
          /// 性别
          /// </summary>
        [DataMember]
        public string Sex { get; set; }

          /// <summary>
          /// 年龄
          /// </summary>
        [DataMember]
        public int Age { get; set; }
    }
}
