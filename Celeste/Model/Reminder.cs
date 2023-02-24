using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    public static class Reminder
    {
        private static string reminderfile = "Reminder.txt";

        static Reminder() 
        {
        }   

        public static void SetDailyReminder(DateTime time)
        {
            //write a save to file
            FileHandler.Write($"{time:MM/dd/yyyy h:mm:ss tt}", reminderfile);

            //add notification worker
        }

        /// <summary>
        /// returns the reminder time for the current user stored in reminder.txt
        /// </summary>
        /// <returns></returns>
        public static DateTime? GetReminderTime()
        {
            try
            {
                return DateTime.Parse(FileHandler.ReadText(reminderfile));
            }
            catch (FormatException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
    


}