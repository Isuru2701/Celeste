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
    /// Interaction logic for Writer.xaml
    /// </summary>
    public partial class Writer : Page
    {
        public Writer()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            btn_save_Click(sender, e);
            NavigationService.GoBack();
        }

        //Write a copy to local for ease of access and also make entry to database
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSave();
        }

        private void ExecuteSave()
        {

        }
    }
}
