using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._10
{
    class Solver : AbstractSolver, ISolver
    {
        public void SolvePart1()
        {
            var ans = solve1(base.GetInputLines());
            Console.WriteLine(ans.Item1);
        }

        public void SolvePart2()
        {
            var point = solve2(base.GetInputLines());
            Console.WriteLine(100 * point?.X + point?.Y);
        }

        Point solve2(List<string> rows)
        {
            var point = solve1(rows).Item2;
            var asteroids = ParseMap(rows);
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
                    return toDestroy;
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
                        return toDestroy;
                    }
                }
                toDestroy = below.FirstOrDefault(x => !destroyed.Contains(x));
                if (toDestroy != null)
                {
                    destroyed.Add(toDestroy);
                }
                if (destroyed.Count == 200)
                {
                    return toDestroy;
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
                        return toDestroy;
                    }
                }
            }
            return toDestroy;
        }

        Tuple<int, Point> solve1(List<string> rows)
        {
            var asteroids = ParseMap(rows);
            var max = 0;
            Point placedAt = null;
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
            return new Tuple<int, Point>(max, placedAt);
        }

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

        public void TestPart1()
        {
            var ans = solve1(@".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##".Split(Environment.NewLine).ToList());
            Console.WriteLine(ans.Item1);
        }

        public void TestPart2()
        {
            var point = solve2(@".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##".Split(Environment.NewLine).ToList());
            
        }
    }
}
