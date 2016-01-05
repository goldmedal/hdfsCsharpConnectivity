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
             *   
             */

            bool test = conn.upload(inputDataPath, "test_filename2");  // step 1
            Console.WriteLine("The upload Result: " + test);
            Console.WriteLine("Press any key to leave.");
            Console.ReadLine();  //pause

            #endregion

            #region Remove File and Check

            /*   
             *  Steps of Remove File and Check
             *   1. use remove_dir method to remove all file in test dir.
             *   
             */

            string del_reult = conn.remove_dir();  // step 1
            Console.WriteLine("The delete Result: " + del_reult);
            Console.ReadLine();  //pause
            #endregion

        }


    }
}
