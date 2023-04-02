using NUnit.Framework;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SnakeGame;

internal class Program
{
    private static void Main(string[] args)
    {
        string map = @"
        |---------------------|
        |.....................|
        |.....................|
        |.....................|
        |.....................|        
        |.....................|
        |.....................| 
        |.....................| 
        |.....................|
        |.....................|
        |---------------------|";
        Game.Initialize(map);
        Snake snake = new Snake();
        ConsoleKeyInfo key = new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false);
        while (!Game.IsOver)
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
            }
            snake.Move(key);
            Thread.Sleep(Game.Speed);
        }
    }
}
