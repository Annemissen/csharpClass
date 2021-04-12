using NUnit.Framework;
using ConsoleAppCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCalculator.Tests
{
    [TestFixture()]
    public class CalculatorTests
    {
        [Test()]
        public void AddTest()
        {
            Assert.That(Calculator.Add(5, 3), Is.EqualTo(8));
        }

        [Test()]
        public void SubstractTest()
        {
            Assert.That(Calculator.Substract(8, 3), Is.EqualTo(5));
        }

        [Test()]
        public void MultiplyTest()
        {
            Assert.That(Calculator.Multiply(5, 3), Is.EqualTo(15));
        }

        [Test()]
        public void DivideTest()
        {
            Assert.That(Calculator.Divide(15, 3), Is.EqualTo(5));
        }
    }
}