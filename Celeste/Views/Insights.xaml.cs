using Celeste.Controls;
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
            NavigationService.GoBack();
        }

        private void btn_score_Click(object sender, RoutedEventArgs e)
        {
            InfoFrame.Content = new Graph();
        }

        private void btn_triggers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_comforts_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}