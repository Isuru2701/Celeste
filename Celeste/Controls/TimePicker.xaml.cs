using RoyT.TimePicker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            if(timepicker.Time.Meridiem == Meridiem.PM)
            {
                timepicker.Time = new AnalogueTime(timepicker.Time.Hour, timepicker.Time.Minute, Meridiem.PM);
            }
        }
    }
}
