using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-identity?view=graph-rest-1.0
    /// </summary>
    public partial class ExternalConnectorsIdentity
    {
        public enum ExternalConnectorsIdentityExternalConnectorsIdentityType
        {
            User,
            Group,
            Externalgroup,
        }

        public string? Id { get; set; }
        public ExternalConnectorsIdentityExternalConnectorsIdentityType Type { get; set; }
    }
}
