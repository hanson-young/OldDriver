using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;

namespace XYS.Remp.Screening.Public
{
    public static class ClientInfo
    {
        //private static ScreeningServiceClient client = new ScreeningServiceClient();

        private static ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        //保存新产生的问卷记录，并返回新增的记录ID
        private static Model.M_QuestionnaireUserDetail SaveUserQuestionnair(Model.M_QuestionnaireUserDetail questionnair)
        {
            //client=new ScreeningServiceClient();
            Model.M_QuestionnaireUserDetail result = null;

            questionnair.PatientId = questionnair.UserId;
            if (questionnair.UserId > 0)
            {

                result = screenWebapiClient.AddQuestionUser(questionnair);
            }
            return result;
        }

        //保存每次的答题记录并返回新增的记录ID。
        private static int SaveUserQuestionResult(Model.M_QuestionnaireResultDetail question)
        {
            //client=new ScreeningServiceClient();
            var result = screenWebapiClient.AddQuestionResult(question);
            //client.Close();
            return result;
        }

        //在客户端缓存中增加一个问卷记录，如果已存在此问卷则返回false
        public static bool AddQuestionnaire(Model.M_QuestionnaireUserDetail questionnaire)
        {
            LoginInfo login = LoginInfo.GetInstance();
            if (login.Questionnairs.ContainsKey(questionnaire.QuestionnaireCode))
            {
                return false;
            }
            else 
            {
                //设置界面选择了访客模式，则活动Id置为0
                if (Properties.Settings.Default.SetIsCustomer)
                {
                    questionnaire.ActivityId = 0;
                    questionnaire.ActivityName=string.Empty;
                }

                //先在服务端添加记录

                if (login.UserId > 0)
                {
                    Model.M_QuestionnaireUserDetail mQuestionnaireUserDetail=SaveUserQuestionnair(questionnaire);

                    questionnaire.QuestionnaireRecodId = mQuestionnaireUserDetail.QuestionnaireRecodId;
                    questionnaire.AnswerTime = mQuestionnaireUserDetail.AnswerTime;

                    //将问卷记录Id记录到全局变量中去
                    Properties.Settings.Default.QuestionnaireRecodId = mQuestionnaireUserDetail.QuestionnaireRecodId;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    questionnaire.QuestionnaireRecodId = -1; //游客模式登录，问卷ID为-1，不在服务端保存。
                }

                //初始化问卷的题目列表
                questionnaire.Questions = new List<Model.M_QuestionnaireResultDetail>();

                //再添加到客户端缓存
                login.Questionnairs.Add(questionnaire.QuestionnaireCode, questionnaire);

                return true;
            }
        }

        //根据问卷代码获取用户本次登录回答的某个问卷对象
        public static Model.M_QuestionnaireUserDetail GetQuestionnaireByCode(string questionnaireCode)
        {
            LoginInfo login = LoginInfo.GetInstance();
            if (login.Questionnairs.Contains(questionnaireCode))
            {
                Model.M_QuestionnaireUserDetail questionnaire = (Model.M_QuestionnaireUserDetail)login.Questionnairs[questionnaireCode];
                return questionnaire;
              
            }
            else
            {
                return null;
            }
        }

        //往某个问卷里添加一个回答记录。
        public static bool AddQuestionToQuestionnaire(Model.M_QuestionnaireResultDetail question, string questionnaireCode)
        {

            Model.M_QuestionnaireUserDetail questionnaire = GetQuestionnaireByCode(questionnaireCode);

            if (questionnaire == null) return false;

            IList<Model.M_QuestionnaireResultDetail> questions = questionnaire.Questions;

            //foreach (QuestionnaireResultDetail qust in questions)
            //{
            //    if (qust.QuestionCode == question.QuestionCode)
            //    {
            //        //第二次添加同一个题目时，更新题目答案。
            //        qust.QuestionResult = question.QuestionResult;
            //        return false;
            //    }
            //}

            //第二次添加同一个题目时，更新题目答案。
            bool flag = false;
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].QuestionCode == question.QuestionCode)
                {
                    //答案项
                    questions[i].QuestionResult = question.QuestionResult;
                    //题目分数
                    questions[i].QuestionScore = question.QuestionScore;
                    //所属大题加权分
                    questions[i].PQuestionWeightScore = question.PQuestionWeightScore;

                    //更新至数据库
                    //client = new ScreeningServiceClient();
                    //如果登录
                    if (LoginInfo.GetInstance().UserId > 0)
                    {
                        bool result = screenWebapiClient.UpdateQuestionnaireResult(questions[i].QuestionUserId,
                        questions[i].QuestionCode,
                        questions[i].QuestionResult, questions[i].QuestionScore, questions[i].PQuestionWeightScore);

                        //client.Close();

                        
                    }
                    //如果是更新操作，将标记设为true
                    flag = true;
                }
            }
            if (flag)
            {
                //终止
                return false;
            }

            //往服务端添加记录

            question.PatientId = LoginInfo.GetInstance().UserId;
            question.FamilyMemberID = LoginInfo.GetInstance().FamilyMemberID;

            question.QuestionUserId = questionnaire.QuestionnaireRecodId;

            if (question.PatientId > 0)
            {
                try
                {
                    //往服务端添加记录，可能存在网络不好的情况
                    //question.QuestionResultId = SaveUserQuestionResult(question);
                    question.QuestionnaireResultDetailId = SaveUserQuestionResult(question);
                }
                catch (Exception ex)
                {
                    throw new Exception("网络连接失败。"+ex);
                }
            }
            questions.Add(question);
            return true;
            
        }

        /// <summary>
        /// 根据问卷编码和题目编码获取问题答案
        /// </summary>
        /// <param name="qustionnaireCode">问卷代码</param>
        /// <param name="questionCode">题目代码</param>
        /// <returns>题目答案</returns>
        public static string GetAnswerByCode(string questionnaireCode, string questionCode)
        {
            string answer = string.Empty;

            Model.M_QuestionnaireUserDetail questionnaire = GetQuestionnaireByCode(questionnaireCode);

            if (questionnaire == null)
            {
                //return answer;
                //如果本地问卷记录为空，则从数据库取数据
                questionnaire = screenWebapiClient.GetQuestionnaireUserDetailById(Properties.Settings.Default.QuestionnaireRecodId);
                if (questionnaire != null)
                    questionnaire.Questions = screenWebapiClient.GetQuestionnaireResultDetails(questionnaire.QuestionnaireRecodId);
            }

            IList<Model.M_QuestionnaireResultDetail> questions =questionnaire!=null? questionnaire.Questions:null;

            if (questions != null)
            {
                foreach (Model.M_QuestionnaireResultDetail qust in questions)
                {
                    if (qust.QuestionCode == questionCode)
                    {
                        answer = qust.QuestionResult;
                    }
                }
                if (answer == null) answer = string.Empty;
            }
            
            return answer;
        }

        /// <summary>
        /// 退出登录，清空问卷
        /// </summary>
        public static void Logout()
        {
            LoginInfo.GetInstance().UserId = -9;
            LoginInfo.GetInstance().FamilyMemberID = 0;
            LoginInfo.GetInstance().Name = string.Empty;
            LoginInfo.GetInstance().PatientAccount = string.Empty;
            LoginInfo.GetInstance().Phone = string.Empty;
            LoginInfo.GetInstance().Questionnairs.Clear();
        }

        #region 根据问卷编码、会员Id、当前时间查询问卷记录是否存在

        /// <summary>
        /// 根据问卷编码、会员Id、当前时间查询问卷记录是否存在
        /// </summary>
        /// <param name="questionnaireCode">问卷编码</param>
        /// <param name="pid">会员Id</param>
        /// <param name="activityId">活动Id</param>
        /// <returns></returns>
        public static M_QuestionnaireUserDetail AlreadyExistQuestionnaire(string questionnaireCode, int pid,int activityId)
        {
            return screenWebapiClient.AlreadyExistQuestionnaire(questionnaireCode, pid, activityId);
        }
        #endregion

        #region 将本次问卷的得分状态及会员标签更新
        /// <summary>
        /// 将本次问卷的得分状态及会员标签更新
        /// </summary>
        /// <param name="questionnaireUserDetail">问卷对象</param>
        /// <param name="score">问卷分数</param>
        public static void UpdateQuestionnaireStatusScoreAndMemberFeatures(M_QuestionnaireUserDetail questionnaireUserDetail,decimal score,List<int> mfItemsIds)
        {
            int result = screenWebapiClient.UpdateQuestionUserScoreStatus(questionnaireUserDetail.QuestionnaireRecodId, score, 1);
            if (questionnaireUserDetail.ActivityId > 0)
            {
                //更新成功，且有做相同问卷，则作废上一次问卷
                if (result > 0 && Properties.Settings.Default.LastTimeQuestionnaireRecodId > 0)
                {
                    int secResult = screenWebapiClient.UpdateQuestionnaireStatus(new M_QuestionnaireUserDetail
                    {
                        QuestionnaireRecodId = Properties.Settings.Default.LastTimeQuestionnaireRecodId,
                        QuestionnaireStatus = 2,
                        //问卷同步状态（0-未同步 1-同步中 2-同步完成）
                        QuestionnaireSyncStatus = 1
                    });
                    if (secResult > 0)
                    {
                        //清空上次问卷Id
                        Properties.Settings.Default.LastTimeQuestionnaireRecodId = 0;
                        Properties.Settings.Default.Save();

                        //清空上次问卷所打标签
                        screenWebapiClient.DeleteMemberFeaturesRecordByCActivityId(new M_DelMemberFeaturesRecord
                        {
                            CActivityId = Properties.Settings.Default.ActivityId,
                            PatientId = LoginInfo.GetInstance().UserId,
                            MfItemsIds = mfItemsIds,
                            UpdateId = Properties.Settings.Default.DoctorId,
                            UpdateName = Properties.Settings.Default.DoctorName
                        });
                    }
                }
            }
        }
        #endregion
    }
}
