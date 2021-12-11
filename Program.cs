using System;
using System.Collections.Generic;
using System.Text.Json;

namespace hk_programmeerimine_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Excercise 1 =====");
            List<string> list = new List<string>()
            {
                "Item1",
                "Item2",
                "Item3",
                "Item4"
            };

            Console.WriteLine(JsonSerializer.Serialize(list));

            List<string> newList = new List<string>();

            list.ForEach(item => { newList.Insert(0, item); });
            
            Console.WriteLine(JsonSerializer.Serialize(newList));
        }
    }
}
