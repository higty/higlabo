using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments: return $"/admin/serviceAnnouncement/messages/{ServiceUpdateMessageId}/attachments";
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
    }
    public partial class ServiceupdatemessageListAttachmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/serviceannouncementattachment?view=graph-rest-1.0
        /// </summary>
        public partial class ServiceAnnouncementAttachment
        {
            public Stream? Content { get; set; }
            public string? ContentType { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Name { get; set; }
            public Int32? Size { get; set; }
        }

        public ServiceAnnouncementAttachment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync()
        {
            var p = new ServiceupdatemessageListAttachmentsParameter();
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageListAttachmentsParameter();
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync(ServiceupdatemessageListAttachmentsParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-list-attachments?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageListAttachmentsResponse> ServiceupdatemessageListAttachmentsAsync(ServiceupdatemessageListAttachmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageListAttachmentsParameter, ServiceupdatemessageListAttachmentsResponse>(parameter, cancellationToken);
        }
    }
}
