using System;
using System.Collections.Generic;
using SnakeGame.Threads;
using System.Threading;
using SnakeGame.Interfaces;

namespace SnakeGame
{
    class Program
    {
        static Board board = Board.Instance;
        static void Main(string[] args)
        {
            List<ITread> threads = new List<ITread>();

            ITread refreshConsoleThread = new RefreshConsoleThread();
            ITread drawSnakeOnBoardThread = new DrawSnakeOnBoardThread();
            ITread listenToKeyThread = new ListenToKeyThread();
            ITread foodRandomizeThread = new FoodRandomizeThread();

            threads.Add(refreshConsoleThread);
            threads.Add(drawSnakeOnBoardThread);
            threads.Add(listenToKeyThread);
            threads.Add(foodRandomizeThread);

            foreach (ITread threadToRun in threads)
            {
                Thread startThread = new Thread(new ThreadStart(threadToRun.Run));
                startThread.Start();
            }

            Console.ReadKey();
        }
    }
}
