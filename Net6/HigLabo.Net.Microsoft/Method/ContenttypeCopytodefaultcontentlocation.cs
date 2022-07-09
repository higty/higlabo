using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContentTypeCopytodefaultContentLocationParameter : IRestApiParameter
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
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_CopyToDefaultContentLocation: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/copyToDefaultContentLocation";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_CopyToDefaultContentLocation,
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
        public ItemReference? SourceFile { get; set; }
        public string? DestinationFileName { get; set; }
    }
    public partial class ContentTypeCopytodefaultContentLocationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeCopytodefaultContentLocationResponse> ContentTypeCopytodefaultContentLocationAsync()
        {
            var p = new ContentTypeCopytodefaultContentLocationParameter();
            return await this.SendAsync<ContentTypeCopytodefaultContentLocationParameter, ContentTypeCopytodefaultContentLocationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeCopytodefaultContentLocationResponse> ContentTypeCopytodefaultContentLocationAsync(CancellationToken cancellationToken)
        {
            var p = new ContentTypeCopytodefaultContentLocationParameter();
            return await this.SendAsync<ContentTypeCopytodefaultContentLocationParameter, ContentTypeCopytodefaultContentLocationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeCopytodefaultContentLocationResponse> ContentTypeCopytodefaultContentLocationAsync(ContentTypeCopytodefaultContentLocationParameter parameter)
        {
            return await this.SendAsync<ContentTypeCopytodefaultContentLocationParameter, ContentTypeCopytodefaultContentLocationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContentTypeCopytodefaultContentLocationResponse> ContentTypeCopytodefaultContentLocationAsync(ContentTypeCopytodefaultContentLocationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContentTypeCopytodefaultContentLocationParameter, ContentTypeCopytodefaultContentLocationResponse>(parameter, cancellationToken);
        }
    }
}
