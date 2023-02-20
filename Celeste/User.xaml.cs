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
using Celeste.Model;

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


        private byte[] _rawImageData;
        public byte[] RawImageData
        {
            get { return _rawImageData; }
            set
            {

                //check if the new image is different.
                if (value != _rawImageData)
                {
                    _rawImageData = value;
                }
            }
        }

        private void changepfp_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog selector = new OpenFileDialog();
                selector.CheckFileExists = true;

                if (selector.ShowDialog() == true)
                {

                    //store a local copy AND upload to database
                    if (File.Exists(selector.FileName) && selector.FileName != string.Empty)

                    {
                        pic_pfp.Source = new BitmapImage(new Uri(selector.FileName));

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
                pic_pfp.Source = new BitmapImage(new Uri("Resources/logo(large).png", UriKind.Relative));
            }
            catch (Exception)
            {
                throw new Exception("FATAL: SOME RESOURCES APPEAR TO BE MISSING: " + Flow.BaseAddress);
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
