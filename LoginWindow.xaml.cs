using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
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
using MahApps.Metro.Controls;
using Telegram.Bot;
using Native.Tool.IniConfig;
using Native.Tool.IniConfig.Linq;
using System.Windows.Threading;

namespace Hanaya_TgBot
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : MetroWindow
    {
        public bool isOpen = false;
        public LoginWindow()
        {
            IniConfig ini = new IniConfig(Directory.GetCurrentDirectory() + "\\bot.config.ini");
            ini.Load();
            ini.Clear();
            ini.Save();
            ResizeMode = ResizeMode.CanMinimize;
            InitializeComponent();
        }

        private void Login_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                var botClient = new TelegramBotClient(Bot_Token.Text);
                var bot_info = botClient.GetMeAsync().Result;
                Login_Rtn.Foreground = new SolidColorBrush(Color.FromRgb(102, 204, 255));
                Login_Rtn.Text = $"Welcome!\nHanaya.TgBot框架现在登录的是Bot账号 {bot_info.Id}\nBot名字为 {bot_info.FirstName}.";
                IniConfig ini = new IniConfig(Directory.GetCurrentDirectory()+"\\bot.config.ini");
                ini.Load();
                ini.Object.Add(new ISection("BotAccount"));
                ini.Object["BotAccount"]["token"] = Bot_Token.Text;
                ini.Object["BotAccount"]["ID"] = bot_info.Id;
                ini.Object["BotAccount"]["Name"] = bot_info.FirstName;
                ini.Save();
                MainWindow mainWindow = new MainWindow();
                Help_Login help = new Help_Login();
                if (isOpen != false)
                {
                    mainWindow.Show();
                    help.Close();
                    Close();
                }
                else
                {
                    mainWindow.Show();
                    Close();
                }
            }
            catch (AggregateException ex)
            {
                Login_Rtn.Text = "错误:System.AggregateException" + "\n请检查网络连接(国内连接Telegram需要代理)" + "\n以及检查Token是否正确\n" + ex.Message;
            }
            catch (WebException ex)
            {
                Login_Rtn.Text = "错误:System.Net.WebException\n" + ex.Message;
            }
            catch(Exception ex)
            {
                Login_Rtn.Text = "错误:System.Exception:请填写正确的Token(格式错误)\n" + ex.Message;
            }
        }
        private void Close_Btn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GitHub(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HacknetBar-Telegram-Bot-Developer/Hanaya_Telegram.Bot");
        }

        private void LoginHelp(object sender, RoutedEventArgs e)
        {
            Help_Login help = new Help_Login();
            if (isOpen==true)
            {
                help.Activate();
            }
            else
            {
                help.Show();
                isOpen = true;
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //DispatcherTimer timer;
            //timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(5);
            //timer.Tick += timer_Tick;
            //timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //以下弃用:telegram禁止ping
            //
            //定时执行的内容
            //Telegram_ConnectCheck check = new Telegram_ConnectCheck();
            //string Status = check.ConnectCheck("api.telegram.com");
            //if (Status == "0")
            //{
            //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
            //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            //    var ping = new Ping();
            //    var result = ping.Send("api.telegram.org");
            //    PingInfo.Foreground = new SolidColorBrush(Color.FromRgb(0, 102, 102));
            //    PingInfo.Text = $"Connect api.telegram.org Success. ({result.RoundtripTime}ms||{result.Address}";
            //}
            //else if (Status == "1")
            //{
            //    PingInfo.Foreground = new SolidColorBrush(Color.FromRgb(238, 0, 0));
            //    PingInfo.Text = $"Connect api.telegram.org Timeout. Please check your network or proxy.";
            //}
            //else if (Status == "2")
            //{
            //    PingInfo.Foreground = new SolidColorBrush(Color.FromRgb(238, 0, 0));
            //    PingInfo.Text = $"Connect api.telegram.org throw an Error. Please check your network or proxy.";
            //}
            //else if (Status == "3")
            //{
            //    PingInfo.Foreground = new SolidColorBrush(Color.FromRgb(238, 0, 0));
            //    PingInfo.Text = $"Connect api.telegram.org throw a PingException. Please check your network or proxy.";
            //}
            //else if (Status == "4")
            //{
            //    PingInfo.Foreground = new SolidColorBrush(Color.FromRgb(238, 0, 0));
            //    PingInfo.Text = $"Connect api.telegram.org throw an Exception. Please check your network or proxy.";
            //}
            //else if (Status == null)
            //{
            //    PingInfo.Foreground = new SolidColorBrush(Color.FromRgb(238, 0, 0));
            //    PingInfo.Text = $"Connection check is not running. This is a programming error. Please wait.";
            //}
        }
    }
}

