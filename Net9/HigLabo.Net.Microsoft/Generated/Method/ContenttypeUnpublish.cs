using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
/// </summary>
public partial class ContentTypeUnpublishParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? SiteId { get; set; }
        public string? ContentTypeId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_Unpublish: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/unpublish";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Sites_SiteId_ContentTypes_ContentTypeId_Unpublish,
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
}
public partial class ContentTypeUnpublishResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContentTypeUnpublishResponse> ContentTypeUnpublishAsync()
    {
        var p = new ContentTypeUnpublishParameter();
        return await this.SendAsync<ContentTypeUnpublishParameter, ContentTypeUnpublishResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContentTypeUnpublishResponse> ContentTypeUnpublishAsync(CancellationToken cancellationToken)
    {
        var p = new ContentTypeUnpublishParameter();
        return await this.SendAsync<ContentTypeUnpublishParameter, ContentTypeUnpublishResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContentTypeUnpublishResponse> ContentTypeUnpublishAsync(ContentTypeUnpublishParameter parameter)
    {
        return await this.SendAsync<ContentTypeUnpublishParameter, ContentTypeUnpublishResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/contenttype-unpublish?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ContentTypeUnpublishResponse> ContentTypeUnpublishAsync(ContentTypeUnpublishParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ContentTypeUnpublishParameter, ContentTypeUnpublishResponse>(parameter, cancellationToken);
    }
}
