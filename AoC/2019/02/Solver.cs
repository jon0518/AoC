using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2019._02
{
    public class Solver : AbstractSolver, ISolver
    {       
        long solve(long[] input, int noun, int verb)
        {
            input[1] = noun;
            input[2] = verb;
            Calculator.Process(input);
            return input[0];
        }

        public string SolvePart1(IEnumerable<string> inputLines)
        {
            var ins = inputLines.First().Split(',').Select(long.Parse).ToArray();
            return solve(ins, 12, 2).ToString();
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            var ins = inputLines.First().Split(',').Select(long.Parse).ToArray();
            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    if (solve(ins, i, j) == 19690720)
                        return (100 * i + j).ToString();
            return string.Empty;
        }
    }
}
