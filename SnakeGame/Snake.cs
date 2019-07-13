using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public sealed class Snake
    {
        private static readonly Lazy<List<Snake>> lazy = new Lazy<List<Snake>>(() => new List<Snake>() { new Snake(1, 1) });
        public static int Direction { get; set; }


        public int Y { get; set; }
        public int X { get; set; }

        public int LastSnakePosX { get; set; }
        public int LastSnakePosY { get; set; }

        private Snake(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static void AddSnakeTail(Snake snakeOldPos)
        {
            lazy.Value.Add(new Snake(snakeOldPos.X, snakeOldPos.Y));
        }

        public static List<Snake> Instance { get { return lazy.Value; } }
    }
}
