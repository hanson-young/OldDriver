using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model.Enums
{
    /// <summary>
    /// 体重状态枚举
    /// </summary>
    public enum WeightStandardState
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        NotSet = -1,
        /// <summary>
        /// 正常
        /// </summary>
        [Description("正常")]
        Normal = 0,
        /// <summary>
        /// 超重
        /// </summary>
        [Description("超重")]
        Overweight = 12,
        /// <summary>
        /// 肥胖
        /// </summary>
        [Description("肥胖")]
        Obesity = 13
    }
}
