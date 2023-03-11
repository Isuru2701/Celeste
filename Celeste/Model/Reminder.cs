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
using System.Collections.Concurrent;
using System.ServiceProcess;

namespace Celeste.Model
{
    /// <summary>
    /// interaction with the notification dispatcher and reminder file
    /// </summary>
    public static class Reminder
    {
        private static string reminderfile = "Reminder.txt";
        private static ServiceController serviceController;


        static Reminder() 
        {
        }   

        /// <summary>
        /// sets daily reminder to the time specified
        /// </summary>
        /// <param name="time"></param>
        public static void SetDailyReminder(DateTime time, Meridiem meridiem)
        {
            try
            {

                //write a save to file
                FileHandler.Write($"{DateTime.Now:yyyy/MM/dd} {time:h:mm:ss} {meridiem}", reminderfile);

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

        public static void SetNotification(DateTime date)
        {
            try
            {
                serviceController = new ServiceController("ChronoForCeleste");
                if (serviceController.Status == ServiceControllerStatus.Running)
                {
                    //terminate any existing service with previous reminder time
                    serviceController.Stop();
                }

                //service accepts string of HH:mm
                serviceController.Start(new string[] { date.ToString("HH:mm") });
            }
            catch (Exception ex)
            {
                throw new Exception("REMINDER:SERVICE_NOT_FOUND_NO_START " + ex.Message);
            }

        }

        public static void RemoveNotification()
        {
            try
            {
                serviceController.Stop();
            }
            catch (Exception)
            {
                throw new Exception("REMINDER:SERIVCE_NOT_FOUND_NO_STOP");
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
                return DateTime.Parse($"{FileHandler.ReadText(reminderfile)}");

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