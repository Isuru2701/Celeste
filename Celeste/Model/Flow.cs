using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    //MAIN CONTROLLER
    public class Flow
    {

        
        DateTime StartTime { get; set; }

        //Create when program is run
        public Flow()
        {
            StartTime = DateTime.Now;
        }
    }
}
