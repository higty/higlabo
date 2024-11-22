using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
/// </summary>
public partial class IdentityProviderUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityProviders_Id: return $"/identityProviders/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityProviders_Id,
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
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? Name { get; set; }
}
public partial class IdentityProviderUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderUpdateResponse> IdentityProviderUpdateAsync()
    {
        var p = new IdentityProviderUpdateParameter();
        return await this.SendAsync<IdentityProviderUpdateParameter, IdentityProviderUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderUpdateResponse> IdentityProviderUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new IdentityProviderUpdateParameter();
        return await this.SendAsync<IdentityProviderUpdateParameter, IdentityProviderUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderUpdateResponse> IdentityProviderUpdateAsync(IdentityProviderUpdateParameter parameter)
    {
        return await this.SendAsync<IdentityProviderUpdateParameter, IdentityProviderUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityprovider-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<IdentityProviderUpdateResponse> IdentityProviderUpdateAsync(IdentityProviderUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<IdentityProviderUpdateParameter, IdentityProviderUpdateResponse>(parameter, cancellationToken);
    }
}
