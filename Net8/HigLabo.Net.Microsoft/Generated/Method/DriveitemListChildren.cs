using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
/// </summary>
public partial class DriveItemListChildrenParameter : IRestApiParameter, IQueryParameterProperty
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
                case ApiPath.Drives_DriveId_Items_ItemId_Children: return $"/drives/{DriveId}/items/{ItemId}/children";
                case ApiPath.Groups_GroupId_Drive_Items_ItemId_Children: return $"/groups/{GroupId}/drive/items/{ItemId}/children";
                case ApiPath.Me_Drive_Items_ItemId_Children: return $"/me/drive/items/{ItemId}/children";
                case ApiPath.Sites_SiteId_Drive_Items_ItemId_Children: return $"/sites/{SiteId}/drive/items/{ItemId}/children";
                case ApiPath.Users_UserId_Drive_Items_ItemId_Children: return $"/users/{UserId}/drive/items/{ItemId}/children";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Drives_DriveId_Items_ItemId_Children,
        Groups_GroupId_Drive_Items_ItemId_Children,
        Me_Drive_Items_ItemId_Children,
        Sites_SiteId_Drive_Items_ItemId_Children,
        Users_UserId_Drive_Items_ItemId_Children,
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
public partial class DriveItemListChildrenResponse : RestApiResponse<DriveItem>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListChildrenResponse> DriveItemListChildrenAsync()
    {
        var p = new DriveItemListChildrenParameter();
        return await this.SendAsync<DriveItemListChildrenParameter, DriveItemListChildrenResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListChildrenResponse> DriveItemListChildrenAsync(CancellationToken cancellationToken)
    {
        var p = new DriveItemListChildrenParameter();
        return await this.SendAsync<DriveItemListChildrenParameter, DriveItemListChildrenResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListChildrenResponse> DriveItemListChildrenAsync(DriveItemListChildrenParameter parameter)
    {
        return await this.SendAsync<DriveItemListChildrenParameter, DriveItemListChildrenResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListChildrenResponse> DriveItemListChildrenAsync(DriveItemListChildrenParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DriveItemListChildrenParameter, DriveItemListChildrenResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-children?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DriveItem> DriveItemListChildrenEnumerateAsync(DriveItemListChildrenParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DriveItemListChildrenParameter, DriveItemListChildrenResponse>(parameter, cancellationToken);
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
