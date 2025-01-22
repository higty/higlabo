using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/apiapplication?view=graph-rest-1.0
/// </summary>
public partial class ApiApplication
{
    public bool? AcceptMappedClaims { get; set; }
    public Guid[]? KnownClientApplications { get; set; }
    public PermissionScope[]? Oauth2PermissionScopes { get; set; }
    public PreAuthorizedApplication[]? PreAuthorizedApplications { get; set; }
    public Int32? RequestedAccessTokenVersion { get; set; }
}
