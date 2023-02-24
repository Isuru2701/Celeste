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
            lbl_confirmation.Content = $"Reminder set for {timepicker.Time}";
            lbl_confirmation.Visibility = Visibility.Visible;

            new ToastContentBuilder()

            .AddArgument("action", "viewConversation")
            .AddArgument("conversationId", 9813)
            .AddText("Andrew sent you a picture")
            .AddText("Check this out, The Enchantments in Washington!")

            // Inline image
            .AddInlineImage(new Uri("https://picsum.photos/360/202?image=883"))

            // Profile (app logo override) image
            .AddAppLogoOverride(new Uri("../Resources/quill.png", UriKind.Relative), ToastGenericAppLogoCrop.Default).Show();
        }
    }
}
