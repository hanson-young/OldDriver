using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Other.COPD;
using XYS.Remp.Screening.Other.Diabetes;
using XYS.Remp.Screening.Other.THAH;
using XYS.Remp.Screening.Properties;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Other
{
    public partial class ScreenOtherSelect : BaseForm
    {
        private LoginInfo loginInfo = LoginInfo.GetInstance();

        public ScreenOtherSelect()
        {
            InitializeComponent();
        }

        //排尿异常筛查
        private void btnParuria_Click(object sender, EventArgs e)
        {
            Other.ScreenOtherSelect screenOtherSelect = new ScreenOtherSelect();

            Paruria.Paruria paruria = new Paruria.Paruria();

            if (loginInfo.UserId > -2)
            {
                //如果已经登录
                paruria.TopMost = false;
                paruria.Show();
                Close();
            }
            else
            {
                //新的登录
                LoginFormNew frmLoginFormNew = new LoginFormNew(screenOtherSelect);
                frmLoginFormNew.Show();
                this.Hide();
            }
        }
        //糖尿病筛查
        private void btnDiabetes_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.Diabetes, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }

            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了糖尿病筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
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

            var questionnaire = new Model.M_QuestionnaireUserDetail
            {
                QuestionnaireCode = QuestionnaireCode.Diabetes,
                QuestionnaireName = QuestionnaireCode.DiabetesName,
                UserId = loginInfo.UserId,
                FamilyMemberID = loginInfo.FamilyMemberID,
                QuestionnaireStatus = 0,
                ActivityId = Settings.Default.ActivityId,
                QuestionnaireScore = 0,
                QuestionnaireType = 0,
                ActivityName = Settings.Default.ActivityName,
                AnswerTime = DateTime.Now
            };
            ClientInfo.AddQuestionnaire(questionnaire);

            if (loginInfo.UserId > -2)
            {
                var question = new QuestionOne { TopMost = false };
                question.Show();
                Close();
            }
            else
            {
                var loginForm = new LoginFormNew(this);
                loginForm.Show();
                Hide();
            }
        }
        //慢阻肺筛查
        private void btnCopd_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.Copd, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }

            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了慢阻肺筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
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

            var questionnaire = new Model.M_QuestionnaireUserDetail
            {
                QuestionnaireCode = QuestionnaireCode.Copd,
                QuestionnaireName = QuestionnaireCode.CopdName,
                UserId = loginInfo.UserId,
                FamilyMemberID = loginInfo.FamilyMemberID,
                QuestionnaireStatus = 0,
                ActivityId = Settings.Default.ActivityId,
                QuestionnaireScore = 0,
                QuestionnaireType = 0,
                ActivityName = Settings.Default.ActivityName,
                AnswerTime = DateTime.Now
            };
            ClientInfo.AddQuestionnaire(questionnaire);

            if (loginInfo.UserId > -2)
            {
                var copdOne = new CopdOne() { TopMost = false };
                copdOne.Show();
                Close();
            }
            else
            {
                var loginForm = new LoginFormNew(this);
                loginForm.Show();
                Hide();
            }
        }
        //青少年二高筛查
        private void btnThah_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.Thah, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }

            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了青少年二高筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
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

            var questionnaire=new Model.M_QuestionnaireUserDetail
            {
                QuestionnaireCode = QuestionnaireCode.Thah,
                QuestionnaireName = QuestionnaireCode.ThahName,
                UserId = loginInfo.UserId,
                FamilyMemberID = loginInfo.FamilyMemberID,
                QuestionnaireStatus = 0,
                ActivityId = Settings.Default.ActivityId,
                QuestionnaireScore = 0,
                QuestionnaireType = 0,
                ActivityName = Settings.Default.ActivityName,
                AnswerTime = DateTime.Now
            };
            ClientInfo.AddQuestionnaire(questionnaire);

            if (loginInfo.UserId > -2)
            {
                var thahOne = new ThahOne() { TopMost = false };
                thahOne.Show();
                Close();
            }
            else
            {
                var loginForm = new LoginFormNew(this);
                loginForm.Show();
                Hide();
            }
        }
    }
}
