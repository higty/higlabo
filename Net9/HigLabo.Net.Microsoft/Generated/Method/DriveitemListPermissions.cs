using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
/// </summary>
public partial class DriveItemListPermissionsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? DriveId { get; set; }
        public string? ItemId { get; set; }
        public string? GroupId { get; set; }
        public string? Path { get; set; }
        public string? SiteId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Drives_DriveId_Items_ItemId_Permissions: return $"/drives/{DriveId}/items/{ItemId}/permissions";
                case ApiPath.Groups_GroupId_Drive_Items_ItemId_Permissions: return $"/groups/{GroupId}/drive/items/{ItemId}/permissions";
                case ApiPath.Me_Drive_Items_ItemId_Permissions: return $"/me/drive/items/{ItemId}/permissions";
                case ApiPath.Me_Drive_Root_Path_Permissions: return $"/me/drive/root:/{Path}:/permissions";
                case ApiPath.Sites_SiteId_Drive_Items_ItemId_Permissions: return $"/sites/{SiteId}/drive/items/{ItemId}/permissions";
                case ApiPath.Users_UserId_Drive_Items_ItemId_Permissions: return $"/users/{UserId}/drive/items/{ItemId}/permissions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Drives_DriveId_Items_ItemId_Permissions,
        Groups_GroupId_Drive_Items_ItemId_Permissions,
        Me_Drive_Items_ItemId_Permissions,
        Me_Drive_Root_Path_Permissions,
        Sites_SiteId_Drive_Items_ItemId_Permissions,
        Users_UserId_Drive_Items_ItemId_Permissions,
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
public partial class DriveItemListPermissionsResponse : RestApiResponse<Permission>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListPermissionsResponse> DriveItemListPermissionsAsync()
    {
        var p = new DriveItemListPermissionsParameter();
        return await this.SendAsync<DriveItemListPermissionsParameter, DriveItemListPermissionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListPermissionsResponse> DriveItemListPermissionsAsync(CancellationToken cancellationToken)
    {
        var p = new DriveItemListPermissionsParameter();
        return await this.SendAsync<DriveItemListPermissionsParameter, DriveItemListPermissionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListPermissionsResponse> DriveItemListPermissionsAsync(DriveItemListPermissionsParameter parameter)
    {
        return await this.SendAsync<DriveItemListPermissionsParameter, DriveItemListPermissionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DriveItemListPermissionsResponse> DriveItemListPermissionsAsync(DriveItemListPermissionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DriveItemListPermissionsParameter, DriveItemListPermissionsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/driveitem-list-permissions?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<Permission> DriveItemListPermissionsEnumerateAsync(DriveItemListPermissionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DriveItemListPermissionsParameter, DriveItemListPermissionsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<Permission>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
