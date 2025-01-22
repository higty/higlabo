using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
/// </summary>
public partial class CrosstenantAccessPolicyListPartnersParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_CrossTenantAccessPolicy_Partners: return $"/policies/crossTenantAccessPolicy/partners";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_CrossTenantAccessPolicy_Partners,
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
public partial class CrosstenantAccessPolicyListPartnersResponse : RestApiResponse<CrossTenantAccessPolicyConfigurationPartner>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync()
    {
        var p = new CrosstenantAccessPolicyListPartnersParameter();
        return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync(CancellationToken cancellationToken)
    {
        var p = new CrosstenantAccessPolicyListPartnersParameter();
        return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync(CrosstenantAccessPolicyListPartnersParameter parameter)
    {
        return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CrosstenantAccessPolicyListPartnersResponse> CrosstenantAccessPolicyListPartnersAsync(CrosstenantAccessPolicyListPartnersParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/crosstenantaccesspolicy-list-partners?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<CrossTenantAccessPolicyConfigurationPartner> CrosstenantAccessPolicyListPartnersEnumerateAsync(CrosstenantAccessPolicyListPartnersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<CrosstenantAccessPolicyListPartnersParameter, CrosstenantAccessPolicyListPartnersResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<CrossTenantAccessPolicyConfigurationPartner>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
