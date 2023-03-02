using Microsoft.Win32.TaskScheduler;
using Microsoft.Toolkit.Uwp.Notifications;
using RoyT.TimePicker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Celeste.Model;
using System.IO;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Microsoft.Win32;
using System.Globalization;

namespace Celeste.Controls
{
    /// <summary>
    /// Interaction logic for TimePicker.xaml
    /// </summary>
    public partial class TimePicker : UserControl
    {
        public TimePicker()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            var overlayframe = ((FrameworkElement)Window.GetWindow(this).Content).FindName("OverlayFrame") as Frame;
            overlayframe.Content = null;

        }

        private void btn_meridian_Click(object sender, RoutedEventArgs e)
        {
            if(timepicker.Time.Meridiem == Meridiem.AM)
            {
                timepicker.Time = new AnalogueTime(timepicker.Time.Hour, timepicker.Time.Minute, Meridiem.PM);
            }
            else
            {
                timepicker.Time = new AnalogueTime(timepicker.Time.Hour, timepicker.Time.Minute, Meridiem.AM);
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            lbl_confirmation.Content = $"Reminder set for\n {timepicker.Time}";
            lbl_confirmation.Visibility = Visibility.Visible;

            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, timepicker.Time.Hour, timepicker.Time.Minute, DateTime.Now.Second);

            //Setting up the notification even if the app is closed
            try
            {

                Reminder.SetDailyReminder(time);
            }
            catch(Exception ex)
            {
                MessageBox.Show("TIMEPICKER: SAVE_ERROR: " + ex.Message + ex.Source, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FileHandler.ResourceExists("Reminder.txt"))
                {
                    DateTime time = Reminder.GetReminderTime();
                    timepicker.Time = new AnalogueTime(time.Hour, time.Minute, time.ToString("tt") == "AM" ? Meridiem.AM : Meridiem.PM);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("TIMEPICKER: LOAD_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
