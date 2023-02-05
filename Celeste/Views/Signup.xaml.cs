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

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> months = new List<string>()
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

            //cmb_year. lim{1900 -- current.Year}
            for(int i = 1900; i <= DateTime.Now.Year - 1; ++i) 
            {
                cmb_years.Items.Add(i);
            }

            //cmb_months. lim{January to December}
            foreach (string month in months)
            {
                cmb_months.Items.Add(month);
            }

            for(int i = 1; i <= 31; ++i)
            {
                cmb_days.Items.Add(i);
            }


        }

        private void cmb_days_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToInt32(cmb_days.SelectedValue) == 31)
            {
                cmb_months.Items.Clear();

                List<string> months = new List<string>()
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
            else
            {
                cmb_months.Items.Clear();
                List<string> months = new List<string>()
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
        }

        private void cmb_months_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> monthswith31 = new List<string>
            {
              "January",
              "March",
              "May",
              "July",
              "August",
              "October",
              "December"

            };
            if (!monthswith31.Any(x => x == Convert.ToString(cmb_months.SelectedValue)))
            {
                cmb_days.Items.Clear();

                for (int i = 1; i <= 30; ++i)
                {
                    cmb_days.Items.Add(i);
                }


            }
        }
    }
}
