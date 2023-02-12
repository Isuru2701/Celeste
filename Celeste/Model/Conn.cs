using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
    //GENERIC CONNECTION WITH DATABASE. DOES NOT CARE ABOUT THE DATA, ONLY TRANSPORTATION
    //ALL INTERACTIONS WITH THE DB WILL PASS THRU THIS OBJ

    /*
     * 
     * Methods:
     * 
        - FETCHCOL METHOD DEALS WITH FETCHING ONLY ONE COLUMN, USEFUL FOR DATA WHERE DATA-CLEANING DOESNT NEED TO BE DONE
        - FETCH METHOD DEALS WITH FETCHING ALL COLUMNS, DATA-CLEANING MUST BE DONE BY REQUESTER

    */


    public class Conn
    {
        SqlConnection pipeline;
        SqlCommand cmd;
        

        public Conn()
        {
            pipeline = new SqlConnection("Data Source=ISURU;Initial Catalog=Lunar;Integrated Security=True");
            cmd = new SqlCommand();
        }

        public List<string> FetchCol(string cmdstring)
        {
            try
            {
                pipeline.Open();
                cmd.CommandText = cmdstring;
                SqlDataReader entries = cmd.ExecuteReader();

                //temporary holding bay for reader output
                List<string> temp = new List<string> { };

                while(entries.Read()) 
                {
                    temp.Add(entries.GetString(0));
                }
                pipeline.Close();

                return temp;
                
            }catch(Exception)
            {
                throw new Exception("CONN_FALIURE");
            }

        }

        public List<List<object>> Fetch(string cmdstring)
        {
            try
            {
                pipeline.Open();
                cmd.CommandText = cmdstring;
                SqlDataReader entries = cmd.ExecuteReader();

                //temporary holding bay for reader output
                List<List<object>> temp = new List<List<object>> { };

                while (entries.Read())
                {
                    List<object> row = new List<object> { };
                    for(int i = 0; i < entries.FieldCount; ++i)
                    {
                        row.Add(entries.GetValue(i));
                    }
                    temp.Add(row);
                }
                pipeline.Close();

                return temp;

            }
            catch (Exception)
            {
                throw new Exception("CONN_FALIURE");
            }

        }


    }
}
