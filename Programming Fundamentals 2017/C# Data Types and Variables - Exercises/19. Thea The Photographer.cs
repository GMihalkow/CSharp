using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            int PicturesCount = int.Parse(Console.ReadLine());
            int FilterTime = int.Parse(Console.ReadLine());
            int FilteredPictures = int.Parse(Console.ReadLine());
            int UploadTime = int.Parse(Console.ReadLine());

            double ApprovedPictures = PicturesCount * (FilteredPictures / 100.0);

            double CeilThePics = Math.Ceiling(ApprovedPictures);
            BigInteger first = (PicturesCount * (long)FilterTime);
            BigInteger second = ((BigInteger)CeilThePics * (long)UploadTime);
            
            BigInteger TotalTime = ((first) + (second));

            TimeSpan FormatConvertion = TimeSpan.FromSeconds((double)TotalTime);
            string PrintOutput = string.Format($"{(int)FormatConvertion.Days}:{(int)FormatConvertion.Hours:d2}:{(int)FormatConvertion.Minutes:d2}:{(int)FormatConvertion.Seconds:d2}");
            Console.WriteLine(PrintOutput);
            
        }
    }
}
