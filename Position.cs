using System;

namespace Shop
{
    class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            Console.SetCursorPosition(X, Y);
        }

        public void SetNextLine()
        {
            Y++;
            Console.SetCursorPosition(X, Y);
        }
    }
}
