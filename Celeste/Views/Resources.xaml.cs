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
    /// Interaction logic for Resources.xaml
    /// </summary>
    public partial class Resources : Page
    {
        public Resources()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
        }

        private void btn_videos_Click(object sender, RoutedEventArgs e)
        {
            //TODO ADD THIS STUFF4
            
        }

        private void btn_books_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_locations_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
