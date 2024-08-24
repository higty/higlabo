using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/webpartdata?view=graph-rest-1.0
    /// </summary>
    public partial class WebPartData
    {
        public String[]? Audiences { get; set; }
        public string? DataVersion { get; set; }
        public string? Description { get; set; }
        public Json? Properties { get; set; }
        public ServerProcessedContent? ServerProcessedContent { get; set; }
        public string? Title { get; set; }
    }
}
