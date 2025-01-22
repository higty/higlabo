using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-searchsettings?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsSearchSettings
{
    public ExternalConnectorsDisplayTemplate[]? SearchResultTemplates { get; set; }
}
