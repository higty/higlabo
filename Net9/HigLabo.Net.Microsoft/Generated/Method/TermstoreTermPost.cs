using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-term-post?view=graph-rest-1.0
/// </summary>
public partial class TermStoreTermPostParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? SetId { get; set; }
        public string? TermId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Children: return $"/sites/{SiteId}/termStore/sets/{SetId}/children";
                case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children: return $"/sites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/children";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Sites_SiteId_TermStore_Sets_SetId_Children,
        Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children,
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
    public TermStoreLocalizedlabel[]? Labels { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public TermStoreLocalizeddescription[]? Descriptions { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public KeyValue[]? Properties { get; set; }
    public TermStoreTerm[]? Children { get; set; }
    public TermStoreRelation[]? Relations { get; set; }
    public TermStoreSet? Set { get; set; }
}
public partial class TermStoreTermPostResponse : RestApiResponse
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public TermStoreLocalizeddescription[]? Descriptions { get; set; }
    public string? Id { get; set; }
    public TermStoreLocalizedlabel[]? Labels { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public KeyValue[]? Properties { get; set; }
    public TermStoreTerm[]? Children { get; set; }
    public TermStoreRelation[]? Relations { get; set; }
    public TermStoreSet? Set { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-term-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreTermPostResponse> TermStoreTermPostAsync()
    {
        var p = new TermStoreTermPostParameter();
        return await this.SendAsync<TermStoreTermPostParameter, TermStoreTermPostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreTermPostResponse> TermStoreTermPostAsync(CancellationToken cancellationToken)
    {
        var p = new TermStoreTermPostParameter();
        return await this.SendAsync<TermStoreTermPostParameter, TermStoreTermPostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreTermPostResponse> TermStoreTermPostAsync(TermStoreTermPostParameter parameter)
    {
        return await this.SendAsync<TermStoreTermPostParameter, TermStoreTermPostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreTermPostResponse> TermStoreTermPostAsync(TermStoreTermPostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TermStoreTermPostParameter, TermStoreTermPostResponse>(parameter, cancellationToken);
    }
}
