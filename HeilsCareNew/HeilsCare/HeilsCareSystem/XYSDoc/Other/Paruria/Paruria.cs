using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other.Paruria
{
    public partial class Paruria : BaseForm
    {
        private LoginInfo loginInfo = LoginInfo.GetInstance();

        public Paruria()
        {
            InitializeComponent();
        }
        //上一页
        private void btnBefore_Click(object sender, EventArgs e)
        {
            btnBack_Click(this, e);
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            //判断是否选择
            if (!rbQ1A.Checked && !rbQ1B.Checked)
            {
                MessageBox.Show("请选择性别","提示",MessageBoxButtons.OK);
                return;
            }
            if (!rbQ2A.Checked && !rbQ2B.Checked)
            {
                MessageBox.Show("请选择年龄", "提示", MessageBoxButtons.OK);
                return;
            }

            //排尿异常一二题选择标识 start
            Properties.Settings.Default.QuesSelFlag = string.Empty;
            Properties.Settings.Default.Save();

            if (rbQ1A.Checked) Properties.Settings.Default.QuesSelFlag += "rbQ1A,";
            if (rbQ1B.Checked) Properties.Settings.Default.QuesSelFlag += "rbQ1B,";
            if (rbQ2A.Checked) Properties.Settings.Default.QuesSelFlag += "rbQ2A,";
            if (rbQ2B.Checked) Properties.Settings.Default.QuesSelFlag += "rbQ2B,";
            Properties.Settings.Default.Save();
            //排尿异常一二题选择标识 end

            //男>40  就用良性前列腺筛查问卷.其它就用膀胱过度活动筛查问卷
            if (rbQ1A.Checked && rbQ2A.Checked)
            {
                M_QuestionnaireUserDetail result = null;
                if (Properties.Settings.Default.ActivityId > 0)
                {
                    //同人同天同问卷做控制
                    result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.Ipss, loginInfo.UserId,
                        Properties.Settings.Default.ActivityId);
                }

                if (result != null)
                {
                    //记录上次问卷Id
                    Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                    Properties.Settings.Default.Save();

                    string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了良性前列腺筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
                    QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this, str);
                    DialogResult dr = quitComfirmFrm.ShowDialog();
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    //清空上次问卷Id
                    Properties.Settings.Default.LastTimeQuestionnaireRecodId = 0;
                    Properties.Settings.Default.Save();
                }

                //良性前列腺筛查问卷
                //添加问卷记录
                Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
                questionnaire.QuestionnaireCode = QuestionnaireCode.Ipss;
                questionnaire.QuestionnaireName = QuestionnaireCode.IpssName;
                questionnaire.UserId = loginInfo.UserId;
                questionnaire.FamilyMemberID = loginInfo.FamilyMemberID;
                questionnaire.QuestionnaireStatus = 0;
                questionnaire.ActivityId = Properties.Settings.Default.ActivityId;
                questionnaire.QuestionnaireScore = 0;
                questionnaire.QuestionnaireType = 0;
                questionnaire.ActivityName = Properties.Settings.Default.ActivityName;
                questionnaire.AnswerTime = DateTime.Now;
                ClientInfo.AddQuestionnaire(questionnaire);

                //添加答题记录
                //第一题
                M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
                string strResult1 = "";

                if (rbQ1A.Checked) { strResult1 = "A,"; }
                if (rbQ1B.Checked) { strResult1 = "B,"; }

                question1.QuestionResult = strResult1;
                question1.QuestionCode = QuestionnaireCode.Ipss + ".1";
                question1.PQuestionCode=QuestionnaireCode.Ipss + ".1";
                question1.QuestionType = 1;
                question1.QuestionScore = 0;
                question1.PQuestionWeightScore = 0;

                ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.Ipss);

                //第二题
                M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
                string strResult2 = "";

                if (rbQ2A.Checked) { strResult2 = "A,"; }
                if (rbQ2B.Checked) { strResult2 = "B,"; }

                question2.QuestionResult = strResult2;
                question2.QuestionCode = QuestionnaireCode.Ipss + ".2";
                question2.PQuestionCode = QuestionnaireCode.Ipss + ".2";
                question2.QuestionType = 1;
                question2.QuestionScore = 0;
                question2.PQuestionWeightScore = 0;

                ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.Ipss);

                //跳转
                Other.Paruria.IPSS.IpssOne ipssOne = new Other.Paruria.IPSS.IpssOne();
                ipssOne.TopMost = false;
                ipssOne.Show();
                Close();
            }
            else
            {
                M_QuestionnaireUserDetail result = null;
                if (Properties.Settings.Default.ActivityId > 0)
                {
                    //同人同天同问卷做控制
                    result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.Oab, loginInfo.UserId,
                        Properties.Settings.Default.ActivityId);
                }

                if (result != null)
                {
                    //记录上次问卷Id
                    Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                    Properties.Settings.Default.Save();

                    string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了膀胱过度活动筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
                    QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this, str);
                    DialogResult dr = quitComfirmFrm.ShowDialog();
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                else
                {
                    //清空上次问卷Id
                    Properties.Settings.Default.LastTimeQuestionnaireRecodId = 0;
                    Properties.Settings.Default.Save();
                }

                //膀胱过度活动筛查问卷
                //添加问卷记录
                Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
                questionnaire.QuestionnaireCode = QuestionnaireCode.Oab;
                questionnaire.QuestionnaireName = QuestionnaireCode.OabName;
                questionnaire.UserId = loginInfo.UserId;
                questionnaire.FamilyMemberID = loginInfo.FamilyMemberID;
                questionnaire.QuestionnaireStatus = 0;
                questionnaire.ActivityId = Properties.Settings.Default.ActivityId;
                questionnaire.QuestionnaireScore = 0;
                questionnaire.QuestionnaireType = 0;
                questionnaire.ActivityName = Properties.Settings.Default.ActivityName;
                questionnaire.AnswerTime = DateTime.Now;
                ClientInfo.AddQuestionnaire(questionnaire);

                //添加答题记录
                //第一题
                M_QuestionnaireResultDetail question1 = new M_QuestionnaireResultDetail();
                string strResult1 = "";

                if (rbQ1A.Checked) { strResult1 = "A,"; }
                if (rbQ1B.Checked) { strResult1 = "B,"; }

                question1.QuestionResult = strResult1;
                question1.QuestionCode = QuestionnaireCode.Oab + ".1";
                question1.PQuestionCode = QuestionnaireCode.Oab + ".1";
                question1.QuestionType = 1;
                question1.QuestionScore = 0;
                question1.PQuestionWeightScore = 0;

                ClientInfo.AddQuestionToQuestionnaire(question1, QuestionnaireCode.Oab);

                //第二题
                M_QuestionnaireResultDetail question2 = new M_QuestionnaireResultDetail();
                string strResult2 = "";

                if (rbQ2A.Checked) { strResult2 = "A,"; }
                if (rbQ2B.Checked) { strResult2 = "B,"; }

                question2.QuestionResult = strResult2;
                question2.QuestionCode = QuestionnaireCode.Oab + ".2";
                question2.PQuestionCode = QuestionnaireCode.Oab + ".2";
                question2.QuestionType = 1;
                question2.QuestionScore = 0;
                question2.PQuestionWeightScore = 0;

                ClientInfo.AddQuestionToQuestionnaire(question2, QuestionnaireCode.Oab);

                //跳转
                Other.Paruria.OAB.OabOne oabOne = new Other.Paruria.OAB.OabOne();
                oabOne.TopMost = false;
                oabOne.Show();
                Close();
            }
        }
        //返回
        private void btnBack_Click(object sender, EventArgs e)
        {
            ScreenOtherSelect screenOtherSelect=new ScreenOtherSelect();
            screenOtherSelect.TopMost = false;
            screenOtherSelect.Show();
            Close();
        }
        //退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreenOtherSelect(), this);
            quitComfirmFrm.ShowDialog();
        }
        //加载
        private void Paruria_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.QuesSelFlag.Contains("rbQ1A")) { rbQ1A.Checked = true; }
            if (Properties.Settings.Default.QuesSelFlag.Contains("rbQ1B")) { rbQ1B.Checked = true; }

            if (Properties.Settings.Default.QuesSelFlag.Contains("rbQ2A")) { rbQ2A.Checked = true; }
            if (Properties.Settings.Default.QuesSelFlag.Contains("rbQ2B")) { rbQ2B.Checked = true; }
        }
    }
}
