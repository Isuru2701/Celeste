﻿using Celeste.Controls;
using Celeste.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

        ListBox box = new ListBox();

        private void btn_videos_Click(object sender, RoutedEventArgs e)
        {

            var rand = new Random();
            int i = Person.GetInstance(Flow.User_ID).FetchTriggers();
            try
            {
                if (i > 0)
                {

                    var query = Person.GetInstance(Flow.User_ID).Triggers.OrderBy(x => rand.Next()).Take(1).First();

                    var videos = new VideoHandler().SearchVideos(query.Name);

                    //var listitems = new List<Button>
                    //{

                    //}
                    if (videos.Count > 0)
                    {
                        foreach (var video in videos)
                        {
                            var image = new Image();
                            image.Source = new BitmapImage(new Uri(video.Thumbnail.Url));
                            image.Stretch = Stretch.Fill;

                            Button button = new Button
                            {
                                Name = video.Id,
                                Style = new Style().BasedOn = FindResource("MenuButtonTheme") as Style,
                                Content = new StackPanel
                                {
                                    Orientation = Orientation.Horizontal,
                                    Children =
                                    {
                                        new Border
                                        {
                                            Child = image,
                                            
                                        },
                                        new StackPanel {

                                            Children={
                                            new Label { Content = video.Title, FontSize=20, Margin = new Thickness(20,0,0,0)},

                                            new Label {Content = video.Author, FontSize = 10, Margin = new Thickness(5)}
                                            }
                                        }
                                    }
                                }
                            };
                            
                            button.Click += new RoutedEventHandler(btn_Click);
                            box.Items.Add(button);
                        }
                        
                        Container.Content = box;
                    }
                    else
                    {
                        Container.Content = new InsufficientInfo();
                    }
                }
            }
            catch (Exception)
            {
                Container.Content = new NoConnection();
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            
        }

        private void PlayVideo(Video video)
        {

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
