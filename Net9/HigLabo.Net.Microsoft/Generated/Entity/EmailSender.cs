using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-emailsender?view=graph-rest-1.0
/// </summary>
public partial class EmailSender
{
    public string? DisplayName { get; set; }
    public string? DomainName { get; set; }
    public string? EmailAddress { get; set; }
}
