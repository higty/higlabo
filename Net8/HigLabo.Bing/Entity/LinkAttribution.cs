namespace HigLabo.Bing
{
    public class LinkAttribution
    {
        public string _Type { get; set; } = "";
        public bool? MustBeCloseToContent { get; set; }
        public string TargetPropertyName { get; set; } = "";
        public string Text { get; set; } = "";
        public string Url { get; set; } = "";
    }
}
