using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/delegatedadminaccesscontainer?view=graph-rest-1.0
/// </summary>
public partial class DelegatedAdminAccessContainer
{
    public enum DelegatedAdminAccessContainerDelegatedAdminAccessContainerType
    {
        SecurityGroup,
        UnknownFutureValue,
    }

    public string? AccessContainerId { get; set; }
    public DelegatedAdminAccessContainerDelegatedAdminAccessContainerType AccessContainerType { get; set; }
}
