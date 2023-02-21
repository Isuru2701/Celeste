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
                    string hash = Convert.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(password)));

                    List<object> reply = conn.FetchRow($"Select enduser_id, email, password_hash from EndUser where email={email} AND password_hash={hash}");

                    string str = "";
                    for(int i = 0; i < reply.Count; ++i)
                    {
                        str += reply[i] + " | ";
                    }
                    MessageBox.Show("DB REPLY: " + str);

                }

                catch (SqlException ex)
                {
                    MessageBox.Show("FATAL: INTERNAL_ERROR" + ex.Message, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);

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
    }
}
