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
        /*UC5 Each month would like to know the days won and lost and by howmuch*/
        /*Both UC4 and UC5 are in same method Refactored UC4*/
        public static int AmountForMonthOfPlay()
        {
            int totalDaysAmount = 0;
            int outcome = 0;
            int[,] daysOutCome;
            for (int day = 0; day < numOfDaysInMonth; day++)
            {
                int amountAfterPlay = WinOrLooseFiftyPercent();
                int amountWonOrLoss = amountAfterPlay - 100;
                Console.WriteLine("Amount won or loss for the day: " + day + " " + amountWonOrLoss);
                if (amountWonOrLoss > 0)
                    outcome = 1;
                daysOutCome = new int[,]
                    {
                        { outcome, amountWonOrLoss}
                    };
                totalDaysAmount += amountAfterPlay;
            }
            int amountWonOrLost = totalDaysAmount - (numOfDaysInMonth * STAKE);
            return amountWonOrLost;
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
