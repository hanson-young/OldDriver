using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;//这是用到DllImport时候要引入的包

namespace HeilsCareSystem
{
    /// <summary>
    /// 身份证阅读类
    /// </summary>
    class CVRSDK
    {
        [DllImport("termb.dll", EntryPoint = "CVR_InitComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_InitComm(int Port);//声明外部的标准动态库, 跟Win32API是一样的
        [DllImport("termb.dll", EntryPoint = "CVR_Authenticate", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Authenticate();
        [DllImport("termb.dll", EntryPoint = "CVR_Read_Content", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_Read_Content(int Active);
        [DllImport("termb.dll", EntryPoint = "CVR_CloseComm", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern int CVR_CloseComm();
        [DllImport("termb.dll", EntryPoint = "GetPeopleName", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern unsafe int GetPeopleName(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleNation", CharSet = CharSet.Ansi, SetLastError = false)]
        public static extern int GetPeopleNation(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleBirthday", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleBirthday(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleAddress", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleAddress(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleIDCode", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleIDCode(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetDepartment", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetDepartment(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetStartDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetStartDate(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetEndDate", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetEndDate(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "GetPeopleSex", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetPeopleSex(ref byte strTmp, ref int strLen);
        [DllImport("termb.dll", EntryPoint = "CVR_GetSAMID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int CVR_GetSAMID(ref byte strTmp);
        [DllImport("termb.dll", EntryPoint = "GetManuID", CharSet = CharSet.Ansi, SetLastError = false, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetManuID(ref byte strTmp);
        public static int iRetUSB = 0, iRetCOM = 0;
        public struct CardInfo
        {
            public string name;                         //姓名
            public string sex;                          //性别
            public string people;                       //民族，护照识别时此项为空
            public string birthday;                     //出生日期
            public string address;                      //地址，在识别护照时导出的是国籍简码
            public string number;                       //地址，在识别护照时导出的是国籍简码
            public string signdate;                     //签发日期，在识别护照时导出的是有效期至 
            public string validtermOfStart;             //有效起始日期，在识别护照时为空
            public string validtermOfEnd;               //有效截止日期，在识别护照时为空
            public string samid;                        //安全模块id
            public string time;                         //有效期
        };

        public static void InitializeDevice()
        {
            try
            {
                int iPort;
                for (iPort = 1001; iPort <= 1016; iPort++)
                {
                    iRetUSB = CVRSDK.CVR_InitComm(iPort);
                    if (iRetUSB == 1)
                    {
                        break;
                    }
                }
                if (iRetUSB != 1)
                {
                    for (iPort = 1; iPort <= 4; iPort++)
                    {
                        iRetCOM = CVRSDK.CVR_InitComm(iPort);
                        if (iRetCOM == 1)
                        {
                            break;
                        }
                    }
                }

                if ((iRetCOM == 1) || (iRetUSB == 1))
                {
                    MessageBox.Show("身份证读卡器初始化成功！");
                }
                else
                {
                    MessageBox.Show("身份证读卡器初始化失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }//InitializeDevice end here

        public static CardInfo ReadCard()
        {
            CardInfo m_cardInfo = new CardInfo();
            while(MainFormOld.m_pMainWnd.m_isReadIdCard)
            {
                 try
                {
                    if ((iRetCOM == 1) || (iRetUSB == 1))
                    {

                        int authenticate = CVRSDK.CVR_Authenticate();
                        if (authenticate == 1)
                        {
                            int readContent = CVRSDK.CVR_Read_Content(4);
                            if (readContent == 1)
                            {
                                byte[] name = new byte[30];
                                int length = 30;
                                CVRSDK.GetPeopleName(ref name[0], ref length);
                                //MessageBox.Show();
                                byte[] number = new byte[30];
                                length = 36;
                                CVRSDK.GetPeopleIDCode(ref number[0], ref length);
                                byte[] people = new byte[30];
                                length = 3;
                                CVRSDK.GetPeopleNation(ref people[0], ref length);
                                byte[] validtermOfStart = new byte[30];
                                length = 16;
                                CVRSDK.GetStartDate(ref validtermOfStart[0], ref length);
                                byte[] birthday = new byte[30];
                                length = 16;
                                CVRSDK.GetPeopleBirthday(ref birthday[0], ref length);
                                byte[] address = new byte[30];
                                length = 70;
                                CVRSDK.GetPeopleAddress(ref address[0], ref length);
                                byte[] validtermOfEnd = new byte[30];
                                length = 16;
                                CVRSDK.GetEndDate(ref validtermOfEnd[0], ref length);
                                byte[] signdate = new byte[30];
                                length = 30;
                                CVRSDK.GetDepartment(ref signdate[0], ref length);
                                byte[] sex = new byte[30];
                                length = 3;
                                CVRSDK.GetPeopleSex(ref sex[0], ref length);

                                byte[] samid = new byte[32];
                                CVRSDK.CVR_GetSAMID(ref samid[0]);

                                m_cardInfo.address = System.Text.Encoding.GetEncoding("GB2312").GetString(address).Replace("\0", "").Trim();
                                m_cardInfo.sex = System.Text.Encoding.GetEncoding("GB2312").GetString(sex).Replace("\0", "").Trim();
                                m_cardInfo .birthday= System.Text.Encoding.GetEncoding("GB2312").GetString(birthday).Replace("\0", "").Trim();
                                m_cardInfo.signdate = System.Text.Encoding.GetEncoding("GB2312").GetString(signdate).Replace("\0", "").Trim();
                                m_cardInfo .number= System.Text.Encoding.GetEncoding("GB2312").GetString(number).Replace("\0", "").Trim();
                                m_cardInfo.name = System.Text.Encoding.GetEncoding("GB2312").GetString(name).Replace("\0", "").Trim();
                                m_cardInfo.people = System.Text.Encoding.GetEncoding("GB2312").GetString(people).Replace("\0", "").Trim();
                                m_cardInfo.samid = "安全模块号：" + System.Text.Encoding.GetEncoding("GB2312").GetString(samid).Replace("\0", "").Trim();
                                m_cardInfo.time = System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfStart).Replace("\0", "").Trim() + "-" + System.Text.Encoding.GetEncoding("GB2312").GetString(validtermOfEnd).Replace("\0", "").Trim();
                                return m_cardInfo;
                            }
                            else
                            {
                                MessageBox.Show("身份证读卡操作失败！");
                                return m_cardInfo;
                            }
                        }
                        else
                        {
                            MessageBox.Show("未放卡或卡片放置不正确");
                            return m_cardInfo;
                        }
                    }
                    else
                    {
                        MessageBox.Show("身份证读卡器初始化失败！");
                        return m_cardInfo;
                    }
                }
                catch (Exception ex)
                {
                   MessageBox.Show(ex.ToString());
                   return m_cardInfo;
                }
            }
           
            return m_cardInfo;
        }//ReadCard end here



    }

}
