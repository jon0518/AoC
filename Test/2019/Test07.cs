using AoC._2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test._2019
{
    [TestClass]
    public class Test07
    {
        [TestMethod]
        public void TestPart1()
        {
            Assert.AreEqual("43210", new AoC._2019._07.Solver().SolvePart1(@"3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0".Split(';')));
            Assert.AreEqual("54321", new AoC._2019._07.Solver().SolvePart1(@"3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0".Split(';')));
            Assert.AreEqual("65210", new AoC._2019._07.Solver().SolvePart1(@"3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0".Split(';')));           
        }       
    }
}
