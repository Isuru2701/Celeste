using Microsoft.SqlServer.Server;
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
using Hammer.MDIContainer;
using Hammer.MDIContainer.Control;

namespace Celeste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btn_resources_Click(object sender, RoutedEventArgs e)
        {
            new Resource().Show();
        }

        private void btn_insights_Click(object sender, RoutedEventArgs e)
        {
            new Insights().Show();
        }

        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
        }

        private void btn_lightmode_Click(object sender, RoutedEventArgs e)
        {
            //turns the light-mode script on. Not very important,
            //can replace with Credits or something


        }

        private void btn_entries_Click(object sender, RoutedEventArgs e)
        {
            new Entries().Show();
        }

        private void btn_faq_Click(object sender, RoutedEventArgs e)
        {
            new Faq().Show();
        }

        private void btn_user_Click(object sender, RoutedEventArgs e)
        {
            new User().Show();
            this.Opacity= 30;
        }
    }
}
