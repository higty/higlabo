using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/b2xidentityuserflow?view=graph-rest-1.0
    /// </summary>
    public partial class B2xIdentityUserFlow
    {
        public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
        public string? Id { get; set; }
        public string? UserFlowType { get; set; }
        public Single? UserFlowTypeVersion { get; set; }
        public IdentityProvider[]? IdentityProviders { get; set; }
        public UserFlowLanguageConfiguration[]? Languages { get; set; }
        public IdentityUserFlowAttributeAssignment[]? UserAttributeAssignments { get; set; }
    }
}
