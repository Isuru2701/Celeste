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
    /// Interaction logic for Entries.xaml
    /// </summary>
    public partial class Entries : Page
    {
        public Entries()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;  // cast the sender parameter to a Button
            string buttonText = (string)clickedButton.Content;  // get the text content of the button

            DateTime date = new DateTime();
            DateTime.TryParse(buttonText, out date);

            



            
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> buttonTexts = new List<string>();
            for (int i = 0; i < 30; ++i)
            {
                buttonTexts.Add($"{DateTime.Now.Date.AddDays(-i).ToLongDateString()}");
            }
            Container.ItemsSource = buttonTexts;

        }
    }
}
