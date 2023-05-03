using Celeste.Model;
using Celeste.Model.Data;
using Celeste.Controls;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.IO;
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
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Celeste.Views
{
    /// <summary>
    /// Interaction logic for Writer.xaml
    /// </summary>
    public partial class Writer : Page
    {
        Entry current;
        string past_entry;

        public Writer(DateTime date)
        {

            current = new Entry(Flow.User_ID, date.Date);



            InitializeComponent();

            try
            {


                if (FileHandler.ResourceExists($"{date:yyyyMMdd}.txt"))
                {
                    txt_writer.Text = FileHandler.ReadText($"{date:yyyyMMdd}.txt");
                }
                else
                {

                    if (Flow.IsConnected())
                    {
                        using (var context = new LunarContext())
                        {
                            var query = context.user_entries.Where(e => e.enduser_id == Flow.User_ID && e.entry_date == current.Date)
                                .Select(e => e.content).FirstOrDefault();
                            if (query != null)
                            {
                                txt_writer.Text = query.ToString();
                            }
                        }

                        past_entry = txt_writer.Text;
                    }
                    else
                    {
                        Container.Children.Clear();
                        Container.Children.Add(new NoConnection());
                    }

                }

            }
            catch (Exception)
            {
                lbl_confirmation.Content = "Could not save";
            }
        }



        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSave();
            NavigationService.GoBack();
        }

        //Write a copy to local for ease of access and also make entry to database
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            ExecuteSave();
        }

        /// <summary>
        /// Stores file as yyyyMMdd.txt in Appdata
        /// </summary>
        private void ExecuteSave()
        {
            try
            {
                //save a copy to local and then push to db
                if (txt_writer.Text != "" && txt_writer.Text != past_entry)
                {
                    FileHandler.Write(txt_writer.Text, $"{current.Date:yyyyMMdd}.txt");

                    if (Flow.IsConnected())
                    {
                        using (var context = new LunarContext())
                        {
                            var entry = context.user_entries.Find(Flow.User_ID, current.Date);
                            if (entry != null)
                            {
                                entry.content = txt_writer.Text;
                            }
                            else
                            {
                                context.user_entries.Add(new user_entries
                                {
                                    enduser_id = Flow.User_ID,
                                    entry_date = current.Date,
                                    content = txt_writer.Text
                                });

                            }
                            context.SaveChanges();

                            FeedAPI(Flow.User_ID, current.Date);
                            lbl_confirmation.Content = "saved at " + DateTime.Now.ToString("h:mm tt"); 
                        }
                    }
                    else
                    {
                        new ToastContentBuilder()
                            .AddText("Celeste couldn't analyse your last entry.\nAre you connected to the internet?")
                            .Show();
                    }

                }
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation cuz of timeout

                lbl_confirmation.Content = "we couldn't save this entry.\nAre you connected to the internet?";
            }

            catch (DbUpdateException ex)
            {
                MessageBox.Show("WRITER: DB_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch(Exception ex)
            {
                MessageBox.Show("WRITER: SAVE_INTERNAL_ERROR: " + ex.Message + " " + ex.InnerException.Message + " " + ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private static async Task FeedAPI(int userId, DateTime date)
        {
            string url = $"localhost:8000/execute?user={userId}&date={date:yyyy-MM-dd}";

            try
            {
                var response = await new HttpClient().GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Flow.LastUpdate = DateTime.Now;
                }
            }
            catch (Exception)
            {
                //TODO: update a list in Flow to call all once connection is established
            }
        }


        private void btn_upload_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "Text Files (*.txt) | *.txt";

                if (dialog.ShowDialog() == true)
                {
                    txt_writer.Text = File.ReadAllText(dialog.FileName);
                }
            } 
            catch(FileNotFoundException ex)
            {
                MessageBox.Show("WRITER: READ_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show("WRITER: UPLOAD_INTERNAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

    }
}
