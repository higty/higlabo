using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
/// </summary>
public partial class ListItemUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? ListId { get; set; }
        public string? ItemId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}";
                case ApiPath.Sites_SiteId_Lists_ListId_Items_ItemId_Fields: return $"/sites/{SiteId}/lists/{ListId}/items/{ItemId}/fields";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Sites_SiteId_Lists_ListId_Items_ItemId,
        Sites_SiteId_Lists_ListId_Items_ItemId_Fields,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
}
public partial class ListItemUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemUpdateResponse> ListItemUpdateAsync()
    {
        var p = new ListItemUpdateParameter();
        return await this.SendAsync<ListItemUpdateParameter, ListItemUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemUpdateResponse> ListItemUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new ListItemUpdateParameter();
        return await this.SendAsync<ListItemUpdateParameter, ListItemUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemUpdateResponse> ListItemUpdateAsync(ListItemUpdateParameter parameter)
    {
        return await this.SendAsync<ListItemUpdateParameter, ListItemUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ListItemUpdateResponse> ListItemUpdateAsync(ListItemUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ListItemUpdateParameter, ListItemUpdateResponse>(parameter, cancellationToken);
    }
}
