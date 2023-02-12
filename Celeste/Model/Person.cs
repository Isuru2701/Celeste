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

        int user_id;

        Conn connection = new Conn();
        public Person()
        {
            
        }

        public void FetchEntries()
        {
            entries = connection.Fetch("Select content from user_entries where enduser_id= '" + user_id + "'");
        }

        //TODO
        public void FetchTriggers()
        {
            triggers = connection.Fetch("Select content from user_entries where enduser_id= '" + user_id + "'");
        }


        public void FetchComforts()
        {
            entries = connection.Fetch("Select content from user_entries where enduser_id= '" + user_id + "'");
        }
    }
}
