﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    internal class Score
    {
       
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public Score(DateTime date, double value) 
        {
            Date = date;
            Value = value;
        }
    }
}
