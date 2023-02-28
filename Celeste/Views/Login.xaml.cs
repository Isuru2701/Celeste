using Celeste.Model;
using Celeste.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string email = txt_email.Text;
            string password = pwb_password.Password;

            //is user present in database:
            if (txt_email.Text == "" || pwb_password.Password == "")
            {
                Warning.Content = "Some fields are empty";
            }
            else
            {
                Warning.Content = "";
                try
                {
                    SHA1 sha = SHA1.Create();

                    
                    byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                    string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    using (var context = new LunarContext())
                    {
                        var endUser = context.EndUsers
                            .Where(u => u.email == email && u.password_hash == hash)
                            .FirstOrDefault();

                        if (endUser != null)
                        {
                            Flow.Initiate();
                            Flow.User_ID = endUser.enduser_id;
                            Person.GetInstance(Flow.User_ID);

                            // Person.GetInstance(Flow.User_ID).DebugDisplay();
                            NavigationService.Navigate(new Home());
                        }
                        else
                        {
                            Warning.Content = "Invalid pairing. Please try again";
                        }
                    }


                }

                catch (SqlException ex)
                {
                    MessageBox.Show(" FATAL: SQL_ERROR " + ex.Message ,  " ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

                }

                catch (Exception ex)
                {
                    MessageBox.Show("FATAL: INTERNAL_ERROR " + ex.Message, " ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Signup());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Warning.Content = "";
        }
    }
}
