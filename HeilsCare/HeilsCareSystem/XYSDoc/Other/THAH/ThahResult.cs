using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Model.Enums;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.THAH
{
    public partial class ThahResult : BaseForm
    {
        private Font printFont = new Font("Arial", 10); //定义打印文档的字体 
        private StringReader streamToPrint;                //定义一个可连续读取字符的读取器 
        //问卷答题时间
        private DateTime answerTime;
        //打印结果
        private string printResult = string.Empty;
        //综合评估
        private StringBuilder printAppraise=new StringBuilder();

        private ScreenWebapiClient screenWebapiClient = new ScreenWebapiClient();

        public ThahResult()
        {
            InitializeComponent();
        }
        //加载
        private void ThahResult_Load(object sender, EventArgs e)
        {
            try
            {
                M_QuestionnaireUserDetail questionnaireUserDetail =
                        ClientInfo.GetQuestionnaireByCode(QuestionnaireCode.Thah);

                //如果本地问卷记录为空，则从数据库取数据
                if (questionnaireUserDetail == null)
                {
                    questionnaireUserDetail = screenWebapiClient.GetQuestionnaireUserDetailById(Properties.Settings.Default.QuestionnaireRecodId);
                    if (questionnaireUserDetail != null)
                        questionnaireUserDetail.Questions = screenWebapiClient.GetQuestionnaireResultDetails(questionnaireUserDetail.QuestionnaireRecodId);
                }

                //问卷答题时间
                answerTime = questionnaireUserDetail != null ? questionnaireUserDetail.AnswerTime : DateTime.Now;

                //将游客的结果保存为xml
                if (LoginInfo.GetInstance().Name.Equals(""))
                {
                    if (questionnaireUserDetail != null && questionnaireUserDetail.Questions != null &&
                        questionnaireUserDetail.Questions.Any())
                    {
                        string number = Properties.Settings.Default.ScreenNumber.ToString();
                        switch (number.Length)
                        {
                            case 1:
                                number = "000" + number;
                                break;
                            case 2:
                                number = "00" + number;
                                break;
                            case 3:
                                number = "0" + number;
                                break;
                        }
                        SaveXml saveXml = new SaveXml();
                        saveXml.AddXmlElement(number, questionnaireUserDetail.Questions);

                        //显示游客编号
                        lblVisitor.Text += number;
                        lblVisitor.Visible = true;
                    }
                    
                }

                //将登录人与活动关联
                if (!LoginInfo.GetInstance().Name.Equals(""))
                {
                    new CottageActivityManager().AddPToCActivity();
                }

                //将本次问卷的得分更新
                if (questionnaireUserDetail != null && !string.IsNullOrEmpty(LoginInfo.GetInstance().Name))
                {
                    ClientInfo.UpdateQuestionnaireStatusScoreAndMemberFeatures(questionnaireUserDetail,0,new List<int>
                    {
                        int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedPrehypertension")),
                        int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedFirstStageHypertension")),
                        int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedSecondStageHypertension")),
                        int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedPrediabetes")),
                        int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedDiabetes")),
                        int.Parse(ConfigHelper.GetAppsettings("ThahHigherBloodSugar"))
                    });
                }

                //分析结果
                //***************************************血压结果***********************************************
                int? sex = null;
                int? age = null;
                short? height = null;
                //收缩压
                int? sbpValue = null;
                //舒张压
                int? dbpValue = null;
                //第1题的性别：0 男、 1 女
                string answer1 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".1");
                if (answer1.Contains("A"))
                {
                    //男
                    sex = 0;
                }
                if (answer1.Contains("B"))
                {
                    //女
                    sex = 1;
                }

                //第2题的年龄
                string answer2 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".2");
                if (!string.IsNullOrEmpty(answer2))
                    age = int.Parse(answer2.Substring(0, answer2.Length - 1));

                //第3题的身高
                string answer3 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".3");
                if (!string.IsNullOrEmpty(answer3))
                    height = short.Parse(answer3.Substring(0, answer3.Length - 1));

                //第六题，收缩压和舒张压
                string answer6 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".6");
                if (!string.IsNullOrEmpty(answer6))
                {
                    string[] strs6 = answer6.Substring(0, answer6.Length - 1).Split(',');
                    if (!string.IsNullOrEmpty(strs6[0]))
                        sbpValue = int.Parse(strs6[0]);
                    if (!string.IsNullOrEmpty(strs6[1]))
                        dbpValue = int.Parse(strs6[1]);
                }

                //分析结果
                if (sex.HasValue && age.HasValue && height.HasValue && sbpValue.HasValue && dbpValue.HasValue)
                {
                    BloodPressureState bloodPressureState = screenWebapiClient.GetBloodPressureResult(sex.Value, age.Value,
                        height.Value, sbpValue.Value,
                        dbpValue.Value);
                    //血压状态正常
                    if (bloodPressureState == BloodPressureState.Normal)
                    {
                        lblResult.Text += "您本次测定的血压为：" + sbpValue + "/" + dbpValue + " mmHg，<P90th 初步定义为正常血压。（收缩压：" +
                                          sbpValue + "和舒张压：" + dbpValue + "小于P90th）\r\n";

                        printResult = "您本次测定的血压为：" + sbpValue + "/" + dbpValue + " mmHg，<\r\n" +
                                      "P90th。初步定义为正常血压。（收缩压\r\n" +
                                      "：" + sbpValue + "和舒张压：" + dbpValue + "小于P90th）\r\n";

                        lblAppraise.Text = "您目前血压正常，配合良好的睡眠、健康的饮食和适当的体育锻炼有助于维持健康血压水平。\r\n";
                        printAppraise.Append(@"您目前血压正常，配合良好的睡眠、健康
的饮食和适当的体育锻炼有助于维持健康
血压水平。" + "\r\n");
                    }
                    //疑似高血压前期
                    else if (bloodPressureState == BloodPressureState.EarlyStage)
                    {
                        lblResult.Text += "您本次测定的血压为：" + sbpValue + "/" + dbpValue +
                                          " mmHg，≥ P90th 且 <P95th疑似高血压前期，需进一步确诊。（收缩压：" + sbpValue + "或舒张压" + dbpValue +
                                          "≥ P90th，且收缩压：" + sbpValue + "和舒张压" + dbpValue + "<P95th）\r\n";

                        printResult = "您本次测定的血压为：" + sbpValue + "/" + dbpValue + " mmHg，≥\r\n" +
                                      "P90th 且 <P95th疑似高血压前期，需进\r\n" +
                                      "一步确诊。（收缩压：" + sbpValue + "或舒张压" + dbpValue + "≥\r\n" +
                                      "P90th，且收缩压：" + sbpValue + "和舒张压" + dbpValue + "<\r\nP95th）\r\n";

                        lblAppraise.Text =
                            "青少年高血压前期可通过非药物治疗的健康管理方式进行调节，如不及早进行干预，易进一步转化。建议您咨询专科医生，并在医院作进一步检查，提早预知疾病风险并及时进行健康管理。\r\n";

                        printAppraise.Append(@"青少年高血压前期可通过非药物治疗的健
康管理方式进行调节，如不及早进行干预
，易进一步转化。建议您咨询专科医生，
并在医院作进一步检查，提早预知疾病风
险并及时进行健康管理。" + "\r\n");

                        //给用户打标签
                        if (!LoginInfo.GetInstance().Name.Equals(""))
                        {
                            new PatientRecordsManager().UpdatePatientAllRecords(
                                int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedPrehypertension")), "疑似高血压前期");
                        }
                    }
                    //疑似一级高血压
                    else if (bloodPressureState == BloodPressureState.Primary)
                    {
                        lblResult.Text += "您本次测定的血压为：" + sbpValue + "/" + dbpValue +
                                          " mmHg，≥ P95th 且 <P99th+5 mmHg 疑似一级高血压，需进一步确诊。（收缩压：" + sbpValue + "或舒张压：" +
                                          dbpValue + "≥ P95th，且收缩压：" + sbpValue + "和舒张压" + dbpValue + "< P99th+5 mmHg）\r\n";
                        printResult = "您本次测定的血压为：" + sbpValue + "/" + dbpValue + " mmHg，≥\r\n" +
                                      "P95th 且 <P99th+5 mmHg 疑似一级高血\r\n压，" +
                                      "需进一步确诊。（收缩压：" + sbpValue + "或舒张\r\n压：" +
                                      "" + dbpValue + "≥ P95th，且收缩压：" + sbpValue + "和舒张压" + dbpValue + "\r\n" +
                                      "< P99th+5 mmHg）\r\n";

                        lblAppraise.Text =
                            "青少年一级高血压可通过非药物治疗的健康管理方式进行调节，如不及早进行干预，易进一步转化。建议您咨询专科医生，并在医院作进一步检查，提早预知疾病风险并及时进行健康管理。\r\n";

                        printAppraise.Append(@"青少年一级高血压可通过非药物治疗的健
康管理方式进行调节，如不及早进行干预
，易进一步转化。建议您咨询专科医生，
并在医院作进一步检查，提早预知疾病风
险并及时进行健康管理。" + "\r\n");

                        //给用户打标签
                        if (!LoginInfo.GetInstance().Name.Equals(""))
                        {
                            new PatientRecordsManager().UpdatePatientAllRecords(
                                int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedFirstStageHypertension")), "疑似一级高血压");
                        }
                        
                    }
                    //疑似二级高血压
                    else if (bloodPressureState == BloodPressureState.TwoStage)
                    {
                        lblResult.Text += "您本次测定的血压为：" + sbpValue + "/" + dbpValue +
                                          " mmHg，≥ P99th+5 mmHg 疑似二级高血压，需进一步确诊。（收缩压：" + sbpValue + "或舒张压：" + dbpValue +
                                          "≥ P99th+5 mmHg）\r\n";

                        printResult = "您本次测定的血压为：" + sbpValue + "/" + dbpValue + " mmHg，≥\r\n" +
                                      "P99th+5 mmHg 疑似二级高血压，需进一步\r\n" +
                                      "确诊。（收缩压：" + sbpValue + "或舒张压：" + dbpValue + "≥\r\n" +
                                      "P99th+5 mmHg）\r\n";

                        lblAppraise.Text = "您血压的初步筛查结果为二级高血压，建议您及早咨询专科医生，并在医院作进一步检查。必要时需采用药物治疗并配合健康管理方式进行血压控制。" + "\r\n";

                        printAppraise.Append(@"您血压的初步筛查结果为二级高血压，建
议您及早咨询专科医生，并在医院作进一
步检查。必要时需采用药物治疗并配合健
康管理方式进行血压控制。" + "\r\n");

                        //给用户打标签
                        if (!LoginInfo.GetInstance().Name.Equals(""))
                        {
                            new PatientRecordsManager().UpdatePatientAllRecords(
                                int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedSecondStageHypertension")),
                                "疑似二级高血压");
                        }
                    }

                    //***************************************血糖结果***********************************************

                    //第七题
                    int? envir = null;
                    double? bloodGlucose = null;
                    string answer7 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".7");
                    if (!string.IsNullOrEmpty(answer7))
                    {

                        string[] strs = answer7.Substring(0, answer7.Length - 1).Split(',');

                        //空腹
                        if (strs[0].Contains("A"))
                            envir = (int)BloodSugarEnvir.Kongfu;
                        //餐后2小时
                        if (strs[0].Contains("B"))
                            envir = (int)BloodSugarEnvir.Canhou;
                        //随机血糖
                        if (strs[0].Contains("C"))
                            envir = (int)BloodSugarEnvir.Suiji;

                        //填写的数值
                        if (!string.IsNullOrEmpty(strs[1]))
                            bloodGlucose = double.Parse(strs[1]);

                        if (envir.HasValue && bloodGlucose.HasValue)
                        {
                            BloodSugarState bloodSugarState = screenWebapiClient.GetBloodSugarState(envir.Value,
                                bloodGlucose.Value);
                            if (strs[0].Contains("A"))
                            {
                                //正常血糖值
                                if (bloodSugarState == BloodSugarState.Normal)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，＜5.6 mmol/L 初步定义为正常血糖值。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，＜\r\n" +
                                                   "5.6 mmol/L 初步定义为正常血糖值。\r\n";

                                    lblAppraise.Text += "您目前血糖正常，配合良好的睡眠、健康的饮食和适当的体育锻炼有助于维持健康血糖水平。\r\n";
                                    printAppraise.Append(@"您目前血糖正常，配合良好的睡眠、健康
的饮食和适当的体育锻炼有助于维持健康
血糖水平。" + "\r\n");
                                }
                                //疑似糖尿病前期
                                else if (bloodSugarState == BloodSugarState.EarlyStage)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose +
                                                      " mmol/L，≥5.6 mmol/L 且＜7 mmol/L，疑似糖尿病前期，需进一步确诊。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，≥\r\n" +
                                                   "5.6 mmol/L 且＜7 mmol/L，疑似糖尿病\r\n" +
                                                   "前期，需进一步确诊。\r\n";

                                    lblAppraise.Text +=
                                        "您疑似糖尿病前期，为从正常过渡到糖尿病的过渡阶段，必要时采用药物治疗并配合健康管理方式进行血糖控制，有可能使血糖恢复正常。建议您及早咨询专科医生，并在医院作进一步检查。\r\n";

                                    printAppraise.Append(@"您疑似糖尿病前期，为从正常过渡到糖尿
病的过渡阶段，必要时采用药物治疗并配
合健康管理方式进行血糖控制，有可能使
血糖恢复正常。建议您及早咨询专科医生
，并在医院作进一步检查。" + "\r\n");

                                    //给用户打标签
                                    if (!LoginInfo.GetInstance().Name.Equals(""))
                                    {
                                        new PatientRecordsManager().UpdatePatientAllRecords(
                                            int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedPrediabetes")), "疑似糖尿病前期");
                                    }
                                }
                                //疑似糖尿病
                                else if (bloodSugarState == BloodSugarState.SuspectedDiabetes)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，≥7 mmol/L，疑似糖尿病，需进一步确诊。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，≥\r\n" +
                                                   "7 mmol/L，疑似糖尿病，需进一步确\r\n" +
                                                   "诊。\r\n";

                                    lblAppraise.Text +=
                                        "依据您的血糖水平，疑似为糖尿病，建议您及早咨询专科医生，并在医院作进一步检查。必要时需采用药物治疗并配合健康管理方式进行血糖控制。\r\n";

                                    printAppraise.Append(@"依据您的血糖水平，疑似为糖尿病，建议
您及早咨询专科医生，并在医院作进一步
检查。必要时需采用药物治疗并配合健康
管理方式进行血糖控制。" + "\r\n");

                                    //给用户打标签
                                    if (!LoginInfo.GetInstance().Name.Equals(""))
                                    {
                                        new PatientRecordsManager().UpdatePatientAllRecords(
                                            int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedDiabetes")), "疑似糖尿病");
                                    }
                                }
                            }
                            else if (strs[0].Contains("B"))
                            {
                                if (bloodSugarState == BloodSugarState.Normal)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，＜7.8 mmol/L 初步定义为正常血糖值。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，＜\r\n" +
                                                   "7.8 mmol/L 初步定义为正常血糖\r\n" +
                                                   "值。\r\n";

                                    lblAppraise.Text += "您目前血糖正常，配合良好的睡眠、健康的饮食和适当的体育锻炼有助于维持健康血糖水平。\r\n";
                                    printAppraise.Append(@"您目前血糖正常，配合良好的睡眠、健康
的饮食和适当的体育锻炼有助于维持健康
血糖水平。" + "\r\n");
                                }
                                //疑似糖尿病前期
                                else if (bloodSugarState == BloodSugarState.EarlyStage)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose +
                                                      " mmol/L，≥7.8 mmol/L 且＜11.1 mmol/L，疑似糖尿病前期，需进一步确诊。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，≥\r\n" +
                                                   "7.8 mmol/L 且＜11.1 mmol/L，疑似糖\r\n" +
                                                   "尿病前期，需进一步确诊。\r\n";

                                    lblAppraise.Text +=
                                        "您疑似糖尿病前期，为从正常过渡到糖尿病的过渡阶段，必要时采用药物治疗并配合健康管理方式进行血糖控制，有可能使血糖恢复正常。建议您及早咨询专科医生，并在医院作进一步检查。\r\n";
                                    printAppraise.Append(@"您疑似糖尿病前期，为从正常过渡到糖尿
病的过渡阶段，必要时采用药物治疗并配
合健康管理方式进行血糖控制，有可能使
血糖恢复正常。建议您及早咨询专科医生
，并在医院作进一步检查。" + "\r\n");

                                    //给用户打标签
                                    if (!LoginInfo.GetInstance().Name.Equals(""))
                                    {
                                        new PatientRecordsManager().UpdatePatientAllRecords(
                                            int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedPrediabetes")), "疑似糖尿病前期");
                                    }
                                }
                                //疑似糖尿病
                                else if (bloodSugarState == BloodSugarState.SuspectedDiabetes)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose +
                                                      " mmol/L，≥11.1 mmol/L，疑似糖尿病，需进一步确诊。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，≥\r\n" +
                                                   "11.1 mmol/L，疑似糖尿病，需进一步确\r\n" +
                                                   "诊。\r\n";

                                    lblAppraise.Text +=
                                        "依据您的血糖水平，疑似为糖尿病，建议您及早咨询专科医生，并在医院作进一步检查。必要时需采用药物治疗并配合健康管理方式进行血糖控制。\r\n";
                                    printAppraise.Append(@"依据您的血糖水平，疑似为糖尿病，建议
您及早咨询专科医生，并在医院作进一步
检查。必要时需采用药物治疗并配合健康
管理方式进行血糖控制。" + "\r\n");

                                    //给用户打标签
                                    if (!LoginInfo.GetInstance().Name.Equals(""))
                                    {
                                        new PatientRecordsManager().UpdatePatientAllRecords(
                                            int.Parse(ConfigHelper.GetAppsettings("ThahSuspectedDiabetes")), "疑似糖尿病");
                                    }
                                }
                            }
                            else if (strs[0].Contains("C"))
                            {
                                //正常随机血糖
                                if (bloodSugarState == BloodSugarState.NormalSuijiBloodSugar)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose +
                                                      " mmol/L，＜10 mmol/L 初步定义为正常随机血糖值，需进一步确诊。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，＜\r\n" +
                                                   "10 mmol/L 初步定义为正常随机血糖值\r\n" +
                                                   "，需进一步确诊。\r\n";

                                    lblAppraise.Text += "由于您所测量为随机血糖值，初步定义为正常血糖值，但仍需进一步确诊，建议您再次进行“空腹”或“餐后2小时”的血糖测量。\r\n";
                                    printAppraise.Append(@"由于您所测量为随机血糖值，初步定义为
正常血糖值，但仍需进一步确诊，建议您
再次进行“空腹”或“餐后2小时”的血糖测
量。" + "\r\n");
                                }
                                //血糖值偏高
                                else if (bloodSugarState == BloodSugarState.High)
                                {
                                    lblResult.Text += "您本次测量的血糖值为：" + bloodGlucose +
                                                      " mmol/L，≥10 mmol/L 初步定义为血糖值偏高，需进一步确诊。\r\n";
                                    printResult += "您本次测量的血糖值为：" + bloodGlucose + " mmol/L，≥\r\n" +
                                                   "10 mmol/L 初步定义为血糖值偏高，需\r\n" +
                                                   "进一步确诊。\r\n";

                                    lblAppraise.Text += "由于您所测量为随机血糖值，初步定义为血糖值偏高，但仍需进一步确诊，建议您再次进行“空腹”或“餐后2小时”的血糖测量。\r\n";
                                    printAppraise.Append(@"由于您所测量为随机血糖值，初步定义为
血糖值偏高，但仍需进一步确诊，建议您
再次进行“空腹”或“餐后2小时”的血糖测
量。" + "\r\n");
                                    //给用户打标签
                                    if (!LoginInfo.GetInstance().Name.Equals(""))
                                    {
                                        new PatientRecordsManager().UpdatePatientAllRecords(
                                            int.Parse(ConfigHelper.GetAppsettings("ThahHigherBloodSugar")), "血糖值偏高");
                                    }
                                }
                            }
                        }
                    }

                    //***************************************高危因素结果***********************************************
                    //第八题及第九题，≥1个，选择了B、C、D
                    StringBuilder sb = new StringBuilder();
                    StringBuilder sbText = new StringBuilder();
                    string answer8 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".8");
                    string answer9 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".9");
                    if (answer8.Contains("B") || answer8.Contains("C") || answer8.Contains("D") || answer9.Contains("B") ||
                        answer9.Contains("C") || answer9.Contains("D"))
                    {
                        sb.Append("\r\n高危因素" + "\r\n");
                    }
                    if (answer8.Contains("B") || answer8.Contains("C") || answer8.Contains("D"))
                    {
                        sb.Append("高血压家族史" + "\r\n");
                        sbText.Append("高血压家族史" + "\r\n");
                    }
                    if (answer9.Contains("B") || answer9.Contains("C") || answer9.Contains("D"))
                    {
                        sb.Append("糖尿病家族史" + "\r\n");
                        sbText.Append("糖尿病家族史" + "\r\n");
                    }

                    //第五题，bmi
                    decimal? bmi = null;
                    string answer5 = ClientInfo.GetAnswerByCode(QuestionnaireCode.Thah, QuestionnaireCode.Thah + ".5");
                    if (!string.IsNullOrEmpty(answer5))
                    {
                        bmi = decimal.Parse(answer5.Substring(0, answer5.Length - 1));
                    }

                    if (sex.HasValue && age.HasValue && bmi.HasValue)
                    {
                        //获取bmi结果
                        WeightStandardState weightStandardState = screenWebapiClient.GetBmiResult(sex.Value, age.Value,
                            bmi.Value);
                        if (weightStandardState == WeightStandardState.Overweight)
                        {
                            if (!sb.ToString().Contains("高危因素"))
                                sb.Insert(0, "\r\n高危因素" + "\r\n");
                            sb.Append("超重" + "\r\n");
                            sbText.Append("超重" + "\r\n");
                        }
                        else if (weightStandardState == WeightStandardState.Obesity)
                        {
                            if (!sb.ToString().Contains("高危因素"))
                                sb.Insert(0, "\r\n高危因素" + "\r\n");
                            sb.Append("肥胖" + "\r\n");
                            sbText.Append("肥胖" + "\r\n");
                        }
                    }
                    if (string.IsNullOrEmpty(sbText.ToString()))
                    {
                        sbText.Append("无" + "\r\n");
                    }

                    if (!string.IsNullOrEmpty(sb.ToString()))
                    {
                        printResult += sb.ToString();
                    }
                    lblDangerReason.Text = sbText.ToString();
                }
            }
            catch (Exception ex)
            {
                screenWebapiClient.AddErrorLog(new M_LogForAtm { Title = "筛查机客户端错误", Content = ex.ToString(), Description = "青少年二高筛查问卷" });
            }
        }

        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            var quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //打印预览
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            foreach (PaperSize paperSize in printDocument1.PrinterSettings.PaperSizes)
            {
                if (paperSize.PaperName.Contains("Roll Paper 80 x 297 mm"))
                {
                    this.printDocument1.DefaultPageSettings.PaperSize = paperSize;
                    break;

                }
            }
            printPreviewDialog1.Document = this.printDocument1;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.TopMost = false;
            printPreviewDialog1.ShowDialog();
        }
        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            foreach (PaperSize paperSize in printDocument1.PrinterSettings.PaperSizes)
            {
                if (paperSize.PaperName.Contains("Roll Paper 80 x 297 mm"))
                {
                    this.printDocument1.DefaultPageSettings.PaperSize = paperSize;
                    break;

                }
            }
            this.printDocument1.Print();

            //打印按钮置灰
            PrintManager.SetBtnPrint(true, btnPrint, timerPrint);
        }
        //打印按钮置灰
        private void timerPrint_Tick(object sender, EventArgs e)
        {
            PrintManager.SetBtnPrint(false, btnPrint, timerPrint);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float totalines = 0;  //总行数 
            float yPos = 10;          //打印点Y轴坐标 
            float fltXPos = 0;         //每一行的X坐标 
            int count = 0;           //当前正在打印第几行 
            float leftM = 15; // e.MarginBounds.Left;  //在打印范围内获取左边的打印点 
            float topT = 0;// e.MarginBounds.Top;    //在打印范围内获取上边的打印点 
            string lineStr = null;       //存储一行数据 
            totalines = e.MarginBounds.Height / printFont.GetHeight(e.Graphics); // 打印区域高度/字体高度 
            //如果没有超过最大行 并且 还存在一行数据 就开始打印 

            //string userName = LoginInfo.GetInstance().PatientAccount == ""
            //    ? "访客"
            //    : (LoginInfo.GetInstance().Name.Equals(LoginInfo.GetInstance().Phone)
            //        ? LoginInfo.GetInstance().PatientAccount
            //        : LoginInfo.GetInstance().Name);//LoginInfo.GetInstance().PatientAccount;
            string userName = LoginInfo.GetInstance().PatientAccount == ""
                ? "访客"
                : LoginInfo.GetInstance().PatientAccount;

            string printTest = string.Empty;
            if (userName.Length == 2)
            {
                printTest = "============尊敬的" + userName + "============ \r\n";
            }
            else if (userName.Length == 3)
            {
                printTest = "===========尊敬的" + userName + "=========== \r\n";
            }
            else if (userName.Length == 4)
            {
                printTest = "==========尊敬的" + userName + "========== \r\n";
            }
            else if (userName.Length <= 11)
            {
                printTest = "========尊敬的" + userName + "======== \r\n";
            }
            else if (userName.Length <= 15)
            {
                printTest = "======尊敬的" + userName + "====== \r\n";
            }
            else if (userName.Length <= 18)
            {
                printTest = "=====尊敬的" + userName + "===== \r\n";
            }

            printTest += "\r\n筛查时间：" + answerTime + "\r\n";
            printTest += "\r\n筛查结果";
            printTest += "\r\n" + printResult;
            printTest += "\r\n综合评估（治疗建议）";
            printTest += "\r\n" + printAppraise;
            
            streamToPrint = (StringReader)new StringReader(printTest);//从本地文件来打印 
            StringFormat fmt = new StringFormat();
            //fmt.LineAlignment = StringAlignment.Center;
            //fmt.FormatFlags = StringFormatFlags.LineLimit;
            while (count < totalines && ((lineStr = streamToPrint.ReadLine()) != null))
            {
                //因为每打印一行，下一行的位置会发生变化， yPos=打印区域的上边界+ 行数*字体高度 
                yPos = topT + (count * printFont.GetHeight(e.Graphics));
                //打印一行 数据，leftM 和 yPos代表了 打印的起始点坐标 
                Rectangle drawRect = new Rectangle((int)leftM, (int)yPos, 300, 600);
                e.Graphics.DrawString(lineStr, printFont, Brushes.Black, drawRect, fmt);
                count++; //下一行  
            }
            if (lineStr != null) //如果还有内容 另换一页 
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        //重写，禁止调用父类的此事件
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            //base.OnMouseDoubleClick(e);
        }
    }
}
