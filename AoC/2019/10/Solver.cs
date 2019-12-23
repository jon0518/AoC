using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._10
{
    public class Solver : AbstractSolver, ISolver
    {

        Point placedAt;

        List<Point> ParseMap(List<string> rows)
        {
            var points = new List<Point>();
            for (int y = 0; y < rows.Count; y++)
            {
                for (int x = 0; x < rows[y].Length; x++)
                {
                    if (rows[y][x] == '#')
                    {
                        points.Add(new Point(x, y));
                    }
                }
            }
            return points;
        }        

        public string SolvePart1(IEnumerable<string> inputLines)
        {
            var asteroids = ParseMap(inputLines.ToList());
            var max = 0;
            foreach (var a in asteroids)
            {
                var count = -1;
                foreach (var b in asteroids)
                {
                    var line = new Line(a, b);
                    if (!asteroids.Where(x => !x.Equals(a) && !x.Equals(b)).Any(x => line.Intersects(x)))
                    {
                        count++;
                    }
                }
                if (count > max)
                {
                    max = Math.Max(max, count);
                    placedAt = a;
                }

            }
            return max.ToString();
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            SolvePart1(inputLines);
            var point = placedAt;
            var asteroids = ParseMap(inputLines.ToList());
            var destroyed = new HashSet<Point>();
            var above = asteroids.Where(a => a.X == point.X && a.Y < point.Y).OrderByDescending(x => x.Y);
            var below = asteroids.Where(a => a.X == point.X && a.Y > point.Y).OrderBy(x => x.Y);
            var right = asteroids.Where(a => a.X > point.X).GroupBy(a => new Line(a, point).GetSlope()).OrderBy(k => k.Key);
            var left = asteroids.Where(a => a.X < point.X).GroupBy(a => new Line(a, point).GetSlope()).OrderBy(k => k.Key);
            Point toDestroy = null;
            while (destroyed.Count < asteroids.Count - 1)
            {
                toDestroy = above.FirstOrDefault(x => !destroyed.Contains(x));
                if (toDestroy != null)
                {
                    destroyed.Add(toDestroy);
                }
                if (destroyed.Count == 200)
                {
                    return (100 * toDestroy.X + toDestroy.Y).ToString();
                }
                foreach (var asteroidGroup in right)
                {
                    toDestroy = asteroidGroup.OrderBy(x => Math.Abs(x.X - point.X) + Math.Abs(x.Y - point.Y)).FirstOrDefault(x => !destroyed.Contains(x));
                    if (toDestroy != null)
                    {
                        destroyed.Add(toDestroy);
                    }
                    if (destroyed.Count == 200)
                    {
                        return (100 * toDestroy.X + toDestroy.Y).ToString();
                    }
                }
                toDestroy = below.FirstOrDefault(x => !destroyed.Contains(x));
                if (toDestroy != null)
                {
                    destroyed.Add(toDestroy);
                }
                if (destroyed.Count == 200)
                {
                    return (100 * toDestroy.X + toDestroy.Y).ToString();
                }
                foreach (var asteroidGroup in left)
                {
                    toDestroy = asteroidGroup.OrderBy(x => Math.Abs(x.X - point.X) + Math.Abs(x.Y - point.Y)).FirstOrDefault(x => !destroyed.Contains(x));
                    if (toDestroy != null)
                    {
                        destroyed.Add(toDestroy);
                    }
                    if (destroyed.Count == 200)
                    {
                        return (100 * toDestroy.X + toDestroy.Y).ToString();
                    }
                }
            }
            return string.Empty;
        }
    }
}
