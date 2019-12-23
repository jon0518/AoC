using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace AoC
{
    public abstract class AbstractSolver 
    {
        public IEnumerable<string> GetInputLines()
        {
            return File.ReadAllLines(GetInputFile()).ToList();
        }

        private string GetInputFile()
        {
            var ns = GetType().Namespace.Split('.').Select(x => x.Replace("_", string.Empty)).ToList();
            return $@"{Environment.CurrentDirectory}\{ns[1]}\{ns[2]}\input.txt";
        }

    }
}
