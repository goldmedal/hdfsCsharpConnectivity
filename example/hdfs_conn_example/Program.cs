using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using CPA_Connectivity;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            CPA_Connection conn = new CPA_Connection();  
            string url = "C:/Users/Jax/test.txt";

            bool test = conn.upload(url, "test_dir/test_filename2");
            Console.WriteLine("The upload Result: " + test);

            string result = conn.list_dir("test_dir");
            Console.WriteLine(result);
            Console.WriteLine("Press any key to leave.");
            Console.ReadLine();  //pause
        }


    }
}