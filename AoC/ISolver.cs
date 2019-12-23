using System;
using System.Collections.Generic;
using System.Text;

namespace AoC
{
    public interface ISolver
    {
        string SolvePart1(IEnumerable<string> inputLines);
        string SolvePart2(IEnumerable<string> inputLines);
        IEnumerable<string> GetInputLines();
    }
}
