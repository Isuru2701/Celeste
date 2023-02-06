using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_signup_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }


        List<string> months = new List<string>
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"
        };

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 31; ++i)
            {
                cmb_days.Items.Add(i);
            }

            foreach (string month in months)
            {
                cmb_months.Items.Add(month);
            }

            //ppl need to be >10 years atleast 
            for (int i = 1900; i <= DateTime.Now.Year - 10; ++i)
            {
                cmb_years.Items.Add(i);
            }
        }

        private void txt_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!Regex.IsMatch(txt_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                lbl_email_error.Visibility = Visibility.Visible;

            }
            else
            {
                lbl_email_error.Visibility = Visibility.Hidden;
            }
        }

        private void txt_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!Regex.IsMatch(txt_username.Text, @"^[a-zA-Z]{4,12}$"))
            {
                lbl_username_error.Visibility = Visibility.Visible;
            }
            else
            {
                lbl_username_error.Visibility = Visibility.Hidden;
            }
        }


        private void pwb_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pwb_password.Password.Length < 8)
            {
                lbl_password_error.Content = "min 8 characters";
                lbl_password_error.Visibility = Visibility.Visible;
            }
            else if (!Regex.IsMatch(pwb_password.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            {
                lbl_password_error.Content = "must contain an uppercase, lower case,\n number, and special character";
                lbl_password_error.Visibility= Visibility.Visible;
            }
            else
            {
                lbl_password_error.Visibility = Visibility.Hidden;
            }
        }
    }
}
