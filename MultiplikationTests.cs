using Aufnahmepruefung;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MultTest
{
    [TestClass]
    public class MultiplikationTests
    {
        [TestMethod]
        [DataRow(257, 17)]
        [DataRow(256, 17)]
        [DataRow(255, 17)]
        [DataRow(1, 17)]
        [DataRow(1, 0)]
        [DataRow(0, 17)]
        [DataRow(0, 0)]
        public void TestEdgeCases(int x, int y)
        {
            // Arrange
            int expectedResult = x * y;

            // Act
            int product = Multiplikation.Mul(x, y);

            // Assert
            Assert.AreEqual(expectedResult, product);
        }


        [TestMethod]
        [DataRow(1000)]
        public void TestRandomCases(int count)
        {
            // Arrange
            var random = new Random();
            var values = new List<(int, int)>();

            for (int i = 0; i < count; i++)
            {
                values.Add((random.Next(), random.Next()));
            }

            // Act + Assert
            foreach ((int x, int y) in values)
            {
                Assert.AreEqual(x * y, Multiplikation.Mul(x, y));
            }
        }
    }
}
