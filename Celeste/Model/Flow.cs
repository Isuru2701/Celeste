using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    //MAIN CONTROLLER
    //The highest-level of abstraction
    public static class Flow
    {
        public static DateTime StartTime { get; set; }

        public static string BaseAddress { get; set; }

        public static int User_ID { get; set; }

        public static string APIString
        {
            get { return APIString; }
            private set { APIString = "127.0.0.1:777/execute"; }

        }

        public static string AppId
        {
            get { return AppId; }
            private set { AppId = "CELESTE_JOURNAL_V1_DEV_RELEASE";}
        }

        //Create when user logs in
        public static void Initiate()
        {            

            BaseAddress = AppDomain.CurrentDomain.BaseDirectory;
            StartTime = DateTime.Now;
        }
    }
}
