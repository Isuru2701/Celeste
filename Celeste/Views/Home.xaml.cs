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
            
        }

        private void btn_entries_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Entries());
        }

        private void btn_user_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainFrame = VisualTreeHelper.GetParent(this) as Frame;
                var overlayFrame = mainFrame.Template.FindName("OverlayFrame", mainFrame) as Frame;

                // Set the Source property of the OverlayFrame to display the User page
                overlayFrame.Source = new Uri("Views/User.xaml", UriKind.Relative);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();   
        }

        private void btn_writer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Writer());
        }
    }

}