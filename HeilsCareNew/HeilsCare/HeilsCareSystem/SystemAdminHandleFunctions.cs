using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevComponents.DotNetBar;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.ApplicationServices;
using Microsoft.WindowsAPICodePack.Shell;

namespace HeilsCareSystem
{
    partial class SystemAdminHandler
    {
        private void ShowAdminMenu(Message m_message)
        {
            if (m_message.GetMessageType() != MessageType.MSG_SYSTEM_ADMIN_MENU)
            {
                return;
            }
            RadialMenuContainer menuContainer = null;
            if (MainFormOld.m_pMainWndTemp.metroTileItemSystemAdmin.SubItems.Count == 0)
            {
                menuContainer = new RadialMenuContainer();
                menuContainer.Font = new Font(MainFormOld.m_pMainWndTemp.Font.FontFamily, 15);
                //   五角星  
                //   主页
                //    X
                //    √
                //    返回
                //    问号 ？
                //    完成
                //    红旗
                // \uf040  笔
                menuContainer.SubItems.Add(CreateItem("WIFI", ""));
                menuContainer.SubItems.Add(CreateItem("亮度", "\uf040"));
                menuContainer.SubItems.Add(CreateItem("电量", ""));
                menuContainer.SubItems.Add(CreateItem("gif测试播放","\uf040"));
                menuContainer.Diameter = 280;
                MainFormOld.m_pMainWndTemp.metroTileItemSystemAdmin.SubItems.Add(menuContainer);
            }
            else
                menuContainer = (RadialMenuContainer)MainFormOld.m_pMainWndTemp.metroTileItemSystemAdmin.SubItems[0];
            menuContainer.MenuLocation = new Point(Control.MousePosition.X - menuContainer.Diameter / 2, Control.MousePosition.Y - menuContainer.Diameter / 2);
            menuContainer.Expanded = true;
        }

        private void RadialMenuItemClick(object sender, EventArgs e)
        {
            RadialMenuItem item = sender as RadialMenuItem;
            if (item != null && !string.IsNullOrEmpty(item.Text))
            {
                //MessageBox.Show(string.Format("{0} Menu item clicked: {1}\r\n", DateTime.Now, item.Text));
                string m_string = item.Text;

                if (m_string == "WIFI")
                {
                    wifi m_wifi = new wifi();
                    wifi.WLAN_AVAILABLE_NETWORK_LIST m_wifiList = m_wifi.EnumerateAvailableNetwork();
                    for (int j = 0; j < m_wifiList.dwNumberOfItems; j++)
                    {
                        if(j%2==1)
                            continue;
                        wifi.WLAN_AVAILABLE_NETWORK network = m_wifiList.wlanAvailableNetwork[j];
                        string printoutString = "";
                        printoutString += "Available Network: \n";
                        printoutString += "SSID: " + network.dot11Ssid.ucSSID+"\n";
                        //printoutString += "StrProfile:" + network.strProfileName + "\n";
                        //printoutString += "Encrypted: " + network.bSecurityEnabled + "\n";
                        printoutString += "Signal Strength: " + network.wlanSignalQuality + "\n";
                        //printoutString += "Default Authentication: " +
                        //    network.dot11DefaultAuthAlgorithm.ToString() + "\n";
                        // printoutString += "Default Cipher: " + network.dot11DefaultCipherAlgorithm.ToString() + "\n";
                        MessageBox.Show(printoutString);
                    }
                }

                else if (m_string=="亮度")
                {
                    Device.ChassisTypes m_deviceType = Device.GetCurrentChassisType();
                    if(m_deviceType.ToString() != "Laptop")
                    {
                        MessageBox.Show(m_deviceType.ToString()+" 不支持亮度设置！");
                        return;
                    }
                    int lightValue = LightValue.GetBacklightValue();
                    MessageBox.Show("当前屏幕亮度值为:" + lightValue.ToString());
                }

                else if(m_string == "电量")
                {
                    Device.ChassisTypes m_deviceType = Device.GetCurrentChassisType();
                    MessageBox.Show("电源为："+PowerManager.PowerSource.ToString());
                    if (m_deviceType.ToString() != "Laptop")
                    {
                        MessageBox.Show("当前设备不支持电量设置！");
                        //return;
                    }
                    else
                    {
                        int theBatteryPercent= PowerManager.BatteryLifePercent;
                        MessageBox.Show("当前电量为:" + theBatteryPercent.ToString()+"%");
                    }
                }

                else if(m_string=="gif测试播放")
                {
                    MainFormOld.m_pMainWnd.image.Play();
                }


            }
        }

        private BaseItem CreateItem(string text, string symbol)
        {
            RadialMenuItem item = new RadialMenuItem();
            item.Click += new EventHandler(RadialMenuItemClick);
            item.Text = text;
            item.Symbol = symbol;
            return item;
        }
    }
}
