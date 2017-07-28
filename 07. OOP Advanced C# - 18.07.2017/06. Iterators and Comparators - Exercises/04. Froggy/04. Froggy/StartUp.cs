﻿using System;
using System.Linq;

namespace _04.Froggy
{
    public class StartUp
    {
        public static void Main()
        {
            var inputStones = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake myLake = new Lake(inputStones);
            Console.WriteLine(string.Join(", ", myLake));
        }
    }
}
