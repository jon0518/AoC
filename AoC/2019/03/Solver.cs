using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2019._03
{
    public class Solver : AbstractSolver, ISolver
    {

        List<Point> intersections;

        private List<Line> GetLines(string s)
        {
            var lines = new List<Line>();
            var point = new Point();
            foreach(var val in s.Split(','))
            {
                var line = new Line();
                line.From = new Point(point);
                int move = int.Parse(val.Substring(1));
                if (val[0] == 'R')
                    point.X += move;
                if (val[0] == 'L')
                    point.X -= move;
                if (val[0] == 'U')
                    point.Y += move;
                if (val[0] == 'D')
                    point.Y -= move;
                line.To = new Point(point);
                lines.Add(line);
            }
            return lines;
        }

        int moves(List<Line> line, Point point)
        {
            int sum = 0;            
            foreach(var segment in  line)
            {
                if (segment.Intersects(point))
                    return sum + Math.Abs(point.X - segment.From.X) + Math.Abs(point.Y - segment.From.Y);
                sum += (int)segment.GetLength();
            }            
            return sum;
        }

        public string SolvePart1(IEnumerable<string> inputLines)
        {
            var line1 = GetLines(inputLines.ElementAt(0));
            var line2 = GetLines(inputLines.ElementAt(1));
            intersections = new List<Point>();
            foreach (var line in line1)
            {
                intersections.AddRange(line2.Where(x => x.Intersects(line)).Select(x => x.From.X == x.To.X ? new Point(x.From.X, line.From.Y) : new Point(line.From.X, x.From.Y)));
            }
            intersections = intersections.Where(x => !(x.X == 0 && x.Y == 0)).ToList();
            var min = intersections.Min(s => Math.Abs(s.X) + Math.Abs(s.Y));
            return min.ToString();
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            SolvePart1(inputLines);
            var min = int.MaxValue;
            foreach (var point in intersections)
            {
                min = Math.Min(inputLines.Sum(x => moves(GetLines(x), point)), min);
            }
            return min.ToString();
        }
    }
}
