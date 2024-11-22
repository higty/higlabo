using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
/// </summary>
public partial class IdentitycontainerPostIdentityProvidersParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_IdentityProviders: return $"/identity/identityProviders";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Identity_IdentityProviders,
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
    public string? DisplayName { get; set; }
    public string? IdentityProviderType { get; set; }
    public string? Scope { get; set; }
    public string? Id { get; set; }
}
public partial class IdentitycontainerPostIdentityProvidersResponse : RestApiResponse
{
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? IdentityProviderType { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitycontainerPostIdentityProvidersResponse> IdentitycontainerPostIdentityProvidersAsync()
    {
        var p = new IdentitycontainerPostIdentityProvidersParameter();
        return await this.SendAsync<IdentitycontainerPostIdentityProvidersParameter, IdentitycontainerPostIdentityProvidersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitycontainerPostIdentityProvidersResponse> IdentitycontainerPostIdentityProvidersAsync(CancellationToken cancellationToken)
    {
        var p = new IdentitycontainerPostIdentityProvidersParameter();
        return await this.SendAsync<IdentitycontainerPostIdentityProvidersParameter, IdentitycontainerPostIdentityProvidersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitycontainerPostIdentityProvidersResponse> IdentitycontainerPostIdentityProvidersAsync(IdentitycontainerPostIdentityProvidersParameter parameter)
    {
        return await this.SendAsync<IdentitycontainerPostIdentityProvidersParameter, IdentitycontainerPostIdentityProvidersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identitycontainer-post-identityproviders?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentitycontainerPostIdentityProvidersResponse> IdentitycontainerPostIdentityProvidersAsync(IdentitycontainerPostIdentityProvidersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentitycontainerPostIdentityProvidersParameter, IdentitycontainerPostIdentityProvidersResponse>(parameter, cancellationToken);
    }
}
