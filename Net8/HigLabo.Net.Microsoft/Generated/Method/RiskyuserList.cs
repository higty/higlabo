using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
/// </summary>
public partial class RiskyUserListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityProtection_RiskyUsers: return $"/identityProtection/riskyUsers";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityProtection_RiskyUsers,
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
public partial class RiskyUserListResponse : RestApiResponse<RiskyUser>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskyUserListResponse> RiskyUserListAsync()
    {
        var p = new RiskyUserListParameter();
        return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskyUserListResponse> RiskyUserListAsync(CancellationToken cancellationToken)
    {
        var p = new RiskyUserListParameter();
        return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskyUserListResponse> RiskyUserListAsync(RiskyUserListParameter parameter)
    {
        return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<RiskyUserListResponse> RiskyUserListAsync(RiskyUserListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/riskyuser-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<RiskyUser> RiskyUserListEnumerateAsync(RiskyUserListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<RiskyUserListParameter, RiskyUserListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<RiskyUser>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
