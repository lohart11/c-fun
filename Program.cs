using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.Write("How many dice rolls would you like to simulate? ");
        int numberOfThrows = Convert.ToInt32(Console.ReadLine());

        DiceSimulator diceSimulator = new DiceSimulator();
        int[] results = diceSimulator.SimulateDiceRolls(numberOfThrows);

        PrintResults(results, numberOfThrows);

        Console.WriteLine("Thank you for using the dice throwing simulator. Goodbye!");
    }

    static void PrintResults(int[] results, int numberOfThrows)
    {
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {numberOfThrows}.");

        for (int i = 2; i <= 12; i++)
        {
            Console.Write($"{i}: ");

            // Calculate the percentage and print '*' for each 1%
            int percentage = results[i - 2] * 100 / numberOfThrows;
            for (int j = 0; j < percentage; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }
    }
}

class DiceSimulator
{
    public int[] SimulateDiceRolls(int numberOfThrows)
    {
        Random random = new Random();
        int[] results = new int[11];

        for (int i = 0; i < numberOfThrows; i++)
        {
            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int sum = dice1 + dice2;

            results[sum - 2]++;
        }

        return results;
    }
}