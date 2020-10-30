using System;
using System.Collections.Generic;
using System.Text;

namespace Misc
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point operator+(Point a, Point b)
        {
            return new Point { X = a.X + b.X, Y = a.Y + b.Y };
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
