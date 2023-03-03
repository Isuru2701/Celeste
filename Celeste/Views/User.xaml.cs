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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using Celeste.Model;
using System.Drawing;
using System.Windows.Navigation;
using Celeste.Model.Data;
using CefSharp.DevTools.WebAudio;
using Windows.UI.Xaml.Media.Imaging;

namespace Celeste
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            var overlayframe = ((FrameworkElement)Window.GetWindow(this).Content).FindName("OverlayFrame") as Frame;
            overlayframe.Content = null;
            
        }


        private void changepfp_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {


            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Please select an image", "Oops!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            catch (Exception ex)
            {
                MessageBox.Show("USER: INTERNAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void resetpfp_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pic_pfp.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri("../Resources/logo(large).png", UriKind.Relative));

                using (var context = new LunarContext())
                {
                    var query = context.ProfilePictures.Where(u => u.enduser_id == Flow.User_ID).FirstOrDefault();

                    if (query.picture != null)
                    {
                        query.picture = null;
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("USER: FATAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            lbl_username.Content = Person.GetInstance(Flow.User_ID).username;
            lbl_email.Content = Person.GetInstance(Flow.User_ID).email;
            lbl_user_id.Content = Person.GetInstance(Flow.User_ID).user_id;


            try
            {
                using (var context = new LunarContext())
                {
                    var image = context.ProfilePictures.FirstOrDefault(i => i.enduser_id == Flow.User_ID);

                    if (image.picture != null)
                    {
                        var imageData = image.picture;
                        var bitmapImage = new System.Windows.Media.Imaging.BitmapImage();

                        using (var memoryStream = new System.IO.MemoryStream(imageData))
                        {
                            bitmapImage.BeginInit();
                            bitmapImage.CacheOption = System.Windows.Media.Imaging.BitmapCacheOption.OnLoad;
                            bitmapImage.StreamSource = memoryStream;
                            bitmapImage.EndInit();
                        }

                        pic_pfp.Source = bitmapImage;                   
                    }
                }
            }

            catch (Exception)
            {

            }


        }
    }
}
