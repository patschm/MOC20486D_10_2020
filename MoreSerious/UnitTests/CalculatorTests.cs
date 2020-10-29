using BusinessLogic;
using System;
using Xunit;

namespace UnitTests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAdd()
        {
            // Arrange
            int a = 10;
            int b = 20;
            int expected = 30;
            Calculator calc = new Calculator();

            // Act
            int actual = calc.Add(a, b);

            // Assert
            Assert.Equal(actual, expected);
        }
        [Fact]
        public void TestSubtract()
        {
            // Arrange
            int a = 10;
            int b = 20;
            int expected = -10;
            Calculator calc = new Calculator();

            // Act
            int actual = calc.Subtract(a, b);

            // Assert
            Assert.Equal(actual, expected);

        }
    }
}
