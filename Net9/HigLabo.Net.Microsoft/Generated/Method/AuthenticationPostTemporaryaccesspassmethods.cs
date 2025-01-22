using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationPostTemporaryAccesspassmethodsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods: return $"/users/{IdOrUserPrincipalName}/authentication/temporaryAccessPassMethods";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Users_IdOrUserPrincipalName_Authentication_TemporaryAccessPassMethods,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public bool? IsUsableOnce { get; set; }
    public Int32? LifetimeInMinutes { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public bool? IsUsable { get; set; }
    public string? MethodUsabilityReason { get; set; }
    public string? TemporaryAccessPass { get; set; }
}
public partial class AuthenticationPostTemporaryAccesspassmethodsResponse : RestApiResponse
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public bool? IsUsable { get; set; }
    public bool? IsUsableOnce { get; set; }
    public Int32? LifetimeInMinutes { get; set; }
    public string? MethodUsabilityReason { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public string? TemporaryAccessPass { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationPostTemporaryAccesspassmethodsResponse> AuthenticationPostTemporaryAccesspassmethodsAsync()
    {
        var p = new AuthenticationPostTemporaryAccesspassmethodsParameter();
        return await this.SendAsync<AuthenticationPostTemporaryAccesspassmethodsParameter, AuthenticationPostTemporaryAccesspassmethodsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationPostTemporaryAccesspassmethodsResponse> AuthenticationPostTemporaryAccesspassmethodsAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationPostTemporaryAccesspassmethodsParameter();
        return await this.SendAsync<AuthenticationPostTemporaryAccesspassmethodsParameter, AuthenticationPostTemporaryAccesspassmethodsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationPostTemporaryAccesspassmethodsResponse> AuthenticationPostTemporaryAccesspassmethodsAsync(AuthenticationPostTemporaryAccesspassmethodsParameter parameter)
    {
        return await this.SendAsync<AuthenticationPostTemporaryAccesspassmethodsParameter, AuthenticationPostTemporaryAccesspassmethodsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authentication-post-temporaryaccesspassmethods?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationPostTemporaryAccesspassmethodsResponse> AuthenticationPostTemporaryAccesspassmethodsAsync(AuthenticationPostTemporaryAccesspassmethodsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationPostTemporaryAccesspassmethodsParameter, AuthenticationPostTemporaryAccesspassmethodsResponse>(parameter, cancellationToken);
    }
}
