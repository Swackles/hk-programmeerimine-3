using System;
using System.Text.RegularExpressions;

namespace _4_excercise
{
    class Program
    {
        private static Drink _SelectedDrink;
        private static bool? _AddSugar;
        private static bool? _AddCup;
        private static bool? _AddMixingStick;

        static void Main(string[] args)
        {
            Drink.LoadFromJson();

            while(_SelectedDrink == null)
            {
                DrinkSelectionOrCoinEnterInterface();
            }

            Money.CoinsToBeReturned(_SelectedDrink.Price);

            while(_AddSugar == null)
            {
                AskForBooleanResponse("Do you wish to add sugar? (yes, no)", out _AddSugar);
            }

            while (_AddCup == null)
            {
                AskForBooleanResponse("Do you wish to add a cup? (yes, no)", out _AddCup);
            }

            while (_AddMixingStick == null)
            {
                AskForBooleanResponse("Do you wish to add mixing stick? (yes, no)", out _AddMixingStick);
            }

            _SelectedDrink.Make((bool)_AddSugar, (bool)_AddCup, (bool)_AddMixingStick);
            Console.Clear();

            Console.WriteLine("Your drink is ready, enjoy.");
            Console.ReadKey();
        }

        static void DrinkSelectionOrCoinEnterInterface()
        {
            Console.Clear();

            Money.PrintCoins();
            Console.WriteLine();
            Drink.PrintDrinks();

            Console.WriteLine("\n Balance: {0}", Money.GetBalance());
            Console.Write("Please select what coins to enter or what drink to select: ");

            var inserted = Console.ReadLine();
            if (inserted.StartsWith("D"))
            {
                var drink = Drink.SelectedDrink(inserted);
                if (drink != null && drink.Price <= Money.GetBalance())
                {
                    _SelectedDrink = drink;
                }
            } else if (Regex.IsMatch(inserted, @"^\d+$"))
            {
                Money.InsertCoin(inserted);
            }
        }

        static void AskForBooleanResponse(string query, out bool? value)
        {
            Console.Clear();
            Console.Write(query);

            var res = Console.ReadLine().ToLower();

            if (res == "yes" || res == "y")
            {
                value = true;
            } else if (res == "no" || res == "n")
            {
                value = false;
            } else
            {
                value = null;
            }

        }
    }
}
