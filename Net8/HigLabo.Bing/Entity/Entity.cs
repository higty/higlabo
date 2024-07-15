namespace HigLabo.Bing
{
    public class Entity
    {
        public string BingId { get; set; } = "";
        public ContractualRule[]? ContractualRules { get; set; }
        public string Description { get; set; } = "";
        public string Name { get; set; } = "";
        public string WebSearchUrl { get; set; } = "";

        public override string ToString()
        {
            return this.Name;
        }
    }
}
