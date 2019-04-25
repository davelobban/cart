using System.Collections.Generic;

namespace Cart01
{
    internal class PriceListRepository : IPriceListRepository
    {
        static Dictionary<string, int> _priceList = new Dictionary<string, int>
        {
            {"A99", 50},
            {"B15", 30},
            {"C40", 60},
            {"T34", 99},
        };

        public int GetPriceFor(string sku)
        {
            return _priceList[sku];
        }

    }
}