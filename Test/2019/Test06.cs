using AoC._2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test._2019
{
    [TestClass]
    public class Test06
    {
        [TestMethod]
        public void TestPart1()
        {
            var input = @"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L";
            Assert.AreEqual("42", new AoC._2019._06.Solver().SolvePart1(input.Split(Environment.NewLine)));           
        }        

    }
}
