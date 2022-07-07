using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/requiredresourceaccess?view=graph-rest-1.0
    /// </summary>
    public partial class RequiredResourceAccess
    {
        public ResourceAccess[]? ResourceAccess { get; set; }
        public string? ResourceAppId { get; set; }
    }
}
