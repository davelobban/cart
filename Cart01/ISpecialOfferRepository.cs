namespace Cart01
{
    internal interface ISpecialOfferRepository
    {
        (bool Found, SpecialOffer Offer) GetOfferFor(string sku);
    }
}