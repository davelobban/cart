using System.Collections.Generic;
using Cart01;
using NUnit.Framework;

namespace Tests
{
    public class CartTests

    {
        private static void AssertActualTotalEqualsExpectedTotal(int expected, Cart subject)
        {
            var actual = subject.Total;
            Assert.AreEqual(actual, expected);
        }

        private static Cart GetTestSubject()
        {
            var subject = new Cart();
            return subject;
        }

        private static void ScanAll(List<string> skus, Cart subject)
        {
            foreach (var sku in skus)
            {
                subject.Scan(sku);
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("A99", 50)]
        [TestCase("B15", 30)]
        [TestCase("C40", 60)]
        [TestCase("T34", 99)]
        public void Total_SingleItemScanned_UnitPriceReturned(string sku, int expected)
        {
            var subject = GetTestSubject();
            subject.Scan(sku);
            AssertActualTotalEqualsExpectedTotal(expected, subject);
        }

        [TestCase("A99", "B15", 80)]
        [TestCase("B15", "A99", 80)]
        [TestCase("C40", "A99", 110)]
        [TestCase("T34", "A99", 149)]
        public void Total_SingleItemsOfMultipleSkusScanned_ExpectedPriceReturned(string sku1, string sku2, int expected)
        {
            var subject = GetTestSubject();
            var skus = new List<string> {sku1, sku2};
            ScanAll(skus, subject);
            AssertActualTotalEqualsExpectedTotal(expected, subject);
        }

    }
}