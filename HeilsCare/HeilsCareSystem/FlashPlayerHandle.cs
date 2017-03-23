using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeilsCareSystem
{
    public class FlashRightKey : AxShockwaveFlashObjects.AxShockwaveFlash
    {
        //定义一个公共类FlashRightKey(类名自己定义)来继承AxShockwaveFlashObjects.AxShockwaveFlash(在实例化Shockwave Flash Object控件后生成)类
        protected override void WndProc(ref System.Windows.Forms.Message m) //重载WndProc方法(此方法即消息处理机制)
        {
            if (m.Msg == 0X0204) //0×0204即鼠标右键的16进制编码
                return; //返回并不输出
            else
                base.WndProc(ref m); //如果不是右键的话则返回正常的信息
        }
    }
}
