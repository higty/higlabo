using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
/// </summary>
public partial class IdentityProviderbaseDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_IdentityProviders_Id: return $"/identity/identityProviders/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Identity_IdentityProviders_Id,
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
public partial class IdentityProviderbaseDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseDeleteResponse> IdentityProviderbaseDeleteAsync()
    {
        var p = new IdentityProviderbaseDeleteParameter();
        return await this.SendAsync<IdentityProviderbaseDeleteParameter, IdentityProviderbaseDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseDeleteResponse> IdentityProviderbaseDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityProviderbaseDeleteParameter();
        return await this.SendAsync<IdentityProviderbaseDeleteParameter, IdentityProviderbaseDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseDeleteResponse> IdentityProviderbaseDeleteAsync(IdentityProviderbaseDeleteParameter parameter)
    {
        return await this.SendAsync<IdentityProviderbaseDeleteParameter, IdentityProviderbaseDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityproviderbase-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderbaseDeleteResponse> IdentityProviderbaseDeleteAsync(IdentityProviderbaseDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityProviderbaseDeleteParameter, IdentityProviderbaseDeleteResponse>(parameter, cancellationToken);
    }
}
