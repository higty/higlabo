using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationconditions?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationConditions
{
    public AuthenticationConditionsApplications? Applications { get; set; }
}
