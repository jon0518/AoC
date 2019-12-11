using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2019._02
{
    class Solver : AbstractSolver, ISolver
    {       

        public void SolvePart1()
        {
            Console.WriteLine(solve(12,2));
        }

        long solve(int noun, int verb)
        {
            var input = base.GetInput().Split(',').Select(long.Parse).ToArray();
            input[1] = noun;
            input[2] = verb;
            Calculator.Process(input);
            return input[0];
        }

        public void SolvePart2()
        {
            for(int i=0; i<100; i++)
                for(int j = 0; j< 100; j++)
                    if(solve(i,j) == 19690720)
                    {
                        Console.WriteLine(100 * i + j);
                        return;
                    }
        }

        public void TestPart1()
        {
            var input = "1,1,1,4,99,5,6,0,99".Split(',').Select(long.Parse).ToArray();
            Calculator.Process(input);
        }

        public void TestPart2()
        {
            throw new NotImplementedException();
        }
    }
}
