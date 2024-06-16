using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THE_ROOM
{
    class Enemy
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
    }

    class E1M1
    {
        public void Episode1()
        {
            Intermission intermission = new Intermission();
            List<Enemy> enemies = new List<Enemy>
            {
                new Enemy { X = 6, Y = 8, Health = 10 }
            };

            int playerX = 1;
            int playerY = 1;
            int playerH = 30;
            int shotgun = 1;
            char[,] grid =
            {
                { '|', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|', '-', '-', '-', '-', '-', '-', '|' },
                { ']', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { ']', ' ', '_', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', '_', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', ' ', '_', '_', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', ' ', 'E', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', '|', '_', '_', '|', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', '?', '|' },
                { '|', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '|', ' ', ' ', ' ', ' ', ' ', ' ', '|' },
                { '|', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '-', '|', '-', '-', '-', '-', '-', '-', '|' }
            };

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
                if (playerX == 8 && playerY == 9)
                {
                    Console.Clear();
                    intermission.Intermission_Screen();
                    Console.WriteLine(" Entering : E1M2");
                    break;
                }
                else if (playerX == 19 && playerY == 12)
                {
                    Console.WriteLine(" You found a 'shotgun' !");
                    shotgun = 0;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                char key = keyInfo.KeyChar;

                int newX = playerX;
                int newY = playerY;
                if (playerH != 0)
                {
                    if (key == 'w') newY--;
                    else if (key == 'a') newX--;
                    else if (key == 's') newY++;
                    else if (key == 'd') newX++;
                    else if (key == 'k')
                    {
                        for (int i = 0; i < enemies.Count; i++)
                        {
                            if (Math.Abs(enemies[i].X - playerX) <= 5 && Math.Abs(enemies[i].Y - playerY) <= 5)
                            {
                                if (shotgun == 0)
                                {
                                    enemies[i].Health -= 20;
                                    if (enemies[i].Health <= 0)
                                    {
                                        grid[enemies[i].Y, enemies[i].X] = ' ';
                                        enemies.RemoveAt(i);
                                        i--;
                                    }
                                }
                                else
                                {
                                    enemies[i].Health -= 10;
                                    if (enemies[i].Health <= 0)
                                    {
                                        grid[enemies[i].Y, enemies[i].X] = ' ';
                                        enemies.RemoveAt(i);
                                        i--;
                                    }
                                }
                            }
                            continue;
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
