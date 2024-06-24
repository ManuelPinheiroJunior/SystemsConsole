using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Subtraction");
                Console.WriteLine("3 - Division");
                Console.WriteLine("4 - Multiplication");
                Console.WriteLine("5 - Exit");
                Console.WriteLine("----------");
                Console.Write("Select an option: ");

                if (short.TryParse(Console.ReadLine(), out short res))
                {
                    switch (res)
                    {
                        case 1: PerformOperation(Add); break;
                        case 2: PerformOperation(Subtract); break;
                        case 3: PerformOperation(Divide); break;
                        case 4: PerformOperation(Multiply); break;
                        case 5: Environment.Exit(0); break;
                        default: Console.WriteLine("Invalid option. Try again."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            }
        }

        static void PerformOperation(Func<float, float, float> operation)
        {
            Console.Clear();

            float v1 = GetInput("First value: ");
            float v2 = GetInput("Second value: ");

            float result = operation(v1, v2);
            Console.WriteLine($"\nThe result is {result}");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        static float GetInput(string prompt)
        {
            float value;
            Console.Write(prompt);
            while (!float.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. " + prompt);
            }
            return value;
        }

        static float Add(float v1, float v2) => v1 + v2;
        static float Subtract(float v1, float v2) => v1 - v2;
        static float Divide(float v1, float v2)
        {
            if (v2 == 0)
            {
                Console.WriteLine("Cannot divide by zero. Returning zero as result.");
                return 0;
            }
            return v1 / v2;
        }
        static float Multiply(float v1, float v2) => v1 * v2;
    }
}
