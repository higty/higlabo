using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-itemidresolver?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsItemidresolver
{
    public string? ItemId { get; set; }
    public Int32? Priority { get; set; }
    public ExternalConnectorsUrlmatchinfo? UrlMatchInfo { get; set; }
}
