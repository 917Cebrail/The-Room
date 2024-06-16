using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace THE_ROOM
{
    class E1_Ending
    {
        public void Ending()
        {
            string mp3FilePath = @"end.mp3";
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = mp3FilePath;
            player.controls.play();
            System.Threading.Thread.Sleep(1750);
            string[] _grid = new string[]
            {
            "| You destroyed all the demons and     |",
            "| jumped into the portal that appeared |",
            "| in front of you. What is this place? |",
            "| Did you come to hell? seems there are|",
            "|  more demons to destroy...           |"
            };

            char[,] grid = new char[_grid.Length, _grid[0].Length];

            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[i].Length; j++)
                {
                    grid[i, j] = _grid[i][j];
                }
            }
            Console.WriteLine("|--------------------------------------|");
            PrintGrid(grid);
            Console.WriteLine("|______________________________________|");
            player.controls.stop();
        }
        public void PrintGrid(char[,] grid)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    Console.Write(grid[y, x]);
                    System.Threading.Thread.Sleep(50);
                }
                Console.WriteLine();
            }
        }
    }
}
