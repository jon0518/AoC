using System;
using System.IO;
using System.Reflection;

namespace AoC
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = DateTime.Now.Year;
            var day = DateTime.Now.Day;
            Console.WriteLine("enter YYYYDD or leave blank for today");
            var dy = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(dy))
            {
                year = int.Parse(dy.Substring(0, 4));
                day = int.Parse(dy.Substring(4, 2));
            }
            Console.WriteLine("Part 1 or 2?");
            var part = Console.ReadLine();
            var solver = SolverFactory.GetSolver(year, day);
            var inputLines = solver.GetInputLines();
            if (part == "1")
            {
                Console.WriteLine(solver.SolvePart1(inputLines));
            }
            else
            {
                Console.WriteLine(solver.SolvePart2(inputLines));
            }
        }
    }
}
