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
        public static void SetDailyReminder(DateTime time)
        {
            try
            {

                //write a save to file
                FileHandler.Write($"{DateTime.Now:yyyy/MM/dd} {time:h:mm:ss tt}", reminderfile);

                /*
                 * Note that scheduled toast notifications have a delivery window of 5 minutes. If the computer is turned off during the scheduled delivery time, and remains off for longer than 5 minutes, the notification will be "dropped" as no longer relevant to the user. --Microsoft
                 */
                HandleTask(time);


            }
            catch (Exception ex)
            {
                throw new Exception("REMINDER: INTERNAL_ERROR: " + ex.Message);
            }
        }

        public static void HandleTask(DateTime time)
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    // Create a new task definition.
                    TaskDefinition td = ts.NewTask();

                    // Set the task properties.
                    td.RegistrationInfo.Description = "Chrono";
                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    // Set the trigger to run every day at <time>
                    DailyTrigger trigger = new DailyTrigger();
                    trigger.StartBoundary = time;
                    trigger.DaysInterval = 1;
                    td.Triggers.Add(trigger);

                    td.Actions.Add(new ExecAction("cmd.exe", " c/ C:\\Users\\ASUS\\Downloads\\Chrono\\Chrono\\bin\\Release\\Chrono.exe"));

                    // Register the task with the task scheduler.
                    ts.RootFolder.RegisterTaskDefinition("Chrono", td);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("REMINDER: INTERNAL_ERROR: " + ex.Message);
            }
        }

        public static void RemoveNotification()
        {
            TaskService ts = new TaskService();
            ts.RootFolder.DeleteTask("Chrono");
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