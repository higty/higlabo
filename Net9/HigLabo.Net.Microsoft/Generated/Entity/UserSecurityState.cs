using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/usersecuritystate?view=graph-rest-1.0
/// </summary>
public partial class UserSecurityState
{
    public enum UserSecurityStateEmailRole
    {
        Unknown,
        Sender,
        Recipient,
    }
    public enum UserSecurityStateLogonType
    {
        Unknown,
        Interactive,
        RemoteInteractive,
        Network,
        Batch,
        Service,
    }
    public enum UserSecurityStateUserAccountSecurityType
    {
        Unknown,
        Standard,
        Power,
        Administrator,
    }

    public string? AadUserId { get; set; }
    public string? AccountName { get; set; }
    public string? DomainName { get; set; }
    public UserSecurityStateEmailRole EmailRole { get; set; }
    public bool? IsVpn { get; set; }
    public DateTimeOffset? LogonDateTime { get; set; }
    public string? LogonId { get; set; }
    public string? LogonIp { get; set; }
    public string? LogonLocation { get; set; }
    public UserSecurityStateLogonType LogonType { get; set; }
    public string? OnPremisesSecurityIdentifier { get; set; }
    public string? RiskScore { get; set; }
    public UserSecurityStateUserAccountSecurityType UserAccountType { get; set; }
    public string? UserPrincipalName { get; set; }
}
