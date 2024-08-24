using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/communicationsapplicationidentity?view=graph-rest-1.0
    /// </summary>
    public partial class CommunicationsApplicationIdentity
    {
        public string? ApplicationType { get; set; }
        public string? DisplayName { get; set; }
        public bool? Hidden { get; set; }
        public string? Id { get; set; }
    }
}
