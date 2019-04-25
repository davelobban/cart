namespace Cart01
{
    struct SpecialOffer
    {
        internal string Sku { get; }
        internal int Quantity { get; }
        internal int Price { get; }

        internal SpecialOffer(string sku, int quantity, int price)
        {
            Sku = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}