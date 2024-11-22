using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
/// </summary>
public partial class DriveItemListThumbnailsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DriveId { get; set; }
        public string? ItemId { get; set; }
        public string? GroupId { get; set; }
        public string? SiteId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Drives_DriveId_Items_ItemId_Thumbnails: return $"/drives/{DriveId}/items/{ItemId}/thumbnails";
                case ApiPath.Groups_GroupId_Drive_Items_ItemId_Thumbnails: return $"/groups/{GroupId}/drive/items/{ItemId}/thumbnails";
                case ApiPath.Me_Drive_Items_ItemId_Thumbnails: return $"/me/drive/items/{ItemId}/thumbnails";
                case ApiPath.Sites_SiteId_Drive_Items_ItemId_Thumbnails: return $"/sites/{SiteId}/drive/items/{ItemId}/thumbnails";
                case ApiPath.Users_UserId_Drive_Items_ItemId_Thumbnails: return $"/users/{UserId}/drive/items/{ItemId}/thumbnails";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Drives_DriveId_Items_ItemId_Thumbnails,
        Groups_GroupId_Drive_Items_ItemId_Thumbnails,
        Me_Drive_Items_ItemId_Thumbnails,
        Sites_SiteId_Drive_Items_ItemId_Thumbnails,
        Users_UserId_Drive_Items_ItemId_Thumbnails,
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
public partial class DriveItemListThumbnailsResponse : RestApiResponse<ThumbnailSet>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListThumbnailsResponse> DriveItemListThumbnailsAsync()
    {
        var p = new DriveItemListThumbnailsParameter();
        return await this.SendAsync<DriveItemListThumbnailsParameter, DriveItemListThumbnailsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListThumbnailsResponse> DriveItemListThumbnailsAsync(CancellationToken cancellationToken)
    {
        var p = new DriveItemListThumbnailsParameter();
        return await this.SendAsync<DriveItemListThumbnailsParameter, DriveItemListThumbnailsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListThumbnailsResponse> DriveItemListThumbnailsAsync(DriveItemListThumbnailsParameter parameter)
    {
        return await this.SendAsync<DriveItemListThumbnailsParameter, DriveItemListThumbnailsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListThumbnailsResponse> DriveItemListThumbnailsAsync(DriveItemListThumbnailsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DriveItemListThumbnailsParameter, DriveItemListThumbnailsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-thumbnails?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ThumbnailSet> DriveItemListThumbnailsEnumerateAsync(DriveItemListThumbnailsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DriveItemListThumbnailsParameter, DriveItemListThumbnailsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ThumbnailSet>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
