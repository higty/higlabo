using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
/// </summary>
public partial class TermStoreSetPostParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_TermStore_Sets: return $"/sites/{SiteId}/termStore/sets";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Sites_SiteId_TermStore_Sets,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public TermStoreLocalizedname[]? LocalizedNames { get; set; }
    public TermStoreGroup? ParentGroup { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? Id { get; set; }
    public KeyValue[]? Properties { get; set; }
    public TermStoreTerm[]? Children { get; set; }
    public TermStoreRelation[]? Relations { get; set; }
    public TermStoreTerm[]? Terms { get; set; }
}
public partial class TermStoreSetPostResponse : RestApiResponse
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? Id { get; set; }
    public TermStoreLocalizedname[]? LocalizedNames { get; set; }
    public KeyValue[]? Properties { get; set; }
    public TermStoreTerm[]? Children { get; set; }
    public TermStoreGroup? ParentGroup { get; set; }
    public TermStoreRelation[]? Relations { get; set; }
    public TermStoreTerm[]? Terms { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreSetPostResponse> TermStoreSetPostAsync()
    {
        var p = new TermStoreSetPostParameter();
        return await this.SendAsync<TermStoreSetPostParameter, TermStoreSetPostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreSetPostResponse> TermStoreSetPostAsync(CancellationToken cancellationToken)
    {
        var p = new TermStoreSetPostParameter();
        return await this.SendAsync<TermStoreSetPostParameter, TermStoreSetPostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreSetPostResponse> TermStoreSetPostAsync(TermStoreSetPostParameter parameter)
    {
        return await this.SendAsync<TermStoreSetPostParameter, TermStoreSetPostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-set-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreSetPostResponse> TermStoreSetPostAsync(TermStoreSetPostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TermStoreSetPostParameter, TermStoreSetPostResponse>(parameter, cancellationToken);
    }
}
