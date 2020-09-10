using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Tests
{
    public class CalculatorTest
    {
        [Fact]
        public void Add_GivenTwoDoubleValues_ReturnsDouble()
        {
            double result = Calculator.Program.Add(99.03333333, 44.3);
            Assert.Equal(143.3, result, 1); //the 1 sets decimal precision.
        }

        [Theory]
        [CalculatorData]
        public void Add_GivenTwoDoubles_ReturnsDouble(double numA, double numB, double expected)
        {
            double result = Calculator.Program.Add(numA, numB);
            Assert.Equal(expected, result);
        }

        [Theory]
        [CalculatorData]
        public void Subtract_GivenTwoDoubles_ReturnsDouble(double numA, double numB, double expected)
        {
            double result = Calculator.Program.Subtract(numA, numB);
            Assert.Equal(expected, result);
        }

        [Theory]
        [CalculatorData]
        public void Divide_GivenTwoDoubles_ReturnsDouble(double numA, double numB, double expected)
        {
            if(numB != 0)
            {
                double result = Calculator.Program.Divide(numA, numB);
                Assert.Equal(expected, result);
            }
            else
            {
                var errorDetails = Assert.Throws<DivideByZeroException>(() => Calculator.Program.Divide(numA, numB));
            }

        }

        [Theory]
        [Trait("Category", "MathOperation")]
        [InlineData(23, 0)]
        public void Divide_GivenTwoDoublesThe2ndBeingZero_ThrowsException(double numA, double numB)
        {
            var errorDetails = Assert.Throws<DivideByZeroException>(() => Calculator.Program.Divide(numA, numB));
        }

        [Theory]
        [CalculatorData]
        public void Multiply_GivenTwoDoubles_ReturnsDouble(double numA, double numB, double expected)
        {
            double result = Calculator.Program.Multiply(numA, numB);
            Assert.Equal(expected, result);
        }
    }
}
