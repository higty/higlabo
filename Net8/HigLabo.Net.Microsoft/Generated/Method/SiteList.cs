using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-list?view=graph-rest-1.0
/// </summary>
public partial class SiteListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites: return $"/sites";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
        CreatedDateTime,
        Description,
        DisplayName,
        ETag,
        Id,
        LastModifiedDateTime,
        Name,
        Root,
        SharepointIds,
        SiteCollection,
        WebUrl,
        Analytics,
        Columns,
        ContentTypes,
        Drive,
        Drives,
        Items,
        Lists,
        Onenote,
        Operations,
        Permissions,
        Sites,
        TermStore,
        TermStores,
    }
    public enum ApiPath
    {
        Sites,
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
public partial class SiteListResponse : RestApiResponse
{
    public Site[]? Value { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/site-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListResponse> SiteListAsync()
    {
        var p = new SiteListParameter();
        return await this.SendAsync<SiteListParameter, SiteListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListResponse> SiteListAsync(CancellationToken cancellationToken)
    {
        var p = new SiteListParameter();
        return await this.SendAsync<SiteListParameter, SiteListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListResponse> SiteListAsync(SiteListParameter parameter)
    {
        return await this.SendAsync<SiteListParameter, SiteListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SiteListResponse> SiteListAsync(SiteListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SiteListParameter, SiteListResponse>(parameter, cancellationToken);
    }
}
