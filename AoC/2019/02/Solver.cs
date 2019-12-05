using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2019._02
{
    class Solver : AbstractSolver, ISolver
    {
        private void process(int[] inputs)
        {
            int i = 0;
            while(inputs[i] != 99)
            {
                inputs[inputs[i + 3]] = inputs[i] == 1 ? (inputs[inputs[i + 1]] + inputs[inputs[i + 2]]) : (inputs[inputs[i + 1]] * inputs[inputs[i + 2]]);
                i += 4;
            }
            foreach(var val in inputs)
            {
                Console.Write(val + ",");
            }
            Console.WriteLine();
            Console.WriteLine(inputs[0]);
        }

        public void SolvePart1()
        {
            
        }

        int solve(int noun, int verb)
        {
            var input = base.GetInput().Split(',').Select(int.Parse).ToArray();
            input[1] = noun;
            input[2] = verb;
            process(input);
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
            var input = "1,1,1,4,99,5,6,0,99".Split(',').Select(int.Parse).ToArray();
            process(input);
        }

        public void TestPart2()
        {
            throw new NotImplementedException();
        }
    }
}
