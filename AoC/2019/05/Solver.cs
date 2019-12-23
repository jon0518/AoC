using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._05
{
    public class Solver : AbstractSolver, ISolver
    {
        public string SolvePart1(IEnumerable<string> inputLines)
        {
            var inputs = inputLines.First().Split(',').Select(long.Parse).ToArray();
            var outputs = Calculator.Process(inputs, 1);
            return string.Join(',', outputs);
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            var inputs = inputLines.First().Split(',').Select(long.Parse).ToArray();
            var outputs = Calculator.Process(inputs, 5);
            return string.Join(',', outputs);
        }
    }
}
