using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/linkedresource?view=graph-rest-1.0
    /// </summary>
    public partial class LinkedResource
    {
        public string? ApplicationName { get; set; }
        public string? DisplayName { get; set; }
        public string? ExternalId { get; set; }
        public string? Id { get; set; }
        public string? WebUrl { get; set; }
    }
}
