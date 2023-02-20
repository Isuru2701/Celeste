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
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Celeste
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changepfp_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog selector = new OpenFileDialog();
                selector.CheckFileExists = true;

                if (selector.ShowDialog() == true)
                { 
                    if (File.Exists(selector.FileName) && selector.FileName != string.Empty)
                    {

                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void resetpfp_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                pic_pfp.Source = new BitmapImage(new Uri("Resources /logo(minimal).png"));
            }
            catch (Exception)
            {
                throw new Exception("FATAL: SOME RESOURCES APPEAR TO BE MISSING");
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
