﻿using System;

namespace _01.Card_Suit
{
    public class StartUp
    {
        public static void Main()
        {
            Array suits = Enum.GetValues(typeof(CardSuits));

            Console.WriteLine("Card Suits:");

            foreach (var cardSuit in suits)
            {
                Console.WriteLine($"Ordinal value: {(int)cardSuit}; Name value: {cardSuit}");
            }
        }
    }
}
