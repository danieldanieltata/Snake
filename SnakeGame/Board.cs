using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    // Sigleton class, only one instance of this
    public sealed class Board
    {
        private static readonly Lazy<Board> lazy = new Lazy<Board>(() => new Board());
        public int[,] BoardArray { get; set; }
        public static bool HaveFood { get; set; } = false;

        private Board()
        {
            BoardArray = new int[10, 10];

            for (var i = 0; i < BoardArray.GetLength(0); i++)
            {
                for (var j = 0; j < BoardArray.GetLength(1); j++)
                {
                    BoardArray[i, j] = 0;
                }
            }
        }


        public static void RefreshBoard(int oldX, int oldY)
        {
            foreach (Snake snake in Snake.Instance)
            {
                lazy.Value.BoardArray[snake.X, snake.Y] = 5;
            }
            lazy.Value.BoardArray[oldX, oldY] = 0;
        }
        public static void CheckIfSteppedOnFood(int headX, int headY, int oldX, int oldY)
        {
            if (lazy.Value.BoardArray[headX, headY] == 3)
            {                  
                Snake.AddSnakeTail(oldX, oldY);
                HaveFood = false;
            }
            
        }

        public static Board Instance { get { return lazy.Value; } }
    }
}
