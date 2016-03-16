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
        private string home = "testFile";
        private WebClient client = new WebClient();

        // using default para Constructor 
        public CPA_Connection(){

        }

        // using custom para Constructor
        public CPA_Connection(string _host, string _user, string _port="14000")
        {
            this.host = _host;
            this.user = _user;
            this.port = _port;
        }

        // upload CPA data with PUT http request
        public bool upload(string inputFilePath, string outputFilePath)
        {

            this.url = buildUploadURL(outputFilePath, "upload");
            WebClient client = this.client;
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

        public string append(string inputFilePath, string outputFilePath)
        {
            this.url = buildUploadURL(outputFilePath, "append");
            var request = (HttpWebRequest)FileWebRequest.Create(this.url);

            request.Method = "POST";
            request.ContentType = "application/octet-stream";
            request.SendChunked = true;
            Stream web = request.GetRequestStream();

            try{

                Stream input = File.OpenRead(inputFilePath);
                input.CopyTo(web);
                web.Close();
                input.Close();

            }catch(IOException ex)
            {
                Console.Write("An error occured, " + ex.ToString());
            }

            var response = (HttpWebResponse)request.GetResponse();
            return response.ToString();

        }
        
        // remove all file in the test dir.
        public string remove_dir()
        {

            string url = buildUploadURL(this.home, "rm");
            Console.WriteLine(url);
            WebClient client = this.client;
            try
            {
                client.UploadString(url, "DELETE", "");
                return "true";
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                return "false";
            }

        }


        // list contens of the des dir
        /*
         * HttpFS can't load too manys data info.
         * 
         */
 
      /*  public string list_dir()
        {

            string url = buildUploadURL(this.home, "ls");
            WebClient client = this.client;
            try
            {
                Stream result = client.OpenRead(url);
                StreamReader sr = new StreamReader(result);
                return sr.ReadToEnd();
            }
            catch (WebException ex)
            {
                var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
                return "false";
            }
            

        } */

        // build the request url
        private string buildUploadURL(string outputFilePath, string method)
        {

            string fileURL = "";
            string config = "";
            
            switch (method) 
            { 
                case "upload":  // upload file method
                    fileURL = "http://" + this.host + ":" + this.port + "/webhdfs/v1/user/" + this.user + "/" + this.home + "/" + outputFilePath;
                    config = "?user.name=" + this.user + "&op=CREATE&data=true";
                    break;

                case "ls": // list dir method
                    fileURL = "http://" + this.host + ":" + this.port + "/webhdfs/v1/user/" + this.user + "/" + this.home;
                    config = "?user.name=" + this.user + "&op=LISTSTATUS";
                    break;

                case "rm": // delete method
                    fileURL = "http://" + this.host + ":" + this.port + "/webhdfs/v1/user/" + this.user + "/" + this.home + "/";
                    config = "?user.name=" + this.user + "&op=DELETE&recursive=true";
                    break;

                case "append" : //append method
                    fileURL = "http://" + this.host + ":" + this.port + "/webhdfs/v1/user/" + this.user + "/" + this.home + "/" + outputFilePath;
                    config = "?user.name=" + this.user + "&op=APPEND&data=true";
                    break;

                case "filestatus":
                    fileURL = "http://" + this.host + ":" + this.port + "/webhdfs/v1/user/" + this.user + "/" + this.home + "/";
                    config = "?user.name=" + this.user + "&op=GETFILESTATUS";
                    break;

                default:
                    break;

            }
            
            return fileURL + config;
        }

    }
}
