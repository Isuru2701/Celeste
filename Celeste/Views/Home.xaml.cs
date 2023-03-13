using CefSharp.Web;
using Celeste.Controls;
using Celeste.Model;
using LottieFiles.IO;
using LottieSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Storage;

namespace Celeste.Views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();


        }



        private void btn_resources_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Resources());
        }

        private void btn_insights_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Insights());
        }

        private void btn_notification_Click(object sender, RoutedEventArgs e)
        {
            var overlayframe = ((FrameworkElement)Window.GetWindow(this).Content).FindName("OverlayFrame") as Frame;
            overlayframe.Content = new TimePicker();


        }

        private void btn_entries_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Entries());
        }

        private void btn_user_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var overlayframe = ((FrameworkElement)Window.GetWindow(this).Content).FindName("OverlayFrame") as Frame;
                overlayframe.Content = new User();

            }
            catch (Exception ex)
            {
                MessageBox.Show("HOME: INTERNAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_writer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Writer(DateTime.Now));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                (this.FindResource("WriterLines") as Storyboard).Begin();

                (this.FindResource("Orbital") as Storyboard).Begin();

                (this.FindResource("Tapestry") as Storyboard).Begin();

                (this.FindResource("Stars") as Storyboard).Begin();
            }
            catch (Exception)
            {
                //Do nothing, just dont crash.
            }

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var image = (Image)sender;

            //relative to center
            double mouseX = e.GetPosition(image).X - (image.ActualWidth / 2);
            double mouseY = e.GetPosition(image).Y - (image.ActualHeight / 2);

            double maxOffset = 10;

            // Calculate the new X and Y offsets
            double offsetX = (maxOffset / image.ActualWidth) * mouseX;
            double offsetY = (maxOffset / image.ActualHeight) * mouseY;

            // Update image
            var transform = (TranslateTransform)image.RenderTransform;
            transform.X = offsetX;
            transform.Y = offsetY;
        }
    }

}