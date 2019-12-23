using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test._2019
{
    [TestClass]
    public class Test01
    {
        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual(2, AoC._2019._01.Solver.CalcPart1(12));
            Assert.AreEqual(2, AoC._2019._01.Solver.CalcPart1(14));
            Assert.AreEqual(654, AoC._2019._01.Solver.CalcPart1(1969));
            Assert.AreEqual(33583, AoC._2019._01.Solver.CalcPart1(100756));
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual(2, AoC._2019._01.Solver.CalcPart2(14));
            Assert.AreEqual(966, AoC._2019._01.Solver.CalcPart2(1969));
            Assert.AreEqual(50346, AoC._2019._01.Solver.CalcPart2(100756));
        }
    }
}
