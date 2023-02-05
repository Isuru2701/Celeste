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
            for (int i = 0; i <= 31; ++i)
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


    }
}
