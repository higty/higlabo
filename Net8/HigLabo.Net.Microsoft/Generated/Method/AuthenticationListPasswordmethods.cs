using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authentication-list-passwordmethods?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationListPasswordmethodsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Authentication_PasswordMethods: return $"/me/authentication/passwordMethods";
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_PasswordMethods: return $"/users/{IdOrUserPrincipalName}/authentication/passwordMethods";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Authentication_PasswordMethods,
        Users_IdOrUserPrincipalName_Authentication_PasswordMethods,
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
public partial class AuthenticationListPasswordmethodsResponse : RestApiResponse<PasswordAuthenticationMethod>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authentication-list-passwordmethods?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-passwordmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPasswordmethodsResponse> AuthenticationListPasswordmethodsAsync()
    {
        var p = new AuthenticationListPasswordmethodsParameter();
        return await this.SendAsync<AuthenticationListPasswordmethodsParameter, AuthenticationListPasswordmethodsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-passwordmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPasswordmethodsResponse> AuthenticationListPasswordmethodsAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationListPasswordmethodsParameter();
        return await this.SendAsync<AuthenticationListPasswordmethodsParameter, AuthenticationListPasswordmethodsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-passwordmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPasswordmethodsResponse> AuthenticationListPasswordmethodsAsync(AuthenticationListPasswordmethodsParameter parameter)
    {
        return await this.SendAsync<AuthenticationListPasswordmethodsParameter, AuthenticationListPasswordmethodsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-passwordmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPasswordmethodsResponse> AuthenticationListPasswordmethodsAsync(AuthenticationListPasswordmethodsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationListPasswordmethodsParameter, AuthenticationListPasswordmethodsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-passwordmethods?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PasswordAuthenticationMethod> AuthenticationListPasswordmethodsEnumerateAsync(AuthenticationListPasswordmethodsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AuthenticationListPasswordmethodsParameter, AuthenticationListPasswordmethodsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PasswordAuthenticationMethod>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
