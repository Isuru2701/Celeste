using Celeste.Controls;
using Celeste.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            //TODO ADD THIS STUFF

            var rand = new Random();
            int i = Person.GetInstance(Flow.User_ID).FetchTriggers();
            try
            {
                if (i > 0)
                {

                    var query = Person.GetInstance(Flow.User_ID).Triggers.OrderBy(x => rand.Next()).Take(1).First();

                    var videos = new VideoHandler().SearchVideos(query.Name);

                    ListBox box = new ListBox();
                    if (videos.Count > 0)
                    {

                        box.ItemsSource = videos;
                    }
                    else
                    {
                        Container.Content = new InsufficientInfo();
                    }

                    Container.Content = box;
                }
            }
            catch (Exception)
            {
                Container.Content = new NoConnection();
            }
        }

        private void PlayVideo_Click(object sender, RoutedEventArgs e)
        {
            var video = box.SelectedItem as Video;

            if (video != null)
            {
                Process.Start($"https://www.youtube.com/watch?v={video.Id}");
            }
        }


        private void btn_books_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_locations_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
