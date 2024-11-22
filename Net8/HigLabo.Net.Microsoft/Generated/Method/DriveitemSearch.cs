using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
/// </summary>
public partial class DriveItemSearchParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DriveId { get; set; }
        public string? GroupId { get; set; }
        public string? SiteId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Drives_DriveId_Root_Search: return $"/drives/{DriveId}/root/search";
                case ApiPath.Groups_GroupId_Drive_Root_Search: return $"/groups/{GroupId}/drive/root/search";
                case ApiPath.Me_Drive_Root_Search: return $"/me/drive/root/search";
                case ApiPath.Sites_SiteId_Drive_Root_Search: return $"/sites/{SiteId}/drive/root/search";
                case ApiPath.Users_UserId_Drive_Root_Search: return $"/users/{UserId}/drive/root/search";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Drives_DriveId_Root_Search,
        Groups_GroupId_Drive_Root_Search,
        Me_Drive_Root_Search,
        Sites_SiteId_Drive_Root_Search,
        Users_UserId_Drive_Root_Search,
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
public partial class DriveItemSearchResponse : RestApiResponse<DriveItem>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemSearchResponse> DriveItemSearchAsync()
    {
        var p = new DriveItemSearchParameter();
        return await this.SendAsync<DriveItemSearchParameter, DriveItemSearchResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemSearchResponse> DriveItemSearchAsync(CancellationToken cancellationToken)
    {
        var p = new DriveItemSearchParameter();
        return await this.SendAsync<DriveItemSearchParameter, DriveItemSearchResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemSearchResponse> DriveItemSearchAsync(DriveItemSearchParameter parameter)
    {
        return await this.SendAsync<DriveItemSearchParameter, DriveItemSearchResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemSearchResponse> DriveItemSearchAsync(DriveItemSearchParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DriveItemSearchParameter, DriveItemSearchResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-search?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DriveItem> DriveItemSearchEnumerateAsync(DriveItemSearchParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DriveItemSearchParameter, DriveItemSearchResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DriveItem>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
