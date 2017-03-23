using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using XYS.Remp.Screening.Services;

namespace XYS.Remp.Screening
{

    public partial class LoginForm : BaseForm
    {
        private bool isSucess = true;
        private BaseForm mRedicectForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        #region 引入DLL

        [DllImport("Sdtapi.dll")]
        private static extern int InitComm(int iPort);

        [DllImport("Sdtapi.dll")]
        private static extern int Authenticate();

        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseInfos(StringBuilder Name, StringBuilder Gender, StringBuilder Folk,
            StringBuilder BirthDay, StringBuilder Code, StringBuilder Address,
            StringBuilder Agency, StringBuilder ExpireStart, StringBuilder ExpireEnd);

        [DllImport("Sdtapi.dll")]
        private static extern int CloseComm();

        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsg(byte[] pMsg, ref int len);

        [DllImport("Sdtapi.dll")]
        private static extern int ReadBaseMsgW(byte[] pMsg, ref int len);

        #endregion

        public LoginForm(BaseForm frmRedirect)
        {
            InitializeComponent();
            this.mRedicectForm = frmRedirect;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ScreeningServiceClient client = new ScreeningServiceClient();

            string strUserName = txtUserName.Text.Trim();
            string strPassword = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(strUserName))
            {
                //MessageBox.Show("请输入用户名");
                label4.Text = "请输入用户名！";
                return;
            }

            if (string.IsNullOrEmpty(strPassword))
            {
                //MessageBox.Show("请输入密码");
                label4.Text = "请输入密码！";
                return;
            }

            Services.M_User userInfo = client.Login(strUserName, strPassword);

            if (userInfo != null)
            {
                Public.LoginInfo.GetInstance().UserId = userInfo.UserId;
                Public.LoginInfo.GetInstance().Name = userInfo.UserName;

                //把登录的人作为活动参与人员建立与活动的关联关系。
                //M_CottageActivityRecord entity = new M_CottageActivityRecord();
                //entity.CActivityID = Properties.Settings.Default.ActivityId;
                //entity.PatientAccount = strUserName;
                //entity.PatientID = userInfo.UserId;
                //entity.PatientName = userInfo.UserName;
                //entity.Phone = userInfo.Mobie;
                //entity.DoctorID = Properties.Settings.Default.DoctorId;
                //entity.DoctorName = Properties.Settings.Default.DoctorName;
                //entity.DrID = Properties.Settings.Default.DoctorId;
                //entity.DrName = Properties.Settings.Default.DoctorName;
                //entity.UpdateDrID = Properties.Settings.Default.DoctorId;

                ////新增
                //entity.CreateDrID = Properties.Settings.Default.DoctorId;
                //entity.CreateDrName = Properties.Settings.Default.DoctorName;
                //entity.UpdateDrName = Properties.Settings.Default.DoctorName;
                ////报名来源,默认0,1-WEB医生端,2-网络医院APP,3-推广大使APP,4-健康管理师APP,5-筛查机
                //entity.RegSource = 5;
                ////签到来源,默认0,1-WEB医生端,2-网络医院APP,3-推广大使APP,4-健康管理师APP,5-筛查机
                //entity.SignSource = 5;

                //var result= client.AddPatientToCottageActivity(entity);

                //if (result!=null)
                //{
                //    Properties.Settings.Default.CARecordID = result.CARecordID;
                //    Properties.Settings.Default.Save();

                //    //MessageBox.Show(Properties.Settings.Default.CARecordID.ToString());
                //}

                //清空Questionnairs集合
                Public.LoginInfo.GetInstance().Questionnairs.Clear();

                if (mRedicectForm != null)
                {
                    //MessageBox.Show("登录成功");
                    label4.Text = "登录成功！";
                    //mRedicectForm.TopMost = false;
                    mRedicectForm.Show();
                    this.Close();
                }
                else
                {
                    int iWhichQuestion = Properties.Settings.Default.ScreenSet;
                    switch (iWhichQuestion)
                    {
                        case 1: //老年痴呆筛查
                            AD.FirstFrm frmAdFirst = new AD.FirstFrm();
                            frmAdFirst.TopMost = false;
                            frmAdFirst.Show();
                            break;
                        case 2: //脑卒中筛查
                            Naocuzhong.FirstFrm naoFirst = new Naocuzhong.FirstFrm();
                            naoFirst.TopMost = false;
                            naoFirst.Show();
                            break;
                        case 3: //早癌筛查
                            Zaoai.ScreeningZaoaiSelect frmZaoAi = new Zaoai.ScreeningZaoaiSelect();
                            frmZaoAi.TopMost = false;
                            frmZaoAi.Show();
                            break;
                        case 4: //工伤康复筛查
                            Kangfu.ScreeningSelect frmKangfu = new Kangfu.ScreeningSelect();
                            frmKangfu.TopMost = false;
                            frmKangfu.Show();
                            break;
                        default:
                            break;

                    }
                    this.Close();
                }
            }
            else
            {
                //MessageBox.Show("用户名或密码不对，请重新输入");
                label4.Text = "用户名或密码不对，请重新输入！";
                return;
            }

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            RegistStep1Form resStep1Form = new RegistStep1Form("","","");
            resStep1Form.TopMost = false;
            resStep1Form.Show();
            this.Close();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            //修改游客序号配置
            if (!Properties.Settings.Default.ScreenDate.ToShortDateString().Equals(DateTime.Now.ToShortDateString()))
            {
                Properties.Settings.Default.ScreenDate = DateTime.Now.Date;
                Properties.Settings.Default.ScreenNumber = 1;
            }
            else
            {
                if (Properties.Settings.Default.ScreenNumber <= 9999)
                {
                    Properties.Settings.Default.ScreenNumber += 1;
                }
                else
                {
                    label4.Text = "人数已达到上限";
                    return;
                }

            }
            Properties.Settings.Default.Save();

            btnGuest.Enabled = true;
            Public.LoginInfo.GetInstance().UserId = -1; //游客模式，UserID定为-1
            Public.LoginInfo.GetInstance().Name = "";
            if (mRedicectForm != null)
            {
                mRedicectForm.TopMost = false;
                mRedicectForm.Show();
                this.Close();
            }
            else
            {
                int iWhichQuestion = Properties.Settings.Default.ScreenSet;
                switch (iWhichQuestion)
                {
                    case 1: //老年痴呆筛查
                        AD.FirstFrm frmAdFirst = new AD.FirstFrm();
                        frmAdFirst.TopMost = false;
                        frmAdFirst.Show();
                        break;
                    case 2: //脑卒中筛查
                        Naocuzhong.FirstFrm naoFirst = new Naocuzhong.FirstFrm();
                        naoFirst.TopMost = false;
                        naoFirst.Show();
                        break;
                    case 3: //早癌筛查
                        Zaoai.ScreeningZaoaiSelect frmZaoAi = new Zaoai.ScreeningZaoaiSelect();
                        frmZaoAi.TopMost = false;
                        frmZaoAi.Show();
                        break;
                    case 4: //工伤康复筛查
                        Kangfu.ScreeningSelect frmKangfu = new Kangfu.ScreeningSelect();
                        frmKangfu.TopMost = false;
                        frmKangfu.Show();
                        break;
                    default:
                        break;

                }
                this.Close();
            }
        }

        private void timerLogin_Tick(object sender, EventArgs e)
        {
            Public.LoginInfo loginInfo = Public.LoginInfo.GetInstance();
            if (loginInfo.UserId<0)
            {
                StringBuilder Name = new StringBuilder(31);
                StringBuilder Gender = new StringBuilder(3);
                StringBuilder Folk = new StringBuilder(10);
                StringBuilder BirthDay = new StringBuilder(9);
                StringBuilder Code = new StringBuilder(19);
                StringBuilder Address = new StringBuilder(71);
                StringBuilder Agency = new StringBuilder(31);
                StringBuilder ExpireStart = new StringBuilder(9);
                StringBuilder ExpireEnd = new StringBuilder(9);
                //打开端口
                int intOpenRet = InitComm(1001);
                if (intOpenRet != 1)
                {
                    return;
                }

                //卡认证
                int intReadRet = Authenticate();
                if (intReadRet != 1)
                {

                    CloseComm();
                    return;
                }
                //三种方式读取基本信息
                //ReadBaseInfos（推荐使用）
                try
                {

                }
                catch (Exception)
                {
                    
                    throw;
                }
                int intReadBaseInfosRet = ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart,
                    ExpireEnd);
                if (intReadBaseInfosRet != 1)
                {
                    //MessageBox.Show("读卡失败,请重试");
                    label4.Text = "读卡失败,请重试！";
                    CloseComm();
                    return;
                }

                string cardNo = Code.ToString();
                //关闭端口
                if (!string.IsNullOrEmpty(cardNo))
                {
                    ScreeningServiceClient client = new ScreeningServiceClient();
                    M_User userInfo = client.GetUserInfoByCardNo(cardNo);
                    if (userInfo != null)
                    {
                        Public.LoginInfo.GetInstance().UserId = userInfo.UserId;
                        Public.LoginInfo.GetInstance().Name = Name.ToString();

                        //把登录的人作为活动参与人员建立与活动的关联关系。
                        //M_CottageActivityRecord entity = new M_CottageActivityRecord();
                        //entity.CActivityID = Properties.Settings.Default.ActivityId;
                        //entity.PatientAccount = userInfo.PatientAccount;
                        //entity.PatientID = userInfo.UserId;
                        //entity.PatientName = userInfo.UserName;
                        //entity.Phone = userInfo.Mobie;
                        //entity.DoctorID = Properties.Settings.Default.DoctorId;
                        //entity.DoctorName = Properties.Settings.Default.DoctorName;
                        //entity.DrID = Properties.Settings.Default.DoctorId;
                        //entity.DrName = Properties.Settings.Default.DoctorName;
                        //entity.UpdateDrID = Properties.Settings.Default.DoctorId;

                        //var result = client.AddPatientToCottageActivity(entity);

                        //if (result != null)
                        //{
                        //    Properties.Settings.Default.CARecordID = result.CARecordID;
                        //    Properties.Settings.Default.Save();

                        //    //MessageBox.Show(Properties.Settings.Default.CARecordID.ToString());
                        //}

                        //清空Questionnairs集合
                        Public.LoginInfo.GetInstance().Questionnairs.Clear();

                        if (mRedicectForm != null)
                        {
                            mRedicectForm.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        //MessageBox.Show("未找到此用户，请手工输入您的账号和密码进行登录");
                        label4.Text = "未找到此用户，请手工输入您的账号和密码进行登录！";
                    }
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            TopMost = false;
            int iWhichQuestion = Properties.Settings.Default.ScreenSet;
            switch (iWhichQuestion)
            {
                case 1: //老年痴呆筛查
                    AD.FirstFrm frmAdFirst = new AD.FirstFrm();
                    frmAdFirst.TopMost = false;
                    frmAdFirst.Show();
                    break;
                case 2: //脑卒中筛查
                    Naocuzhong.FirstFrm naoFirst = new Naocuzhong.FirstFrm();
                    naoFirst.TopMost = false;
                    naoFirst.Show();
                    break;
                case 3: //早癌筛查
                    Zaoai.ScreeningZaoaiSelect frmZaoAi = new Zaoai.ScreeningZaoaiSelect();
                    frmZaoAi.TopMost = false;
                    frmZaoAi.Show();
                    break;
                case 4: //工伤康复筛查
                    Kangfu.ScreeningSelect frmKangfu = new Kangfu.ScreeningSelect();
                    frmKangfu.TopMost = false;
                    frmKangfu.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
