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

        public void GetEntries(string user_id)
        {
            try
            {
                pipeline.Open();
                cmd.CommandText ="Select content from user_entries where enduser_id= '" + user_id + "'";
                cmd.ExecuteReader();

                pipeline.Close();
                
            }catch(Exception)
            {
                throw new Exception("CONN_FAIURE");
            }

        }

        public void GetInsights()
        {
            pipeline.Open();

            pipeline.Close();
        }

    }
}
