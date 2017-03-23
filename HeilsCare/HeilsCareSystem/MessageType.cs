using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeilsCareSystem
{
    class MessageType
    {
        /*******************************************************************
         * 软件界面消息
         ********************************************************************/
        public const int MSG_INTERFACE_MIN = 0x1000;
        public const int MSG_INTERFACE_MAX = 0x1fff;
        //测试 just
        public const int MSG_INTERFACE_PEOPLE_COUNT = 0x1002;
        //显示注册表单
        public const int MSG_INTERFACE_REGISTER = 0x1003;
        //更新界面UI是否可用
        public const  int MSG_INTERFACE_UPDATE_UI = 0x1004;
        //登录
        public const int MSG_INTERFACE_LOGIN = 0x1005;
        //退出
        public const int MSG_INTERFACE_CLOSE_FORM = 0x1006;
        //初始化设备
        public const int MSG_REGISTER_ID_CARD_INITIALIZE = 0x1007;
        //身份证读卡器处理
        public const int MSG_REGISTER_ID_CARD_READ_PROCESS = 0x1008;
        //问卷一
        public const int MSG_INTERFACE_QUESTIONARE_ONE = 0x1009;





















        /*******************************************************************
         * 注册用户消息
         ********************************************************************/
        public const int MSG_REGISTER_MIN = 0x2000;
        public const int MSG_REGISTER_MAX = 0x2fff;
        //新版本使用的字段
        //用户注册
        public const int MSG_REGISTER_USER = 0x2001; 
        //显示注册对话框
        public const int MSG_SHOW_REGISTER_USER = 0x2002;

























        /*******************************************************************
         * 登录消息
        ********************************************************************/
        public const int MSG_LOGIN_MIN = 0x3000;
        public const int MSG_LOGIN_MAX = 0x3fff;
        //登录成功之后，显示用户信息
        public const int MSG_LOGIN_SHOW_USER_INFO = 0x3001;
        //登出
        public const int MSG_LOGIN_OUT = 0x3002;
        //显示用于其他图形、图线历史数据
        public const int MSG_SHOW_HISTROTY_DATA = 0x3003;
        //新版本消息
        //登录
        public const int MSG_USER_LOGIN_IN = 0x3004;
          
     

































        /*******************************************************************
         * 问卷消息
         ********************************************************************/
        public const int MSG_QUESTIONAR_MIN = 0x4000;
        public const int MSG_QUESTIONAR_MAX = 0x4fff;























        /*******************************************************************
         * 体感操消息
        ********************************************************************/
        public const int MSG_GYMNASTIC_MIN = 0x5000;
        public const int MSG_GYMNASTIC_MAX = 0x5fff;
        public const int MSG_GYMNASTIC_SHOW_FORM = 0x5001;

























        /*******************************************************************
         * 运动控制消息
         ********************************************************************/
        public const int MSG_MOTION_MIN = 0x6000;
        public const int MSG_MOTION_MAX = 0x6fff;


























        /*******************************************************************
         * 系统管理消息
        ********************************************************************/
        public const int MSG_SYSTEM_ADMIN_MIN = 0x7000;
        public const int MSG_SYSTEM_ADMIN_MAX = 0x7fff;































        //系统设置菜单
        public const int MSG_SYSTEM_ADMIN_MENU = 0x7001;
    }
}
