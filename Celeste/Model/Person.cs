using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


// CONTAINS THE DATA FOR THE CURRENT USER
// CONNECTS WITH DATABASE TO FETCH DATA
// INITIALIZED WHEN USER SUCCESSFULLY LOGS IN

namespace Celeste.Model
{
    public class Person
    {
        //dynamic data stored on database
        private List<Entry> entries = new List<Entry> { };
        private List<string> triggers = new List<string> { };
        private List<string> comforts = new List<string> { };

        private List<Score> scores = new List<Score> { };

        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public char gender { get; set; }

        private Image profilepic;

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

        public void FetchInfo()
        {
            try
            {
                //there'll only be one row
                List<List<object>> temp = connection.Fetch("Select email, dob, gender, username from EndUser where enduser_id= '" + user_id + "'");
                email = temp[0][0].ToString();
                dob = Convert.ToDateTime(temp[0][1]);
                gender = Convert.ToChar(temp[0][2]);
                username = temp[0][3].ToString();


            }
            catch (Exception)
            {
                
                throw new Exception("USE_ERROR_USER_CONTROL");
            }

        }



        public void FetchEntries()
        {

            try
            {
                List<List<object>> temp = connection.Fetch("Select entry_date, content from user_entries where enduser_id= '" + user_id + "'order by entry_date asc");

                foreach(List<object> row in temp)
                {
                    entries.Add(new Entry(Convert.ToDateTime(row[0]), Convert.ToString(row[1])));
                }


            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }

        //TODO: ADD TABLE AND COL NAMES
        public void FetchTriggers()
        {
            try
            {
                //purges past data, if any
                triggers.Clear();

                triggers = connection.FetchCol("Select <> from <> where enduser_id= '" + user_id + "'")
                    .Select(x => x.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }
        }


        public void FetchComforts()
        {
            try
            {
                //purges past data, if any
                comforts.Clear();

                comforts = connection.FetchCol("Select <> from <> where enduser_id= '" + user_id + "'")
                    .Select(x => x.ToString()).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }

        }

        public void FetchScores()
        {
            try
            {
                //purges past data, if any
                scores.Clear();

                List<List<object>> temp = connection.Fetch("Select entry_date, score from user_score where enduser_id= '" + user_id + "' order by entry_date asc");

                foreach (List<object> row in temp)
                {
                    scores.Add(new Score(Convert.ToDateTime(row[0]), Convert.ToDouble(row[1])));
                }

            }
            catch (FormatException)
            {
                throw new FormatException("INVALID_DATA_TYPE_CONVERSION_ERROR");
            }

            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message);
            }

        }

        public void DebugDisplay()
        {
            MessageBox.Show(user_id + " " + email + " " + dob + " " + gender);
        }

    }
}