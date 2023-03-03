using Celeste.Model.Data;
using Microsoft.Win32;
using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;


// CONTAINS THE DATA FOR THE CURRENT USER
// CONNECTS WITH DATABASE TO FETCH DATA
// INITIALIZED WHEN USER SUCCESSFULLY LOGS IN

namespace Celeste.Model
{
    public class Record
    {
        public string Name { get; set;}
        public DateTime Date { get; set;}

    }


    public class Person
    {
        //dynamic data stored on database
        private List<Score> scores = new List<Score> { };

        private List<Record> triggers = new List<Record> { };
        private List<Record> comforts = new List<Record> { };

        //accessors
        public List<Score> Scores => scores;
        public List<Record> Triggers => triggers;
        public List<Record> Comforts => comforts;



        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }

        private BitmapImage profilepic;

        public BitmapImage ProfilePic
        {
            get
            {
                GetPic();
            }
            set
            {

            }

        }

        private Conn connection = new Conn();


        //Uses Singleton design to ensure only one user is acting at a time.
        //To acccess properties/methods, remember to use sessionUser.GetInstance(<user id>).<property>/<method>()

        private static Person instance;

        private Person(int user_id)
        {
            this.user_id = user_id;
            FetchInfo();
        }

        public static Person GetInstance(int id)
        {
            if (instance == null)
            {
                instance = new Person(id);
            }

            return instance;
        }


        public static BitmapImage GetPic()
        {

            try
            {
                OpenFileDialog selector = new OpenFileDialog();
                selector.CheckFileExists = true;
                selector.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*"; ;

                if (selector.ShowDialog() == true)
                {

                    if (File.Exists(selector.FileName))
                    {
                        using (var context = new LunarContext())
                        {

                            byte[] imageData;

                            using (System.IO.FileStream fs = new System.IO.FileStream(selector.FileName, System.IO.FileMode.Open))
                            {
                                imageData = new byte[fs.Length];
                                fs.Read(imageData, 0, (int)fs.Length);
                            }

                            var pic = new ProfilePicture
                            {
                                enduser_id = Flow.User_ID,
                                picture = imageData
                            };

                            //Check if there is any pre-existing profilpicture
                            //if there is, update instead

                            var query = context.ProfilePictures.Where(u => u.enduser_id == Flow.User_ID).FirstOrDefault();

                            if (query.picture != null)
                            {
                                query = pic;

                            }
                            else
                            {
                                context.ProfilePictures.Add(pic);
                            }

                            context.SaveChanges();

                        }
                    }
                }

                return new BitmapImage(new Uri(selector.FileName));

            }

            catch (NotSupportedException)
            {
                MessageBox.Show("Please select an image", "Oops!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            catch (Exception)
            {
                throw new Exception("PERSON: IMAGE_FETCH_ERROR");
            }
        }

        public void FetchInfo()
        {
            try
            {
                using(var context = new LunarContext())
                {
                    var endUser = context.EndUsers
                        .Where(e => e.enduser_id == user_id)
                        .Select(e => new
                        {
                            e.email,
                            e.dob,
                            e.gender,
                            e.username
                        })
                        .FirstOrDefault();

                    username = endUser.username;
                    email = endUser.email;
                    dob = (DateTime)endUser.dob;
                    gender = endUser.gender;

                }


            }
            catch (Exception ex)
            {
                
                throw new Exception("PERSON:INTERNAL_ERROR " + ex.Message);
            }

        }

        /// <summary>
        /// returns number of rows in query result. returns 0 if nothing's there.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public int FetchTriggers()
        {
            try
            {

                using (var context = new LunarContext())
                {
                    var query = from u in context.user_triggers
                                join t in context.triggers
                                on u.trigger_id equals t.trigger_id
                                where u.enduser_id == Flow.User_ID
                                select new { t.trigger_name, u.entry_date };

                    var results = query.ToList();

                    if (results.Count > 0)
                    {
                        triggers.Clear();
  
                        foreach (var result in results)
                            {
                                triggers.Add(new Record { Name = result.trigger_name, Date = result.entry_date });

                            }

                            return results.Count;
                    }
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("PERSON:INTERNAL_ERROR " + ex.Message);
            }
        }


        public int FetchComforts()
        {
            try
            {
                using (var context = new LunarContext())
                {
                    var query = from u in context.user_comforts
                                join t in context.comforts
                                on u.trigger_id equals t.trigger_id
                                where u.enduser_id == Flow.User_ID
                                select new { t.trigger_name, u.entry_date };

                    var results = query.ToList();
                    if (results.Count > 0)
                    {
                        comforts.Clear();
                        foreach (var result in results)
                        {
                            comforts.Add(new Record { Name = result.trigger_name, Date = result.entry_date });
                        }
                        return results.Count;
                    }
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("PERSON:INTERNAL_ERROR " + ex.Message);
            }

        }

        public int FetchScores()
        {
            try
            {
                using (var context = new LunarContext())
                {
                    var query = context.user_score
                                    .Where(s => s.enduser_id == Flow.User_ID)
                                    .Select(s => new { s.entry_date, s.score });

                    var results = query.ToList();
                    if (results.Count > 0)
                    {
                        scores.Clear();
                        foreach (var result in results)
                        {

                            scores.Add(new Score { Value = (double)result.score, Date = result.entry_date });

                        }
                        return results.Count;
                    }
                    return 0;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("PERSON:INTERNAL_ERROR " + ex.Message);
            }

        }

        public void DebugDisplay()
        {
            MessageBox.Show(user_id + " " + email + " " + dob + " " + gender);
        }

    }
}