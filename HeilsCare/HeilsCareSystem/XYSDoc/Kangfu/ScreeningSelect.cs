using System;
using System.Windows.Forms;
using XYS.Remp.Screening.Kangfu.Ankle._1._0;
using XYS.Remp.Screening.Model;
using XYS.Remp.Screening.Properties;
using XYS.Remp.Screening.Public;

namespace XYS.Remp.Screening.Kangfu
{
    public partial class ScreeningSelect : BaseForm
    {
        private readonly LoginInfo loginInfo = LoginInfo.GetInstance();

        public ScreeningSelect()
        {
            InitializeComponent();
        }

        private void btnZuHuai_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.KangFuAnkle, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }

            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了足踝筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
                QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this, str);
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
            

            var screeningSelect = new ScreeningSelect();

            var frmNext = new QuestionOne();
            var questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.KangFuAnkle;
            questionnaire.QuestionnaireName = QuestionnaireCode.KangFuAnkleName;
            questionnaire.UserId = loginInfo.UserId;
            questionnaire.FamilyMemberID = loginInfo.FamilyMemberID;
            questionnaire.QuestionnaireStatus = 0;
            questionnaire.ActivityId = Settings.Default.ActivityId;
            questionnaire.QuestionnaireScore = 0;
            questionnaire.QuestionnaireType = 0;
            questionnaire.ActivityName = Settings.Default.ActivityName;
            questionnaire.AnswerTime = DateTime.Now;
            ClientInfo.AddQuestionnaire(questionnaire);
            if (loginInfo.UserId > -2)
            {
                //如果已经登录，则先判断本次登录是否已经做过此问卷，否则产生用户的回答记录。

                //选择了足踝疾患问卷，则在添加一条问卷记录。
                frmNext.TopMost = false;
                frmNext.Show();
                Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(frmNext);
                //LoginForm frmLogin = new LoginForm(screeningSelect);
                //frmLogin.Show();
                //Hide();

                //新的登录
                var frmLoginFormNew = new LoginFormNew(screeningSelect);
                frmLoginFormNew.Show();
                Hide();
            }
        }

        private void btnLunYi_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.KangFuLunYi, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }

            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了轮椅筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
                QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this, str);
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

            var screeningSelect = new ScreeningSelect();

            var frmNext = new LunYi.QuestionOne();
            var questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.KangFuLunYi;
            questionnaire.QuestionnaireName = QuestionnaireCode.KangFuLunYiName;
            questionnaire.UserId = loginInfo.UserId;
            questionnaire.FamilyMemberID = loginInfo.FamilyMemberID;
            questionnaire.QuestionnaireStatus = 0;
            questionnaire.ActivityId = Settings.Default.ActivityId;
            questionnaire.QuestionnaireScore = 0;
            questionnaire.QuestionnaireType = 0;
            questionnaire.ActivityName = Settings.Default.ActivityName;
            questionnaire.AnswerTime = DateTime.Now;

            ClientInfo.AddQuestionnaire(questionnaire);
            if (loginInfo.UserId > -2)
            {
                //如果已经登录，则先判断本次登录是否已经做过此问卷，否则产生用户的回答记录。

                //选择了轮椅问卷，则在添加一条问卷记录。    
                frmNext.TopMost = false;
                frmNext.Show();

                Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(frmNext);
                //LoginForm frmLogin = new LoginForm(screeningSelect);
                //frmLogin.Show();
                //Hide();

                //新的登录
                var frmLoginFormNew = new LoginFormNew(screeningSelect);
                frmLoginFormNew.Show();
                Hide();
            }
        }

        private void btnJiZhu_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.KangFuSpine, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }

            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了脊柱筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
                QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this, str);
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

            var screeningSelect = new ScreeningSelect();
            var frmNext = new Spine.QuestionOne();
            var questionnaire = new Model.M_QuestionnaireUserDetail
            {
                QuestionnaireCode = QuestionnaireCode.KangFuSpine,
                QuestionnaireName = QuestionnaireCode.KangFuSpineName,
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
                //如果已经登录，则先判断本次登录是否已经做过此问卷，否则产生用户的回答记录。

                //选择了脊柱侧弯问卷，则在添加一条问卷记录。
                frmNext.TopMost = false;
                frmNext.Show();
                Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(frmNext);
                //LoginForm frmLogin = new LoginForm(screeningSelect);
                //frmLogin.Show();
                //Hide();

                //新的登录
                var frmLoginFormNew = new LoginFormNew(screeningSelect);
                frmLoginFormNew.Show();
                Hide();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var frm = new XYSMainfrm();
            frm.Show();
            Close();
        }

        private void btnShouShangZhi_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.KangFuShouShangZhi, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }

            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime + "参加本活动，完成了手上肢筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
                QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new ScreeningSelect(), this, str);
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

            var screeningSelect = new ScreeningSelect();

            var frmOne = new ShouShangZhi.QuestionOne();
            var questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.KangFuShouShangZhi;
            questionnaire.QuestionnaireName = QuestionnaireCode.KangFuShouShangZhiName;
            questionnaire.UserId = loginInfo.UserId;
            questionnaire.FamilyMemberID = loginInfo.FamilyMemberID;
            questionnaire.QuestionnaireStatus = 0;
            questionnaire.ActivityId = Settings.Default.ActivityId;
            questionnaire.QuestionnaireScore = 0;
            questionnaire.QuestionnaireType = 0;
            questionnaire.ActivityName = Settings.Default.ActivityName;
            questionnaire.AnswerTime = DateTime.Now;
            ClientInfo.AddQuestionnaire(questionnaire);
            if (loginInfo.UserId > -2)
            {
                //如果已经登录，则先判断本次登录是否已经做过此问卷，否则产生用户的回答记录。

                //选择了手上支问卷，则在添加一条问卷记录。
                frmOne.TopMost = false;
                frmOne.Show();
                Close();
            }
            else
            {
                //LoginForm frmLogin=new LoginForm(frmOne);
                //LoginForm frmLogin = new LoginForm(screeningSelect);
                //frmLogin.Show();
                //Close();

                //新的登录
                var frmLoginFormNew = new LoginFormNew(screeningSelect);
                frmLoginFormNew.Show();
                Hide();
            }
        }
    }
}