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
    /// 处理康复足踝历史数据
    /// </summary>
    public class KangfuZuHuai
    {
        //private static ScreeningServiceClient client = new ScreeningServiceClient();
        private static ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();

        public int UpdateHistoryData()
        {
            int result = 0;
            //var questionnaireList = client.GetQuestionnaireUserDetailsByCode("KANGFUZUHUAI");
            var questionnaireList = screenWebapiClient.GetQuestionnaireListByTypeAndCode("KANGFUZUHUAI", 1);
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
            var questionResults = screenWebapiClient.GetQuestionnaireResultDetails(questionUserId);

            int score = 0;

            #region 计算每题得分
            if (questionResults != null && questionResults.Any())
            {
                for (int i = 0; i < questionResults.Count(); i++)
                {
                    var model = questionResults[i];
                    QuestionnaireResultDetail result = new QuestionnaireResultDetail();
                    result.QuestionCode = model.QuestionCode;
                    result.QuestionResult = model.QuestionResult;


                    int tempScore = 0;

                    string answer = result.QuestionResult;

                    //第一题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".1")
                    {

                        if (answer.Contains("A") || (answer.Contains("B")) || answer.Contains("C") || answer.Contains("D"))
                        {
                            score += 15;
                        }
                        else if (answer.Contains("E"))
                        {
                            score += 5;
                        }

                    }// end 第一题

                    //第二题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".2")
                    {

                        if (answer.Contains("A"))
                        {
                            tempScore += 3;
                        }
                        if (answer.Contains("B"))
                        {
                            tempScore += 2;
                        }
                        if (answer.Contains("C"))
                        {
                            tempScore += 5;
                        }

                        if (tempScore > 5) tempScore = 5;

                        score += tempScore;

                    }//end 第二题

                    //第三题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".3")
                    {
                        if (answer.Contains("A"))
                        {
                            score += 5;
                        }
                    }

                    //第四题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".4")
                    {
                        if (answer.Contains("A") || answer.Contains("B") || answer.Contains("C"))
                        {
                            score += 15;
                        }
                    }

                    //第五题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".5")
                    {
                        if (answer.Contains("A") || answer.Contains("B"))
                        {
                            score += 5;
                        }
                    }

                    //第六题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".6")
                    {
                        if (answer.Contains("A") || answer.Contains("B") || answer.Contains("C"))
                        {
                            score += 10;
                        }
                    }

                    //第七题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".7")
                    {
                        tempScore = 0;
                        if (answer.Contains("A"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("B"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("C"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("D"))
                        {
                            tempScore += 5;
                        }
                        if (tempScore > 10) tempScore = 10;

                        score += tempScore;
                    }

                    //第八题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".8")
                    {
                        tempScore = 0;
                        if (answer.Contains("A"))
                        {
                            tempScore += 5;
                        }
                        if (answer.Contains("B"))
                        {
                            tempScore += 3;
                        }
                        if (answer.Contains("C"))
                        {
                            tempScore += 3;
                        }
                        if (answer.Contains("D"))
                        {
                            tempScore += 2;
                        }
                        if (answer.Contains("E"))
                        {
                            tempScore += 2;
                        }
                        if (tempScore > 10) tempScore = 10;

                        score += tempScore;
                    }

                    //第九题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".9")
                    {
                        if (answer.Contains("A"))
                        {
                            score += 5;
                        }
                        if (answer.Contains("B"))
                        {
                            score += 3;
                        }
                    }

                    //第10题
                    if (result.QuestionCode.Trim() == QuestionnaireCode.KangFuZuHuai + ".10")
                    {
                        if (answer.Contains("B"))
                        {
                            score += 5;
                        }
                        if (answer.Contains("C"))
                        {
                            score += 10;
                        }
                        if (answer.Contains("D"))
                        {
                            score += 15;
                        }
                    }

                }// end for


            }// end  if (questions != null && questions.Count > 0)

            return score;

            #endregion;
        }
    }
}
