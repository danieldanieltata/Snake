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
                            snakeHead.Direction = (int)Enums.SnakeMovment.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snakeHead.Direction = (int)Enums.SnakeMovment.Down;
                            break;
                        case ConsoleKey.RightArrow:
                            snakeHead.Direction = (int)Enums.SnakeMovment.Right;
                            break;
                        case ConsoleKey.LeftArrow:
                            snakeHead.Direction = (int)Enums.SnakeMovment.Left;
                            break;
                        default:
                            break;
                    }
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
