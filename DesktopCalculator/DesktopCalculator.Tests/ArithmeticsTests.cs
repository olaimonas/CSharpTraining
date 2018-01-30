using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesktopCalculator.Tests
{
    [TestClass]
    public class ArithmeticsTests
    {
        [TestMethod]
        public void TwoPlusTwoIsFour()
        {
            // Arrange
            int num1 = 3;
            int num2 = 2;
            string action = "+";
            int expectedResult = 4;
            Arithmetics arithmetics = new Arithmetics();

            // Act
            int actualResult = arithmetics.Calculate(num1, num2, action);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
