using System;
using System.IO;

namespace TextEditor
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
                Console.WriteLine("1 - Open file");
                Console.WriteLine("2 - Create new file");
                Console.WriteLine("0 - Exit");

                if (short.TryParse(Console.ReadLine(), out short option))
                {
                    switch (option)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            Open();
                            break;
                        case 2:
                            Edit();
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("Enter the file path:");
            string path = Console.ReadLine();

            try
            {
                using (var file = new StreamReader(path))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Type your text below (Ctrl+S to save and Esc to exit)");
            Console.WriteLine("----------------");
            string text = "";

            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.S)
                {
                    Save(text);
                    break;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    text += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Enter the path to save the file:");
            string path = Console.ReadLine();

            try
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }
                Console.WriteLine($"File saved successfully at {path}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
