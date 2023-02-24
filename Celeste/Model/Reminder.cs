﻿using RoyT.TimePicker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Notifications;
using Windows.Data;
using Windows.Foundation;
using System.Windows;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Celeste.Model
{
    public static class Reminder
    {
        private static string reminderfile = "Reminder.txt";

        static Reminder() 
        {
        }   

        /// <summary>
        /// sets daily reminder to the time specified
        /// </summary>
        /// <param name="time"></param>
        public static void SetDailyReminder(DateTime time)
        {
            try
            {

                //write a save to file
                FileHandler.Write($"{time:h:mm:ss (tt)}", reminderfile);

                /*
                 * Note that scheduled toast notifications have a delivery window of 5 minutes. If the computer is turned off during the scheduled delivery time, and remains off for longer than 5 minutes, the notification will be "dropped" as no longer relevant to the user. --Microsoft
                 */

                List<string> list = new List<string>
                {
                    "How did your day go?",
                    "Write the way into your heart!",
                    "What did you accomplish today?"
                };

                new ToastContentBuilder()
                    .AddArgument("action", "Celeste")
                    .AddText("Time to Write!")
                    .AddText(list[new Random().Next(list.Count)])
                    .Schedule(new ScheduledToastNotification(time, new TimeSpan().FromDays(1))
                     {
                         Tag = "18365",
                         Group = "ASTR 170B1"
                     });



            }
            catch (Exception ex)
            {
                MessageBox.Show("REMINDER: INTERNAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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