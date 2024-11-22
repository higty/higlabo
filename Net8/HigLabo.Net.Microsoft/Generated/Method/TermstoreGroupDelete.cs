using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
/// </summary>
public partial class TermStoreGroupDeleteParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class TermStoreGroupDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupDeleteResponse> TermStoreGroupDeleteAsync()
    {
        var p = new TermStoreGroupDeleteParameter();
        return await this.SendAsync<TermStoreGroupDeleteParameter, TermStoreGroupDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupDeleteResponse> TermStoreGroupDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new TermStoreGroupDeleteParameter();
        return await this.SendAsync<TermStoreGroupDeleteParameter, TermStoreGroupDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupDeleteResponse> TermStoreGroupDeleteAsync(TermStoreGroupDeleteParameter parameter)
    {
        return await this.SendAsync<TermStoreGroupDeleteParameter, TermStoreGroupDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<TermStoreGroupDeleteResponse> TermStoreGroupDeleteAsync(TermStoreGroupDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<TermStoreGroupDeleteParameter, TermStoreGroupDeleteResponse>(parameter, cancellationToken);
    }
}
