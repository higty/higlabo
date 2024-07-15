namespace HigLabo.Bing
{
    public class Place
    {
        public string _Type { get; set; } = "";
        public PostalAddress? Address { get; set; } 
        public EntityPresentationInfo? EntityPresentationInfo { get; set; } 
        public string Name { get; set; } = "";
        public string Telephone { get; set; } = "";
        public string Url { get; set; } = "";
        public string WebSearchUrl { get; set; } = "";

        public override string ToString()
        {
            return this.Name;
        }
    }
}
