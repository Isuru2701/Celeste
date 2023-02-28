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
using System.Windows.Shapes;
using System.Windows.Navigation;
using Celeste.Views;
using Celeste.Model;

namespace Celeste
{
    /// <summary>
    /// Interaction logic for MAINFRAME.xaml
    /// </summary>
    public partial class MAINFRAME : Window
    {
        public MAINFRAME()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Login());
            OverlayFrame = new Frame();
        }
    }
}
