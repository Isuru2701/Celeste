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


using WPFCustomMessageBox;
using System.Drawing;
using System.Windows.Navigation;

namespace Celeste
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Page
    {
        public User()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
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
                selector.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*"; ;

                if (selector.ShowDialog() == true)
                {

                    //store a local copy AND upload to database
                    if (File.Exists(selector.FileName))
                    {
                    }
                }

            }
            catch (NotSupportedException)
            {
                MessageBox.Show("Please select an image");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            lbl_username.Content = Person.GetInstance(Flow.User_ID).username;
            lbl_email.Content = Person.GetInstance(Flow.User_ID).email;
            lbl_user_id.Content = Person.GetInstance(Flow.User_ID).user_id;



            if (File.Exists($"{Flow.BaseAddress}../../Resources/profile_pic.png"))
            {
            }
            else
            {
                resetpfp_btn_Click(sender, e);
            }


        }
    }
}
