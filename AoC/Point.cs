using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    public class Point
    {
        public Point() { X = 0; Y = 0; }
        public Point(int x, int y) { X = x; Y = y; }
        public Point(Point point) { X = point.X; Y = point.Y; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
