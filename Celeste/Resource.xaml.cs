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
using System.Windows.Shapes;
using System.Drawing;

namespace Celeste
{
    /// <summary>
    /// Interaction logic for Resource.xaml
    /// </summary>
    public partial class Resource : Window
    {
        public Resource()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_videos_Click(object sender, RoutedEventArgs e)
        {
            //this was used to change the color of the button when clicked. it worked but
            //it stays like that forever
            //in the future, check if the user control is open, if so, do this, else reset it
            //apply to other events as well

            //btn_videos.Background = (Brush)(new BrushConverter().ConvertFrom("#d8c6a0"));
            //btn_videos.Foreground = border_menu.Background;

        }

        private void btn_books_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_locations_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
