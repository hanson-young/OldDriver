using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening.Services;

namespace XYS.Remp.Screening
{
    public partial class registSetp3 : XYS.Remp.Screening.BaseForm
    {
        private string mobile = "";
        private string account = "";
        private string password = "";
        private bool isSuccess = false;
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

        public registSetp3(string userAccount,string pwd,string userMobile)
        {
            InitializeComponent();
            account = userAccount;
            password = pwd;
            mobile = userMobile;
            txtName.Text = userMobile;
            //将姓名文本框赋值为手机号

        }

        private void btnBefore_Click(object sender, EventArgs e)
        {
            //去往第二个页面
            //RegistStep2Form registStep2Form = new RegistStep2Form(account);
            //registStep2Form.TopMost = false;
            //registStep2Form.Show();
            //this.Close();

            //去往第一个页面
            RegistStep1Form registStep1Form = new RegistStep1Form(account, mobile, password);
            registStep1Form.TopMost = false;
            registStep1Form.Show();
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string fullName = this.txtName.Text;
            string cardNo = this.txtCard.Text;
            int sex = radSexA.Checked ? 1 : 2;
            //var birthday = "2016-01-01";
            var birthday = "";
            //1561 小屋类型、专项筛查
            int cottageOrgId = Properties.Settings.Default.CottageOrgId == -1 ? Convert.ToInt32("1561") : Properties.Settings.Default.CottageOrgId;

            //如果设置界面选择了访客模式
            if (Properties.Settings.Default.SetIsCustomer)
            {
                //设置默认小屋
                cottageOrgId = Convert.ToInt32("1561");
            }

            if (string.IsNullOrEmpty(fullName))
            {
                //MessageBox.Show("真实姓名不能为空");
                label5.Text = "请您输入真实姓名！";
                return;
            }

            //if (string.IsNullOrEmpty(cardNo))
            //{
            //    //MessageBox.Show("身份证号码不能为空");
            //    label5.Text = "身份证号码不能为空！";
            //    return;
            //}

            if (!string.IsNullOrEmpty(cardNo))
            {
                if ((!Regex.IsMatch(cardNo, @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$", RegexOptions.IgnoreCase)))
                {
                    //MessageBox.Show("请输入正确的身份证号码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    label5.Text = "请您输入正确的身份证号码！";
                    return;

                }

                if (cardNo.Length == 18)
                {
                    birthday = cardNo.Substring(6, 4) + "-" + cardNo.Substring(10, 2) + "-" + cardNo.Substring(12, 2);
                    try
                    {
                        DateTime.Parse(birthday);
                    }
                    catch
                    {
                        //MessageBox.Show("请输入正确的身份证号码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        label5.Text = "请您输入正确的身份证号码！";
                        return;
                    }

                }

                //处理15位的身份证号码从号码中得到生日和性别代码
                if (cardNo.Length == 15)
                {
                    birthday = "19" + cardNo.Substring(6, 2) + "-" + cardNo.Substring(8, 2) + "-" + cardNo.Substring(10, 2);
                    try
                    {
                        DateTime.Parse(birthday);
                    }
                    catch
                    {
                        //MessageBox.Show("请输入正确的身份证号码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        label5.Text = "请您输入正确的身份证号码！";
                        return;
                    }
                }
            }

            
            

            //ScreeningServiceClient client =new ScreeningServiceClient();
            ScreenWebapiClient screenWebapiClient=new ScreenWebapiClient();
            //M_Msg result = client.Regist(account, password, fullName, cardNo, sex, DateTime.Parse(birthday));

            Model.M_Msg result = null;
            if (string.IsNullOrEmpty(birthday))
            {
                result = screenWebapiClient.Regist(account, mobile, password, fullName, cardNo, sex, null, cottageOrgId);
            }
            else
            {
                result = screenWebapiClient.Regist(account, mobile, password, fullName, cardNo, sex, DateTime.Parse(birthday), cottageOrgId);
            }

            if (result.IsSuccss)
            {
                MessageBox.Show("注册成功");
                //label5.Text = "注册成功！";
                //RegistSucess registSucess = new RegistSucess();
                //registSucess.TopMost = false;
                //registSucess.Show();
                //this.Close();

                //把注册的人作为活动参与人员建立与活动的关联关系。
                //M_CottageActivityRecord entity=new M_CottageActivityRecord();
                //entity.CActivityID = Properties.Settings.Default.ActivityId;
                //entity.PatientAccount = account;
                //entity.PatientID = result.PatientId;
                //entity.PatientName = fullName;
                //entity.Phone = account;
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
                

                //var aResult= client.AddPatientToCottageActivity(entity);
                //if (aResult != null)
                //{
                //    Properties.Settings.Default.CARecordID = aResult.CARecordID;
                //    Properties.Settings.Default.Save();
                //}

                
                //登录
                //Services.M_User userInfo = client.Login(account, password);
                Model.M_User userInfo=screenWebapiClient.Login(account, password);
                if (userInfo != null)
                {
                    Public.LoginInfo.GetInstance().UserId = userInfo.UserId;
                    Public.LoginInfo.GetInstance().Name = userInfo.UserName;
                    Public.LoginInfo.GetInstance().FamilyMemberID = 0;
                    Public.LoginInfo.GetInstance().PatientAccount = account;
                    Public.LoginInfo.GetInstance().Phone = mobile;

                    //登录成功
                    //清空Questionnairs集合
                    Public.LoginInfo.GetInstance().Questionnairs.Clear();

                    //int iWhichQuestion = Properties.Settings.Default.ScreenSet;
                    //switch (iWhichQuestion)
                    //{
                    //    case 1: //老年痴呆筛查
                    //        AD.FirstFrm frmAdFirst = new AD.FirstFrm();
                    //        frmAdFirst.TopMost = false;
                    //        frmAdFirst.Show();
                    //        break;
                    //    case 2: //脑卒中筛查
                    //        Naocuzhong.FirstFrm naoFirst = new Naocuzhong.FirstFrm();
                    //        naoFirst.TopMost = false;
                    //        naoFirst.Show();
                    //        break;
                    //    case 3: //早癌筛查
                    //        Zaoai.ScreeningZaoaiSelect frmZaoAi = new Zaoai.ScreeningZaoaiSelect();
                    //        frmZaoAi.TopMost = false;
                    //        frmZaoAi.Show();
                    //        break;
                    //    case 4: //工伤康复筛查
                    //        Kangfu.ScreeningSelect frmKangfu = new Kangfu.ScreeningSelect();
                    //        frmKangfu.TopMost = false;
                    //        frmKangfu.Show();
                    //        break;
                    //    case 5: //排尿异常
                    //        Other.ScreenOtherSelect screenOtherSelect = new Other.ScreenOtherSelect();
                    //        screenOtherSelect.TopMost = false;
                    //        screenOtherSelect.Show();
                    //        break;
                    //    default:
                    //        break;

                    //}
                    this.Close();
                }
            }
            else
            {
                //MessageBox.Show("注册失败 "+result.Message);
                label5.Text = "注册失败 " + result.Message;
                return;
            }
        }

        private void timerRegist_Tick(object sender, EventArgs e)
        {
            if (isSuccess)
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

                int intReadBaseInfosRet = ReadBaseInfos(Name, Gender, Folk, BirthDay, Code, Address, Agency, ExpireStart, ExpireEnd);
                if (intReadBaseInfosRet != 1)
                {
                    //MessageBox.Show("读卡失败,请重试");
                    label5.Text = "读卡失败,请重试！";
                    return;
                }
                isSuccess = false;
                this.txtName.Text = Name.ToString();
                this.txtCard.Text = Code.ToString();
                string sex = Gender.ToString();
                if (sex == "男") radSexA.Checked = true;
                if (sex == "女") radSexB.Checked = true;
                label5.Text = "温馨提示：身份证验证成功!";
                //关闭端口
            }
         
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //LoginForm frmMain = new LoginForm();
            //frmMain.Show();
            //this.Close();

            LoginFormNew loginFormNew=new LoginFormNew();
            loginFormNew.Show();
            Close();
        }
    }
}
