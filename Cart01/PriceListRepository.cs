using System.Collections.Generic;

namespace Cart01
{
    internal class PriceListRepository : IPriceListRepository
    {
        public int GetPriceFor(string sku)
        {
            return GetPriceList()[sku];
        }
        static Dictionary<string, int> GetPriceList()
        {
            return new Dictionary<string, int>
            {
                {"A99", 50},
                {"B15", 30},
                {"C40", 60},
                {"T34", 99},
            };
        }
    }
}