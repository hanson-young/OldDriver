using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XYS.Remp.Screening.APIClient;
using XYS.Remp.Screening.Public;
using System.IO;
using System.Text;
using HeilsCareSystem;

namespace XYS.Remp.Screening
{

    public partial class LoginFormNew : BaseForm
    {
        private bool isSucess = true;
        private BaseForm mRedicectForm;

        //ScreeningServiceClient client = new ScreeningServiceClient();
        //UserService.PatientServiceClient patientServiceClient = new UserService.PatientServiceClient();

        ScreenWebapiClient screenWebapiClient = new ScreenWebapiClient();

        public LoginFormNew()
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

        public LoginFormNew(BaseForm frmRedirect)
        {
            InitializeComponent();
            this.mRedicectForm = frmRedirect;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strMobile = txtMobile.Text.Trim();

            if (string.IsNullOrEmpty(strMobile))
            {
                //MessageBox.Show("请输入手机号码！");
                var msgBox = new CustomMessageBox("请输入手机号码！");
                msgBox.ShowDialog();
                return;
            }

            //手机号码
            string pattern = "^1\\d{10}$";
            //匹配固定电话
            string phone = "^(0[0-9]{2,3}\\-)?([2-9][0-9]{6,7})+(\\-[0-9]{1,4})?$";
            //小灵通
            string xiaoLt = "^0[0-9]{9,11}$";

            if (!Regex.IsMatch(strMobile, pattern, RegexOptions.IgnoreCase) && !Regex.IsMatch(strMobile, phone, RegexOptions.IgnoreCase) && !Regex.IsMatch(strMobile, xiaoLt, RegexOptions.IgnoreCase))
            {
                //MessageBox.Show("请您输入正确的手机号码、固定电话或小灵通!");
                var msgBox = new CustomMessageBox("请您输入正确的手机号码、固定电话或小灵通！");
                msgBox.ShowDialog();
                return;
            }

            //根据手机号码查询用户及所属成员
            //var results= patientServiceClient.GetPatientAndRelationInfoByMobile(strMobile);
            //var results = screenWebapiClient.GetPatientAndRelationInfoByMobile(strMobile);
            var results = screenWebapiClient.GetPatientByMobile(strMobile);
            if (results != null && results.Any())
            {
                lblCurMobile.Text = strMobile;
                label2.Visible = true;

                label4.Text = "温馨提示：已注册用户可以刷身份证快速登录";
                lvLoginAccount.Items.Clear();
                foreach (var item in results)
                {
                    ListViewItem lvitem = new ListViewItem(item.RelationtID == 0 ? item.PatientName : item.PatientRelName);
                    lvitem.Tag = item.PatientID + "," + item.RelationtID;
                    lvitem.SubItems.AddRange(new string[] { item.PatientAccount.Trim() });
                    lvLoginAccount.Items.Add(lvitem);
                }
            }
            else
            {
                lblCurMobile.Text = "此号码未被使用，新会员请先注册。";
                label2.Visible = false;
                lvLoginAccount.Items.Clear();
            }
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            RegistStep1Form resStep1Form = new RegistStep1Form("", txtMobile.Text.Trim(), "");
            resStep1Form.TopMost = false;
            resStep1Form.Show();
            this.Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            //lvLoginAccount.OwnerDraw = true;

            #region 样式
            btnLogin.BackColor = Color.FromArgb(44, 158, 41);
            btnLogin.ForeColor = Color.White;
            btnGuest.BackColor = Color.FromArgb(1, 102, 172);
            btnGuest.ForeColor = Color.White;
            btnPatientLogin.BackColor = Color.FromArgb(248, 248, 248);
            btnPatientLogin.ForeColor = Color.FromArgb(72, 135, 197);
            btnPatientLogin.FlatAppearance.BorderColor = Color.FromArgb(214, 214, 214);
            btnReg.BackColor = Color.FromArgb(248, 248, 248);
            btnReg.ForeColor = Color.FromArgb(72, 135, 197);
            btnReg.FlatAppearance.BorderColor = Color.FromArgb(214, 214, 214);
            panel3.ForeColor = Color.FromArgb(214, 214, 214);
            label6.ForeColor = Color.FromArgb(72, 135, 197);
            #endregion
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
            Public.LoginInfo.GetInstance().PatientAccount = "";
            Public.LoginInfo.GetInstance().FamilyMemberID = 0;
            Public.LoginInfo.GetInstance().Phone = "";

            //清空Questionnairs集合
            Public.LoginInfo.GetInstance().Questionnairs.Clear();

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
                    case 5: //排尿异常
                        Other.ScreenOtherSelect screenOtherSelect = new Other.ScreenOtherSelect();
                        screenOtherSelect.TopMost = false;
                        screenOtherSelect.Show();
                        break;
                    default:
                        break;

                }
                this.Close();
            }
        }

        private void timerLogin_Tick(object sender, EventArgs e)
        {
            //LiuPeng
            return;

            Public.LoginInfo loginInfo = Public.LoginInfo.GetInstance();
            if (loginInfo.UserId < 0)
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
                    //ScreeningServiceClient client = new ScreeningServiceClient();
                    //M_User userInfo = client.GetUserInfoByCardNo(cardNo);
                    Model.M_User userInfo = screenWebapiClient.GetUserInfoByCardNo(cardNo);
                    if (userInfo != null)
                    {
                        Public.LoginInfo.GetInstance().UserId = userInfo.UserId;
                        Public.LoginInfo.GetInstance().Name = !string.IsNullOrEmpty(userInfo.UserName) ? userInfo.UserName.Trim() : "";//Name.ToString();
                        Public.LoginInfo.GetInstance().FamilyMemberID = 0;
                        Public.LoginInfo.GetInstance().PatientAccount = !string.IsNullOrEmpty(userInfo.PatientAccount) ? userInfo.PatientAccount.Trim() : (!string.IsNullOrEmpty(userInfo.UserName) ? userInfo.UserName.Trim() : "");
                        Public.LoginInfo.GetInstance().Phone = !string.IsNullOrEmpty(userInfo.Mobie) ? userInfo.Mobie : "";


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
                        label4.Text = "未找到此用户，请手工输入您的账号和密码进行登录！";
                    }
                }
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Program.frmMain.TopMost = false;
            //Program.frmMain.Show();
            Close();
        }

        //选择账号登录
        private void lvLoginAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //在此处设断点，发现点击不同的Item后，此事件居然执行了2次 //第一次是取消当前Item选中状态，导致整个ListView的SelectedIndices变为0
            //第二次才将新选中的Item设置为选中状态，SelectedIndices变为1
            //如果不加listview.SelectedIndices.Count>0判断，将导致获取listview.Items[]索引超界的异常

            if (lvLoginAccount.SelectedIndices != null && lvLoginAccount.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = lvLoginAccount.SelectedIndices;

                //将会员Id和成员Id分开
                if (lvLoginAccount.Items[c[0]].Tag != null)
                {
                    //results[0] 会员Id，results[1] 成员Id
                    string[] results = lvLoginAccount.Items[c[0]].Tag.ToString().Split(',');

                    Public.LoginInfo.GetInstance().UserId = Convert.ToInt32(results[0]);
                    Public.LoginInfo.GetInstance().FamilyMemberID = Convert.ToInt32(results[1]);

                    Public.LoginInfo.GetInstance().Name = lvLoginAccount.Items[c[0]].Text;
                    Public.LoginInfo.GetInstance().PatientAccount = lvLoginAccount.Items[c[0]].SubItems[1].Text.Trim();

                    Public.LoginInfo.GetInstance().Phone = txtMobile.Text;
                }
            }

            //改变高亮显示
            foreach (ListViewItem itm in lvLoginAccount.Items)
            {

                itm.BackColor = SystemColors.Window;

                itm.ForeColor = Color.Black;

            }

            foreach (ListViewItem itm2 in lvLoginAccount.SelectedItems)
            {

                itm2.BackColor = SystemColors.MenuHighlight;

                itm2.ForeColor = Color.White;

            }
        }

        //会员登录
        private void btnPatientLogin_Click(object sender, EventArgs e)
        {

            if (lvLoginAccount.SelectedIndices != null && lvLoginAccount.SelectedIndices.Count > 0)
            {
                var msgBox = new CustomMessageBox("登录成功");
                msgBox.ShowDialog();
                MainFormOld.m_isLegalUser = true;
                ListView.SelectedIndexCollection c = lvLoginAccount.SelectedIndices;
                ListViewItem m_theUserItem = lvLoginAccount.Items[c[0]];
                string userName = m_theUserItem.SubItems[0].Text;
                HeilsCareSystem.Message m_message = new HeilsCareSystem.Message(MessageType.MSG_LOGIN_SHOW_USER_INFO);
                m_message.AddString(userName);
                HeilsCareSystem.MainFormOld.m_pMainWnd.m_sharedDataAndMethod.SendMessage(m_message);
                m_message = new HeilsCareSystem.Message(MessageType.MSG_SHOW_HISTROTY_DATA);
                m_message.AddString(userName);
                HeilsCareSystem.MainFormOld.m_pMainWnd.m_sharedDataAndMethod.SendMessage(m_message);
                if (lvLoginAccount.Items[c[0]].Tag != null)
                {
                    //清空Questionnairs集合
                    Public.LoginInfo.GetInstance().Questionnairs.Clear();

                    if (mRedicectForm != null)
                    {
                        label4.Text = "登录成功！";
                        //mRedicectForm.Show();
                        this.Close();
                    }
                    else
                    {
                        
                        int iWhichQuestion = Properties.Settings.Default.ScreenSet;
                        //LiuPeng
                        iWhichQuestion = -1;
                        //end
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
                            case 5: //排尿异常
                                Other.ScreenOtherSelect screenOtherSelect = new Other.ScreenOtherSelect();
                                screenOtherSelect.TopMost = false;
                                screenOtherSelect.Show();
                                break;
                            default:
                                break;

                        }
                        this.Close();
                    }
                }

            }
            else
            {
                lblCurMobile.Text = "请先从列表中选中一位会员，再进行登录。";
                return;
            }
        }
        #region 样式
        //重绘panel边框
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //每边都设置为同一风格，即相同的颜色、宽度和样式。
            //ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle, Color.Ivory, ButtonBorderStyle.Solid);

            //每边共有三个参数，分别为：边框颜色、宽度和样式；如果把 1 改为 0，则覆盖原来的边框
            ControlPaint.DrawBorder(e.Graphics, panel3.ClientRectangle,
                               Color.White, 1, ButtonBorderStyle.Solid, //左边
                               Color.FromArgb(214, 214, 214), 1, ButtonBorderStyle.Solid, //上边
                               Color.FromArgb(214, 214, 214), 1, ButtonBorderStyle.Solid, //右边
                               Color.FromArgb(214, 214, 214), 1, ButtonBorderStyle.Solid);//底边
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            //每边都设置为同一风格，即相同的颜色、宽度和样式。
            ControlPaint.DrawBorder(e.Graphics, panel2.ClientRectangle, Color.FromArgb(214, 214, 214), ButtonBorderStyle.Solid);
        }

        // 需要设置ListView的OwnerDraw属性为 true
        // 用以改变标题的颜色
        //private void lvLoginAccount_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        //{
        //    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(237,248,255)), e.Bounds);
        //    e.DrawText();
        //} 
        #endregion
    }
}
