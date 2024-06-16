using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_ROOM
{
    class Program
    {
        static void Main(string[] args)
        {
            E1M1 e1m1 = new E1M1();
            Console.Title = "THE ROOM";
            Console.WindowHeight = 20;
            Console.BufferHeight = 20;
            Console.WindowWidth = 50;
            Console.BufferWidth = 50;
            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string room = @"
     ██▀███   ▒█████   ▒█████   ███▄ ▄███▓
     ▓██ ▒ ██▒▒██▒  ██▒▒██▒  ██▒▓██▒▀█▀ ██▒
     ▓██ ░▄█ ▒▒██░  ██▒▒██░  ██▒▓██    ▓██░
     ▒██▀▀█▄  ▒██   ██░▒██   ██░▒██    ▒██ 
     ░██▓ ▒██▒░ ████▓▒░░ ████▓▒░▒██▒   ░██▒
     ░ ▒▓ ░▒▓░░ ▒░▒░▒░ ░ ▒░▒░▒░ ░ ▒░   ░  ░
     ░▒ ░ ▒░  ░ ▒ ▒░   ░ ▒ ▒░ ░  ░      ░
     ░░   ░ ░ ░ ░ ▒  ░ ░ ░ ▒  ░      ░   
     ░         ░ ░      ░ ░         ░   
                                      
";
            Console.WriteLine(room);
            Console.WriteLine(" [1] : Play  [2] : Exit [3] : About\n");
            while (true)
            {
                Console.Write("\n > ");
                string command = Console.ReadLine();
                if (command == "1")
                {
                    Console.Clear();
                    e1m1.Episode1();
                }
                else if (command == "2")
                {
                    break;
                }
                else if (command == "3")
                {
                    Console.Clear();
                    Console.WriteLine(room);
                    Console.WriteLine(" [W,A,S,D] : Move \n [O] : Player \n [0] : Dead Enemy \n [X] : Enemy");
                    Console.WriteLine(" [Creator] : Cebrail Kutlar\n");
                    Console.WriteLine(" [1] : Play  [2] : Exit [3] : About\n");
                }
                else
                {
                    Console.WriteLine(" Wrong Command");
                }
            }
        }
    }
}
