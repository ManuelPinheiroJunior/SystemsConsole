using System;

namespace EditorHtml
{
    public static class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOptions(option);
        }

        public static void DrawScreen()
        {
            Console.Write("+");
            for (int i = 0; i <= 38; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
            Console.Write("\n");

            for (int lines = 0; lines <= 10; lines++)
            {
                Console.Write("|");
                for (int i = 0; i <= 38; i++)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.Write("\n");
            }

            Console.Write("+");
            for (int i = 0; i <= 38; i++)
            {
                Console.Write("-");
            }
            Console.Write("+");
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("HTML Editor");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("===========");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Select an option below");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - New file");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Open");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("0 - Exit");
            Console.SetCursorPosition(3, 10);
            Console.Write("Option: ");
        }

        public static void HandleMenuOptions(short option)
        {
            switch (option)
            {
                case 1: Editor.Show(); break;
                case 2: Viewer.Show(""); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0); break;
                    }
                default: Show(); break;
            }
        }
    }
}
