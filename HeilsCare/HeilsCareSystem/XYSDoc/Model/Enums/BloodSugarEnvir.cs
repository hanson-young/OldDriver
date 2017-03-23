using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model.Enums
{
    /// <summary>
    /// 血糖监视环境
    /// </summary>
    public enum BloodSugarEnvir
    {
        /// <summary>
        /// 随机血糖
        /// </summary>
        [Description("随机血糖")]
        Suiji = 1,
        /// <summary>
        /// 空腹
        /// </summary>
        [Description("空腹血糖")]
        Kongfu = 2,
        /// <summary>
        /// 餐后2小时
        /// </summary>
        [Description("餐后2小时")]
        Canhou = 3
    }
}
