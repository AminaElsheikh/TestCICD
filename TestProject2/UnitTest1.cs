using System;
using Xunit;

namespace TestProject2
{
    public class UnitTest1
    {
        [Fact]
        public void AddTwoNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var calculator = new Calculator();
            int num1 = 4;
            int num2 = 4;

            // Act
            int result = calculator.Add(num1, num2);

            // Assert
            Assert.Equal(7, result);
        }
    }

    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}