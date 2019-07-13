using System;
using SnakeGame.Interfaces;
using System.Threading;

namespace SnakeGame.Threads
{
    class RefreshConsoleThread : ITread
    {
        public void Run()
        {
            Board board = Board.Instance;

            while (true)
            {
                Thread.Sleep(200);
                Console.Clear();

                for (var i = 0; i < board.BoardArray.GetLength(0); i++)
                {
                    for (var j = 0; j < board.BoardArray.GetLength(1); j++)
                    {
                        Console.Write($"{board.BoardArray[i, j]}  ");
                    }
                    Console.WriteLine();
                }

                for (var i = 0; i < Snake.Instance.Count; i++)
                {
                    Console.WriteLine($"x: {Snake.Instance[i].X} y: {Snake.Instance[i].Y}");
                }
            }
        }
    }
}
