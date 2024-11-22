using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
/// </summary>
public partial class ClaimsmappingPolicyListAppliestoParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Policies_ClaimsMappingPolicies_Id_AppliesTo: return $"/policies/claimsMappingPolicies/{Id}/appliesTo";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Policies_ClaimsMappingPolicies_Id_AppliesTo,
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
public partial class ClaimsmappingPolicyListAppliestoResponse : RestApiResponse<DirectoryObject>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ClaimsmappingPolicyListAppliestoResponse> ClaimsmappingPolicyListAppliestoAsync()
    {
        var p = new ClaimsmappingPolicyListAppliestoParameter();
        return await this.SendAsync<ClaimsmappingPolicyListAppliestoParameter, ClaimsmappingPolicyListAppliestoResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ClaimsmappingPolicyListAppliestoResponse> ClaimsmappingPolicyListAppliestoAsync(CancellationToken cancellationToken)
    {
        var p = new ClaimsmappingPolicyListAppliestoParameter();
        return await this.SendAsync<ClaimsmappingPolicyListAppliestoParameter, ClaimsmappingPolicyListAppliestoResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ClaimsmappingPolicyListAppliestoResponse> ClaimsmappingPolicyListAppliestoAsync(ClaimsmappingPolicyListAppliestoParameter parameter)
    {
        return await this.SendAsync<ClaimsmappingPolicyListAppliestoParameter, ClaimsmappingPolicyListAppliestoResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ClaimsmappingPolicyListAppliestoResponse> ClaimsmappingPolicyListAppliestoAsync(ClaimsmappingPolicyListAppliestoParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ClaimsmappingPolicyListAppliestoParameter, ClaimsmappingPolicyListAppliestoResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/claimsmappingpolicy-list-appliesto?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DirectoryObject> ClaimsmappingPolicyListAppliestoEnumerateAsync(ClaimsmappingPolicyListAppliestoParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ClaimsmappingPolicyListAppliestoParameter, ClaimsmappingPolicyListAppliestoResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
