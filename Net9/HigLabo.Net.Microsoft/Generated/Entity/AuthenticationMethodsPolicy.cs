using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/authenticationmethodspolicy?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationMethodsPolicy
{
    public enum AuthenticationMethodsPolicyAuthenticationMethodsPolicyMigrationState
    {
        Premigration,
        MigrationInProgress,
        MigrationComplete,
        UnknownFutureValue,
    }

    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? PolicyVersion { get; set; }
    public RegistrationEnforcement? RegistrationEnforcement { get; set; }
    public AuthenticationMethodsPolicyAuthenticationMethodsPolicyMigrationState PolicyMigrationState { get; set; }
    public AuthenticationMethodConfiguration[]? AuthenticationMethodConfigurations { get; set; }
}
