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
using System.Text.RegularExpressions;
using System.Security.Cryptography;

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
                if(Person.GetInstance(Flow.User_ID).GetPic() != null)
                    pic_pfp.Source = Person.GetInstance(Flow.User_ID).ProfilePic;
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
                    var query = context.ProfilePictures.Find(Flow.User_ID);

                    if (query != null)
                    {
                        context.ProfilePictures.Remove(query);
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
                if (Person.GetInstance(Flow.User_ID).GetPic() != null)
                    pic_pfp.Source = Person.GetInstance(Flow.User_ID).ProfilePic;
                else
                    pic_pfp.Source = new BitmapImage(new Uri("../Resources/logo(large).png", UriKind.Relative));

            }

            catch (Exception ex)
            {
                MessageBox.Show("USER: PFP_LOAD_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void btn_confirm_Click(object sender, RoutedEventArgs e)
        {

            if(ValidatePassword())
            {
                SHA1Managed sha = new SHA1Managed();
                byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(pwb_password.Password));
                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                using (var context = new LunarContext())
                {
                    var query = context.EndUsers.Find(Flow.User_ID);

                    if (query != null)
                    {
                        query.password_hash = hash;

                        lbl_password_error.Content = "update successful!";
                        lbl_password_error.Visibility = Visibility.Visible;
                        context.SaveChanges();

                    }
                    else
                    {
                        lbl_password_error.Content = "something went wrong";
                        lbl_password_error.Visibility = Visibility.Visible;

                    }

                }
            }


        }
        private bool ValidatePassword()
        {
            List<string> common = new List<string>
            {
                "123456",
                "123456789",
                "qwerty",
                "password",
                "12345",
                "qwerty123",
                "1q2w3e",
                "12345678",
                "111111",
                "1234567890"
            };


            if (pwb_password.Password.Length == 0)
            {
                lbl_password_error.Visibility = Visibility.Visible;
                lbl_password_error.Content = "empty password field";
                return false;
            }

            else if (common.Any(x => x == pwb_password.Password))
            {
                //common password
                lbl_password_error.Content = "weak password: common";
                lbl_password_error.Visibility = Visibility.Visible;
                return false;

            }

            else if (Regex.IsMatch(pwb_password.Password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$"))
            {
                //password atleast 8 in length, contains uppercase, lowercase, one number
                lbl_password_error.Content = "strong password";
                lbl_password_error.Visibility = Visibility.Visible;
                return true;

            }
            else if (Regex.IsMatch(pwb_password.Password, @"^[^\s]{8,}$"))
            {
                //password atleast 8 in length, contains any character except spaces
                lbl_password_error.Content = "medium password";
                lbl_password_error.Visibility = Visibility.Visible;
                return true;
            }
            else
            {
                //password fails -- disallow 
                lbl_password_error.Content = "weak password";
                lbl_password_error.Visibility = Visibility.Visible;
                return false;
            }

        }

    }
}
