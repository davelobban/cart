using System.Collections.Generic;
using System.Linq;

namespace Cart01
{
    internal class SpecialOfferRepository : ISpecialOfferRepository
    {

        static List<SpecialOffer>  _specialOffers = new List<SpecialOffer>
        {
            new SpecialOffer("A99",3,130),
            new SpecialOffer("B15",2,45),
        };
        public (bool Found, SpecialOffer Offer) GetOfferFor(string sku)
        {
            var specialOfferFound = _specialOffers.Any(s => s.Sku == sku);
            if (specialOfferFound)
            {
                return (true, _specialOffers.First(s => s.Sku == sku));
            }

            return (false, new SpecialOffer("",0,0));
        }

    }
}