using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{

    internal class Entry
    {
        public int UserId { get; set; } 
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public Entry(int id, DateTime date)
        {
            UserId = id;
            Date = date;
        }

        public Entry(DateTime date, string content)
        {
            Date = date;
            Content = content;
        }



        public Entry(int id, DateTime date, string content) 
        {
            UserId = id;
            Date = date;
            Content = content;
        }

    }
}
