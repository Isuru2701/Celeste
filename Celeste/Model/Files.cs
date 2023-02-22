﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Celeste.Model
{
    //Handles interactions with AppData folder
    public static class FileHandler
    {
        //appdata folder  path
        public static string appFolderPath {get; set;}
        static FileHandler() 
        {
            appFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Celeste/");

        }

        static void VerifyDirectory()
        {
            try { 

                if (!Directory.Exists(appFolderPath))
                {
                    Directory.CreateDirectory(appFolderPath);
                }
            }
            catch(UnauthorizedAccessException ex)
            {
                MessageBox.Show("FILE: ACCESS_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("FILE: INTERNAL_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public static void Write(string content, string filename)
        {
            try
            {
                VerifyDirectory();
                using (StreamWriter writer = new StreamWriter(appFolderPath + filename))
                {
                    writer.Write(content);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("FILE: ACCESS_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (Exception ex)
            {
                Console.WriteLine("FILE: WRITE_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //reads text files
        public static string ReadText(string filename)
        {
            try
            {
                VerifyDirectory();

                return File.ReadAllText(appFolderPath + filename);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("FILE: ACCESS_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine("FILE: READ_ERORR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

        }

        public static byte[] ReadBytes(string filename)
        {
            VerifyDirectory();
            try
            {

                   return File.ReadAllBytes(appFolderPath + filename);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("FILE: ACCESS_ERROR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine("FILE: READ_ERORR: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }

        }


        public static bool ResourceExists(string filename)
        {
           return File.Exists(appFolderPath + filename);
        }
    }
}

