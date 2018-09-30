using System;
using System.Net;
using System.Text;

namespace HTTP_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = Console.ReadLine();

            string result = WebUtility.UrlDecode(url);
            Console.WriteLine(result);
        }
    }
}
