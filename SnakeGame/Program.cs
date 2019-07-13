using System;
using System.Collections.Generic;
using SnakeGame.Threads;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static Board board = Board.Instance;
        static void Main(string[] args)
        {
            RefreshConsoleThread refreshConsoleThread = new RefreshConsoleThread();
            Thread refreshThread = new Thread(new ThreadStart(refreshConsoleThread.Run));
            refreshThread.Start();

            DrawSnakeOnBoardThread drawSnakeOnBoardThread = new DrawSnakeOnBoardThread();
            Thread drawThread = new Thread(new ThreadStart(drawSnakeOnBoardThread.Run));
            drawThread.Start();

            ListenToKeyThread listenToKeyThread = new ListenToKeyThread();
            Thread keyTread = new Thread(new ThreadStart(listenToKeyThread.Run));
            keyTread.Start();

            FoodRandomizeThread foodRandomizeThread = new FoodRandomizeThread();
            Thread foodThread = new Thread(new ThreadStart(foodRandomizeThread.Run));
            foodThread.Start();

            Console.ReadKey();
        }
    }
}
