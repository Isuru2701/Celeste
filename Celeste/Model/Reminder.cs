using RoyT.TimePicker;
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
using HandyControl.Controls;
using System.Drawing;
using System.Threading;
using System.Windows.Media.Imaging;
using Notifications.Wpf;
using Microsoft.Win32.TaskScheduler;
using Quartz;

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
                FileHandler.Write($"{time}", reminderfile);

                /*
                 * Note that scheduled toast notifications have a delivery window of 5 minutes. If the computer is turned off during the scheduled delivery time, and remains off for longer than 5 minutes, the notification will be "dropped" as no longer relevant to the user. --Microsoft
                 */
                SetNotification(time);


            }
            catch (Exception ex)
            {
                throw new Exception("REMINDER: INTERNAL_ERROR: " + ex.Message);
            }
        }

        public static void SetNotification(DateTime time)
        {
            List<string> prompts = new List<string>
                {
                    "How did your day go?",
                    "Write the way into your heart!",
                    "What did you accomplish today?"
                };

            

        }

        public static void DeleteReminder()
        {
            if (FileHandler.ResourceExists(reminderfile))
            {
                FileHandler.Write("", reminderfile);
            }

            // Create the toast notifier
            ToastNotifierCompat notifier = ToastNotificationManagerCompat.CreateToastNotifier();

            // Get the list of scheduled toasts that haven't appeared yet
            IReadOnlyList<ScheduledToastNotification> scheduledToasts = notifier.GetScheduledToastNotifications();

            // Find our scheduled toast we want to cancel
            var toRemove = scheduledToasts.FirstOrDefault(i => i.Tag == "10" && i.Group == "Reminder");
            if (toRemove != null)
            {
                // And remove it from the schedule
                notifier.RemoveFromSchedule(toRemove);
            }
        }

        /// <summary>
        /// returns the reminder time for the current user stored in reminder.txt returns null if exception occurs.
        /// </summary>
        /// <returns></returns>
        public static DateTime GetReminderTime()
        {
            try
            {
                DateTime time = DateTime.MinValue;
                DateTime.TryParse(FileHandler.ReadText(reminderfile), out time);
                return time;

            }
            catch (FormatException)
            {
                throw new Exception("REMINDER: INVALID_FORMAT_ERROR");
            }
            catch (Exception)
            {
                throw new Exception("REMINDER: INTERNAL_ERROR");
            }
        }
    }



}