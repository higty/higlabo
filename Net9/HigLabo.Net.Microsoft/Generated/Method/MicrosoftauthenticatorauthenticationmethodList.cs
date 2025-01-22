using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftauthenticatorauthenticationmethodListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Authentication_MicrosoftAuthenticatorMethods: return $"/me/authentication/microsoftAuthenticatorMethods";
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods: return $"/users/{IdOrUserPrincipalName}/authentication/microsoftAuthenticatorMethods";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_Authentication_MicrosoftAuthenticatorMethods,
        Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods,
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
public partial class MicrosoftauthenticatorauthenticationmethodListResponse : RestApiResponse<MicrosoftAuthenticatorAuthenticationMethod>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync()
    {
        var p = new MicrosoftauthenticatorauthenticationmethodListParameter();
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync(CancellationToken cancellationToken)
    {
        var p = new MicrosoftauthenticatorauthenticationmethodListParameter();
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync(MicrosoftauthenticatorauthenticationmethodListParameter parameter)
    {
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodListResponse> MicrosoftauthenticatorauthenticationmethodListAsync(MicrosoftauthenticatorauthenticationmethodListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<MicrosoftAuthenticatorAuthenticationMethod> MicrosoftauthenticatorauthenticationmethodListEnumerateAsync(MicrosoftauthenticatorauthenticationmethodListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<MicrosoftauthenticatorauthenticationmethodListParameter, MicrosoftauthenticatorauthenticationmethodListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<MicrosoftAuthenticatorAuthenticationMethod>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
