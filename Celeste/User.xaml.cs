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

            OpenFileDialog fileDialog = new OpenFileDialog();

            //make a copy of the file into the resources folder first, and then set the pfp
            if (fileDialog.ShowDialog() == true)
            {
                //copying
                try
                {
                    File.Copy(fileDialog.FileName, @"Resources/PROFILE_PIC.png");
                }
                catch(IOException)
                {

                }

                //pic_pfp.Source = new BitmapImage(new Uri());
            }
        }

        private void resetpfp_btn_Click(object sender, RoutedEventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
