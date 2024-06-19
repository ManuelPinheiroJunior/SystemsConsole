using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("S = Second => 10s = 10 seconds");
            Console.WriteLine("M = Minute => 1m = 1 minute");
            Console.WriteLine("0 = Exit");
            Console.WriteLine("How long do you want to count?");

            string data = Console.ReadLine().ToLower();

            // Validating input
            if (string.IsNullOrEmpty(data) || data.Length < 2)
            {
                Console.WriteLine("Invalid input. Please try again.");
                Thread.Sleep(2000);
                Menu();
                return;
            }

            char type = data[^1]; // Using ^1 to get the last character
            int time;

            // Try to parse the time part of the input
            if (!int.TryParse(data.Substring(0, data.Length - 1), out time))
            {
                Console.WriteLine("Invalid time format. Please try again.");
                Thread.Sleep(2000);
                Menu();
                return;
            }

            if (time == 0)
                Environment.Exit(0);

            int multiplier = (type == 'm') ? 60 : 1;

            PreStart(time * multiplier);
        }

        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }

        static void Start(int time)
        {
            int currentTime = 0;

            while (currentTime < time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Stopwatch finished");
            Thread.Sleep(2500);
            Menu();
        }
    }
}
