using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
/// </summary>
public partial class ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Olicies_ActivityBasedTimeoutPolicies: return $"/olicies/activityBasedTimeoutPolicies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Olicies_ActivityBasedTimeoutPolicies,
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
    public String[]? Definition { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsOrganizationDefault { get; set; }
}
public partial class ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse : RestApiResponse
{
    public String[]? Definition { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsOrganizationDefault { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesAsync()
    {
        var p = new ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter();
        return await this.SendAsync<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter();
        return await this.SendAsync<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesAsync(ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter parameter)
    {
        return await this.SendAsync<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/activitybasedtimeoutpolicy-post-activitybasedtimeoutpolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse> ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesAsync(ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesParameter, ActivitybasedtimeoutPolicyPostActivitybasedtimeoutpoliciesResponse>(parameter, cancellationToken);
    }
}
