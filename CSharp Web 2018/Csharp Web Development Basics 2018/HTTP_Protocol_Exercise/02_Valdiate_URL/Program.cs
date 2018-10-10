using System;
using System.Linq;
using System.Net;
using System.Web;

namespace _02_Valdiate_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();
            Uri myUri = null;

            try
            {
                 myUri = new Uri(url);
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }

            string protocol = url
                .Split(new string[] { "://" }, StringSplitOptions.None)[0];

            string host = myUri.Host;
            string path = myUri.AbsolutePath;
            int port = myUri.Port;
            string queryString = myUri.Query;
            string fragment = myUri.Fragment;

            Console.WriteLine("Protocol: " + protocol);
            Console.WriteLine("Host: " + host);
            Console.WriteLine("Path: " + path);
            Console.WriteLine("Port: " + port);
            if (queryString != string.Empty)
                Console.WriteLine("Query: " + queryString.Substring(1, queryString.Length - 1));

            if (fragment != string.Empty)
                Console.WriteLine("Fragment: " + fragment.Substring(1, fragment.Length - 1));


        }
    }
}
