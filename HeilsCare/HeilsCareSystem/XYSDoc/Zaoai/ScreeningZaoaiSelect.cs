using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening.Zaoai.Weiai;

namespace XYS.Remp.Screening.Zaoai
{
    public partial class ScreeningZaoaiSelect : BaseForm
    {
        public ScreeningZaoaiSelect()
        {
            InitializeComponent();
        }

        private void btnWeiAi_Click(object sender, EventArgs e)
        {
            Public.LoginInfo loginInfo = Public.LoginInfo.GetInstance();

            //同人同天同问卷做控制
            //if (ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.ZaoAiWeiAi, loginInfo.UserId))
            //{
            //    var msgBox = new CustomMessageBox("您今天已做胃癌筛查问卷！");
            //    msgBox.ShowDialog();
            //    return;
            //}

            Zaoai.ScreeningZaoaiSelect screeningZaoaiSelect=new ScreeningZaoaiSelect();

            QuestionA1 questionA1 = new QuestionA1();
 
            
            Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.ZaoAiWeiAi;
            questionnaire.QuestionnaireName = QuestionnaireCode.ZaoAiWeiAiName;
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
                questionA1.TopMost = false;
                questionA1.ShowDialog();
                this.Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(questionA1);
                //LoginForm frmLogin = new LoginForm(screeningZaoaiSelect);
                //frmLogin.Show();
                //this.Close();

                //新的登录
                LoginFormNew frmLoginFormNew = new LoginFormNew(screeningZaoaiSelect);
                frmLoginFormNew.Show();
                this.Hide();
            }
        }

        private void btnRuXian_Click(object sender, EventArgs e)
        {
            Public.LoginInfo loginInfo = Public.LoginInfo.GetInstance();

            //同人同天同问卷做控制
            //if (ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.ZaoAiRuXianAi, loginInfo.UserId))
            //{
            //    var msgBox = new CustomMessageBox("您今天已做乳腺癌筛查问卷！");
            //    msgBox.ShowDialog();
            //    return;
            //}

            Zaoai.ScreeningZaoaiSelect screeningZaoaiSelect=new ScreeningZaoaiSelect();

            XYS.Remp.Screening.Zaoai.Ruxian.QuestionA1 questionA1 = new Ruxian.QuestionA1();

            
            Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.ZaoAiRuXianAi;
            questionnaire.QuestionnaireName = QuestionnaireCode.ZaoAiRuXianAiName;
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


                questionA1.TopMost = false;
                questionA1.ShowDialog();
                this.Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(questionA1);
                //LoginForm frmLogin = new LoginForm(screeningZaoaiSelect);
                //frmLogin.Show();
                //this.Close();

                //新的登录
                LoginFormNew frmLoginFormNew = new LoginFormNew(screeningZaoaiSelect);
                frmLoginFormNew.Show();
                this.Hide();
            }
            //XYS.Remp.Screening.Zaoai.Ruxian.QuestionA1 questionA1 = new Ruxian.QuestionA1();
            //questionA1.Show();
            //this.Close();
        }

        private void btnFeiAi_Click(object sender, EventArgs e)
        {
            Public.LoginInfo loginInfo = Public.LoginInfo.GetInstance();

            //同人同天同问卷做控制
            //if (ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.ZaoAiFeiAi, loginInfo.UserId))
            //{
            //    var msgBox = new CustomMessageBox("您今天已做肺癌筛查问卷！");
            //    msgBox.ShowDialog();
            //    return;
            //}

            Zaoai.ScreeningZaoaiSelect screeningZaoaiSelect=new ScreeningZaoaiSelect();

            //this.btnFeiAi.Enabled = false;
            Feiai.QuestionA1 questionA1 = new Feiai.QuestionA1();

            Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.ZaoAiFeiAi;
            questionnaire.QuestionnaireName = QuestionnaireCode.ZaoAiFeiAiName;
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


                questionA1.TopMost = false;
                questionA1.ShowDialog();
                this.Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(questionA1);
                //LoginForm frmLogin = new LoginForm(screeningZaoaiSelect);
                //frmLogin.Show();
                //this.Close();

                //新的登录
                LoginFormNew frmLoginFormNew = new LoginFormNew(screeningZaoaiSelect);
                frmLoginFormNew.Show();
                this.Hide();
            }
           
        }

        private void btnGaNai_Click(object sender, EventArgs e)
        {
            Public.LoginInfo loginInfo = Public.LoginInfo.GetInstance();

            //同人同天同问卷做控制
            //if (ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.ZaoAiGanAi, loginInfo.UserId))
            //{
            //    var msgBox = new CustomMessageBox("您今天已做肝癌筛查问卷！");
            //    msgBox.ShowDialog();
            //    return;
            //}

            Zaoai.ScreeningZaoaiSelect screeningZaoaiSelect=new ScreeningZaoaiSelect();

            Ganai.QuestionC1 questionC1 = new Ganai.QuestionC1();

            
            Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.ZaoAiGanAi;
            questionnaire.QuestionnaireName = QuestionnaireCode.ZaoAiGanAiName;
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


                questionC1.TopMost = false;
                questionC1.ShowDialog();
                this.Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(questionC1);
                //LoginForm frmLogin = new LoginForm(screeningZaoaiSelect);
                //frmLogin.Show();
                //this.Close();

                //新的登录
                LoginFormNew frmLoginFormNew = new LoginFormNew(screeningZaoaiSelect);
                frmLoginFormNew.Show();
                this.Hide();
            }
        }

        private void btnDaChang_Click(object sender, EventArgs e)
        {
            Public.LoginInfo loginInfo = Public.LoginInfo.GetInstance();

            //同人同天同问卷做控制
            //if (ClientInfo.AlreadyExistQuestionnaire(QuestionnaireCode.ZaoAiDaChangAi, loginInfo.UserId))
            //{
            //    var msgBox = new CustomMessageBox("您今天已做大肠癌筛查问卷！");
            //    msgBox.ShowDialog();
            //    return;
            //}

            Zaoai.ScreeningZaoaiSelect screeningZaoaiSelect=new ScreeningZaoaiSelect();

            Dachang.QuestionA1 questionA1 = new Dachang.QuestionA1();

            
            Model.M_QuestionnaireUserDetail questionnaire = new Model.M_QuestionnaireUserDetail();
            questionnaire.QuestionnaireCode = QuestionnaireCode.ZaoAiDaChangAi;
            questionnaire.QuestionnaireName = QuestionnaireCode.ZaoAiDaChangAiName;
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
                questionA1.TopMost = false;
                questionA1.ShowDialog();
                this.Close();
            }
            else
            {
                //LoginForm frmLogin = new LoginForm(questionA1);
                //LoginForm frmLogin = new LoginForm(screeningZaoaiSelect);
                //frmLogin.Show();
                //this.Close();

                //新的登录
                LoginFormNew frmLoginFormNew = new LoginFormNew(screeningZaoaiSelect);
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
    }
}
