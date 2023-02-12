using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    internal class Score
    {
       
        DateTime date;
        double value;
        public Score(DateTime date, double value) 
        {
            this.date = date;
            this.value = value;
        }
    }
}
