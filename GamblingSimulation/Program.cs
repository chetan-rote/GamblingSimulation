using System;

namespace GamblingSimulation
{
    class Program
    {
        /*UC1 Setting Stake as 100 and Bet as 1*/
        public const int STAKE = 100;
        public const int BET = 1;
        public const float STAKE_VALUE = 0.5f;
        /*UC2 Win or Loose*/
        public static int WinOrLoose()
        {
            int result = new Random().Next(0, 2);
            return result;
        }
        /*UC3 Gambler plays till win or loose fifty percent.*/
        public static int WinOrLooseFiftyPercent()
        {
            int winningAmount, loosingAmount, stake;
            loosingAmount = (int) Math.Round(STAKE * STAKE_VALUE);
            winningAmount = (int)Math.Round(STAKE + (STAKE * STAKE_VALUE));
            bool play = true;
            stake = STAKE;
            while (play == true)
            {
                int betOutcome = WinOrLoose();
                if (betOutcome == 1)
                {
                    stake += BET;
                }
                else
                {
                    stake -= BET;
                }
                if ((stake == loosingAmount) || (stake == winningAmount))
                    play = false;
            }
            return stake;
        }
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gambling Simulation Problem.");
            WinOrLooseFiftyPercent();            
        }
    }
}
