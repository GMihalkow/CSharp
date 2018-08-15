using System;
using System.Collections.Generic;
using System.Linq;

namespace Advanced_exam_11_02_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());

            int gunbarrelSize = int.Parse(Console.ReadLine());

            List<int> bullets =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> Locks =
                Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> AllBullets = new Stack<int>(bullets);
            Queue<int> AllLocks = new Queue<int>(Locks);

            int intelligenceValue = int.Parse(Console.ReadLine());

            //If the bullet has a smaller or equal size to the current lock,
            //print “Bang!” remove the lock

            //If not, print “Ping!”, leaving the lock intact. 
            //The bullet is removed in both cases.

            //After Sam receives all of his information and gear (input),
            //he starts to shoot the locks front-to-back,
            //while going through the bullets back-to-front.

            int counter = 0;

            while (AllLocks.Count != 0)
            {
                if (AllBullets.Count == 0 && AllLocks.Count == 0)
                {
                    break;   
                }
                if (AllBullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {AllLocks.Count}");
                    return;
                }
                counter++;
                if (AllBullets.Peek() <= AllLocks.Peek())
                {
                    Console.WriteLine("Bang!");
                    AllBullets.Pop();
                    AllLocks.Dequeue();
                    if ((counter == gunbarrelSize) && AllBullets.Count > 0)
                    {
                        counter = 0;
                        Console.WriteLine("Reloading!");
                        continue;
                    }
                    if (AllBullets.Count == 0 && AllLocks.Count == 0)
                    {
                        break;
                    }
                    if (AllBullets.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {AllLocks.Count}");
                        return;
                    }
                    continue;
                }
                if (AllBullets.Peek() > AllLocks.Peek())
                {
                    AllBullets.Pop();
                    Console.WriteLine("Ping!");
                    if ((counter == gunbarrelSize) && AllBullets.Count > 0)
                    {
                        counter = 0;
                        Console.WriteLine("Reloading!");
                        continue;
                    }
                    if (AllBullets.Count == 0 && AllLocks.Count == 0)
                    {
                        break;
                    }
                    if (AllBullets.Count == 0)
                    {
                        Console.WriteLine($"Couldn't get through. Locks left: {AllLocks.Count}");
                        return;
                    }
                    continue;
                }
            }
            int FinalBulletCost = (bullets.Count - AllBullets.Count) * bulletPrice;
            int TotalPrice = intelligenceValue - FinalBulletCost;
            Console.WriteLine($"{AllBullets.Count} bullets left. Earned ${TotalPrice}");
        }
    }
}
