using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationcontextClassreferenceUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ConditionalAccess_AuthenticationContextClassReferences_Id: return $"/identity/conditionalAccess/authenticationContextClassReferences/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Identity_ConditionalAccess_AuthenticationContextClassReferences_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public bool? IsAvailable { get; set; }
}
public partial class AuthenticationcontextClassreferenceUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceUpdateResponse> AuthenticationcontextClassreferenceUpdateAsync()
    {
        var p = new AuthenticationcontextClassreferenceUpdateParameter();
        return await this.SendAsync<AuthenticationcontextClassreferenceUpdateParameter, AuthenticationcontextClassreferenceUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceUpdateResponse> AuthenticationcontextClassreferenceUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationcontextClassreferenceUpdateParameter();
        return await this.SendAsync<AuthenticationcontextClassreferenceUpdateParameter, AuthenticationcontextClassreferenceUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceUpdateResponse> AuthenticationcontextClassreferenceUpdateAsync(AuthenticationcontextClassreferenceUpdateParameter parameter)
    {
        return await this.SendAsync<AuthenticationcontextClassreferenceUpdateParameter, AuthenticationcontextClassreferenceUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceUpdateResponse> AuthenticationcontextClassreferenceUpdateAsync(AuthenticationcontextClassreferenceUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationcontextClassreferenceUpdateParameter, AuthenticationcontextClassreferenceUpdateResponse>(parameter, cancellationToken);
    }
}
