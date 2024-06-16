using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace THE_ROOM
{
    class E1M3
    {
        public void Episode3()
        {
            Intermission intermission = new Intermission();
            List<Enemy> enemies = new List<Enemy>
    {
        new Enemy { X = 3, Y = 3, Health = 100 },
        new Enemy { X = 3, Y = 12, Health = 100 },
        new Enemy { X = 30, Y = 3, Health = 100 },
        new Enemy { X = 30, Y = 12, Health = 100 }
    };

            int playerX = 22;
            int playerY = 7;
            int playerH = 50;
            int shotgun = 0;
            string[] _grid = new string[]
            {
        "|--------------------------------------|",
        "|                                      |",
        "|                 ______               |",
        "|                |      |              |",
        "|               |        |             |",
        "|              [  ?       ]            |",
        "|              [          ]            |",
        "|               |        |             |",
        "|                |______|              |",
        "|                                      |",
        "|                                      |",
        "|                                      |",
        "|                                      |",
        "|                                      |",
        "|______________________________________|"
            };

            char[,] grid = new char[_grid.Length, _grid[0].Length];

            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[i].Length; j++)
                {
                    grid[i, j] = _grid[i][j];
                }
            }

            grid[playerY, playerX] = 'O';

            foreach (var enemy in enemies)
            {
                grid[enemy.Y, enemy.X] = 'X';
            }

            while (true)
            {
                Console.Clear();
                PrintGrid(grid);
                Console.WriteLine("Health : " + playerH + " | Position : (" + playerX + "," + playerY + ")");

                if (playerX == 18 && playerY == 5)
                {
                    playerH = 100;
                }
                else if (enemies.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine(" E1M3 FINISHED");
                    intermission.Intermission_Screen();
                    Console.Read();
                    E1_Ending ending = new E1_Ending();
                    ending.Ending();
                    Console.Read();
                    break;
                }

                if (playerH <= 0)
                {
                    intermission.Intermission_Screen();
                    Console.WriteLine(" You're died !");
                    break;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char key = keyInfo.KeyChar;

                int newX = playerX;
                int newY = playerY;

                if (key == 'w') newY--;
                else if (key == 'a') newX--;
                else if (key == 's') newY++;
                else if (key == 'd') newX++;
                else if (key == 'k')
                {
                    string mp3FilePath = @"cannon_shot.mp3";
                    WindowsMediaPlayer player = new WindowsMediaPlayer();
                    player.URL = mp3FilePath;
                    player.controls.play();
                    System.Threading.Thread.Sleep(1000);
                    for (int i = enemies.Count - 1; i >= 0; i--)
                    {
                        if (Math.Abs(enemies[i].X - playerX) <= 5 && Math.Abs(enemies[i].Y - playerY) <= 2)
                        {
                            enemies[i].Health -= shotgun == 0 ? 20 : 10;

                            if (enemies[i].Health <= 0)
                            {
                                grid[enemies[i].Y, enemies[i].X] = ' ';
                                enemies.RemoveAt(i);
                            }
                        }
                    }
                    player.controls.stop(); continue;
                }
                else if (key == 'c')
                {
                    Console.WriteLine(" You opened a cheat menu. \n [exit] : Closed the cheat menu");
                    while (true)
                    {
                        Console.Write(" > ");
                        string code = Console.ReadLine();
                        if (code.ToLower() == "god")
                        {
                            playerH = 100000;
                        }
                        else if (code.ToLower() == "exit")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" Wrong Command");
                        }
                    }
                    continue;
                }

                if (newX >= 0 && newX < grid.GetLength(1) && newY >= 0 && newY < grid.GetLength(0) &&
                    grid[newY, newX] != '|' && grid[newY, newX] != '_' && grid[newY, newX] != '-')
                {
                    bool canMove = true;
                    foreach (var enemy in enemies)
                    {
                        if (((enemy.X == newX + 5) || (enemy.X == newX - 5)) && ((enemy.Y == newY + 3) || (enemy.Y == newY - 3)))
                        {
                            playerH -= 5;
                            canMove = false;
                            break;
                        }
                    }
                    if (canMove)
                    {
                        grid[playerY, playerX] = ' ';
                        playerX = newX;
                        playerY = newY;
                        grid[playerY, playerX] = 'O';
                    }
                }
            }
        }
        public void PrintGrid(char[,] grid)
        {
            for (int y = 0; y < grid.GetLength(0); y++)
            {
                for (int x = 0; x < grid.GetLength(1); x++)
                {
                    Console.Write(grid[y, x]);
                }
                Console.WriteLine();
            }
        }
    }
}
