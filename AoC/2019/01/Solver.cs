using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AoC._2019._01
{
    class Solver : AbstractSolver, ISolver
    {
        public void TestPart1()
        {
            foreach(var inp in new List<int>() { 12,14,1969, 100756 })
            {
                Console.WriteLine(CalcPart1(inp));
            }
        }

        public void SolvePart1()
        {
            var input = base.GetInputLines();
            long total = 0;
            foreach (var line in input.Select(int.Parse))
            {
                total += CalcPart1(line);
            }
            Console.WriteLine(total);
        }
        private int CalcPart1(int input)
        {
            return input / 3 - 2;
        }


        public void TestPart2()
        {
            foreach (var inp in new List<int>() { 14, 1969, 100756 })
            {
                Console.WriteLine(CalcPart2(inp));
            }
        }



        public void SolvePart2()
        {
            var input = base.GetInputLines();
            long total = 0;
            foreach (var line in input.Select(int.Parse))
            {
                total += CalcPart2(line);
            }
            Console.WriteLine(total);
        }

        private int CalcPart2(int val)
        {
            var total = 0;
            while (CalcPart1(val) > 0)
            {
                val = CalcPart1(val);
                total += val;
            }
            return total;
        }
    }
}
