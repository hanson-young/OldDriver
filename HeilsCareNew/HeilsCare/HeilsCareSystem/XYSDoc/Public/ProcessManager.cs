using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Public
{
    public class ProcessManager
    {
        /// <summary>
        /// 关闭某个进程
        /// </summary>
        /// <param name="processName">进程名称</param>
        public static void KillProcessByName(string processName)
        {
            Process[] myproc = Process.GetProcesses();
            foreach (Process item in myproc)
            {
                if (item.ProcessName == processName)
                {
                    item.Kill();
                }
            }
        }
    }
}
