using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceannouncementattachmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments_ServiceAnnouncementAttachmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments_ServiceAnnouncementAttachmentId: return $"/admin/serviceAnnouncement/messages/{ServiceUpdateMessageId}/attachments/{ServiceAnnouncementAttachmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string ServiceUpdateMessageId { get; set; }
        public string ServiceAnnouncementAttachmentId { get; set; }
    }
    public partial class ServiceannouncementattachmentGetResponse : RestApiResponse
    {
        public Stream? Content { get; set; }
        public string? ContentType { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Name { get; set; }
        public Int32? Size { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncementattachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementattachmentGetResponse> ServiceannouncementattachmentGetAsync()
        {
            var p = new ServiceannouncementattachmentGetParameter();
            return await this.SendAsync<ServiceannouncementattachmentGetParameter, ServiceannouncementattachmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncementattachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementattachmentGetResponse> ServiceannouncementattachmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceannouncementattachmentGetParameter();
            return await this.SendAsync<ServiceannouncementattachmentGetParameter, ServiceannouncementattachmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncementattachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementattachmentGetResponse> ServiceannouncementattachmentGetAsync(ServiceannouncementattachmentGetParameter parameter)
        {
            return await this.SendAsync<ServiceannouncementattachmentGetParameter, ServiceannouncementattachmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncementattachment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementattachmentGetResponse> ServiceannouncementattachmentGetAsync(ServiceannouncementattachmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceannouncementattachmentGetParameter, ServiceannouncementattachmentGetResponse>(parameter, cancellationToken);
        }
    }
}
