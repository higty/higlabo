using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/multitenantorganizationidentitysyncpolicytemplate?view=graph-rest-1.0
    /// </summary>
    public partial class MultiTenantOrganizationIdentitySyncPolicyTemplate
    {
        public enum MultiTenantOrganizationIdentitySyncPolicyTemplateTemplateApplicationLevel
        {
            None,
            NewPartners,
            ExistingPartners,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public MultiTenantOrganizationIdentitySyncPolicyTemplateTemplateApplicationLevel TemplateApplicationLevel { get; set; }
        public CrossTenantUserSyncInbound? UserSyncInbound { get; set; }
    }
}
