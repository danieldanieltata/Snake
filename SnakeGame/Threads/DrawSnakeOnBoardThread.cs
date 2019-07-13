using System.Collections.Generic;
using System.Threading;
using SnakeGame.Interfaces;

namespace SnakeGame.Threads
{
    class DrawSnakeOnBoardThread : ITread
    {
        public void Run()
        {
            while (true)
            {
                int X = Snake.Instance[0].X;
                int Y = Snake.Instance[0].Y;

                int oldX = Snake.Instance[Snake.Instance.Count - 1].X;
                int oldY = Snake.Instance[Snake.Instance.Count - 1].Y;

                switch (Snake.Direction)
                {
                    case (int)Enums.SnakeMovment.Up:
                        X -= 1;
                        break;
                    case (int)Enums.SnakeMovment.Down:
                        X += 1;
                        break;
                    case (int)Enums.SnakeMovment.Left:
                        Y -= 1;
                        break;
                    default:
                        Y += 1;
                        break;
                }

                if (Y == Board.Instance.BoardArray.GetLength(1)) Y = 0;
                if (Y < 0) Y = Board.Instance.BoardArray.GetLength(1) - 1;

                if (X == Board.Instance.BoardArray.GetLength(0)) X = 0;
                if (X < 0) X = Board.Instance.BoardArray.GetLength(0) - 1;

                Snake.RefreshPositions(X, Y);
                Board.CheckIfSteppedOnFood(X, Y, oldX, oldY);
                Board.RefreshBoard(oldX, oldY);
 
                Thread.Sleep(250);
            }

        
        }
    }
}
