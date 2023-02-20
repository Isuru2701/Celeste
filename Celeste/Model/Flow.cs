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

        public static Person sessionUser;

        //Create when program is run the first time
        static Flow()
        {

            StartTime = DateTime.Now;

            sessionUser.FetchInfo();
        }
    }
}
