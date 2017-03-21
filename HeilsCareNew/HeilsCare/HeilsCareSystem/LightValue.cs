using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace HeilsCareSystem
{
    /// <summary>  
    /// 调节屏幕的亮度  
    /// </summary>  
    public class LightValue
    {
        public static void SetBright(string strValue)
        {
            SetBackLightValue(strValue);
            ReloadBackLight();
        }
        public static int GetBacklightValue()
        {
            RegistryKey CUser = Registry.CurrentUser;
            RegistryKey Backlight = CUser.OpenSubKey("ControlPanel\\Backlight", true);
            return (int)Backlight.GetValue("Brightness", RegistryValueKind.DWord);
        }
        public static void SetBackLightValue(string strValue)
        {
            try
            {

                RegistryKey hkcu = Registry.CurrentUser;
                RegistryKey Backlight = hkcu.OpenSubKey("ControlPanel\\Backlight", true);
                Backlight.SetValue("Brightness", strValue, RegistryValueKind.DWord);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


        public static bool ReloadBackLight()
        {

            bool ret = false;
            IntPtr scanEvent = NativeWin.CreateEvent(IntPtr.Zero, false, false, "BackLightChangeEvent");
            if (scanEvent == null)
            {
                throw new Exception("CreateEvent失败");
            }
            else
            {
                NativeWin.EventModify(scanEvent, EventFlags.SET);
                NativeWin.CloseHandle(scanEvent);
                ret = true;
            }
            return ret;
        }


        partial class NativeWin
        {
            [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Auto)]
            internal static extern IntPtr CreateEvent(IntPtr lpEventAttributes, [In, MarshalAs(UnmanagedType.Bool)] bool bManualReset, [In, MarshalAs(UnmanagedType.Bool)] bool bIntialState, [In, MarshalAs(UnmanagedType.BStr)] string lpName);


            [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Auto)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool CloseHandle(IntPtr hObject);


            [DllImport("coredll.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool EventModify(IntPtr hEvent, [In, MarshalAs(UnmanagedType.U4)] EventFlags dEvent);
        }


        enum EventFlags : int
        {
            PULSE = 1,
            RESET = 2,
            SET = 3
        }
    }  
}
