using Celeste.Model;
using Celeste.Model.Data;
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

namespace Celeste.Views
{
    /// <summary>
    /// Interaction logic for Writer.xaml
    /// </summary>
    public partial class Writer : Page
    {
        Entry current;
        public Writer()
        {
            current = new Entry(Flow.User_ID, DateTime.Now);

            InitializeComponent();

            try
            {


                if (FileHandler.ResourceExists($"{DateTime.Now:yyyyMMdd}.txt"))
                {
                    txt_writer.Text = FileHandler.ReadText($"{DateTime.Now:yyyyMMdd}.txt");
                }
                else
                {
                    
                    using (var context = new LunarContext())
                    {
                        txt_writer.Text = context.user_entries.Where(e => e.enduser_id == Flow.User_ID && e.entry_date == current.Date)
                            .Select(e => e.content).FirstOrDefault().ToString();
                        
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("WRITER: LOAD_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

        public Writer(DateTime date)
        {

            current = new Entry(Flow.User_ID, date);

            InitializeComponent();

            try
            {
                Conn conn = new Conn();

                if (FileHandler.ResourceExists($"{date:yyyyMMdd}.txt"))
                {
                    txt_writer.Text = FileHandler.ReadText($"{date:yyyyMMdd}.txt");
                }
                else if (conn.EntryExists($"select enduser_id from user_entries where enduser_id='{Flow.User_ID}' AND entry_date='{date:yyyy/MM/dd}'"))
                {
                    txt_writer.Text = (string)conn.FetchCol($"select content from user_entries where enduser_id='{Flow.User_ID}' AND entry_date='{date:yyyy/MM/dd}'")[0];

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("WRITER: SQL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("WRITER: INTERNAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

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
                if (txt_writer.Text != "")
                {
                    FileHandler.Write(txt_writer.Text, $"{current.Date:yyyyMMdd}.txt");

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
                        
                    }    

                }
            }
            catch(DbUpdateException ex)
            {
                MessageBox.Show("WRITER: DB_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch(Exception ex)
            {
                MessageBox.Show("WRITER: SAVE_INTERNAL_ERROR: " + ex.Message + " " + ex.InnerException.Message + " " + ex.InnerException.InnerException.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
