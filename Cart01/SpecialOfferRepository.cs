using System.Collections.Generic;

namespace Cart01
{
    public class SpecialOfferRepository
    {
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