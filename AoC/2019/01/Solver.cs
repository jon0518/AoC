using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2019._01
{
    public class Solver : AbstractSolver, ISolver
    {
        public static int CalcPart1(int input)
        {
            return input / 3 - 2;
        }     

        public static int CalcPart2(int val)
        {
            var total = 0;
            while (CalcPart1(val) > 0)
            {
                val = CalcPart1(val);
                total += val;
            }
            return total;
        }

        public string SolvePart1(IEnumerable<string> inputLines)
        {
            long total = 0;
            foreach (var line in inputLines.Select(int.Parse))
            {
                total += CalcPart1(line);
            }
            return total.ToString();
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            long total = 0;
            foreach (var line in inputLines.Select(int.Parse))
            {
                total += CalcPart2(line);
            }
            return total.ToString();
        }
    }
}
