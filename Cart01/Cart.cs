using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Cart01
{
    public class Cart
    {
        private IDictionary<string, int> _priceList;
        private IDictionary<string, int> _scannedSkus= new Dictionary<string, int>();
        private IEnumerable<SpecialOffer> _offers;
        struct SpecialOffer
        {
            internal string Sku { get; }
            internal int Quantity { get; }
            internal int Price { get; }

            internal SpecialOffer(string sku, int quantity, int price )
            {
                Sku = sku;
                Quantity = quantity;
                Price = price;
            }
        }
        
        public Cart()
        {
            _priceList = new Dictionary<string, int>
            {
                {"A99", 50},
                {"B15", 30},
                {"C40", 60},
                {"T34", 99},
            };
            _offers= new List<SpecialOffer>
            {
                new SpecialOffer("B15",2,45)
            };
        }

        public void Scan(string sku)
        {
            _scannedSkus[sku] =  (_scannedSkus.ContainsKey(sku) ? _scannedSkus[sku] : 0)+1;
        }

        public int Total
        {
            get
            {
                var total = 0;

                foreach (var sku in _scannedSkus.Keys)
                {
                    var numberOfItemsScannedForSku = _scannedSkus[sku];
                    var specialOfferFound = _offers.Any(s=>s.Sku==sku);
                    if (specialOfferFound)
                    {
                        var specialOffer = _offers.First(s => s.Sku == sku);
                        var numberOfTimeSpecialOfferScanned = numberOfItemsScannedForSku / specialOffer.Quantity;
                        total += specialOffer.Price * numberOfTimeSpecialOfferScanned;
                        numberOfItemsScannedForSku -= specialOffer.Quantity * numberOfTimeSpecialOfferScanned;
                    }

                    total += _priceList[sku]*numberOfItemsScannedForSku;
                }

                return total;
            }
        }
    }
}
