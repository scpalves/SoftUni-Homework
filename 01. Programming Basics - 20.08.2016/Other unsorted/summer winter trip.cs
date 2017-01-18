﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication42
{
    class Program
    {
        static void Main(string[] args)
        {
            var budget = decimal.Parse(Console.ReadLine());
            var season = Console.ReadLine();
            season = season.ToLower();

            if (budget <= 100)
            {
                if (season == "summer")
                {
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Camp - {0:f2}", budget * 0.3m);
                }
                else if (season == "winter")
                {
                    Console.WriteLine("Somewhere in Bulgaria");
                    Console.WriteLine("Hotel - {0:f2}", budget * 0.7m);
                }
            }
            else if (budget > 100)
            {
                if (season == "summer")
                {
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Camp - {0:f2}", budget * 0.4m);
                }
                else if (season == "winter")
                {
                    Console.WriteLine("Somewhere in Balkans");
                    Console.WriteLine("Hotel - {0:f2}", budget * 0.8m);
                }
            }
            else if (budget >= 1000)
            {
                if (season == "summer")
                {
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine("Camp - {0:f2}", budget * 0.9m);
                }
                else if (season == "winter")
                {
                    Console.WriteLine("Somewhere in Europe");
                    Console.WriteLine("Hotel - {0:f2}", budget * 0.9m);
                }
            }
        }
    }
}
