using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_ROOM
{
    class E1M2
    {
        public void Episode2()
        {
            Intermission intermission = new Intermission();
            List<Enemy> enemies = new List<Enemy>
            {
                new Enemy { X = 23, Y = 9, Health = 15 },
                new Enemy { X = 18, Y = 9, Health = 15 },
                new Enemy { X = 23, Y = 3, Health = 10 },
                new Enemy { X = 19, Y = 3, Health = 10 },
                new Enemy { X = 28, Y = 1, Health = 10 }
            };

            int playerX = 1;
            int playerY = 1;
            int playerH = 50;
            int shotgun = 0;
            string[] _grid = new string[]
            {
            "|--------------------------------|",
            "|             ]|             ]   |",
            "|     |       ]|             |___|",
            "|    [|]      ]|                 |",
            "|    [O]      ]|_____  __________|",
            "|                   |  |         |",
            "]                   ]  |         |",
            "]                   ]  |         |",
            "|               ____|  |_________|",
            "|             ]|                 |",
            "|             ]|                 |",
            "|  |=|=|=|=|  ]|                 |",
            "|()  () ()    ]|                 |",
            "|_____________]|_________________|"
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
            int newX = playerX;
            int newY = playerY;
            while (true)
            {
                Console.Clear();
                PrintGrid(grid);
                Console.WriteLine("Health : " + playerH + " | Position : (" + playerX + "," + playerY + ")");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char key = keyInfo.KeyChar;

                if (enemies.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine(" E1M2 FINISHED");
                    intermission.Intermission_Screen();
                    Console.WriteLine(" Entering : E1M3");
                    Console.Read();
                    E1M3 e1m3 = new E1M3();
                    e1m3.Episode3();
                    break;
                }
                if (playerH != 0)
                {
                    if (key == 'w') newY--;
                    else if (key == 'a') newX--;
                    else if (key == 's') newY++;
                    else if (key == 'd') newX++;
                    else if (key == 'k')
                    {
                        for (int i = enemies.Count - 1; i >= 0; i--)
                        {
                            if (Math.Abs(enemies[i].X - playerX) <= 3 && Math.Abs(enemies[i].Y - playerY) <= 1)
                            {
                                enemies[i].Health -= shotgun == 0 ? 20 : 10;

                                if (enemies[i].Health <= 0)
                                {
                                    grid[enemies[i].Y, enemies[i].X] = ' ';
                                    enemies.RemoveAt(i);
                                }
                            }
                        }
                        continue;
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
                            else if (code.ToLower() == "e1m2")
                            {
                                E1M1 e1m1 = new E1M1();
                                e1m1.Episode1();
                            }
                            else if (code.ToLower() == "e1m3")
                            {
                                E1M3 e1m3 = new E1M3();
                                e1m3.Episode3();
                            }
                            else
                            {
                                Console.WriteLine(" Wrong Command");
                            }
                        }
                    }
                    foreach (var enemy in enemies)
                    {
                        if (Math.Abs(enemy.X - newX) <= 2 && Math.Abs(enemy.Y - newY) <= 1)
                        {
                            playerH -= 5;
                            break;
                        }
                    }
                    if (newX >= 0 && newX < grid.GetLength(1) && newY >= 0 && newY < grid.GetLength(0) &&
                        grid[newY, newX] != '|' && grid[newY, newX] != '_' && grid[newY, newX] != '-')
                    {
                        grid[playerY, playerX] = ' ';
                        playerX = newX;
                        playerY = newY;
                        grid[playerY, playerX] = 'O';
                    }
                    continue;
                }
                else
                {
                    intermission.Intermission_Screen();
                    Console.WriteLine(" You're died !");
                    break;
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
