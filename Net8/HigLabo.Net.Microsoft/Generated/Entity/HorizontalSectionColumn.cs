using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/horizontalsectioncolumn?view=graph-rest-1.0
    /// </summary>
    public partial class HorizontalSectionColumn
    {
        public string? Id { get; set; }
        public Int32? Width { get; set; }
        public WebPart[]? Webparts { get; set; }
    }
}
