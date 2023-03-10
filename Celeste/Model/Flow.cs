using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    //MAIN CONTROLLER
    //The highest-level of abstraction
    public static class Flow
    {
        public static DateTime StartTime { get; set; }

        public static DateTime LastUpdate { get; set; }

        public static string BaseAddress { get; set; }

        public static int User_ID { get; set; }

        public static string APIString
        {
            get { return APIString; }
            private set { APIString = "127.0.0.1:777"; }

        }

        public static string AppId
        {
            get { return AppId; }
            private set { AppId = "CELESTE_JOURNAL_V1_DEV_RELEASE";}
        }

        //Create when user logs in
        public static void Initiate()
        {
            User_ID = 0;
            BaseAddress = AppDomain.CurrentDomain.BaseDirectory;
            StartTime = DateTime.Now;
        }

        /// <summary>
        /// important method, use to check if there is internet connection
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
        {
            try
            {

                using (var ping = new Ping())
                {
                    var result = ping.Send("www.google.com", 1000);
                    return result.Status == IPStatus.Success;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
