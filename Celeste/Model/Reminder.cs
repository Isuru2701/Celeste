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
        public static void SetDailyReminder(AnalogueTime time)
        {
            try
            {

                //write a save to file
                FileHandler.Write($"{time:h:mm:ss tt}", reminderfile);

                //add notification worker
                var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);

                // Fill in the text elements
                var stringElements = toastXml.GetElementsByTagName("text");
                stringElements[0].AppendChild(toastXml.CreateTextNode("Title"));
                stringElements[1].AppendChild(toastXml.CreateTextNode("Content"));

                // Create the toast and attach event listeners
                var toast = new ToastNotification(toastXml);

                // Show the toast. Be sure to specify the AppUserModelId on your application's shortcut!
                ToastNotificationManager.CreateToastNotifier(Flow.AppId).Show(toast);
            }
            catch(Exception ex)
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