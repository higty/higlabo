using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-mailboxevidence?view=graph-rest-1.0
/// </summary>
public partial class MailboxEvidence
{
    public string? DisplayName { get; set; }
    public string? PrimaryAddress { get; set; }
    public UserAccount? UserAccount { get; set; }
}
