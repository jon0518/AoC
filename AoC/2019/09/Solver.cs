using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._09
{
    class Solver : AbstractSolver, ISolver
    {
        public void SolvePart1()
        {
            Console.WriteLine(Calculator.Process(base.GetInput().Split(',').Select(long.Parse).ToArray()).Last());
        }

        public void SolvePart2()
        {
            Console.WriteLine(Calculator.Process(base.GetInput().Split(',').Select(long.Parse).ToArray(),2,2).Last());
        }

        public void TestPart1()
        {
            var output = Calculator.Process(@"109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99".Split(',').Select(long.Parse).ToArray());
            foreach(var o in output)
            {
                Console.Write(o+",");
            }
            Console.WriteLine();
        }

        public void TestPart2()
        {
            throw new NotImplementedException();
        }
    }
}
