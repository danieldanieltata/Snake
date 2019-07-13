using System;
using SnakeGame.Interfaces;
using System.Threading;

namespace SnakeGame.Threads
{
    class FoodRandomizeThread : ITread
    {
        public void Run()
        {
            int randomRangeX = Board.Instance.BoardArray.GetLength(0);
            int randomRangeY = Board.Instance.BoardArray.GetLength(1);

            Random rand = new Random();

            while (true)
            {
                int randX = rand.Next(0, randomRangeX);
                int randY = rand.Next(0, randomRangeY);

                if (Board.Instance.BoardArray[randX, randY] != 5 && Board.HaveFood == false)
                {
                    Board.Instance.BoardArray[randX, randY] = 3;
                    Board.HaveFood = true;
                }

                Thread.Sleep(2000);
            }

        }
    }
}
