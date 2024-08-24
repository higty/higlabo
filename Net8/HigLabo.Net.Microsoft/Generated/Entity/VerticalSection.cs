using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/verticalsection?view=graph-rest-1.0
    /// </summary>
    public partial class VerticalSection
    {
        public enum VerticalSectionSectionEmphasisType
        {
            None,
            Netural,
            Soft,
            Strong,
            UnknownFutureValue,
        }

        public VerticalSectionSectionEmphasisType Emphasis { get; set; }
        public string? Id { get; set; }
        public WebPart[]? Webparts { get; set; }
    }
}
