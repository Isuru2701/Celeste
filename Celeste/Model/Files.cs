using System;
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
        static string appFolderPath;
        static FileHandler() 
        {
            appFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Celeste");

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

    }


}
