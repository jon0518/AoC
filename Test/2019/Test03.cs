using AoC._2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test._2019
{
    [TestClass]
    public class Test03
    {
        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("6", new AoC._2019._03.Solver().SolvePart1(@"R8,U5,L5,D3;U7,R6,D4,L4".Split(';')));           
        }

        [TestMethod]
        public void TestPart2()
        {
            Assert.AreEqual("410", new AoC._2019._03.Solver().SolvePart2(@"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51;U98,R91,D20,R16,D67,R40,U7,R15,U6,R7".Split(';')));
        }


    }
}
