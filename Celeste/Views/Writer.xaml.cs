using Celeste.Model;
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
            string text = txt_writer.Text;
            //save a copy to local and also upload
            


        }

        //On load check if file with today's date is in appdata
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(FileHandler.ResourceExists($"{DateTime.Now.ToString("yyyyMMdd")}.txt"))
            {
                txt_writer.Text = FileHandler.ReadText($"{DateTime.Now.ToString("yyyyMMdd")}.txt");
            }

        }
    }
}
