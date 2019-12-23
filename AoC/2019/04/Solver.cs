using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._04
{
    public class Solver : AbstractSolver, ISolver
    {

        int GetValue(int i, string number, int min, int max, int part)
        {
            if(number.Length == 6)
            {
                if(int.Parse(number) >= min && int.Parse(number) <= max && ((part == 1 && Regex.IsMatch(number, @"(.)\1")) || (part == 2 && Regex.Matches(number, @"(.)\1+").Any(x => x.Value.Length == 2))))
                {
                    Console.WriteLine(number);
                    return 1;
                }
                return 0;
            }
            var count = 0;
            for(int j = i; j<=9; j++)
            {
                count += GetValue(j, number + j, min, max, part);
            }
            return count;
        }

        public string SolvePart1(IEnumerable<string> inputLines)
        {
            var input = inputLines.First().Split('-').Select(int.Parse).ToArray();
            return GetValue(1, string.Empty, input[0], input[1], 1).ToString();
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            var input = inputLines.First().Split('-').Select(int.Parse).ToArray();
            return GetValue(1, string.Empty, input[0], input[1], 2).ToString();
        }
    }
}
