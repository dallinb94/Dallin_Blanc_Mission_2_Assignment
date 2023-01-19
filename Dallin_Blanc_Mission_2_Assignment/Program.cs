// Author: Dallin Blanc

using System;

namespace Dallin_Blanc_Mission_2_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] TWO_DIE_TOTALS = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }; // i'm using this array to compare which totals match these values and to print out the final result
            float[] trackTotals = new float[11]; // this array is going to hold the count of how many times a die roll adds up to a value in TWO_DIE_TOTALS[]
            string[] histogram = new string[11]; // this is the string array that will eventually print the totals, one "*" meaning 1% of the total rolls
            int numAsterisks = 0;
            string input = "";
            int numRolls = 0;

            Console.WriteLine("Welcome to the dice throwing simulator!\n");
            Console.Write("How many dice rolls would you like to simulate? ");
            input = Console.ReadLine();
            numRolls = Convert.ToInt32(input);

            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine("Total number of rolls = " + numRolls + "\n");

            // this loop goes and rolls two dice for "numRolls" times and adds the total
            for (int i = 0; i < numRolls; i++)
            {
                int die1 = r.Next(6) + 1;
                int die2 = r.Next(6) + 1;
                int total = die1 + die2;

                // this loop compares and adds up the amount of times each die roll totals 
                for (int j = 0; j < 11; j++)
                {
                    if (total == TWO_DIE_TOTALS[j])
                    {
                        trackTotals[j] = trackTotals[j] + 1;
                    }
                }
            }

            // this loop calculated the number of asterisks to print in the histogram by using the tracked totals array, finding it's proportion to the number of rolls, and then multiplying it by 100 and converting it to a whole number
            for (int i = 0; i < 11; i++)
            {
                numAsterisks = Convert.ToInt32((trackTotals[i] / numRolls) * 100);

                // adding one "*" for every percentage from numAsterisks
                for (int j = 0; j < numAsterisks; j++)
                {
                    histogram[i] = histogram[i] + "*";
                }

                Console.WriteLine(TWO_DIE_TOTALS[i] + ":\t" + histogram[i]);
            }
            Console.WriteLine("\nThank you for using the dice throwing simulator.  Goodbye!");
        }
    }
}
