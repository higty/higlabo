using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-acl?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsAcl
{
    public enum ExternalConnectorsAclExternalConnectorsAccessType
    {
        Grant,
        Deny,
        UnknownFutureValue,
    }
    public enum ExternalConnectorsAclExternalConnectorsAclType
    {
        User,
        Group,
        Everyone,
        EveryoneExceptGuests,
        ExternalGroup,
        UnknownFutureValue,
    }

    public ExternalConnectorsAclExternalConnectorsAccessType AccessType { get; set; }
    public ExternalConnectorsAclExternalConnectorsAclType Type { get; set; }
    public string? Value { get; set; }
}
