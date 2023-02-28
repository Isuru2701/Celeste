using CefSharp.Wpf;
using CefSharp;
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
using System.ComponentModel;

namespace Celeste.Controls
{
    /// <summary>
    /// Interaction logic for VideoViewer.xaml
    /// </summary>
    public partial class VideoViewer : Page
    {
        public VideoViewer(string id)
        {
            InitializeComponent();

            try
            {

                browser.Load($"https://www.youtube.com/embed/{id}");

            }
            catch (Exception)
            {
                throw new Exception("VIDEOVIEWER:NOCONN_ERROR");

            }


        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            browser.Dispose();
        }
    }
}
