using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/domaindnsrecord?view=graph-rest-1.0
/// </summary>
public partial class DomainDnsRecord
{
    public string? Id { get; set; }
    public bool? IsOptional { get; set; }
    public string? Label { get; set; }
    public string? RecordType { get; set; }
    public string? SupportedService { get; set; }
    public Int32? Ttl { get; set; }
}
