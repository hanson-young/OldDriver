using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_APIError
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// 默认为-1,成功为0
        /// </summary>
        private int errorCode = -1;

        /// <summary>
        /// 错误编码
        /// </summary>
        public int ErrorCode
        {
            get { return errorCode; }
            set { errorCode = value; }
        }

        /// <summary>
        /// 返回数据信息
        /// </summary>
        public object ReturnData { get; set; }
    }
}
