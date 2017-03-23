using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening.Services;

namespace XYS.Remp.Screening.HistoryData
{
    /// <summary>
    /// 处理康复脊柱历史数据
    /// </summary>
    public class KangfuJizhu
    {
        //private static ScreeningServiceClient client = new ScreeningServiceClient();
        private static ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        public int UpdateHistoryData()
        {
            int result = 0;
            var questionnaireList = screenWebapiClient.GetQuestionnaireListByTypeAndCode("KANGFUJIZHU", 1);
            //更新问卷分数
            if (questionnaireList != null)
            {
                for (int i = 0; i < questionnaireList.Count(); i++)
                {
                    questionnaireList[i].QuestionnaireScore = GetQuestionnaireScore(questionnaireList[i].QuestionnaireRecodId);

                    //将分数更新到数据库
                    result = screenWebapiClient.UpdateQuestionUserScore(questionnaireList[i].QuestionnaireRecodId,
                        questionnaireList[i].QuestionnaireScore);
                }
            }
            return result;
        }

        private int GetQuestionnaireScore(int questionUserId)
        {

            var questions = screenWebapiClient.GetQuestionnaireResultDetails(questionUserId);
            //计算每题得分
            int score = 0;
            if (questions != null && questions.Any())
            {
                for (int i = 0; i < questions.Count(); i++)
                {
                    string answer = questions[i].QuestionResult;

                    if (!string.IsNullOrEmpty(answer) && answer.Contains("A"))
                    {
                        score += 10;
                    }

                }// end for

            }// end  if (questions != null && questions.Count > 0)

            return score;
        }
    }
}
