using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace _3_excercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Excercise 3 =====");
            List<string> items = new List<string>();

            while(items.Count == 0 || items.Count > 0 && items[items.Count - 1] != "")
            {
                items.Add(Console.ReadLine());
            }

            Console.WriteLine(JsonSerializer.Serialize(items.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)));
        }
    }
}
