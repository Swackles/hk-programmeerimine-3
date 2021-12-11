using System.IO;
using Newtonsoft.Json;
using System;

namespace _4_excercise
{
    class Drink
    {
        private static Drink[] _Drinks;

        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("price")] public float Price { get; set; }
        [JsonProperty("components")] public string[] Components { get; set; }

        static public void LoadFromJson()
        {
            using (StreamReader r = new StreamReader("drinks.json"))
            {
                string json = r.ReadToEnd();
                _Drinks = JsonConvert.DeserializeObject<Drink[]>(json);
            }
        }

        public static void PrintDrinks()
        {
            Console.WriteLine("Available drinks: \n");

            for (var i = 1; i <= _Drinks.Length; i++)
            {
                var drink = _Drinks[i - 1];
                Console.WriteLine("D{0}. {1} - {2}", i, drink.Name, drink.Price);
            }
        }

        public static Drink SelectedDrink(string drinkCode)
        {
            int.TryParse(drinkCode.Remove(0, 1), out int selectedDrink);

            if (selectedDrink <= 0 || selectedDrink > _Drinks.Length)
            {
                return null;
            }
            else
            {
                return _Drinks[selectedDrink - 1];
            }
        }

        public void Make(bool sugar, bool cup, bool mixingStick)
        {
            Console.Clear();
            if (cup) { PrintDispense("a cup"); }
            foreach (var item in Components)
            {
                PrintDispense(item.ToLower());
            }
            if (sugar) { PrintDispense("sugar"); }
            if (mixingStick) { PrintDispense("a mixingStick"); }
        }

        private void PrintDispense(string item)
        {
            Console.WriteLine("Dispensing {0}", item);

            System.Threading.Thread.Sleep(new Random().Next(3, 10) * 1000);
        }
    }
}
