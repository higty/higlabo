using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accesspackagelocalizedtext?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageLocalizedText
{
    public string? LanguageCode { get; set; }
    public string? Text { get; set; }
}
