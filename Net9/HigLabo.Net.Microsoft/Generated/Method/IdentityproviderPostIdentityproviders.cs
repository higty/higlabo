using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
/// </summary>
public partial class IdentityProviderPostIdentityProvidersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityProviders: return $"/identityProviders";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityProviders,
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
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Id { get; set; }
}
public partial class IdentityProviderPostIdentityProvidersResponse : RestApiResponse
{
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderPostIdentityProvidersResponse> IdentityProviderPostIdentityProvidersAsync()
    {
        var p = new IdentityProviderPostIdentityProvidersParameter();
        return await this.SendAsync<IdentityProviderPostIdentityProvidersParameter, IdentityProviderPostIdentityProvidersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderPostIdentityProvidersResponse> IdentityProviderPostIdentityProvidersAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityProviderPostIdentityProvidersParameter();
        return await this.SendAsync<IdentityProviderPostIdentityProvidersParameter, IdentityProviderPostIdentityProvidersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderPostIdentityProvidersResponse> IdentityProviderPostIdentityProvidersAsync(IdentityProviderPostIdentityProvidersParameter parameter)
    {
        return await this.SendAsync<IdentityProviderPostIdentityProvidersParameter, IdentityProviderPostIdentityProvidersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderPostIdentityProvidersResponse> IdentityProviderPostIdentityProvidersAsync(IdentityProviderPostIdentityProvidersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityProviderPostIdentityProvidersParameter, IdentityProviderPostIdentityProvidersResponse>(parameter, cancellationToken);
    }
}
