using RoyT.TimePicker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace Celeste.Model
{
    public static class Reminder
    {
        private static string reminderfile = "Reminder.txt";

        static Reminder() 
        {
        }   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        public static void SetDailyReminder(AnalogueTime time)
        {
            //write a save to file
            FileHandler.Write($"{time:h:mm:ss tt}", reminderfile);

            //add notification worker

        }

        /// <summary>
        /// returns the reminder time for the current user stored in reminder.txt returns null if exception occurs.
        /// </summary>
        /// <returns></returns>
        public static DateTime? GetReminderTime()
        {
            try
            {
                return DateTime.ParseExact(FileHandler.ReadText(reminderfile), "hh:mm (tt)", CultureInfo.InvariantCulture);
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