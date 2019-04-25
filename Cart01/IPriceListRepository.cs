namespace Cart01
{
    public interface IPriceListRepository
    {
        int GetPriceFor(string sku);
    }
}