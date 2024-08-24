using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
    /// </summary>
    public partial class ListItemCreateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? ListId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Lists_ListId_Items: return $"/sites/{SiteId}/lists/{ListId}/items";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_Lists_ListId_Items,
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
        public ContentTypeInfo? ContentType { get; set; }
        public ItemActivity[]? Activities { get; set; }
        public ItemAnalytics? Analytics { get; set; }
        public DocumentSetVersion[]? DocumentSetVersions { get; set; }
        public DriveItem? DriveItem { get; set; }
        public FieldValueSet? Fields { get; set; }
        public ListItemVersion[]? Versions { get; set; }
    }
    public partial class ListItemCreateResponse : RestApiResponse
    {
        public ContentTypeInfo? ContentType { get; set; }
        public ItemActivity[]? Activities { get; set; }
        public ItemAnalytics? Analytics { get; set; }
        public DocumentSetVersion[]? DocumentSetVersions { get; set; }
        public DriveItem? DriveItem { get; set; }
        public FieldValueSet? Fields { get; set; }
        public ListItemVersion[]? Versions { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemCreateResponse> ListItemCreateAsync()
        {
            var p = new ListItemCreateParameter();
            return await this.SendAsync<ListItemCreateParameter, ListItemCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemCreateResponse> ListItemCreateAsync(CancellationToken cancellationToken)
        {
            var p = new ListItemCreateParameter();
            return await this.SendAsync<ListItemCreateParameter, ListItemCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemCreateResponse> ListItemCreateAsync(ListItemCreateParameter parameter)
        {
            return await this.SendAsync<ListItemCreateParameter, ListItemCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/listitem-create?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ListItemCreateResponse> ListItemCreateAsync(ListItemCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ListItemCreateParameter, ListItemCreateResponse>(parameter, cancellationToken);
        }
    }
}
