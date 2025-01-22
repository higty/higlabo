using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-whoishistoryrecord?view=graph-rest-1.0
/// </summary>
public partial class WhoisHistoryRecord
{
    public WhoisContact? Abuse { get; set; }
    public WhoisContact? Admin { get; set; }
    public WhoisContact? Billing { get; set; }
    public string? DomainStatus { get; set; }
    public DateTimeOffset? ExpirationDateTime { get; set; }
    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public DateTimeOffset? LastUpdateDateTime { get; set; }
    public WhoisNameserver[]? Nameservers { get; set; }
    public WhoisContact? Noc { get; set; }
    public string? RawWhoisText { get; set; }
    public WhoisContact? Registrant { get; set; }
    public WhoisContact? Registrar { get; set; }
    public DateTimeOffset? RegistrationDateTime { get; set; }
    public WhoisContact? Technical { get; set; }
    public string? WhoisServer { get; set; }
    public WhoisContact? Zone { get; set; }
    public Host? Host { get; set; }
}
