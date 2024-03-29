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
            Console.Clear();

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Division");
            Console.WriteLine("4 - Multiplication");
            Console.WriteLine("5 - Exit");

            Console.WriteLine("----------");
            Console.WriteLine("Select an option: ");

            short res = short.Parse(Console.ReadLine());

            switch (res)
            {
                case 1: Add(); break;
                case 2: Subtract(); break;
                case 3: Divide(); break;
                case 4: Multiply(); break;
                case 5: System.Environment.Exit(0); break;
                default: Menu(); break;
            }
        }

        static void Add()
        {
            Console.Clear();

            Console.WriteLine("First value: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float result = v1 + v2;
            // Console.WriteLine("The result of the addition is " + result);
            Console.WriteLine($"The result of the addition is {result}");
            // Console.WriteLine($"The result of the addition is {v1 + v2}");
            // Console.WriteLine("The result of the addition is " + (v1 + v2));
            Console.ReadKey();
            Menu();
        }

        static void Subtract()
        {
            Console.Clear();

            Console.WriteLine("First value:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float result = v1 - v2;
            Console.WriteLine($"The result of the subtraction is {result}");
            Console.ReadKey();
            Menu();
        }

        static void Divide()
        {
            Console.Clear();

            Console.WriteLine("First value:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float result = v1 / v2;
            Console.WriteLine($"The result of the division is {result}");
            Console.ReadKey();
            Menu();
        }

        static void Multiply()
        {
            Console.Clear();

            Console.WriteLine("First value: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Second value: ");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float result = v1 * v2;
            Console.WriteLine("The result of the multiplication is " + (v1 * v2));
            Console.ReadKey();
            Menu();
        }
    }
}
