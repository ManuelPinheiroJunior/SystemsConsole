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
                        Console.ReadLine(); // Wait for user to acknowledge before going back to menu
                        Menu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                Console.ReadLine(); // Wait for user to acknowledge before going back to menu
                Menu();
            }
        }

        static void Open()
        {
            Console.Clear();
            Console.WriteLine("What is the file path?");
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
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Type your text below (Ctrl+S to save and Esc to exit)");
            Console.WriteLine("----------------");
            string text = "";

            do
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.S)
                {
                    Save(text);
                }
                else if (key.Key != ConsoleKey.Escape)
                {
                    text += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Menu();
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("What is the path to save the file?");
            var path = Console.ReadLine();

            try
            {
                using (var file = new StreamWriter(path))
                {
                    file.Write(text);
                }

                Console.WriteLine($"File {path} saved successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the file: {ex.Message}");
            }

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
            Menu();
        }
    }
}
