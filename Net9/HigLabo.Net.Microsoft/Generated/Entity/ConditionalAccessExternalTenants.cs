using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/conditionalaccessexternaltenants?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessExternalTenants
{
    public enum ConditionalAccessExternalTenantsConditionalAccessExternalTenantsMembershipKind
    {
        All,
        Enumerated,
        UnknownFutureValue,
    }

    public ConditionalAccessExternalTenantsConditionalAccessExternalTenantsMembershipKind MembershipKind { get; set; }
}
