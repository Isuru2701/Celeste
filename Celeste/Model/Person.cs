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
                entries = connection.FetchCol("Select content from user_entries where enduser_id= '" + user_id + "'");
            }
            catch (Exception)
            {
                throw new Exception("USE_ERROR_USER_CONTROL");
            }
        }

        //TODO
        public void FetchTriggers()
        {
            try
            {
                triggers = connection.FetchCol("Select <> from <> where enduser_id= '" + user_id + "'");
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
                entries = connection.FetchCol("Select <> from <> where enduser_id= '" + user_id + "'");
            }
            catch (Exception)
            {
                throw new Exception("USE_ERROR_USER_CONTROL");
            }

        }
    }
}
