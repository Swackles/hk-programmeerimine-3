using System;
using System.Collections.Generic;

namespace _2_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Excercise 2 =====");
            new List<List<int>>
            {
                new List<int> { 01, 02, 03, 04, 05 },
                new List<int> { 11, 12, 13, 14, 15 },
                new List<int> { 21, 22, 23, 24, 25 },
                new List<int> { 31, 32, 33, 34, 35 },
                new List<int> { 41, 42, 43, 44, 45 },
            }.ForEach(x => x.ForEach(Console.WriteLine));
        }
    }
}
