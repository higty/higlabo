namespace HigLabo.Bing
{
    public class RelatedSearchAnswer
    {
        public string Id { get; set; } = "";
        public Query[] Value { get; set; } = Array.Empty<Query>();
    }
}
