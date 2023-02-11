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
        static SqlConnection con;
        static SqlCommand com;

        int id;
        public Person()
        {
            
        }
    }
}
