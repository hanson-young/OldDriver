using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model.Enums
{
    /// <summary>
    /// 血压状态枚举
    /// </summary>
    public enum BloodPressureState
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
        Normal = 1,
        /// <summary>
        /// 高血压前期
        /// </summary>
        [Description("高血压前期")]
        EarlyStage = 2,
        /// <summary>
        /// 一级高血压
        /// </summary>
        [Description("一级高血压")]
        Primary = 3,
        /// <summary>
        /// 二级高血压
        /// </summary>
        [Description("二级高血压")]
        TwoStage = 4
    }
}
