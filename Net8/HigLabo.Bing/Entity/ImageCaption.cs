namespace HigLabo.Bing
{
    public class ImageCaption
    {
        public string Caption { get; set; } = "";
        public string DataSourceUrl { get; set; } = "";
        public Query? RelatedSearches { get; set; }

        public override string ToString()
        {
            return this.Caption;
        }
    }
}
