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

namespace XYS.Remp.Screening.AD
{
    public partial class FirstFrm : BaseForm
    {
        public FirstFrm()
        {
            InitializeComponent();
        }
        private LoginInfo loginInfo = LoginInfo.GetInstance();
        private void btnNext_Click(object sender, EventArgs e)
        {
            M_QuestionnaireUserDetail result = null;
            if (Properties.Settings.Default.ActivityId > 0)
            {
                //同人同天同问卷做控制
                result = ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.NaoNianChiDai, loginInfo.UserId,
                    Properties.Settings.Default.ActivityId);
            }
            if (result != null)
            {
                //记录上次问卷Id
                Properties.Settings.Default.LastTimeQuestionnaireRecodId = result.QuestionnaireRecodId;
                Properties.Settings.Default.Save();

                string str = "会员" + LoginInfo.GetInstance().PatientAccount + "于" + result.AnswerTime +
                             "参加本活动，完成了老年痴呆认知筛查。若继续筛查，则上一次筛查数据将被清除。请参考信息登记表，选择";
                QuitComfirmFrm quitComfirmFrm = new QuitComfirmFrm(new FirstFrm(), this, str);
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

            AD.FirstFrm firstFrm = new FirstFrm();

            QuestionOne frmNext = new QuestionOne();
            Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.NaoNianChiDai;
            questionnaire.QuestionnaireName = QuestionnaireCode.NaoNianChiDaiName;
            questionnaire.UserId = loginInfo.UserId;
            questionnaire.FamilyMemberID = loginInfo.FamilyMemberID;
            questionnaire.QuestionnaireStatus = 0;
            questionnaire.ActivityId = Properties.Settings.Default.ActivityId;
            questionnaire.QuestionnaireScore = 0;
            questionnaire.QuestionnaireType = 0;
            questionnaire.ActivityName = Properties.Settings.Default.ActivityName;
            questionnaire.AnswerTime = DateTime.Now;
            ClientInfo.AddQuestionnaire(questionnaire);
            if (loginInfo.UserId > -2)
            {
                //如果已经登录，则先判断本次登录是否已经做过此问卷，否则产生用户的回答记录。

                //选择了足踝疾患问卷，则在添加一条问卷记录。
                frmNext.TopMost = false;
                frmNext.Show();
                this.Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(frmNext);
                //旧的登录
                //LoginForm frmLogin = new LoginForm(firstFrm);
                //frmLogin.Show();
                //this.Hide();

                //新的登录
                LoginFormNew frmLoginFormNew = new LoginFormNew(firstFrm);
                frmLoginFormNew.Show();
                this.Hide();
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            XYSMainfrm frm = new XYSMainfrm();
            frm.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
