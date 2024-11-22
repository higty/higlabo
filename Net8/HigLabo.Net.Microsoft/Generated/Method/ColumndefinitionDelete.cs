using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
/// </summary>
public partial class ColumnDefinitionDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? ColumnId { get; set; }
        public string? ListId { get; set; }
        public string? ContentTypeId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_Columns_ColumnId: return $"/sites/{SiteId}/columns/{ColumnId}";
                case ApiPath.Sites_SiteId_Lists_ListId_Columns_ColumnId: return $"/sites/{SiteId}/lists/{ListId}/columns/{ColumnId}";
                case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Columns_ColumnId: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/columns/{ColumnId}";
                case ApiPath.Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns_ColumnId: return $"/sites/{SiteId}/lists/{ListId}/contentTypes/{ContentTypeId}/columns/{ColumnId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Sites_SiteId_Columns_ColumnId,
        Sites_SiteId_Lists_ListId_Columns_ColumnId,
        Sites_SiteId_ContentTypes_ContentTypeId_Columns_ColumnId,
        Sites_SiteId_Lists_ListId_ContentTypes_ContentTypeId_Columns_ColumnId,
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
public partial class ColumnDefinitionDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ColumnDefinitionDeleteResponse> ColumnDefinitionDeleteAsync()
    {
        var p = new ColumnDefinitionDeleteParameter();
        return await this.SendAsync<ColumnDefinitionDeleteParameter, ColumnDefinitionDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ColumnDefinitionDeleteResponse> ColumnDefinitionDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ColumnDefinitionDeleteParameter();
        return await this.SendAsync<ColumnDefinitionDeleteParameter, ColumnDefinitionDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ColumnDefinitionDeleteResponse> ColumnDefinitionDeleteAsync(ColumnDefinitionDeleteParameter parameter)
    {
        return await this.SendAsync<ColumnDefinitionDeleteParameter, ColumnDefinitionDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/columndefinition-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ColumnDefinitionDeleteResponse> ColumnDefinitionDeleteAsync(ColumnDefinitionDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ColumnDefinitionDeleteParameter, ColumnDefinitionDeleteResponse>(parameter, cancellationToken);
    }
}
