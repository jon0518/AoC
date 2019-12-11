using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    public class Line
    {
        public Line() { }
        public Line(Point from, Point to) { From = from; To = to; }
        public Point From { get; set; }
        public Point To { get; set; }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(From.X - To.X, 2) + Math.Pow(From.Y - To.Y, 2));
        }

        public bool Intersects(Point point)
        {
            if(From.X - To.X == 0)
            {
                return point.X == From.X && ((From.Y <= point.Y && point.Y <= To.Y) || (To.Y <= point.Y && point.Y <= From.Y));
            }
            if (From.Y - To.Y == 0)
            {
                return point.Y == From.Y && ((From.X <= point.X && point.X <= To.X) || (To.X <= point.X && point.X <= From.X));
            }
            var slope = GetSlope();
            var intercept = From.Y - (slope * From.X);
            return point.Y == Math.Round((slope * point.X) + intercept,10) && ((From.X <= point.X && point.X <= To.X) || (To.X <= point.X && point.X <= From.X));
        }

        public double GetSlope()
        {
            return Convert.ToDouble(From.Y - To.Y) / (From.X - To.X);
        }

        public bool Intersects(Line line)
        {
            Point left, right, top, bottom;
            if (From.X < To.X)
            {
                left = From;
                right = To;
            }
            else
            {
                left = To;
                right = From;
            }
            if (From.Y < To.Y)
            {
                bottom = From;
                top = To;
            }
            else
            {
                bottom = To;
                top = From;
            }

            Point left2, right2, top2, bottom2;
            if (line.From.X < line.To.X)
            {
                left2 = line.From;
                right2 = line.To;
            }
            else
            {
                left2 = line.To;
                right2 = line.From;
            }
            if (line.From.Y < line.To.Y)
            {
                bottom2 = line.From;
                top2 = line.To;
            }
            else
            {
                bottom2 = line.To;
                top2 = line.From;
            }
            return left2.X <= right.X && right2.X >= left.X && bottom2.Y <= top.Y && top2.Y >= bottom.Y;
        }
    }
}
