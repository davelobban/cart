using System;
using System.Collections.Generic;

namespace Cart01
{
    public class Cart
    {
        private IDictionary<string, int> _priceList;
        private IDictionary<string, int> _scannedSkus= new Dictionary<string, int>();
        
        public Cart()
        {
            _priceList = new Dictionary<string, int>
            {
                {"A99", 50},
                {"B15", 30},
                {"C40", 60},
                {"T34", 99},
            };
        }

        public void Scan(string sku)
        {
            _scannedSkus.Add(sku,1);
        }

        public int Total
        {
            get
            {
                var total = 0;
                foreach (var sku in _scannedSkus.Keys)
                {
                    total += _priceList[sku];
                }

                return total;
            }
        }
    }
}
