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
        public void Total_SingleItemScanned_UnitPriceReturned(string sku, int expected)
        {
            var subject = new Cart();
            subject.Scan(sku);
            var actual = subject.Total;
            Assert.AreEqual(actual, expected);
        }
    }
}