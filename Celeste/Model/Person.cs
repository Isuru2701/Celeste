using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// CONTAINS THE DATA FOR THE CURRENT USER
// CONNECTS WITH DATABASE TO FETCH DATA
// INITIALIZED WHEN USER SUCCESSFULLY LOGS IN
namespace Celeste.Model
{
    public  class Person
    {
        //dynamic data stored on database
        List<string> entries = new List<string> { };
        List<string> triggers = new List<string> { };
        List<string> comforts = new List<string> { };

        List<Score> scores = new List<Score> { }; 

        int user_id;


        Conn connection = new Conn();
        public Person()
        {
            
        }



        public void FetchEntries()
        {
            try
            {
                entries = connection.FetchCol("Select content from user_entries where enduser_id= '" + user_id + "'")
                    .Select(x => x.ToString()).ToList();
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
                List<List<object>> temp = connection.Fetch("Select entry_date, score from user_score where enduser_id= '" + user_id + "' order by entry_date asc" );

                foreach(List<object> row in temp)
                {
                    scores.Add(new Score(Convert.ToDateTime(row[0]), Convert.ToDouble(row[1])));
                }

            }
            catch(FormatException)
            {
                throw new Exception("INVALID_DATA_TYPE_CONVERSION_ERROR");
            }

            catch (Exception)
            {
                throw new Exception("USE_ERROR_USER_CONTROL");
            }


        }
    }
}
