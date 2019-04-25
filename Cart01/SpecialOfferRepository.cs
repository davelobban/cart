using System.Collections.Generic;
using System.Linq;

namespace Cart01
{
    internal class SpecialOfferRepository : ISpecialOfferRepository
    {
        public (bool Found, SpecialOffer Offer) GetOfferFor(string sku)
        {
            //return GetSpecialOffers().FirstOrDefault(s => s.Sku == sku);
            var specialOfferFound = GetSpecialOffers().Any(s => s.Sku == sku);
            if (specialOfferFound)
            {
                return (true, GetSpecialOffers().First(s => s.Sku == sku));
            }

            return (false, new SpecialOffer("",0,0));
        }

        internal static List<SpecialOffer> GetSpecialOffers()
        {
            return new List<SpecialOffer>
            {
                new SpecialOffer("A99",3,130),
                new SpecialOffer("B15",2,45),
            };
        }
    }
}