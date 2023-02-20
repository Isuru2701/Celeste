using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        private int user_id;
        private string email;
        private DateTime dob;
        private char gender;

        private Image profilepic;

        private Conn connection = new Conn();
        public Person(int user_id)
        {
            this.user_id = user_id;
            FetchInfo();
        }

        public void FetchInfo()
        {
            try
            {
                //there'll only be one row
                List<List<object>> temp = connection.Fetch("Select email, dob, gender from EndUser where enduser_id= '" + user_id + "'");
                email = temp[0].ToString();
                dob = Convert.ToDateTime(temp[1]);
                gender = Convert.ToChar(temp[2]);
                

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
            catch (Exception)
            {
                throw new Exception("USE_ERROR_USER_CONTROL");
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
            catch (Exception)
            {
                throw new Exception("USE_ERROR_USER_CONTROL");
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
            catch (Exception)
            {
                throw new Exception("USE_ERROR_USER_CONTROL");
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

            catch (Exception)
            {
                throw new Exception("USE_ERROR_USER_CONTROL");
            }

        }

    }
}