using Celeste.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Celeste.Model
{
    //GENERIC CONNECTION WITH DATABASE. DOES NOT CARE ABOUT THE DATA, ONLY TRANSPORTATION
    //ALL INTERACTIONS WITH THE DB WILL PASS THRU THIS OBJ

    /*
     * 
     * Methods:
     * 
        - FETCHROW  :   METHOD DEALS WITH FETCHING ONLY ONE ROW, USEFUL FOR DATA WHERE DATA-CLEANING DOESNT NEED TO BE DONE.
                        DATAYPE CONVERSION MUST BE DONE THO.

        - FETCHCOL  :   FETCHES THE SPECIFIED COL DATA. 

        - FETCH     :   METHOD DEALS WITH FETCHING ALL COLUMNS, DATA-CLEANING MUST BE DONE BY REQUESTER.

        - WRITE     :   EXECUTE NON QUERIES ONTO THE DB. RETURNS NUMBER OF ROWS AFFECTED.

        -EntryExists:   VERIFY THAT A QUERY WILL PRODUCE ROWS OR NOT


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
        /// <summary>
        /// Useful when only one row is returned. Converts it to a list. Throws an exception if more than one is returned.
        /// </summary>
        /// <param name="cmdstring"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<object> FetchRow(string cmdstring)
        {
       
            try
            {
                pipeline.Open();
                cmd.Connection= pipeline;
                cmd.CommandText = cmdstring;

                
                SqlDataReader entries = cmd.ExecuteReader();

                //temporary holding bay for reader output
                List<object> temp = new List<object> ();
                while(entries.Read())
                { 
                    for(int i = 0; i < entries.FieldCount; ++i)
                    {
                    temp.Add(entries.GetValue(i));

                    }
                }

                return temp;
                
            }
            catch (SqlException ex)
            {
                throw new Exception("CONN_FAILURE: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("INTERNAL_ERROR: " + ex.Message);
            }

            finally
            {
                pipeline.Close();
            }

        }
        /// <summary>
        /// If a query returned one or more rows, returns true. Otherwise false.
        /// </summary>
        /// <param name="cmdstring"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool EntryExists(string cmdstring)
        {
            try
            {
                pipeline.Open();
                cmd.Connection = pipeline;
                cmd.CommandText = cmdstring;
                SqlDataReader entries = cmd.ExecuteReader();

                return entries.HasRows;
            }
            catch (SqlException ex)
            {
                throw new Exception("CONN_FAILURE: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("INTERNAL_ERROR: " + ex.Message);
            }
            finally
            {
                pipeline.Close();
            }

        }

        /// <summary>
        /// useful when u know only one col will be fetched. Returns a list. Will throw an exception if not a list.
        /// </summary>
        /// <param name="cmdstring"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<object> FetchCol(string cmdstring)
        {
            try
            {
                pipeline.Open();
                cmd.Connection = pipeline;
                cmd.CommandText = cmdstring;
                SqlDataReader entries = cmd.ExecuteReader();
                List<object> temp = new List<object>();
                while (entries.Read())
                {
                    temp.Add(entries.GetValue(0));
                }
                entries.Close();

                return temp;
            }
            catch (SqlException ex)
            {
                throw new Exception("CONN_FAILURE: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("INTERNAL_ERROR: " + ex.Message);
            }
            finally
            {
                
                pipeline.Close();
            }

        }

        /// <summary>
        /// Fetches a data frame arranged as a list of lists, each an object
        /// </summary>
        /// <param name="cmdstring"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<List<object>> Fetch(string cmdstring)
         {
            try
            {
                pipeline.Open();
                cmd.Connection = pipeline;
                cmd.CommandText = cmdstring;
                SqlDataReader entries = cmd.ExecuteReader();

                //temporary holding bay for reader output
                List<List<object>> temp = new List<List<object>> ();

                //slice off a row n-times
                while (entries.Read())
                {
                    List<object> row = new List<object> ();
                    for(int i = 0; i < entries.FieldCount; ++i)
                    {
                        row.Add(entries.GetValue(i));
                    }
                    temp.Add(row);
                }

                return temp;

            }
            catch (SqlException ex)
            {
                throw new Exception("CONN_FAILURE: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("INTERNAL_ERROR: " + ex.Message);
            }

            finally
            {
                pipeline.Close();
            }


        }
        
        /// <summary>
        /// Does what it says lol. Writes into a table. Returns number of rows affected.
        /// </summary>
        /// <param name="cmdstring"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int Write(string cmdstring)
        {
            try
            {
                pipeline.Open();
                cmd.Connection = pipeline;
                cmd.CommandText = cmdstring;
                int i = cmd.ExecuteNonQuery();
                return i;
            }
            catch (SqlException ex)
            {
                throw new Exception("CON:CONN_FAILURE: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("CONN:INTERNAL_ERROR: " + ex.Message);
            }


            finally
            {
                pipeline.Close();
            }

        }


    }
}
