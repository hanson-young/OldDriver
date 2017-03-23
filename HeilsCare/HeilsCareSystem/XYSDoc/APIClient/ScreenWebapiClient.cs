using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Model.Enums;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.APIClient
{
    public class ScreenWebapiClient
    {
        public string OAuthToken = Token.GetAccessToken();

        #region 用户相关

        #region 根据手机号码获取会员账号和成员账号
        /// <summary>
        /// 根据手机号码获取会员账号和成员账号
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <returns></returns>
        public List<M_PatientExtendInfo> GetPatientAndRelationInfoByMobile(string mobile)
        {
            List<M_PatientExtendInfo> mPatientExtendInfos = null;
            M_APIError mApiError = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/Patient/GetPatientAndRelationInfoByMobile?mobile={1}", "http://rempapi.e24health.com/user", mobile))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    mApiError = JsonConvert.DeserializeObject<M_APIError>(result);
                    mPatientExtendInfos = JsonConvert.DeserializeObject<List<M_PatientExtendInfo>>(mApiError.ReturnData.ToString());
                }
            }
            return mPatientExtendInfos;
        }
        #endregion

        #region 根据手机号码获取会员账号
        /// <summary>
        /// 根据手机号码获取会员账号
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <returns></returns>
        public List<M_PatientExtendInfo> GetPatientByMobile(string mobile)
        {
            List<M_PatientExtendInfo> mPatientExtendInfos = null;
            M_APIError mApiError = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/Patient/GetPatientAndAccountInfoByMobile?mobile={1}", "http://rempapi.e24health.com/user", mobile))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != null)
                {
                    mApiError = JsonConvert.DeserializeObject<M_APIError>(result);
                    mPatientExtendInfos = JsonConvert.DeserializeObject<List<M_PatientExtendInfo>>(mApiError.ReturnData.ToString());
                }
            }
            return mPatientExtendInfos;
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public M_User Login(string account, string pwd)
        {
            M_User mUser = null;

            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/Login?account={1}&pwd={2}", "http://rempapi.e24health.com/Screen", account, pwd))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mUser = JsonConvert.DeserializeObject<M_User>(subResult);
                }
            }
            return mUser;
        }
        #endregion

        #region 注册
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="mobile">账号或手机号</param>
        /// <param name="password">密码</param>
        /// <param name="patientName">姓名</param>
        /// <param name="credNo">身份证号码</param>
        /// <param name="sex">性别1.男 2.女</param>
        /// <param name="birthDay">生日</param>
        /// <returns></returns>
        public M_Msg Regist(string account, string mobile, string password, string patientName, string credNo, int sex,DateTime? birthDay, int orgId)
        {
            M_Msg mMsg = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/Regist?account={1}&mobile={2}&password={3}&patientName={4}&credNo={5}&sex={6}&birthDay={7}&orgId={8}", "http://rempapi.e24health.com/Screen", account, mobile, password, patientName, credNo, sex, birthDay, orgId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mMsg = JsonConvert.DeserializeObject<M_Msg>(subResult);
                }
            }
            return mMsg;
        }
        #endregion

        #region 获取用户信息
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public M_User GetUserInfo(int userId)
        {
            M_User mUser = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetUserInfo?userId={1}", "http://rempapi.e24health.com/Screen", userId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mUser = JsonConvert.DeserializeObject<M_User>(subResult);
                }
            }
            return mUser;
        }

        #endregion

        #region 根据身份证ID获取用户信息
        /// <summary>
        /// 根据身份证ID获取用户信息
        /// </summary>
        /// <param name="cradNo">身份证</param>
        /// <returns></returns>
        public M_User GetUserInfoByCardNo(string cradNo)
        {
            M_User mUser = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetUserInfoByCardNo?cradNo={1}", "http://rempapi.e24health.com/Screen", cradNo))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mUser = JsonConvert.DeserializeObject<M_User>(subResult);
                }
            }
            return mUser;
        }
        #endregion

        #region 检测账号是否存在
        /// <summary>
        /// 检测账号是否存在
        /// </summary>
        /// <param name="account">账号</param>
        /// <returns></returns>
        public bool GetUserInfoByAccount(string account)
        {
            bool result=true;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetUserInfoByAccount?account={1}", "http://rempapi.e24health.com/Screen", account))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<bool>(subResult);
                }
            }
            return result;
        }
        #endregion

        #region 根据账号获取医生信息
        /// <summary>
        /// 根据账号获取医生信息
        /// </summary>
        /// <param name="account">医生账号</param>
        /// <returns></returns>
        public M_DoctorInfo GetDoctorInfoByAccount(string account)
        {
            M_DoctorInfo mDoctorInfo = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetDoctorInfoByAccount?account={1}", "http://rempapi.e24health.com/Screen", account))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mDoctorInfo = JsonConvert.DeserializeObject<M_DoctorInfo>(subResult);
                }
            }
            return mDoctorInfo;
        }
        #endregion

        #region 更新当前会员所有特性记录列表
        /// <summary>
        /// 更新当前会员所有特性记录列表
        /// </summary>
        /// <param name="patientId">会员Id</param>
        /// <param name="records">会员特性记录集合</param>
        /// <param name="recordLog">会员特性记录日志对象</param>
        /// <param name="CARecordID">活动记录Id</param>
        /// <param name="remark">备注</param>
        public void UpdateMemberAllRecords(int patientId, List<M_MemberFeaturesRecord> records,
            M_MemberFeaturesRecordLogExt recordLog = null,
            int? CARecordID = null, string remark = null)
        {
            M_MemberAllRecord mMemberAllRecord=new M_MemberAllRecord
            {
                PatientId = patientId,
                MemberFeaturesRecordList = records,
                MemberFeaturesRecordLogExt = recordLog,
                CARecordID = CARecordID!=null?Convert.ToInt32(CARecordID):0,
                Remark = remark
            };

            var httpClient=new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/UpdateMemberAllRecords", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(mMemberAllRecord);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;

            var result = response.StatusCode == HttpStatusCode.OK
                ? response.Content.ReadAsStringAsync().Result
                : response.ToString();

        }
        #endregion

        #region 删除会员特性记录
        /// <summary>
        /// 删除会员特性记录
        /// </summary>
        /// <param name="mDelMemberFeaturesRecord">用于删除会员特性标签类</param>
        public void DeleteMemberFeaturesRecordByCActivityId(M_DelMemberFeaturesRecord mDelMemberFeaturesRecord)
        {
            var httpClient=new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/DelMemberFeaturesRecordByCActivityId", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(mDelMemberFeaturesRecord);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;
            var result = response.StatusCode == HttpStatusCode.OK
                ? response.Content.ReadAsStringAsync().Result
                : response.ToString();
        }
        #endregion

        #endregion

        #region 问卷相关

        #region 添加用户问卷记录
        /// <summary>
        /// 添加用户问卷记录
        /// </summary>
        /// <param name="mQuestionnaireUserDetail">问卷对象</param>
        /// <returns></returns>
        public M_QuestionnaireUserDetail AddQuestionUser(M_QuestionnaireUserDetail mQuestionnaireUserDetail)
        {
            //M_QuestionnaireUserDetail mQuestionnaireUserDetail=new M_QuestionnaireUserDetail();

            var httpClient = new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/AddQuestionUser", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(mQuestionnaireUserDetail);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;

            var subResult = response.StatusCode == HttpStatusCode.OK
                ? response.Content.ReadAsStringAsync().Result
                : response.ToString();

            M_QuestionnaireUserDetail result = null;
            if (subResult != null)
            {
                subResult = subResult.Substring(1, subResult.Length - 2);
                result = JsonConvert.DeserializeObject<M_QuestionnaireUserDetail>(subResult);
            }
            return result;
        }

        #endregion

        #region 查询已完成的问题答案
        /// <summary>
        /// 查询已完成的问题答案
        /// </summary>
        /// <param name="patientId">会员Id</param>
        /// <param name="questionnaireCode">问卷Code</param>
        /// <returns></returns>
        public List<M_QuestionnaireResultDetail> GetQuestionnaireResultList(int patientId, string questionnaireCode)
        {
            List<M_QuestionnaireResultDetail> mQuestionnaireResultDetails = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetQuestionnaireResultList?patientId={1}&questionnaireCode={2}", "http://rempapi.e24health.com/Screen", patientId, questionnaireCode))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mQuestionnaireResultDetails = JsonConvert.DeserializeObject<List<M_QuestionnaireResultDetail>>(subResult);
                }
            }
            return mQuestionnaireResultDetails;
        } 
        #endregion

        #region 保存问题
        /// <summary>
        /// 保存问题
        /// </summary>
        /// <param name="mQuestionnaireResultDetail">问题对象</param>
        /// <returns></returns>
        public int AddQuestionResult(M_QuestionnaireResultDetail mQuestionnaireResultDetail)
        {
            var httpClient = new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/AddQuestionResult", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(mQuestionnaireResultDetail);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;

            var subResult = response.StatusCode == HttpStatusCode.OK
                ? response.Content.ReadAsStringAsync().Result
                : response.ToString();

            int result = 0;
            if (subResult != null)
            {
                subResult = subResult.Substring(1, subResult.Length - 2);
                int.TryParse(subResult, out result);
            }

            return result;
        }
        #endregion

        #region 修改用户填写问卷状态为已完成
        /// <summary>
        /// 修改用户填写问卷状态为已完成
        /// </summary>
        /// <param name="questionnaireRecodId">问卷Id</param>
        /// <returns></returns>
        public bool UpdateUserRecordStatus(int questionnaireRecodId)
        {
            bool result = false;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/UpdateUserRecordStatus?questionnaireRecodId={1}", "http://rempapi.e24health.com/Screen", questionnaireRecodId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<bool>(subResult);
                }
            }
            return result;
        }
        #endregion

        #region 根据记录ID，题目编码，新答案更新
        /// <summary>
        /// 根据记录ID，题目编码，新答案更新
        /// </summary>
        /// <param name="questionUserId">问卷记录Id</param>
        /// <param name="questionCode">问卷Code</param>
        /// <param name="newQuestionResult">问题答案</param>
        /// <param name="questionScore">问题分数</param>
        /// <param name="pQuestionWeightScore">所属大题权重分</param>
        /// <returns></returns>
        public bool UpdateQuestionnaireResult(int questionUserId, string questionCode,
            string newQuestionResult, decimal questionScore, decimal pQuestionWeightScore)
        {
            bool result = false;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/UpdateQuestionnaireResult?questionUserId={1}&questionCode={2}&newQuestionResult={3}&questionScore={4}&pQuestionWeightScore={5}", "http://rempapi.e24health.com/Screen", questionUserId, questionCode, newQuestionResult, questionScore, pQuestionWeightScore))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<bool>(subResult);
                }
            }
            return result;
        }
        #endregion

        #region 修改问卷的分数及状态
        /// <summary>
        /// 修改问卷的分数及状态
        /// </summary>
        /// <param name="questionnaireRecodID">问卷记录Id</param>
        /// <param name="score">分数</param>
        /// <param name="questionnaireStatus">问卷状态</param>
        /// <returns></returns>
        public int UpdateQuestionUserScoreStatus(int questionnaireRecodID, decimal score,
            int questionnaireStatus)
        {
            int result = 0;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/UpdateQuestionUserScoreStatus?questionnaireRecodID={1}&score={2}&questionnaireStatus={3}", "http://rempapi.e24health.com/Screen", questionnaireRecodID, score, questionnaireStatus))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<int>(subResult);
                }
            }
            return result;
        }
        #endregion

        #region 根据编码获取问卷列表
        /// <summary>
        /// 根据编码获取问卷列表
        /// </summary>
        /// <param name="questionnaireCode">问卷编码</param>
        /// <returns></returns>
        public List<M_QuestionnaireUserDetail> GetQuestionnaireUserDetailsByCode(string questionnaireCode)
        {
            List<M_QuestionnaireUserDetail> mQuestionnaireUserDetails = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetQuestionnaireUserDetailsByCode?questionnaireCode={1}", "http://rempapi.e24health.com/Screen", questionnaireCode))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mQuestionnaireUserDetails = JsonConvert.DeserializeObject<List<M_QuestionnaireUserDetail>>(subResult);
                }
            }
            return mQuestionnaireUserDetails;
        } 
        #endregion

        #region 根据问卷Id获取题目集合
        /// <summary>
        /// 根据问卷Id获取题目集合
        /// </summary>
        /// <param name="questionUserId">问卷Id</param>
        /// <returns></returns>
        public List<M_QuestionnaireResultDetail> GetQuestionnaireResultDetails(int questionUserId)
        {
            List<M_QuestionnaireResultDetail> mQuestionnaireResultDetails = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetQuestionnaireResultDetails?questionUserId={1}", "http://rempapi.e24health.com/Screen", questionUserId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mQuestionnaireResultDetails = JsonConvert.DeserializeObject<List<M_QuestionnaireResultDetail>>(subResult);
                }
            }
            return mQuestionnaireResultDetails;
        } 
        #endregion

        #region 修改问卷的分数
        /// <summary>
        /// 修改问卷的分数
        /// </summary>
        /// <param name="questionnaireRecodID">问卷记录Id</param>
        /// <param name="score">分数</param>
        /// <returns></returns>
        public int UpdateQuestionUserScore(int questionnaireRecodID, decimal score)
        {
            int result = 0;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/UpdateQuestionUserScore?questionnaireRecodID={1}&score={2}", "http://rempapi.e24health.com/Screen", questionnaireRecodID, score))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<int>(subResult);
                }
            }
            return result;
        }
        #endregion

        #region 根据问卷类型及编码获取问卷集合
        /// <summary>
        /// 根据问卷类型及编码获取问卷集合
        /// </summary>
        /// <param name="questionnaireCode">问卷编码</param>
        /// <param name="questionnaireType">问卷类型</param>
        /// <returns></returns>
        public List<M_QuestionnaireUserDetail> GetQuestionnaireListByTypeAndCode(string questionnaireCode,
            sbyte questionnaireType)
        {
            List<M_QuestionnaireUserDetail> mQuestionnaireUserDetails = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetQuestionnaireListByTypeAndCode?questionnaireCode={1}&questionnaireType={2}", "http://rempapi.e24health.com/Screen", questionnaireCode, questionnaireType))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mQuestionnaireUserDetails = JsonConvert.DeserializeObject<List<M_QuestionnaireUserDetail>>(subResult);
                }
            }
            return mQuestionnaireUserDetails;
        } 
        #endregion

        #region 更新题目权重分
        /// <summary>
        /// 更新题目权重分
        /// </summary>
        /// <param name="weightScore">权重分</param>
        /// <param name="resultId">问题Id</param>
        /// <returns></returns>
        public int UpdateQuestionnaireResultWeightScore(decimal weightScore, int resultId)
        {
            int result = 0;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/UpdateQuestionnaireResultWeightScore?weightScore={1}&resultId={2}", "http://rempapi.e24health.com/Screen", weightScore, resultId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<int>(subResult);
                }
            }
            return result;
        }
        #endregion

        #region 根据问卷编码、会员Id、活动Id查询问卷记录
        /// <summary>
        /// 根据问卷编码、会员Id、活动Id查询问卷记录
        /// </summary>
        /// <param name="questionnaireCode">问卷编码</param>
        /// <param name="pid">会员Id</param>
        /// <param name="activityId">活动Id</param>
        /// <returns></returns>
        public M_QuestionnaireUserDetail AlreadyExistQuestionnaire(string questionnaireCode, int pid, int activityId)
        {
            M_QuestionnaireUserDetail mQuestionnaireUserDetail = null;
            var httpClient=new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/AlreadyExistQuestionnaire?questionnaireCode={1}&pid={2}&activityId={3}", "http://rempapi.e24health.com/Screen", questionnaireCode, pid,activityId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    var mAPIReturnMsg = JsonConvert.DeserializeObject<M_APIReturnMsg>(subResult);
                    if (mAPIReturnMsg.ReturnData!=null)
                    {
                        mQuestionnaireUserDetail =
                        JsonConvert.DeserializeObject<M_QuestionnaireUserDetail>(mAPIReturnMsg.ReturnData.ToString());
                    }
                }
            }
            return mQuestionnaireUserDetail;
        }
        #endregion

        #region 根据Id查询问卷记录
        /// <summary>
        /// 根据Id查询问卷记录
        /// </summary>
        /// <param name="id">问卷Id</param>
        /// <returns></returns>
        public M_QuestionnaireUserDetail GetQuestionnaireUserDetailById(int id)
        {
            M_QuestionnaireUserDetail mQuestionnaireUserDetail = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetQuestionnaireUserDetailById?id={1}", "http://rempapi.e24health.com/Screen", id))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    var result = JsonConvert.DeserializeObject<M_APIReturnMsg>(subResult);
                    mQuestionnaireUserDetail =
                        JsonConvert.DeserializeObject<M_QuestionnaireUserDetail>(result.ReturnData.ToString());
                }
            }
            return mQuestionnaireUserDetail;
        }
        #endregion

        #region 修改问卷的状态
        /// <summary>
        /// 修改问卷的状态
        /// </summary>
        /// <param name="mQuestionnaireUserDetail">问卷记录对象，状态有（0：未完成 1：已完成 2：已作废）</param>
        /// <returns></returns>
        public int UpdateQuestionnaireStatus(M_QuestionnaireUserDetail mQuestionnaireUserDetail)
        {
            var httpClient = new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/UpdateQuestionnaireStatus", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(mQuestionnaireUserDetail);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;
            var subResult = response.StatusCode == HttpStatusCode.OK
                ? response.Content.ReadAsStringAsync().Result
                : response.ToString();

            int result = 0;
            if (subResult != null)
            {
                subResult = subResult.Substring(1, subResult.Length - 2);
                var obj= JsonConvert.DeserializeObject<M_APIReturnMsg>(subResult);
                int.TryParse(obj.ReturnData.ToString(), out result);
            }

            return result;
        }
        #endregion
        
        #endregion

        #region 活动相关

        #region 更新小屋活动的类型为专项活动
        /// <summary>
        /// 更新小屋活动的类型为专项活动
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <param name="drId"></param>
        /// <returns></returns>
        public bool UpdateCottageActivityTypeTo1(int id, int type, int? drId)
        {
            bool result = false;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/UpdateCottageActivityTypeTo1?id={1}&type={2}&drId={3}", "http://rempapi.e24health.com/Screen", id, type, drId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<bool>(subResult);
                }
            }
            return result;
        }
        #endregion

        #region 会员关联活动
        /// <summary>
        /// 会员关联活动
        /// </summary>
        /// <param name="entity">活动记录对象</param>
        /// <returns></returns>
        public M_CottageActivityRecord AddPatientToCottageActivity(M_CottageActivityRecord entity)
        {
            M_CottageActivityRecord mCottageActivityRecord = null;

            var httpClient = new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/AddPatientToCottageActivity", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(entity);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult= response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mCottageActivityRecord = JsonConvert.DeserializeObject<M_CottageActivityRecord>(subResult);
                }
                
            }

            return mCottageActivityRecord;
        }
        #endregion

        #region 根据活动名称查询活动
        /// <summary>
        /// 根据活动名称查询活动
        /// </summary>
        /// <param name="name">活动名称</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="pageSize">每页条数</param>
        /// <returns></returns>
        public M_CAPaging GetCottageActivityByName(string name,int pageIndex,int pageSize)
        {
            M_CAPaging mCaPaging = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetCottageActivityByName?name={1}&pageIndex={2}&pageSize={3}", "http://rempapi.e24health.com/Screen", name,pageIndex,pageSize))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);

                    mCaPaging = JsonConvert.DeserializeObject<M_CAPaging>(subResult);
                }
            }
            return mCaPaging;
        }
        #endregion

        #region 根据活动Id查询活动
        /// <summary>
        ///  根据活动Id查询活动
        /// </summary>
        /// <param name="id">活动Id</param>
        /// <returns></returns>
        public M_CottageActivity GetMCottageActivityById(int id)
        {
            M_CottageActivity mCottageActivity = null;
            var httpClient=new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetMCottageActivityById?id={1}", "http://rempapi.e24health.com/Screen", id))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mCottageActivity = JsonConvert.DeserializeObject<M_CottageActivity>(subResult);
                }
            }
            return mCottageActivity;
        }

        #endregion

        #region 根据活动id和会员id获取活动报名记录
        /// <summary>
        /// 根据活动id和会员id获取活动报名记录
        /// </summary>
        /// <param name="CActivityID">活动Id</param>
        /// <param name="PatientId">会员Id</param>
        /// <returns></returns>
        public M_CottageActivityRecord GetRecordByParm(int CActivityID, int PatientId)
        {
            M_CottageActivityRecord mCottageActivityRecord = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetRecordByParm?CActivityID={1}&PatientId={2}", "http://rempapi.e24health.com/Screen", CActivityID, PatientId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mCottageActivityRecord = JsonConvert.DeserializeObject<M_CottageActivityRecord>(subResult);
                }
            }
            return mCottageActivityRecord;
        }
        #endregion

        #region 根据活动id和关系编码获取活动报名记录
        /// <summary>
        /// 根据活动id和关系编码获取活动报名记录
        /// </summary>
        /// <param name="cActivityId">活动Id</param>
        /// <param name="relationtId">关系编码</param>
        /// <returns></returns>
        public M_CottageActivityRecord GetRecordByRelationtId(int cActivityId, int relationtId)
        {
            M_CottageActivityRecord mCottageActivityRecord = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetRecordByRelationtId?cActivityId={1}&relationtId={2}", "http://rempapi.e24health.com/Screen", cActivityId, relationtId))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mCottageActivityRecord = JsonConvert.DeserializeObject<M_CottageActivityRecord>(subResult);
                }
            }
            return mCottageActivityRecord;
        }
        #endregion

        #region 修改活动
        /// <summary>
        /// 修改活动
        /// </summary>
        /// <param name="mCottageActivityRecord">小屋活动记录对象</param>
        /// <returns></returns>
        public M_CottageActivityRecord UpdateCottageActivityRecord(M_CottageActivityRecord mCottageActivityRecord)
        {
            M_CottageActivityRecord result = null;

            var httpClient = new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/UpdateCottageActivityRecord", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(mCottageActivityRecord);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    result = JsonConvert.DeserializeObject<M_CottageActivityRecord>(subResult);
                }
                
            }

            return result;
        }
        #endregion

        #endregion

        #region 小屋相关

        #region 根据小屋名称查询小屋
        /// <summary>
        /// 根据小屋名称查询小屋
        /// </summary>
        /// <param name="name">小屋名称</param>
        /// <returns></returns>
        public List<M_HealthHouse> GetHealthHouseByName(string name)
        {
            List<M_HealthHouse> mHealthHouses = null;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetHealthHouseByName?name={1}", "http://rempapi.e24health.com/Screen", name))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    mHealthHouses = JsonConvert.DeserializeObject<List<M_HealthHouse>>(subResult);
                }
            }
            return mHealthHouses;
        }

        #endregion

        #endregion

        #region 其他基础数据相关

        #region 获取血压结果
        /// <summary>
        /// 获取血压结果
        /// </summary>
        /// <param name="gender">性别 0男,1女</param>
        /// <param name="age">年龄</param>
        /// <param name="height">身高</param>
        /// <param name="sbpValue">收缩压</param>
        /// <param name="dbpValue">舒张压</param>
        /// <returns></returns>
        public BloodPressureState GetBloodPressureResult(int gender, int age, short height, int sbpValue, int dbpValue)
        {
            //int result = -1;
            BloodPressureState bloodPressureState = BloodPressureState.NotSet;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetBloodPressureResult?gender={1}&age={2}&height={3}&sbpValue={4}&dbpValue={5}", "http://rempapi.e24health.com/Screen", gender, age, height, sbpValue, dbpValue))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    var obj = JsonConvert.DeserializeObject<M_APIReturnMsg>(subResult).ReturnData;
                    bloodPressureState = (BloodPressureState)Enum.Parse(typeof(BloodPressureState), obj.ToString());
                }
            }
            return bloodPressureState;
        } 
        #endregion

        #region 获取血糖状态结果
        /// <summary>
        /// 获取血糖状态结果
        /// </summary>
        /// <param name="envir">血糖监视环境</param>
        /// <param name="bloodGlucose">血糖值</param>
        /// <returns></returns>
        public BloodSugarState GetBloodSugarState(int envir, double bloodGlucose)
        {
            BloodSugarState bloodSugarState = BloodSugarState.NotSet;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetBloodSugarState?envir={1}&bloodGlucose={2}", "http://rempapi.e24health.com/Screen", envir, bloodGlucose))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    var obj = JsonConvert.DeserializeObject<M_APIReturnMsg>(subResult).ReturnData;
                    bloodSugarState = (BloodSugarState)Enum.Parse(typeof(BloodSugarState), obj.ToString());
                }
            }
            return bloodSugarState;
        }
        #endregion

        #region 获取BMI超重、肥胖筛查结果
        /// <summary>
        /// 获取BMI超重、肥胖筛查结果
        /// </summary>
        /// <param name="gender">性别 0男,1女</param>
        /// <param name="age">年龄</param>
        /// <param name="weightValue">体重</param>
        /// <returns></returns>
        public WeightStandardState GetBmiResult(int gender, int age, decimal bmiValue)
        {
            WeightStandardState weightStandardState = WeightStandardState.NotSet;
            var httpClient = new OAuthHttpClient(OAuthToken)
            {
                BaseAddress = new Uri(string.Format("{0}/ATM/GetBmiResult?gender={1}&age={2}&bmiValue={3}", "http://rempapi.e24health.com/Screen", gender, age, bmiValue))
            };
            var response = httpClient.GetAsync("").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subResult = response.Content.ReadAsStringAsync().Result;
                if (subResult != null)
                {
                    subResult = subResult.Substring(1, subResult.Length - 2);
                    var obj = JsonConvert.DeserializeObject<M_APIReturnMsg>(subResult).ReturnData;
                    weightStandardState = (WeightStandardState)Enum.Parse(typeof(WeightStandardState), obj.ToString());
                }
            }
            return weightStandardState;
        }
        #endregion

        #endregion

        #region 添加错误日志
        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="log">日志对象</param>
        public void AddErrorLog(M_LogForAtm log)
        {
            var httpClient = new OAuthHttpClient(OAuthToken);
            var uri = new Uri(string.Format("{0}/ATM/AddErrorLogForAtm", "http://rempapi.e24health.com/Screen"));
            var data = JsonConvert.SerializeObject(log);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(uri, content).Result;
        }

        #endregion
    }
}
