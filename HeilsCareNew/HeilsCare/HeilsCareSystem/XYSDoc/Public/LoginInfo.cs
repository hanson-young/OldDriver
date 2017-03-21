using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace XYS.Remp.Screening.Public
{
    public class LoginInfo
    {
        private int _UserId=-9;
        public  int UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        public string Name { get; set; }

        /// <summary>
        /// 成员Id
        /// </summary>
        public int FamilyMemberID { get; set; }
        /// <summary>
        /// 会员账号
        /// </summary>
        public string PatientAccount { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }

        //用来存储当前登录用户每种问卷的回答记录
        private Hashtable _questionnair = new Hashtable();
        public Hashtable Questionnairs
        {
            get
            {
                return _questionnair;
            }
            set
            {
                this._questionnair = value;
            }
        }

        static LoginInfo _loginInfo;

        public static LoginInfo GetInstance()
        {
            if (_loginInfo != null)
            {
                return _loginInfo;
            }
            else
            {
                _loginInfo = new Public.LoginInfo();
                return _loginInfo;
            }
        }
    }
}
