using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
/// </summary>
public partial class TokenissuancePolicyListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Olicies_TokenIssuancePolicies: return $"/olicies/tokenIssuancePolicies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Olicies_TokenIssuancePolicies,
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
public partial class TokenissuancePolicyListResponse : RestApiResponse<TokenIssuancePolicy>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync()
    {
        var p = new TokenissuancePolicyListParameter();
        return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync(CancellationToken cancellationToken)
    {
        var p = new TokenissuancePolicyListParameter();
        return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync(TokenissuancePolicyListParameter parameter)
    {
        return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenissuancePolicyListResponse> TokenissuancePolicyListAsync(TokenissuancePolicyListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenissuancepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<TokenIssuancePolicy> TokenissuancePolicyListEnumerateAsync(TokenissuancePolicyListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TokenissuancePolicyListParameter, TokenissuancePolicyListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<TokenIssuancePolicy>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
