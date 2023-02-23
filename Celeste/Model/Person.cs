﻿using Celeste.Model.Data;
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
        private List<string> triggers = new List<string> { };
        private List<string> comforts = new List<string> { };

        private List<Score> scores = new List<Score> { };

        public int user_id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public DateTime dob { get; set; }
        public string gender { get; set; }

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
                using(var context = new LunarContext())
                {
                    var endUser = context.EndUsers
                        .Where(e => e.enduser_id == user_id)
                        .Select(e => new
                        {
                            e.email,
                            e.dob,
                            e.gender,
                            e.username
                        })
                        .FirstOrDefault();

                    username = endUser.username;
                    email = endUser.email;
                    dob = (DateTime)endUser.dob;
                    gender = endUser.gender;

                }


            }
            catch (Exception ex)
            {
                
                throw new Exception("PERSON:INTERNAL_ERROR " + ex.Message);
            }

        }


        public void FetchTriggers()
        {
            try
            {
                //purges past data, if any
                triggers.Clear();
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