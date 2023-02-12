using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Model
{
  
    //ALL INTERACTIONS WITH THE DB WILL PASS THRU THIS OBJ

    public class Conn
    {
        SqlConnection pipeline;
        SqlCommand cmd;
        

        public Conn()
        {
            pipeline = new SqlConnection("Data Source=ISURU;Initial Catalog=Lunar;Integrated Security=True");
            cmd = new SqlCommand();
        }

        public List<string> Fetch(string cmdstring)
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

        public void GetInsights()
        {
            pipeline.Open();

            pipeline.Close();
        }

    }
}
