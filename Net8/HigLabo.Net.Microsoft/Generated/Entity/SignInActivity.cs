using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/signinactivity?view=graph-rest-1.0
/// </summary>
public partial class SignInActivity
{
    public DateTimeOffset? LastSignInDateTime { get; set; }
    public string? LastSignInRequestId { get; set; }
    public DateTimeOffset? LastNonInteractiveSignInDateTime { get; set; }
    public string? LastNonInteractiveSignInRequestId { get; set; }
}
