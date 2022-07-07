using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceannouncementListMessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages: return $"/admin/serviceAnnouncement/messages";
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
    }
    public partial class ServiceannouncementListMessagesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/serviceupdatemessage?view=graph-rest-1.0
        /// </summary>
        public partial class ServiceUpdateMessage
        {
            public enum ServiceUpdateMessageServiceUpdateCategory
            {
                PreventOrFixIssue,
                PlanForChange,
                StayInformed,
                UnknownFutureValue,
            }
            public enum ServiceUpdateMessageServiceUpdateSeverity
            {
                Normal,
                High,
                Critical,
                UnknownFutureValue,
            }

            public DateTimeOffset? ActionRequiredByDateTime { get; set; }
            public Stream? AttachmentsArchive { get; set; }
            public ItemBody? Body { get; set; }
            public ServiceUpdateMessageServiceUpdateCategory Category { get; set; }
            public KeyValuePair[]? Details { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
            public bool? HasAttachments { get; set; }
            public string? Id { get; set; }
            public bool? IsMajorChange { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public String[]? Services { get; set; }
            public ServiceUpdateMessageServiceUpdateSeverity Severity { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
            public String[]? Tags { get; set; }
            public string? Title { get; set; }
            public ServiceUpdateMessageViewpoint? ViewPoint { get; set; }
        }

        public ServiceUpdateMessage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync()
        {
            var p = new ServiceannouncementListMessagesParameter();
            return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceannouncementListMessagesParameter();
            return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync(ServiceannouncementListMessagesParameter parameter)
        {
            return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceannouncement-list-messages?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceannouncementListMessagesResponse> ServiceannouncementListMessagesAsync(ServiceannouncementListMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceannouncementListMessagesParameter, ServiceannouncementListMessagesResponse>(parameter, cancellationToken);
        }
    }
}
