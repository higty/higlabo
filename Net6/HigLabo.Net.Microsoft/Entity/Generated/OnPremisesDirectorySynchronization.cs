using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/onpremisesdirectorysynchronization?view=graph-rest-1.0
    /// </summary>
    public partial class OnPremisesDirectorySynchronization
    {
        public OnPremisesDirectorySynchronizationConfiguration? Configuration { get; set; }
        public OnPremisesDirectorySynchronizationFeature? Features { get; set; }
        public string? Id { get; set; }
    }
}
