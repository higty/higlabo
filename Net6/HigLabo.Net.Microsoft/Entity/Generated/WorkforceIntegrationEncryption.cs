using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/workforceintegrationencryption?view=graph-rest-1.0
    /// </summary>
    public partial class WorkforceIntegrationEncryption
    {
        public string? Protocol { get; set; }
        public string? Secret { get; set; }
    }
}
