using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Request_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> paths = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                paths.Add(input);
            }

            string request = Console.ReadLine();
            string[] requestChunks = request
                .Split(new string[] { "/t", " " }, StringSplitOptions.RemoveEmptyEntries);

            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            string method = requestChunks[0].ToLower();
            string path = requestChunks[1];
            string protocol = requestChunks[2];

            if (paths.Any(p => p.Contains(path) && p.Split("/")[2].ToLower() == method) == false)
            {
                statusCode = "404 Not Found";
                statusMessage = statusCode.Substring(4, statusCode.Length - 4);
                Console.WriteLine(statusCode);
            }
            else
            {
                statusCode = "200 OK";
                statusMessage = statusCode.Substring(4, statusCode.Length - 4); Console.WriteLine(statusCode);
            }

            Console.WriteLine($"HTTP/1.1 {statusCode}");
            Console.WriteLine($"Content-Length: {statusMessage.Length}");
            Console.WriteLine("Content-Type: text/plain");
            Console.WriteLine();
            Console.WriteLine(statusMessage);
        }
    }
}
