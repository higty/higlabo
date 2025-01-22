using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authentication-list-phonemethods?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationListPhonemethodsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Authentication_PhoneMethods: return $"/me/authentication/phoneMethods";
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_PhoneMethods: return $"/users/{IdOrUserPrincipalName}/authentication/phoneMethods";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Authentication_PhoneMethods,
        Users_IdOrUserPrincipalName_Authentication_PhoneMethods,
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
public partial class AuthenticationListPhonemethodsResponse : RestApiResponse<PhoneAuthenticationMethod>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authentication-list-phonemethods?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-phonemethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPhonemethodsResponse> AuthenticationListPhonemethodsAsync()
    {
        var p = new AuthenticationListPhonemethodsParameter();
        return await this.SendAsync<AuthenticationListPhonemethodsParameter, AuthenticationListPhonemethodsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-phonemethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPhonemethodsResponse> AuthenticationListPhonemethodsAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationListPhonemethodsParameter();
        return await this.SendAsync<AuthenticationListPhonemethodsParameter, AuthenticationListPhonemethodsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-phonemethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPhonemethodsResponse> AuthenticationListPhonemethodsAsync(AuthenticationListPhonemethodsParameter parameter)
    {
        return await this.SendAsync<AuthenticationListPhonemethodsParameter, AuthenticationListPhonemethodsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-phonemethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationListPhonemethodsResponse> AuthenticationListPhonemethodsAsync(AuthenticationListPhonemethodsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationListPhonemethodsParameter, AuthenticationListPhonemethodsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-list-phonemethods?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<PhoneAuthenticationMethod> AuthenticationListPhonemethodsEnumerateAsync(AuthenticationListPhonemethodsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AuthenticationListPhonemethodsParameter, AuthenticationListPhonemethodsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<PhoneAuthenticationMethod>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
