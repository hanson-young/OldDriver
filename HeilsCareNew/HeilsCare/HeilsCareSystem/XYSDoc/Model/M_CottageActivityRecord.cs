using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Model
{
    public class M_CottageActivityRecord
    {
        /// <summary>
        /// 报名及签到记录ID
        /// </summary>
        public int CARecordID { get; set; }
        /// <summary>
        /// 小屋活动ID
        /// </summary>
        public int CActivityID { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public int PatientID { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string PatientAccount { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 总健康币，默认RMB
        /// </summary>
        public Nullable<decimal> HealthCoin { get; set; }
        /// <summary>
        /// 支付现金，默认RMB
        /// </summary>
        public decimal Cash { get; set; }
        /// <summary>
        /// 状态ID：1-报名，2-没有报名直接到场，3-删除
        /// </summary>
        public sbyte StatusID { get; set; }
        /// <summary>
        /// 报名时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public Nullable<DateTime> UpdateTime { get; set; }

        /// <summary>
        /// 健康管理师名称
        /// </summary>
        public virtual string DoctorName
        {
            get;
            set;
        }
        /// <summary>
        /// 健康管理师ID
        /// </summary>
        public virtual Nullable<int> DoctorID
        {
            get;
            set;
        }
        /// <summary>
        /// 推广大使名称
        /// </summary>
        public virtual string DrName
        {
            get;
            set;
        }
        /// <summary>
        /// 推广大使ID
        /// </summary>
        public virtual Nullable<int> DrID
        {
            get;
            set;
        }
        /// <summary>
        /// 更新医生ID
        /// </summary>
        public virtual Nullable<int> UpdateDrID
        {
            get;
            set;
        }
        /// <summary>
        /// 是否到场,0-默认不到场,1-到场
        /// </summary>
        public Nullable<int> NetWorkType { get; set; }
        /// <summary>
        /// 家庭成员关系id
        /// </summary>
        public int RelationtID { get; set; }


        /// <summary>
        /// 创建人医生id即报名医生id,0表示会员自己报名
        /// </summary>
        public int CreateDrID { get; set; }

        /// <summary>
        /// 创建人医生名称即报名医生名称,空表示会员自己报名
        /// </summary>
        public string CreateDrName { get; set; }

        /// <summary>
        /// 修改医生名称即签到医生名称,空表示会员自己签到
        /// </summary>
        public string UpdateDrName { get; set; }

        /// <summary>
        /// 报名来源,默认0,1-WEB医生端,2-网络医院APP,3-推广大使APP,4-健康管理师APP,5-筛查机
        /// </summary>
        public sbyte RegSource { get; set; }

        /// <summary>
        /// 签到来源,默认0,1-WEB医生端,2-网络医院APP,3-推广大使APP,4-健康管理师APP,5-筛查机
        /// </summary>
        public sbyte SignSource { get; set; }
    }
}
