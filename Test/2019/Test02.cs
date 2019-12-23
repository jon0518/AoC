using AoC._2019;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test._2019
{
    [TestClass]
    public class Test02
    {
        [TestMethod]
        public void TestPart1_1()
        {
            var input = "1,9,10,3,2,3,11,0,99,30,40,50".Split(',').Select(long.Parse).ToArray();
            Calculator.Process(input);
            Assert.AreEqual(3500, input[0]);           
        }

        [TestMethod]
        public void TestPart1_2()
        {
            var input = "1,0,0,0,99".Split(',').Select(long.Parse).ToArray();
            Calculator.Process(input);
            Assert.AreEqual(2, input[0]);
        }

        [TestMethod]
        public void TestPart1_3()
        {
            var input = "2,3,0,3,99".Split(',').Select(long.Parse).ToArray();
            Calculator.Process(input);
            Assert.AreEqual(6, input[3]);
        }

        [TestMethod]
        public void TestPart1_4()
        {
            var input = "2,4,4,5,99,0".Split(',').Select(long.Parse).ToArray();
            Calculator.Process(input);
            Assert.AreEqual(9801, input[5]);
        }

        [TestMethod]
        public void TestPart1_5()
        {
            var input = "1,1,1,4,99,5,6,0,99".Split(',').Select(long.Parse).ToArray();
            Calculator.Process(input);
            Assert.AreEqual(30, input[0]);
        }
    }
}
