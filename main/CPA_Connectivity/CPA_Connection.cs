using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Text;

namespace CPA_Connectivity
{
    public class CPA_Connection
    {

        private string host = "localhost";
        private string user = "hduser";
        private string port = "14000";
        private string url;


        // using default para Constructor 
        public CPA_Connection(){

        }

        // using custom para Constructor
        public CPA_Connection(string _host, string _user, string _port)
        {
            this.host = _host;
            this.user = _user;
            this.port = _port;
        }

        // upload CPA data with PUT http request
        public bool upload(string inputFilePath, string outputFilePath)
        {

            this.url = buildUploadURL(outputFilePath, "upload");
            WebClient client = new WebClient();
            try
            {
                client.UploadFile(url, "PUT", inputFilePath);
                return true;
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                Console.Write("An error occured, status code:" + statusCode);
                return false;
            }
            

        }

        // list contens of the des dir
        public string list_dir(string dirPath)
        {

            string url = buildUploadURL(dirPath, "ls");
            Console.WriteLine(url);
            WebClient client = new WebClient();
            try
            {
                Stream result = client.OpenRead(url);
                StreamReader sr = new StreamReader(result);
                return sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                Console.Write("An error occured, status code:" + statusCode);
                return "false";
            }
            

        }

        // build the request url
        private string buildUploadURL(string outputFilePath, string method)
        {

            string fileURL = "";
            string config = "";
            
            switch (method) 
            { 
                case "upload": 
                    fileURL = "http://" + this.host + ":" + this.port + "/webhdfs/v1/user/" + this.user + "/" + outputFilePath;
                    config = "?user.name=" + this.user + "&op=CREATE&data=true";
                    break;

                case "ls":
                    fileURL = "http://" + this.host + ":" + this.port + "/webhdfs/v1/user/" + this.user + "/" + outputFilePath;
                    config = "?user.name=" + this.user + "&op=LISTSTATUS";
                    break;
            }
            
            return fileURL + config;
        }

    }
}
