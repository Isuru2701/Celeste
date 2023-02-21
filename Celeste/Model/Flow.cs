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



        //Create when user logs in
        public static void Initiate()
        {

            new Conn().Fetch("");
            
            BaseAddress = AppDomain.CurrentDomain.BaseDirectory;
            StartTime = DateTime.Now;
        }
    }
}
