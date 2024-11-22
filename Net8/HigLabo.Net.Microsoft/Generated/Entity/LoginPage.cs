using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/loginpage?view=graph-rest-1.0
/// </summary>
public partial class LoginPage
{
    public enum LoginPageSimulationContentStatus
    {
        Unknown,
        Global,
        Tenant,
        UnknownFutureValue,
    }

    public string? Content { get; set; }
    public EmailIdentity? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? Language { get; set; }
    public EmailIdentity? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public LoginPageSimulationContentStatus Source { get; set; }
    public LoginPageSimulationContentStatus Status { get; set; }
}
