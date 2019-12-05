using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace AoC
{
    public class SolverFactory
    {
        public static ISolver GetSolver(int year, int day)
        {
            var dayAsString = day.ToString().PadLeft(2, '0');
            var type = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces()
                .Contains(typeof(ISolver)))
                .FirstOrDefault(x => x.FullName.Contains(year.ToString()) && x.FullName.Contains(dayAsString));
            return Activator.CreateInstance(type) as ISolver;
        }
    }
}
