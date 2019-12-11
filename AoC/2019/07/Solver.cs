using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._07
{
    class Solver : AbstractSolver, ISolver
    {
        public void SolvePart1()
        {
            Console.WriteLine(solve1(base.GetInput().Split(',').Select(long.Parse).ToArray()));
        }

        public void SolvePart2()
        {
            throw new NotImplementedException();
        }

        long solve1(long[] inputs)
        {
            long max = 0;
            for(int a = 0; a<5; a++)
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
            return max;
        }

        public void TestPart1()
        {            
            Console.WriteLine(solve1(@"3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0".Split(',').Select(long.Parse).ToArray()));
            Console.WriteLine(solve1(@"3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0".Split(',').Select(long.Parse).ToArray()));
            Console.WriteLine(solve1(@"3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0".Split(',').Select(long.Parse).ToArray()));
        }

        public void TestPart2()
        {
            throw new NotImplementedException();
        }
    }
}
