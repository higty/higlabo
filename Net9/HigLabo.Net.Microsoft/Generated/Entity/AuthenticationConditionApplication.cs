using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationconditionapplication?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationConditionApplication
{
    public string? AppId { get; set; }
}
