using System;
using System.Threading;
using SnakeGame.Interfaces;

namespace SnakeGame.Threads
{
    class ListenToKeyThread : ITread
    {
        public void Run()
        {
            Snake snakeHead = Snake.Instance[0];
            do
            {
                while (!Console.KeyAvailable)
                {
                    Thread.Sleep(100);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            Snake.Direction = (int)Enums.SnakeMovment.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            Snake.Direction = (int)Enums.SnakeMovment.Down;
                            break;
                        case ConsoleKey.RightArrow:
                            Snake.Direction = (int)Enums.SnakeMovment.Right;
                            break;
                        case ConsoleKey.LeftArrow:
                            Snake.Direction = (int)Enums.SnakeMovment.Left;
                            break;
                        default:
                            break;
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
