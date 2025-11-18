using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeRoomTrain
{
    internal static class Visual
    {
        public static void TypeWrite(string text, int delay = 30)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        public static void PrintBox(string text, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            int width = text.Length + 4;
            Console.WriteLine("╔" + new string('═', width) + "╗");
            Console.WriteLine("║  " + text + "  ║");
            Console.WriteLine("╚" + new string('═', width) + "╝");
            Console.ResetColor();
        }

        public static void ShowLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    ███████╗███████╗ ██████╗ █████╗ ██████╗ ███████╗
    ██╔════╝██╔════╝██╔════╝██╔══██╗██╔══██╗██╔════╝
    █████╗  ███████╗██║     ███████║██████╔╝█████╗  
    ██╔══╝  ╚════██║██║     ██╔══██║██╔═══╝ ██╔══╝  
    ███████╗███████║╚██████╗██║  ██║██║     ███████╗
    ╚══════╝╚══════╝ ╚═════╝╚═╝  ╚═╝╚═╝     ╚══════╝
                                                      
    ██████╗  ██████╗  ██████╗ ███████╗               
    ██╔══██╗██╔═══██╗██╔═══██╗██╔════╝               
    ██████╔╝██║   ██║██║   ██║█████╗                 
    ██╔══██╗██║   ██║██║   ██║██╔══╝                 
    ██║  ██║╚██████╔╝╚██████╔╝███████╗               
    ╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚══════╝               
            ");
            Console.ResetColor();
        }

        public static void DrawDoor()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
                ╔════════════╗
                ║            ║
                ║            ║
                ║            ║
                ║            ║
                ║         *  ║
                ║            ║
                ║            ║
                ║            ║
                ╚════════════╝
            ");
            Console.ResetColor();
        }

        public static void DrawSafe()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(@"
            ┌─────────────────┐
            │  ╔═══════════╗  │
            │  ║  o     o  ║  │
            │  ║     o     ║  │
            │  ║  o     o  ║  │
            │  ╚═══════════╝  │
            └─────────────────┘
            ");
            Console.ResetColor();
        }

        public static void DrawCabinet()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(@"
                ┌───────────┐
                │  ┌─────┐  │
                │  │  ○  │  │
                │  └─────┘  │
                └───────────┘
            ");
            Console.ResetColor();
        }

        public static void ShowSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            /*for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\n          УСПІХ!      ");
                Thread.Sleep(200);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.WriteLine(new string(' ', 50));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Thread.Sleep(200);
            }*/
            Console.WriteLine("\n        УСПІХ!      ");
            Console.ResetColor();
        }

        public static void DrawDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('─', 60));
            Console.ResetColor();
        }
    }
}
