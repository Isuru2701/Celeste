using Celeste.Model;
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

                    Conn conn = new Conn();
                    byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                    string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                    string command = $"Select enduser_id, email, password_hash from EndUser where email='{email}' AND password_hash='{hash}'";

                    if(conn.EntryExists(command))
                    {
                        List<object> reply = conn.FetchRow(command);
                        Flow.User_ID = (int)reply[0];
                            Person.GetInstance(Flow.User_ID);

                        // Person.GetInstance(Flow.User_ID).DebugDisplay();

                            NavigationService.Navigate(new Home());
                        }
                        else
                        {
                        Warning.Content = "Invalid pairing. Please try again";
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
