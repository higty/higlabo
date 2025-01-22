using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationcontextClassreferenceGetParameter : IRestApiParameter, IQueryParameterProperty
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

    public enum Field
    {
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
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class AuthenticationcontextClassreferenceGetResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsAvailable { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceGetResponse> AuthenticationcontextClassreferenceGetAsync()
    {
        var p = new AuthenticationcontextClassreferenceGetParameter();
        return await this.SendAsync<AuthenticationcontextClassreferenceGetParameter, AuthenticationcontextClassreferenceGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceGetResponse> AuthenticationcontextClassreferenceGetAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationcontextClassreferenceGetParameter();
        return await this.SendAsync<AuthenticationcontextClassreferenceGetParameter, AuthenticationcontextClassreferenceGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceGetResponse> AuthenticationcontextClassreferenceGetAsync(AuthenticationcontextClassreferenceGetParameter parameter)
    {
        return await this.SendAsync<AuthenticationcontextClassreferenceGetParameter, AuthenticationcontextClassreferenceGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationcontextclassreference-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationcontextClassreferenceGetResponse> AuthenticationcontextClassreferenceGetAsync(AuthenticationcontextClassreferenceGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationcontextClassreferenceGetParameter, AuthenticationcontextClassreferenceGetResponse>(parameter, cancellationToken);
    }
}
