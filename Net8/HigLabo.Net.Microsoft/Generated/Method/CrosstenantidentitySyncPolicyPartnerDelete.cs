using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-delete?view=graph-rest-1.0
/// </summary>
public partial class CrosstenantidentitySyncPolicyPartnerDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_CrossTenantAccessPolicy_Partners_Id_IdentitySynchronization: return $"/policies/crossTenantAccessPolicy/partners/{Id}/identitySynchronization";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Policies_CrossTenantAccessPolicy_Partners_Id_IdentitySynchronization,
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
public partial class CrosstenantidentitySyncPolicyPartnerDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantidentitySyncPolicyPartnerDeleteResponse> CrosstenantidentitySyncPolicyPartnerDeleteAsync()
    {
        var p = new CrosstenantidentitySyncPolicyPartnerDeleteParameter();
        return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerDeleteParameter, CrosstenantidentitySyncPolicyPartnerDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantidentitySyncPolicyPartnerDeleteResponse> CrosstenantidentitySyncPolicyPartnerDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new CrosstenantidentitySyncPolicyPartnerDeleteParameter();
        return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerDeleteParameter, CrosstenantidentitySyncPolicyPartnerDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantidentitySyncPolicyPartnerDeleteResponse> CrosstenantidentitySyncPolicyPartnerDeleteAsync(CrosstenantidentitySyncPolicyPartnerDeleteParameter parameter)
    {
        return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerDeleteParameter, CrosstenantidentitySyncPolicyPartnerDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantidentitysyncpolicypartner-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantidentitySyncPolicyPartnerDeleteResponse> CrosstenantidentitySyncPolicyPartnerDeleteAsync(CrosstenantidentitySyncPolicyPartnerDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CrosstenantidentitySyncPolicyPartnerDeleteParameter, CrosstenantidentitySyncPolicyPartnerDeleteResponse>(parameter, cancellationToken);
    }
}
