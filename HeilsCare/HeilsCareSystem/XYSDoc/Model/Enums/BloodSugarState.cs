using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model.Enums
{
    /// <summary>
    /// 血糖结果状态枚举
    /// </summary>
    public enum BloodSugarState
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        NotSet = -1,
        /// <summary>
        /// 正常血糖值
        /// </summary>
        [Description("正常血糖值")]
        Normal = 5,
        /// <summary>
        /// 疑似糖尿病前期
        /// </summary>
        [Description("疑似糖尿病前期")]
        EarlyStage = 6,
        /// <summary>
        /// 疑似糖尿病
        /// </summary>
        [Description("疑似糖尿病")]
        SuspectedDiabetes = 7,
        /// <summary>
        /// 正常随机血糖
        /// </summary>
        [Description("正常随机血糖")]
        NormalSuijiBloodSugar = 8,
        /// <summary>
        /// 血糖值偏高
        /// </summary>
        [Description("血糖值偏高")]
        High = 9
    }
}
