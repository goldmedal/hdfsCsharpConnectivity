using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using CPA_Connectivity; // using this dll


namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Initial CPA Connection

            /*
             * First at all
             */

            CPA_Connection conn = new CPA_Connection("localhost", "CPAuser", "14000"); //  initial object
            string inputDataPath = "C:/Users/Jax/test.txt"; // input file path

            #endregion

            #region Upolad File and Check

            /*   
             *  Steps of Upload File and Check 
             *   1. use upload method and asign inputDataURL, outputFileName
             *   2. use list_dir method to check the uploading status.
             *   
             */

            bool test = conn.upload(inputDataPath, "test_filename2");  // step 1
            Console.WriteLine("The upload Result: " + test);
            string result = conn.list_dir(); // step 2
            Console.WriteLine("==============================");
            Console.WriteLine("The List Result:");
            Console.WriteLine(result);
            Console.WriteLine("Press any key to leave.");
            Console.ReadLine();  //pause

            #endregion

            #region Remove File and Check

            /*   
             *  Steps of Remove File and Check
             *   1. use remove_dir method to remove all file in test dir.
             *   2. use list_dir method to check the uploading status.
             *   
             */

            string del_reult = conn.remove_dir();  // step 1
            Console.WriteLine("The delete Result: " + del_reult);
            string result2 = conn.list_dir(); // step 2
            Console.WriteLine("==============================");
            Console.WriteLine("The List Result:");
            Console.WriteLine(result2);
            Console.WriteLine("Press any key to leave.");
            Console.ReadLine();  //pause
            #endregion

        }


    }
}
