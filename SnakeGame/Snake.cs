using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public sealed class Snake
    {
        private static readonly Lazy<List<Snake>> lazy = new Lazy<List<Snake>>(() => new List<Snake>() { new Snake(0, 0) });
        public static int Direction { get; set; }
        public static int SnakeLength { get; set; } = 1;


        public int Y { get; set; }
        public int X { get; set; }

        public int LastSnakePosX { get; set; }
        public int LastSnakePosY { get; set; }

        private Snake(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static List<Snake> AddSnakeTail(int NewX, int NewY)
        {
            List<Snake> NewSnakeList = lazy.Value;
            NewSnakeList.Add(new Snake(NewX, NewY));
            SnakeLength += 1;

            return NewSnakeList;
        }

        public static void RefreshPositions(int x, int y)
        {
            lazy.Value.Insert(0, new Snake(x, y));
            lazy.Value.RemoveAt(lazy.Value.Count - 1);
        }

        public static List<Snake> Instance { get { return lazy.Value; } }
    }
}
