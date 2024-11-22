using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
/// </summary>
public partial class TermStoreGroupGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? GroupId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_TermStore_Groups_GroupId: return $"/sites/{SiteId}/termStore/groups/{GroupId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Sites_SiteId_TermStore_Groups_GroupId,
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
public partial class TermStoreGroupGetResponse : RestApiResponse
{
    public enum TermStoreGroupstring
    {
        Global,
        System,
        SiteCollection,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? ParentSiteId { get; set; }
    public TermStoreGroupstring Scope { get; set; }
    public TermStoreSet[]? Sets { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupGetResponse> TermStoreGroupGetAsync()
    {
        var p = new TermStoreGroupGetParameter();
        return await this.SendAsync<TermStoreGroupGetParameter, TermStoreGroupGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupGetResponse> TermStoreGroupGetAsync(CancellationToken cancellationToken)
    {
        var p = new TermStoreGroupGetParameter();
        return await this.SendAsync<TermStoreGroupGetParameter, TermStoreGroupGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupGetResponse> TermStoreGroupGetAsync(TermStoreGroupGetParameter parameter)
    {
        return await this.SendAsync<TermStoreGroupGetParameter, TermStoreGroupGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupGetResponse> TermStoreGroupGetAsync(TermStoreGroupGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TermStoreGroupGetParameter, TermStoreGroupGetResponse>(parameter, cancellationToken);
    }
}
