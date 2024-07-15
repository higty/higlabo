namespace HigLabo.Bing
{
    public enum ItemAvailability
    {
        Discontinued,
        InStock,
        InStoreOnly,
        LimitedAvailability,
        OnlineOnly,
        OutOfStock,
        PreOrder,
        SoldOut,
    }
    public class Offer
    {
        public AggregateRating? AggregateRating { get; set; } 
        public ItemAvailability Availability { get; set; }
        public string Description { get; set; } = "";
        public string LastUpdated { get; set; } = "";
        public float LowPrice { get; set; }
        public string Name { get; set; } = "";
        public UInt32? OfferCount { get; set; }
        public float? Price { get; set; }
        public string PriceCurrency { get; set; } = "";
        public Organization? Seller { get; set; } 
        public string Url { get; set; } = "";

        public override string ToString()
        {
            return this.Name;
        }
    }
}
