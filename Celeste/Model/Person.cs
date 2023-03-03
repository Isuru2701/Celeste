using Celeste.Model.Data;
using Microsoft.Win32;
using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Windows.Media.Devices.Core;
using Windows.System;


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

        public BitmapImage ProfilePic { get; set; }


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


        public BitmapImage GetPic()
        {
            byte[] imagedata;

            using (var context = new LunarContext())
            {
                var query = context.ProfilePictures.Find(user_id);

                if (query != null)
                {
                    imagedata = query.picture;
                    BitmapImage picture = new BitmapImage();

                    using (var stream = new MemoryStream(imagedata))
                    {
                        picture.BeginInit();
                        picture.CacheOption = BitmapCacheOption.OnLoad;
                        picture.StreamSource = stream;
                        picture.EndInit();
                    }

                    ProfilePic = picture;
                    return ProfilePic;
                }
            }
            return null;
        }

        /// <summary>
        /// use getPic() OR ProfilePicture one line under to get the pic and set it;
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public void SetPic()
        {

            //select file -> convert to binary -> store binary in db
            try
            {
                OpenFileDialog selector = new OpenFileDialog();
                selector.CheckFileExists = true;
                selector.Filter = "Image Files (*.png, *.jpg, *.jpeg)|*.png;*.jpg;*.jpeg";

                if (selector.ShowDialog() == true)
                {
                    using (var context = new LunarContext())
                    {
                        byte[] data;

                        using(FileStream fs = new FileStream(selector.FileName, FileMode.Open))
                        {
                            data = new byte[fs.Length];
                            fs.Read(data, 0, (int)fs.Length);
                        }

                        var existingImage = context.ProfilePictures.Find(user_id);
                        if (existingImage != null)
                        {
                            existingImage.picture = data;
                        }
                        else
                        {
                            var image = new ProfilePicture
                            {
                                enduser_id = user_id,
                                picture = data
                            };
                            context.ProfilePictures.Add(image);
                        }

                        context.SaveChanges();
                    }

                    ProfilePic = new BitmapImage(new Uri(selector.FileName));

                }
            }
            catch (EntityException ex)
            {
                throw new Exception("PERSON: NO_CONN_ERROR " + ex.InnerException.Message);
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