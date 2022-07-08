using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/identityproviderbase?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityProviderBase
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
    }
}
