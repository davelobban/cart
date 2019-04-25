using System.Collections.Generic;
using System.Linq;

namespace Cart01
{
    public class Cart
    {
        private IPriceListRepository _priceList;
        private IDictionary<string, int> _scannedSkus = new Dictionary<string, int>();
        private IEnumerable<SpecialOffer> _offers;

        public Cart()
        {
            _priceList =  new PriceListRepository();
            _offers = SpecialOfferRepository.GetSpecialOffers();
        }

        public void Scan(string sku)
        {
            _scannedSkus[sku] = (_scannedSkus.ContainsKey(sku) ? _scannedSkus[sku] : 0) + 1;
        }

        //public int Total
        //{
        //    get { return GetTotal(_scannedSkus, _priceList, _offers); }
        //}
        public int Total
        {
            get
            {
                var priceList = _priceList;
                var total = 0;

                foreach (var sku in _scannedSkus.Keys)
                {
                    var numberOfItemsScannedForSku = _scannedSkus[sku];
                    var specialOfferFound = _offers.Any(s => s.Sku == sku);
                    if (specialOfferFound)
                    {
                        var specialOffer = _offers.First(s => s.Sku == sku);
                        var numberOfTimeSpecialOfferScanned = numberOfItemsScannedForSku / specialOffer.Quantity;
                        total += specialOffer.Price * numberOfTimeSpecialOfferScanned;
                        numberOfItemsScannedForSku -= specialOffer.Quantity * numberOfTimeSpecialOfferScanned;
                    }

                    total += priceList.GetPriceFor(sku) * numberOfItemsScannedForSku;
                }

                return total;
            }
        }


        
    }
}
