using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/singleserviceprincipal?view=graph-rest-1.0
    /// </summary>
    public partial class SingleServicePrincipal
    {
        public string? Description { get; set; }
        public string? ServicePrincipalId { get; set; }
    }
}
