using System;

namespace GamblingSimulation
{
    class Program
    {
        /*UC1 Setting Stake as 100 and Bet as 1*/
        public const int STAKE = 100;
        public const int BET = 1;
        /*UC2 Win or Loose*/
        public static int WinOrLoose()
        {
            int result = new Random().Next(0, 2);
            return result;
        }
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gambling Simulation Problem.");
            WinOrLoose();
        }
    }
}
