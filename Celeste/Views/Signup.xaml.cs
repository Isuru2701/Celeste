using Celeste.Model;
using Celeste.Model.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        DateTime date;
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
            if(ValidateEmail() && ValidateUsername() && ValidatePassword())
            {
                if (pwb_password.Password == pwb_confirm.Password)
                {
                    if(IsValidGender())
                    { 

                        if (IsValidDate(cmb_days.SelectedValue, (cmb_months.SelectedIndex + 1), cmb_years.SelectedValue))
                        {
                            ExecuteSignup();
                        }
                        else
                        {
                            lbl_validation_error.Visibility = Visibility.Visible;
                            lbl_validation_error.Content = "Invalid Date";
                        }

                    }
                    else
                    {
                        lbl_validation_error.Visibility = Visibility.Visible;
                        lbl_validation_error.Content = "Please select a gender";

                    }

                }
                else
                {
                    lbl_validation_error.Visibility = Visibility.Visible;
                    lbl_validation_error.Content = "Passwords don't match";
                }
            }

        }

        //Executes signup
        private void ExecuteSignup()
        {
            try
            {
                using (var context = new LunarContext())
                {
                    var existingUser = context.EndUsers.FirstOrDefault(u => u.email == txt_email.Text);

                    if (existingUser != null)
                    {
                        lbl_validation_error.Content = "This email is already registered by another user!";
                        lbl_validation_error.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        lbl_validation_error.Visibility = Visibility.Hidden;

                        SHA1Managed sha = new SHA1Managed();
                        byte[] hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(pwb_password.Password));
                        string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();


                        DateTime date = DateTime.Parse($"{(int)cmb_years.SelectedValue}/{(int)(cmb_months.SelectedIndex + 1)}/{(int)(cmb_days.SelectedValue)}");

                        context.EndUsers.Add(new EndUser
                        {
                            email = txt_email.Text,
                            password_hash = hash,
                            dob = date,
                            gender = (cmb_gender.SelectedValue.ToString())[0].ToString(),
                            username = txt_username.Text
                        });

                        context.SaveChanges();
                        lbl_validation_error.Content = "Sign up successful!";
                        lbl_validation_error.Visibility = Visibility.Visible;
                        Thread.Sleep(500);
                        NavigationService.Navigate(new Login());
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("INTERNAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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

            List<string> genders = new List<string>{ "male", "female", "other" };

            foreach (string gender in genders)
            {
                cmb_gender.Items.Add(gender);
            }
        }

        private void txt_email_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateEmail();
        }

        private void txt_username_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateUsername();
        }



        private void pwb_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ValidatePassword();
        }

        private bool IsValidDate(object day, object month, object year)
        {

            return DateTime.TryParse((day + "/" + month + "/" + year), out date);

        }

        private bool IsValidGender()
        {
            if (cmb_gender.SelectedValue != null) return true;
            else return false;
        }

        private bool ValidateEmail()
        {
            if (!Regex.IsMatch(txt_email.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") || txt_email.Text.Length > 100)
            {
                lbl_email_error.Visibility = Visibility.Visible;
                return false;

            }
            else
            {
                lbl_email_error.Visibility = Visibility.Hidden;
                return true;
            }

        }

        private bool ValidateUsername()
        {
            if (!Regex.IsMatch(txt_username.Text, @"^[a-zA-Z]{4,12}$"))
            {
                lbl_username_error.Visibility = Visibility.Visible;
                return false;
            }
            else
            {
                lbl_username_error.Visibility = Visibility.Hidden;
                return true;
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
                bar_strength.Value = 0;
                return false;
            }

            else if (common.Any(x => x == pwb_password.Password))
            {
                //common password
                lbl_password_error.Content = "weak password: common";
                lbl_password_error.Visibility = Visibility.Visible;
                bar_strength.Value = 25;
                return false;

            }

            else if (Regex.IsMatch(pwb_password.Password, @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d).{8,}$"))
            {
                //password atleast 8 in length, contains uppercase, lowercase, one number
                lbl_password_error.Content = "strong password";
                lbl_password_error.Visibility = Visibility.Visible;
                bar_strength.Value = 100;
                return true ;

            }
            else if (Regex.IsMatch(pwb_password.Password, @"^[^\s]{8,}$"))
            {
                //password atleast 8 in length, contains any character except spaces
                lbl_password_error.Content = "medium password";
                lbl_password_error.Visibility = Visibility.Visible;
                bar_strength.Value = 50;
                return true ;
            }
            else
            {
                //password fails -- disallow 
                lbl_password_error.Content = "weak password";
                lbl_password_error.Visibility = Visibility.Visible;
                bar_strength.Value = 25;
                return false;
            }

        }
    }
}
