using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/userregistrationmethodcount?view=graph-rest-1.0
/// </summary>
public partial class UserRegistrationMethodCount
{
    public string? AuthenticationMethod { get; set; }
    public Int64? UserCount { get; set; }
}
