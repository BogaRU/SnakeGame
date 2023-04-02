using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class Snake
    {
        SnakeItem Head;
        SnakeItem Tail;
        Directions direction;
        Dictionary<ConsoleKey, Action> commands;

        public Snake()
        {
            Head = new SnakeItem(new Point(Game.MapWidth / 2 - 1, Game.MapHeight / 2, 'O'));
            Tail = Head;
            direction = Directions.Right;
            commands = new Dictionary<ConsoleKey, Action>()
        {
            {ConsoleKey.UpArrow,  () => {if (direction != Directions.Down) direction = Directions.Up;} },
            {ConsoleKey.DownArrow, () => {if (direction != Directions.Up) direction = Directions.Down;} },
            {ConsoleKey.LeftArrow, () => {if (direction != Directions.Right) direction = Directions.Left;} },
            {ConsoleKey.RightArrow, () => {if (direction != Directions.Left) direction = Directions.Right;} },
        };
        }

        public void Move(ConsoleKeyInfo pressedKey)
        {
            if (commands.ContainsKey(pressedKey.Key)) commands[pressedKey.Key].Invoke();
            MoveHead();
            Check();
        }

        public void MoveHead()
        {
            int x = 0, y = 0;
            switch (direction)
            {
                case Directions.Up:
                    y--;
                    break;
                case Directions.Down:
                    y++;
                    break;
                case Directions.Right:
                    x++;
                    break;
                case Directions.Left:
                    x--;
                    break;
            }
            Head.Next = new SnakeItem(new Point(Head.Place.X + x, Head.Place.Y + y, 'O'));
            Head = Head.Next;
        }

        public void Check()
        {
            switch (Game.Map[Head.Place.Y, Head.Place.X])
            {
                case '.':
                    Game.Map[Tail.Place.Y, Tail.Place.X] = '.';
                    Game.Draw(Tail.Place.X, Tail.Place.Y, '.');
                    Tail = Tail.Next;
                    break;
                case '*':
                    Game.GenerateFood();
                    break;
                default:
                    Game.Over();
                    return;
            }
            Game.Map[Head.Place.Y, Head.Place.X] = 'O';
            Game.Draw(Head.Place.X, Head.Place.Y, 'O');
        }
    }
}
