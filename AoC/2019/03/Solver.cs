using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2019._03
{
    class Solver : AbstractSolver, ISolver
    {
        public void SolvePart1()
        {
            solve1(base.GetInputLines().ToArray());
        }

        public void SolvePart2()
        {
            var inputs = base.GetInputLines().ToArray();
            Console.WriteLine(solve2(inputs, solve1(inputs)));
        }

        public void TestPart1()
        {
            var input = @"R8,U5,L5,D3;U7,R6,D4,L4";
            var lines = GetLines(input.Split(';')[0]);
            solve1(input.Split(';'));
        }

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

        private List<Point> solve1(string[] inputs)
        {
            var line1 = GetLines(inputs[0]);
            var line2 = GetLines(inputs[1]);
            var intersections = new List<Point>();
            foreach(var line in line1)
            {
                intersections.AddRange(line2.Where(x => x.Intersects(line)).Select(x => x.From.X == x.To.X ? new Point(x.From.X, line.From.Y) : new Point(line.From.X, x.From.Y)));
            }
            intersections = intersections.Where(x => !(x.X == 0 && x.Y == 0)).ToList();
            var min = intersections.Min(s => Math.Abs(s.X) + Math.Abs(s.Y));
            Console.WriteLine(min);
            return intersections;
        }

        int solve2(string[] inputs, List<Point> points)
        {
            var min = int.MaxValue;
            foreach (var point in points)
            {
                min = Math.Min(inputs.Sum(x => moves(GetLines(x), point)), min);
            }
            return min;
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

        public void TestPart2()
        {
            var inputs = @"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51;U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(';').ToArray();
        }
    }
}
