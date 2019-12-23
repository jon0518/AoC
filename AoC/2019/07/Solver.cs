using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._07
{
    public class Solver : AbstractSolver, ISolver
    {        
        public string SolvePart1(IEnumerable<string> inputLines)
        {
            var inputs = inputLines.First().Split(',').Select(long.Parse).ToArray();
            long max = 0;
            for (int a = 0; a < 5; a++)
                for (int b = 0; b < 5; b++)
                    for (int c = 0; c < 5; c++)
                        for (int d = 0; d < 5; d++)
                            for (int e = 0; e < 5; e++)
                            {
                                if (a != b && a != c && a != d && a != e && b != c && b != d && b != e && c != d && c != e && d != e)
                                {
                                    max = Math.Max(max, Calculator.Process(inputs, Calculator.Process(inputs, Calculator.Process(inputs, Calculator.Process(inputs, Calculator.Process(inputs, 0, a).Last(), b).Last(), c).Last(), d).Last(), e).Last());
                                }
                            }
            return max.ToString();
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            throw new NotImplementedException();
        }
    }
}
