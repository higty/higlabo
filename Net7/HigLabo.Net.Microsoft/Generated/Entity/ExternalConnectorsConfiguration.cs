using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-configuration?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsConfiguration
    {
        public String[]? AuthorizedAppIds { get; set; }
    }
}
