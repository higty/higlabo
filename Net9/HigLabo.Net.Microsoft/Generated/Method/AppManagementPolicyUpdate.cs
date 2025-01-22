using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-update?view=graph-rest-1.0
/// </summary>
public partial class AppManagementPolicyUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_AppManagementPolicies_Id: return $"/policies/appManagementPolicies/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Policies_AppManagementPolicies_Id,
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
    public string? DisplayName { get; set; }
    public string? Description { get; set; }
    public bool? IsEnabled { get; set; }
    public AppManagementConfiguration? Restrictions { get; set; }
}
public partial class AppManagementPolicyUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppManagementPolicyUpdateResponse> AppManagementPolicyUpdateAsync()
    {
        var p = new AppManagementPolicyUpdateParameter();
        return await this.SendAsync<AppManagementPolicyUpdateParameter, AppManagementPolicyUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppManagementPolicyUpdateResponse> AppManagementPolicyUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new AppManagementPolicyUpdateParameter();
        return await this.SendAsync<AppManagementPolicyUpdateParameter, AppManagementPolicyUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppManagementPolicyUpdateResponse> AppManagementPolicyUpdateAsync(AppManagementPolicyUpdateParameter parameter)
    {
        return await this.SendAsync<AppManagementPolicyUpdateParameter, AppManagementPolicyUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AppManagementPolicyUpdateResponse> AppManagementPolicyUpdateAsync(AppManagementPolicyUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AppManagementPolicyUpdateParameter, AppManagementPolicyUpdateResponse>(parameter, cancellationToken);
    }
}
