using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/privacyprofile?view=graph-rest-1.0
/// </summary>
public partial class PrivacyProfile
{
    public string? ContactEmail { get; set; }
    public string? StatementUrl { get; set; }
}
