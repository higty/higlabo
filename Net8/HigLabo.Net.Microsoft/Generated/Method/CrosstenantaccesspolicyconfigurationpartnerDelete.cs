using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
/// </summary>
public partial class CrosstenantAccessPolicyConfigurationPartnerDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id: return $"/policies/crossTenantAccessPolicy/partners/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Policies_CrossTenantAccessPolicy_Partners_Id,
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
public partial class CrosstenantAccessPolicyConfigurationPartnerDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationPartnerDeleteResponse> CrosstenantAccessPolicyConfigurationPartnerDeleteAsync()
    {
        var p = new CrosstenantAccessPolicyConfigurationPartnerDeleteParameter();
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerDeleteParameter, CrosstenantAccessPolicyConfigurationPartnerDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationPartnerDeleteResponse> CrosstenantAccessPolicyConfigurationPartnerDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new CrosstenantAccessPolicyConfigurationPartnerDeleteParameter();
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerDeleteParameter, CrosstenantAccessPolicyConfigurationPartnerDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationPartnerDeleteResponse> CrosstenantAccessPolicyConfigurationPartnerDeleteAsync(CrosstenantAccessPolicyConfigurationPartnerDeleteParameter parameter)
    {
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerDeleteParameter, CrosstenantAccessPolicyConfigurationPartnerDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationpartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationPartnerDeleteResponse> CrosstenantAccessPolicyConfigurationPartnerDeleteAsync(CrosstenantAccessPolicyConfigurationPartnerDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationPartnerDeleteParameter, CrosstenantAccessPolicyConfigurationPartnerDeleteResponse>(parameter, cancellationToken);
    }
}
