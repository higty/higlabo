using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/userflowapiconnectorconfiguration?view=graph-rest-1.0
/// </summary>
public partial class UserFlowApiConnectorConfiguration
{
    public IdentityApiConnector? PostAttributeCollection { get; set; }
    public IdentityApiConnector? PostFederationSignup { get; set; }
}
