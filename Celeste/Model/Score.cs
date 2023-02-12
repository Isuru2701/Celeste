using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    internal class Score
    {
        int value;
        DateTime date;
        public Score(DateTime date, int value) 
        {
            this.date = date;
            this.value = value;
        }
    }
}
