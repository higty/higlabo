using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftauthenticatorauthenticationmethodDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? MicrosoftAuthenticatorAuthenticationMethodId { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId: return $"/me/authentication/microsoftAuthenticatorMethods/{MicrosoftAuthenticatorAuthenticationMethodId}";
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId: return $"/users/{IdOrUserPrincipalName}/authentication/microsoftAuthenticatorMethods/{MicrosoftAuthenticatorAuthenticationMethodId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId,
        Users_IdOrUserPrincipalName_Authentication_MicrosoftAuthenticatorMethods_MicrosoftAuthenticatorAuthenticationMethodId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class MicrosoftauthenticatorauthenticationmethodDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync()
    {
        var p = new MicrosoftauthenticatorauthenticationmethodDeleteParameter();
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new MicrosoftauthenticatorauthenticationmethodDeleteParameter();
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync(MicrosoftauthenticatorauthenticationmethodDeleteParameter parameter)
    {
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/microsoftauthenticatorauthenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<MicrosoftauthenticatorauthenticationmethodDeleteResponse> MicrosoftauthenticatorauthenticationmethodDeleteAsync(MicrosoftauthenticatorauthenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<MicrosoftauthenticatorauthenticationmethodDeleteParameter, MicrosoftauthenticatorauthenticationmethodDeleteResponse>(parameter, cancellationToken);
    }
}
