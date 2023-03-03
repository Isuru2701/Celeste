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
                Person.GetInstance(Flow.User_ID).SetPic();
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
                pic_pfp.Source = new BitmapImage(new Uri("../Resources/logo(large).png", UriKind.Relative));

                using (var context = new LunarContext())
                {
                    var query = context.ProfilePictures.Where(u => u.enduser_id == Flow.User_ID).FirstOrDefault();

                    if (query.picture != null)
                    {
                        query.picture = null;
                        Person.GetInstance(Flow.User_ID).ProfilePic = null;
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
                if (Person.GetInstance(Flow.User_ID).ProfilePic!= null)
                    pic_pfp.Source = Person.GetInstance(Flow.User_ID).GetPic();
                else
                    pic_pfp.Source = new BitmapImage(new Uri("../Resources/logo(large).png", UriKind.Relative));

            }

            catch (Exception ex)
            {
                MessageBox.Show("USER: PFP_LOAD_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }
    }
}
