using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace Hanaya_TgBot
{
    public class Telegram_ConnectCheck
    {
        public string ConnectCheck(string hostname)
        {
            string Rtn = null;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                var ping = new Ping();
                var result = ping.Send(hostname);
                if (result.Status == IPStatus.Success)
                {
                    Rtn = "0";
                }
                else if (result.Status == IPStatus.TimedOut)
                {
                    Rtn = "1";
                }
                else
                {
                    Rtn = "2";
                }
            }
            catch (PingException)
            {
                Rtn = "3";
            }
            catch (Exception)
            {
                Rtn = "4";           
            }
            return Rtn;
        }
    }
}
