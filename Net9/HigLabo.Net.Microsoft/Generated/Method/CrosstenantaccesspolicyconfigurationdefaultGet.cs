using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
/// </summary>
public partial class CrosstenantAccessPolicyConfigurationdefaultGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_CrossTenantAccessPolicy_Default: return $"/policies/crossTenantAccessPolicy/default";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_CrossTenantAccessPolicy_Default,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class CrosstenantAccessPolicyConfigurationdefaultGetResponse : RestApiResponse
{
    public InboundOutboundPolicyConfiguration? AutomaticUserConsentSettings { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bCollaborationInbound { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bCollaborationOutbound { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectInbound { get; set; }
    public CrossTenantAccessPolicyB2BSetting? B2bDirectConnectOutbound { get; set; }
    public CrossTenantAccessPolicyInboundTrust? InboundTrust { get; set; }
    public bool? IsServiceDefault { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationdefaultGetResponse> CrosstenantAccessPolicyConfigurationdefaultGetAsync()
    {
        var p = new CrosstenantAccessPolicyConfigurationdefaultGetParameter();
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultGetParameter, CrosstenantAccessPolicyConfigurationdefaultGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationdefaultGetResponse> CrosstenantAccessPolicyConfigurationdefaultGetAsync(CancellationToken cancellationToken)
    {
        var p = new CrosstenantAccessPolicyConfigurationdefaultGetParameter();
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultGetParameter, CrosstenantAccessPolicyConfigurationdefaultGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationdefaultGetResponse> CrosstenantAccessPolicyConfigurationdefaultGetAsync(CrosstenantAccessPolicyConfigurationdefaultGetParameter parameter)
    {
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultGetParameter, CrosstenantAccessPolicyConfigurationdefaultGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicyconfigurationdefault-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyConfigurationdefaultGetResponse> CrosstenantAccessPolicyConfigurationdefaultGetAsync(CrosstenantAccessPolicyConfigurationdefaultGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CrosstenantAccessPolicyConfigurationdefaultGetParameter, CrosstenantAccessPolicyConfigurationdefaultGetResponse>(parameter, cancellationToken);
    }
}
