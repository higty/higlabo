using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
/// </summary>
public partial class TokenlifetimePolicyListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Olicies_TokenLifetimePolicies: return $"/olicies/tokenLifetimePolicies";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Olicies_TokenLifetimePolicies,
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
public partial class TokenlifetimePolicyListResponse : RestApiResponse<TokenLifetimePolicy>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync()
    {
        var p = new TokenlifetimePolicyListParameter();
        return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync(CancellationToken cancellationToken)
    {
        var p = new TokenlifetimePolicyListParameter();
        return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync(TokenlifetimePolicyListParameter parameter)
    {
        return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TokenlifetimePolicyListResponse> TokenlifetimePolicyListAsync(TokenlifetimePolicyListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tokenlifetimepolicy-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<TokenLifetimePolicy> TokenlifetimePolicyListEnumerateAsync(TokenlifetimePolicyListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<TokenlifetimePolicyListParameter, TokenlifetimePolicyListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<TokenLifetimePolicy>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
