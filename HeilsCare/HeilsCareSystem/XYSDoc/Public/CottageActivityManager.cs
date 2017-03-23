using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Services;

namespace XYS.Remp.Screening.Public
{
    public class CottageActivityManager
    {
        //ScreeningServiceClient client = new ScreeningServiceClient();
        ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        #region 把登录的人作为活动参与人员建立与活动的关联关系（签到）。
        /// <summary>
        /// 把登录的人作为活动参与人员建立与活动的关联关系（签到）。
        /// </summary>
        private void AddPatientToCottageActivity()
        {
            //client = new ScreeningServiceClient();
            //把登录的人作为活动参与人员建立与活动的关联关系。
            Model.M_CottageActivityRecord entity = new Model.M_CottageActivityRecord();
            entity.CActivityID = Properties.Settings.Default.ActivityId;
            entity.PatientAccount = Public.LoginInfo.GetInstance().PatientAccount;
            entity.PatientID = Public.LoginInfo.GetInstance().UserId;
            entity.PatientName = Public.LoginInfo.GetInstance().Name;
            entity.Phone = Public.LoginInfo.GetInstance().Phone;
            entity.DoctorID = 0;
            entity.DoctorName = string.Empty;
            entity.DrID = 0;
            entity.DrName = string.Empty;
            entity.UpdateDrID = Properties.Settings.Default.DoctorId;

            entity.StatusID = 2; //状态ID：1-报名，2-没有报名直接到场，3-删除
            entity.Cash = 0;
            //entity.CreateTime = DateTime.Now;
            entity.HealthCoin = null;
            //entity.UpdateTime = DateTime.Now;
            entity.NetWorkType = 1;//是否到场,0-默认不到场,1-到场
            entity.RelationtID = Public.LoginInfo.GetInstance().FamilyMemberID;

            //新增
            entity.CreateDrID = Properties.Settings.Default.DoctorId;
            entity.CreateDrName = Properties.Settings.Default.DoctorName;
            entity.UpdateDrName = Properties.Settings.Default.DoctorName;
            entity.RegSource = 0;//报名来源,默认0,1-WEB医生端,2-网络医院APP,3-推广大使APP,4-健康管理师APP,5-筛查机
            entity.SignSource = 5;//签到来源,默认0,1-WEB医生端,2-网络医院APP,3-推广大使APP,4-健康管理师APP,5-筛查机


            var result = screenWebapiClient.AddPatientToCottageActivity(entity);

            if (result != null)
            {
                Properties.Settings.Default.CARecordID = result.CARecordID;
                Properties.Settings.Default.Save();
            }
        } 
        #endregion

        #region 会员或成员修改活动或加入活动
        /// <summary>
        /// 会员或成员修改活动或加入活动
        /// </summary>
        public void AddPToCActivity()
        {
            if (Properties.Settings.Default.ActivityId>0)
            {
                //设置界面非选择访客模式
                if (!Properties.Settings.Default.SetIsCustomer)
                {
                    //client = new ScreeningServiceClient();
                    //会员Id
                    int patientId = Public.LoginInfo.GetInstance().UserId;
                    //家庭成员Id
                    int familyMemberId = Public.LoginInfo.GetInstance().FamilyMemberID;
                    //活动Id
                    int activityId = Properties.Settings.Default.ActivityId;

                    //如果家庭成员Id>0，则是选择的家庭成员登录
                    if (familyMemberId > 0)
                    {
                        //判断此家庭成员是否已经在活动记录中
                        Model.M_CottageActivityRecord result = screenWebapiClient.GetRecordByRelationtId(activityId, familyMemberId);
                        //已经存在此活动中
                        if (result != null)
                        {
                            //修改属性及活动记录
                            UpdatePropertyAndARecord(result);
                        }
                        //不存在此活动记录中
                        else
                        {
                            //添加
                            AddPatientToCottageActivity();
                        }
                    }
                    //选择的会员登录
                    else
                    {
                        //判断会员是否在活动记录中
                        Model.M_CottageActivityRecord result = screenWebapiClient.GetRecordByParm(activityId, patientId);
                        //已经存在此活动中
                        if (result != null)
                        {
                            //修改属性及活动记录
                            UpdatePropertyAndARecord(result);
                        }
                        //不存在此活动记录中
                        else
                        {
                            //添加
                            AddPatientToCottageActivity();
                        }
                    }
                    //client.Close();
                }
            }
        }
        #endregion

        #region 修改属性及活动记录
        /// <summary>
        /// 修改属性及活动记录
        /// </summary>
        /// <param name="mCottageActivityRecord"></param>
        private void UpdatePropertyAndARecord(Model.M_CottageActivityRecord mCottageActivityRecord)
        {
            //client = new ScreeningServiceClient();
            //将此活动记录的签到来源改为筛查机及其他字段的修改
            mCottageActivityRecord.UpdateDrID = Properties.Settings.Default.DoctorId;
            mCottageActivityRecord.UpdateDrName = Properties.Settings.Default.DoctorName;
            //mCottageActivityRecord.UpdateTime = DateTime.Now;
            mCottageActivityRecord.NetWorkType = 1; //是否到场,0-默认不到场,1-到场
            mCottageActivityRecord.SignSource = 5; //签到来源,默认0,1-WEB医生端,2-网络医院APP,3-推广大使APP,4-健康管理师APP,5-筛查机
            //mCottageActivityRecord.StatusID = 2;//状态ID：1-报名，2-没有报名直接到场，3-删除

            //修改活动记录
            Model.M_CottageActivityRecord result= screenWebapiClient.UpdateCottageActivityRecord(mCottageActivityRecord);
            if (result != null)
            {
                Properties.Settings.Default.CARecordID = result.CARecordID;
                Properties.Settings.Default.Save();
            }
        } 
        #endregion
    }
}
