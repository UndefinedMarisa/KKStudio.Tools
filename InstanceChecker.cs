using System;
using System.Diagnostics;
using System.Windows;

namespace KKStudio.Tools
{
    public class InstanceChecker
    {
        // 传递一个 bool 变量，告知是否存在多个实例运行
        // 默认情况下，此变量为 false
        public bool isAnotherInstanceRunning = false;

        // 检查是否多实例
        public void Check()
        {
            Process[] processes = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (processes.Length > 1)
            {
                // 告知程序另一实例正在运行
                isAnotherInstanceRunning = true;
            }
        }

        // 内置的多实例处理方式
        public void ExitCurrentProcess()
        {
            MessageBox.Show("Another Instance Is Running! This Instance Will Exit.");
            Environment.Exit(0);
        }
    }
}
