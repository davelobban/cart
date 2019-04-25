using Cart01;
using NUnit.Framework;

namespace Tests
{
    public class CartTests

    {
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
            var subject = new Cart();
            subject.Scan(sku);
            var actual = subject.Total;
            Assert.AreEqual(actual, expected);
        }


        [TestCase("A99", "B15", 80)]
        [TestCase("B15", "A99", 80)]
        [TestCase("C40", "A99", 110)]
        [TestCase("T34", "A99", 149)]
        public void Total_SingleItemsOfMultipleSkusScanned_ExpectedPriceReturned(string sku1, string sku2, int expected)
        {
            var subject = new Cart();
            subject.Scan(sku1);
            subject.Scan(sku2);
            var actual = subject.Total;
            Assert.AreEqual(actual, expected);
        }
    }
}