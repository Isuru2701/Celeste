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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 1; i<=31; ++i)
            {
                cmb_days.Items.Add(i);
            }
        }

        private void cmb_days_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToInt32(cmb_days.SelectedValue) == 31)
            {
                List<string> months = new List<string>
                {
                    "January",
                    "March",
                    "May",
                    "July",
                    "August",
                    "October",
                    "December"
                };

                foreach (string month in months)
                {
                    cmb_months.Items.Add(month);
                }
            }

            else if (Convert.ToInt32(cmb_days.SelectedValue) == 30)
            {
                List<string> months = new List<string>
                {
                    "January",
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

                foreach (string month in months)
                {
                    cmb_months.Items.Add(month);
                }
            }

            else
            {
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

                foreach (string month in months)
                {
                    cmb_months.Items.Add(month);

                }
            
            }

                if (cmb_days.SelectedValue != null)
                cmb_months.IsEnabled = true;

            else
                cmb_months.IsEnabled = false;
        }
    }
}
