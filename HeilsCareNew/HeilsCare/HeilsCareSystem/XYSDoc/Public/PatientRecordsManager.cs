using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;

namespace XYS.Remp.Screening.Public
{
    public class PatientRecordsManager
    {
        private ScreenWebapiClient screenWebapiClient = new ScreenWebapiClient();

        /// <summary>
        /// 给用户打标签
        /// </summary>
        /// <param name="mFItemId">标签Id</param>
        /// <param name="remark">备注</param>
        public void UpdatePatientAllRecords(int mFItemId,string remark)
        {

            //访客模式下去除医生id及姓名
            int doctorId = Properties.Settings.Default.SetIsCustomer ? 0 : Properties.Settings.Default.DoctorId;
            string doctorName = Properties.Settings.Default.SetIsCustomer ? string.Empty : Properties.Settings.Default.DoctorName;

            List<M_MemberFeaturesRecord> array = new List<M_MemberFeaturesRecord>
                    {
                        new M_MemberFeaturesRecord
                        {
                            CreateID = doctorId, 
                            //CreateTime = DateTime.Now, 
                            MFItemID = mFItemId, 
                            PatientID = LoginInfo.GetInstance().UserId
                        }
                    };

            M_MemberFeaturesRecordLogExt recordLogExt = new M_MemberFeaturesRecordLogExt();
            recordLogExt.DoctorID = 0;//doctorId;
            recordLogExt.DoctorName = string.Empty;//doctorName;
            recordLogExt.DrID = 0;//doctorId;
            recordLogExt.DrName =string.Empty;//doctorName;
            recordLogExt.OpID = doctorId;
            recordLogExt.OpName = doctorName;

            int cARecordId = Properties.Settings.Default.SetIsCustomer
                ? 0
                : Properties.Settings.Default.CARecordID;

            screenWebapiClient.UpdateMemberAllRecords(LoginInfo.GetInstance().UserId, array, recordLogExt, cARecordId, remark);
        }
    }
}
