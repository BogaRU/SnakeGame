using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SnakeGame
{
    public static class Game
    {
        public static bool IsOver = false;
        public static char[,] Map { get; private set; }
        public static int Speed { get; private set; } = 400;
        public static int MapWidth { get; private set; }
        public static int MapHeight { get; private set; }

        static Random random = new Random();

        public static void Initialize(string map)
        {
            Console.CursorVisible = false;
            var lines = Regex.Split(map, "\\s").Where(l => l != "").ToArray();
            Map = new char[lines.Length, lines[0].Length];
            MapHeight = lines.Length;
            MapWidth = lines[0].Length;
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                {
                    Map[i, j] = lines[i][j];
                    Draw(j, i, lines[i][j]);
                }
            }
            GenerateFood();
            DrawMap();
        }

        public static void GenerateFood()
        {
            var x = random.Next(1, MapWidth);
            var y = random.Next(1, MapHeight);

            if (Map[y, x] == '.')
            {
                Map[y, x] = '*';
                Draw(x, y, '*');
                Game.Speed -= Game.Speed > 99 ? 20 : 0;
            }
            else GenerateFood();
        }

        public static void Draw(int x, int y, char c)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public static void DrawMap()
        {
            if (Game.IsOver) return;
            Console.Clear();
            for (int i = 0; i < MapHeight; i++)
            {
                for (int j = 0; j < MapWidth; j++)
                    Draw(j, i, Map[i, j]);
                Console.WriteLine();
            }
        }

        public static void Over()
        {
            IsOver = true;
            Console.Clear();
            Console.WriteLine("Game over =(");
        }
    }
}
