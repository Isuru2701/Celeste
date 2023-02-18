using HandyControl.Controls;
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

            List<string> buttonTexts = new List<string>();
            for(int i = 1; i < 30; ++i)
            {
                buttonTexts.Add($"{DateTime.Now.Date.AddDays(-i).ToLongDateString()}");
            }
            Container.ItemsSource = buttonTexts;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;  // cast the sender parameter to a Button
            string buttonText = (string)clickedButton.Content;  // get the text content of the button
                                                                // Do something with the clicked button, such as displaying a message with the button text
            System.Windows.MessageBox.Show("You clicked the button with text: " + buttonText);
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
