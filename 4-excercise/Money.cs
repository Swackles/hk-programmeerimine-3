using System;
using System.Linq;

namespace _4_excercise
{
    class Money
    {
        public static int[] INSERTED_COINS = new int[] { 0, 0, 0, 0, 0 };
        static readonly double[] ACCEPTED_COINS = new double[] { 0.1, .2, .5, 1, 2 };

        public static double GetBalance()
        {
            double sum = 0;
            for (var i = 0; i < ACCEPTED_COINS.Length; i++)
            {
                sum += INSERTED_COINS[i] * ACCEPTED_COINS[i];
            }

            return sum;
        }

        public static void PrintCoins()
        {
            Console.WriteLine("These coins can be inserted: \n");

            for (var i = 1; i <= ACCEPTED_COINS.Length; i++)
            {
                var coin = ACCEPTED_COINS[i - 1];
                Console.WriteLine("{0}. {1}", i, coin);
            }
        }

        public static void InsertCoin(string coin)
        {
            int.TryParse(coin, out int selectedCoin);

            if (!(selectedCoin <= 0 || selectedCoin > ACCEPTED_COINS.Length))
            {
                INSERTED_COINS[selectedCoin - 1] += 1;
            }
        }

        public static void CoinsToBeReturned(double drinkCost)
        {
            Console.Clear();
            var returnedCoins = new int[] { 0, 0, 0, 0, 0 };

            var difference = GetBalance() - drinkCost;

            var returnString = "You've been returned: ";

            for (var i = ACCEPTED_COINS.Length - 1; i > -1; i-- )
            {
                var coin = ACCEPTED_COINS[i];

                returnedCoins[i] = (int)Math.Floor(difference / coin);
                if (returnedCoins[i] > 0)
                {
                    returnString += returnedCoins[i] + "x" + coin + ", ";
                    difference -= returnedCoins[i] * coin;
                }
            }

            Console.WriteLine(returnString.Remove(returnString.Length - 2, 2));
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
