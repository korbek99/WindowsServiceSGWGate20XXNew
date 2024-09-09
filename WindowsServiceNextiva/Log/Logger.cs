using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System;
using System.IO;

namespace WindowsServiceNextiva.Log
{
    public class Logger
    {
        public void LoggerWritter(String lines)
        {

            DateTime moment;
            moment = DateTime.Now;
            // Year gets 1999.
            int year = moment.Year;

            // Month gets 1 (January).
            int month = moment.Month;

            // Day gets 13.
            int day = moment.Day;

            // Hour gets 3.
            int hour = moment.Hour;

            // Minute gets 57.
            int minute = moment.Minute;

            // Second gets 32.
            int second = moment.Second;

            // Millisecond gets 11.
            int millisecond = moment.Millisecond;

            string DateTemp = Convert.ToString(moment.Year + "-" + moment.Month + "-" + moment.Day + "  " + moment.Hour + ":" + moment.Minute + ":" + moment.Second);


            createFile();
            // Write the string to a file.append mode is enabled so that the log
            // lines get appended to  test.txt than wiping content and writing the log

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Loggs\LogSystemService.txt", true);
            file.WriteLine(DateTemp + " - " + lines);

            file.Close();

        }
        public void createFile()
        {
            try
            {

                string path = @"C:\Loggs";

                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    // return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

                //// Delete the directory.
                //di.Delete();
                //Console.WriteLine("The directory was deleted successfully.");


                string pathString = @"C:\Loggs";

                System.IO.Directory.CreateDirectory(pathString);

                // Create a file name for the file you want to create. 
                string fileName = "LogSystemService.txt"; //System.IO.Path.GetRandomFileName();

                // This example uses a random string for the name, but you also can specify
                // a particular name.
                //string fileName = "MyNewFile.txt";

                // Use Combine again to add the file name to the path.
                pathString = System.IO.Path.Combine(pathString, fileName);

                // Verify the path that you have constructed.
                Console.WriteLine("Path to my file: {0}\n", pathString);

                // Check that the file doesn't already exist. If it doesn't exist, create
                // the file and write integers 0 - 99 to it.
                // DANGER: System.IO.File.Create will overwrite the file if it already exists.
                // This could happen even with random file names, although it is unlikely.
                if (!System.IO.File.Exists(pathString))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File \"{0}\" already exists File Log.", fileName);
                    return;
                }

            }
            catch (Exception Ex)
            {


            }

        }
    }
}
