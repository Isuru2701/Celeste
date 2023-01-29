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

        string slnAt, resourcesPath;

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
                string profilePicPath = System.IO.Path.Combine(slnAt, "Resources\\PROFILE_PIC.png");
                File.Copy(fileDialog.FileName, profilePicPath, true);

                pic_pfp.Source = new BitmapImage(new Uri(profilePicPath));
            }
        }

        private void resetpfp_btn_Click(object sender, RoutedEventArgs e)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            slnAt = System.IO.Path.GetFullPath(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            resourcesPath = System.IO.Path.Combine(slnAt, "Resources\\");
            try
            {
                pic_pfp.Source = new BitmapImage(new Uri(System.IO.Path.Combine(resourcesPath, "PROFILE_PIC.png")));
            }
            catch(FileNotFoundException)
            {
                pic_pfp.Source = new BitmapImage(new Uri(System.IO.Path.Combine(resourcesPath, "logo(minimal).png")));
            }
        }
    }
}
