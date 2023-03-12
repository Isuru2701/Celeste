using Celeste.Controls;
using Celeste.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
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
    /// Interaction logic for Insights.xaml
    /// </summary>
    public partial class Insights : Page
    {
        public Insights()
        {
            InitializeComponent();
        }
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Home());
        }

        private void btn_score_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Flow.IsConnected())
                {
                    InfoFrame.Content = new Chart();
                }
                else
                {
                    InfoFrame.Content = new NoConnection();
                }
            }
            catch (SqlException)
            {
                InfoFrame.Content = new NoConnection();
            }
            catch (Exception)
            {
                InfoFrame.Content = new InsufficientInfo();
            }

        }

        private void btn_triggers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Flow.IsConnected())
                    InfoFrame.Content = new PieChart("trigger");
                else
                    InfoFrame.Content = new NoConnection();
                
            }
            catch(SqlException)
            {
                InfoFrame.Content = new NoConnection();
            }

            catch (Exception)
            {
                InfoFrame.Content = new InsufficientInfo();
            }
        }

        private void btn_comforts_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Flow.IsConnected())
                    InfoFrame.Content = new PieChart("comfort");
                else
                    InfoFrame.Content = new NoConnection();
            }
            catch (SqlException)
            {
                InfoFrame.Content = new NoConnection();
            }
            catch (Exception)
            {
                InfoFrame.Content = new InsufficientInfo();
            }
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            if (Flow.IsConnected())
                InfoFrame.Content = new Report();
            else
                InfoFrame.Content = new NoConnection();
        }
    }
}