using System.Collections.Generic;

namespace Cart01
{
    internal class TotalCalculator
    {
        internal static int GetTotal(IDictionary<string, int> scannedSkus, ISpecialOfferRepository offers, IPriceListRepository priceList)
        {
            var total = 0;

            foreach (var sku in scannedSkus.Keys)
            {
                var numberOfItemsScannedForSku = scannedSkus[sku];
                var specialOffer = offers.GetOfferFor(sku);
                if (specialOffer.Found)
                {
                    var offer = specialOffer.Offer;
                    var numberOfTimeSpecialOfferScanned = numberOfItemsScannedForSku / offer.Quantity;
                    total += offer.Price * numberOfTimeSpecialOfferScanned;
                    numberOfItemsScannedForSku -= offer.Quantity * numberOfTimeSpecialOfferScanned;
                }

                total += priceList.GetPriceFor(sku) * numberOfItemsScannedForSku;
            }

            return total;
        }
    }
}