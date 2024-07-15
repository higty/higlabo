namespace HigLabo.Bing
{
    public class Query
    {
        public string DisplayText { get; set; } = "";
        public string Text { get; set; } = "";
        public string WebSearchUrl { get; set; } = "";

        public override string ToString()
        {
            return this.DisplayText;
        }
    }
}
