using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC._2019._05
{
    class Solver : AbstractSolver, ISolver
    {
        public void SolvePart1()
        {
            var inputs = base.GetInput().Split(',').Select(int.Parse).ToArray();
            var outputs = Calculator.Process(inputs, 1);
            foreach (var i in outputs)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
                    
        }

        public void SolvePart2()
        {
            var inputs = base.GetInput().Split(',').Select(int.Parse).ToArray();
            var outputs = Calculator.Process(inputs, 5);
            foreach (var i in outputs)
            {
                Console.Write(i + ",");
            }
            Console.WriteLine();
        }

        public void TestPart1()
        {
            throw new NotImplementedException();
        }

        public void TestPart2()
        {
            throw new NotImplementedException();
        }
    }
}
