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
                for (int i = Snake.Instance.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        int X = Snake.Instance[0].X;
                        int Y = Snake.Instance[0].Y;

                        if (Snake.Instance[0].Y == Board.Instance.BoardArray.GetLength(1)) Snake.Instance[0].Y = 0;
                        if (Snake.Instance[0].Y < 0) Snake.Instance[0].Y = Board.Instance.BoardArray.GetLength(1) - 1;

                        if (Snake.Instance[0].X == Board.Instance.BoardArray.GetLength(0)) Snake.Instance[0].X = 0;
                        if (Snake.Instance[0].X < 0) Snake.Instance[0].X = Board.Instance.BoardArray.GetLength(0) - 1;

                        Board.MarkOnBoard(Snake.Instance[0], X, Y);
                    }
                    else
                    {
                    
                        Snake currentSnake = Snake.Instance[i];
                        Snake nextSnake = Snake.Instance[i-1];

                        int oldX = currentSnake.X;
                        int oldY = currentSnake.Y;

                        currentSnake.X = nextSnake.X;
                        currentSnake.Y = nextSnake.Y;

                        Board.MarkOnBoard(currentSnake, oldX, oldY);
                    }
                
                }

                Thread.Sleep(250);
            }
        }
    }
}
