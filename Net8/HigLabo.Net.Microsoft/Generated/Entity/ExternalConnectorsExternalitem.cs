using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/externalconnectors-externalitem?view=graph-rest-1.0
/// </summary>
public partial class ExternalConnectorsExternalItem
{
    public ExternalConnectorsAcl[]? Acl { get; set; }
    public ExternalConnectorsExternalItemContent? Content { get; set; }
    public string? Id { get; set; }
    public ExternalConnectorsProperties? Properties { get; set; }
    public ExternalConnectorsExternalActivity[]? Activities { get; set; }
}
