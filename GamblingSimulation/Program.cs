using System;

namespace GamblingSimulation
{
    class Program
    {
        /*UC1 Setting Stake as 100 and Bet as 1*/
        public const int STAKE = 100;
        public const int BET = 1;
        public const float STAKE_VALUE = 0.5f;
        public static int numOfDaysInMonth = 20;
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
            loosingAmount = (int)Math.Round(STAKE * STAKE_VALUE);
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
        /*UC4 Find Amount after 20 days of play.*/
        public static int AmountForMonthOfPlay()
        {
            int totalDaysAmount = 0;
            int outcome = 0;
            int[,] daysOutCome = new int[20,2];
            for (int day = 0; day < numOfDaysInMonth; day++)
            {
                int amountAfterPlay = WinOrLooseFiftyPercent();
                totalDaysAmount += amountAfterPlay;
            }
            return totalDaysAmount;
        }
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Gambling Simulation Problem.");
            int amountWonOrLoss = AmountForMonthOfPlay();
            Console.WriteLine("Amount won or los for a month = " + amountWonOrLoss);
        }
    }
}
