using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
/// </summary>
public partial class HomeRealmDiscoveryPolicyDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_HomeRealmDiscoveryPolicies_Id: return $"/policies/homeRealmDiscoveryPolicies/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Policies_HomeRealmDiscoveryPolicies_Id,
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
public partial class HomeRealmDiscoveryPolicyDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyDeleteResponse> HomeRealmDiscoveryPolicyDeleteAsync()
    {
        var p = new HomeRealmDiscoveryPolicyDeleteParameter();
        return await this.SendAsync<HomeRealmDiscoveryPolicyDeleteParameter, HomeRealmDiscoveryPolicyDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyDeleteResponse> HomeRealmDiscoveryPolicyDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new HomeRealmDiscoveryPolicyDeleteParameter();
        return await this.SendAsync<HomeRealmDiscoveryPolicyDeleteParameter, HomeRealmDiscoveryPolicyDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyDeleteResponse> HomeRealmDiscoveryPolicyDeleteAsync(HomeRealmDiscoveryPolicyDeleteParameter parameter)
    {
        return await this.SendAsync<HomeRealmDiscoveryPolicyDeleteParameter, HomeRealmDiscoveryPolicyDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/homerealmdiscoverypolicy-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<HomeRealmDiscoveryPolicyDeleteResponse> HomeRealmDiscoveryPolicyDeleteAsync(HomeRealmDiscoveryPolicyDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<HomeRealmDiscoveryPolicyDeleteParameter, HomeRealmDiscoveryPolicyDeleteResponse>(parameter, cancellationToken);
    }
}
