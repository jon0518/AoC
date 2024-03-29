﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._09
{
    public class Solver : AbstractSolver, ISolver
    {
        public string SolvePart1(IEnumerable<string> inputLines)
        {
            return Calculator.Process(inputLines.First().Split(',').Select(long.Parse).ToArray()).Last().ToString();
        }

        public string SolvePart2(IEnumerable<string> inputLines)
        {
            return Calculator.Process(inputLines.First().Split(',').Select(long.Parse).ToArray(), 2, 2).Last().ToString();
        }        
    }
}
