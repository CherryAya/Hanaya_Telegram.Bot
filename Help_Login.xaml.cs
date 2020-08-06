using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hanaya_TgBot
{
    /// <summary>
    /// Help_Login.xaml 的交互逻辑
    /// </summary>
    public partial class Help_Login : MetroWindow
    {
        public Help_Login()
        {
            ResizeMode = ResizeMode.CanMinimize;
            InitializeComponent();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetForegroundWindow", CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetF(); //获得本窗体的句柄
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetF(IntPtr hWnd); //设置此窗体为活动窗体

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.isOpen = false;
        }

    }
}
