using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ContenttypeCopytodefaultcontentlocationParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes_ContentTypeId_CopyToDefaultContentLocation,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Sites_SiteId_ContentTypes_ContentTypeId_CopyToDefaultContentLocation: return $"/sites/{SiteId}/contentTypes/{ContentTypeId}/copyToDefaultContentLocation";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ItemReference? SourceFile { get; set; }
        public string? DestinationFileName { get; set; }
        public string SiteId { get; set; }
        public string ContentTypeId { get; set; }
    }
    public partial class ContenttypeCopytodefaultcontentlocationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeCopytodefaultcontentlocationResponse> ContenttypeCopytodefaultcontentlocationAsync()
        {
            var p = new ContenttypeCopytodefaultcontentlocationParameter();
            return await this.SendAsync<ContenttypeCopytodefaultcontentlocationParameter, ContenttypeCopytodefaultcontentlocationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeCopytodefaultcontentlocationResponse> ContenttypeCopytodefaultcontentlocationAsync(CancellationToken cancellationToken)
        {
            var p = new ContenttypeCopytodefaultcontentlocationParameter();
            return await this.SendAsync<ContenttypeCopytodefaultcontentlocationParameter, ContenttypeCopytodefaultcontentlocationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeCopytodefaultcontentlocationResponse> ContenttypeCopytodefaultcontentlocationAsync(ContenttypeCopytodefaultcontentlocationParameter parameter)
        {
            return await this.SendAsync<ContenttypeCopytodefaultcontentlocationParameter, ContenttypeCopytodefaultcontentlocationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/contenttype-copytodefaultcontentlocation?view=graph-rest-1.0
        /// </summary>
        public async Task<ContenttypeCopytodefaultcontentlocationResponse> ContenttypeCopytodefaultcontentlocationAsync(ContenttypeCopytodefaultcontentlocationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ContenttypeCopytodefaultcontentlocationParameter, ContenttypeCopytodefaultcontentlocationResponse>(parameter, cancellationToken);
        }
    }
}
