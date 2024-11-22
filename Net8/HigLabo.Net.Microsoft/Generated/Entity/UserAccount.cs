using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-useraccount?view=graph-rest-1.0
/// </summary>
public partial class UserAccount
{
    public string? AccountName { get; set; }
    public string? AzureAdUserId { get; set; }
    public string? DomainName { get; set; }
    public string? UserPrincipalName { get; set; }
    public string? UserSid { get; set; }
}
