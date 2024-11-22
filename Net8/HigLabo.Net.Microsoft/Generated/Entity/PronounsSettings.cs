using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/pronounssettings?view=graph-rest-1.0
/// </summary>
public partial class PronounsSettings
{
    public bool? IsEnabledInOrganization { get; set; }
}
