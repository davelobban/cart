using System.Collections.Generic;
using System.Linq;

namespace Cart01
{
    public class Cart
    {
        private readonly IPriceListRepository _priceList;
        private readonly IDictionary<string, int> _scannedSkus = new Dictionary<string, int>();
        private readonly ISpecialOfferRepository _offers;

        public Cart()
        {
            _priceList =  new PriceListRepository();
            _offers = new SpecialOfferRepository();
        }

        public void Scan(string sku)
        {
            _scannedSkus[sku] = (_scannedSkus.ContainsKey(sku) ? _scannedSkus[sku] : 0) + 1;
        }

        public int Total
        {
            get
            {
                var priceList = _priceList;
                var offers = _offers;
                var scannedSkus = _scannedSkus;

                return TotalCalculator.GetTotal(scannedSkus, offers, priceList);
            }
        }
    }
}
