using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ServiceUpdateMessageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId: return $"/admin/serviceAnnouncement/messages/{ServiceUpdateMessageId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId,
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
    public partial class ServiceupdatemessageGetResponse : RestApiResponse
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
        public ServiceAnnouncementAttachment[]? Attachments { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageGetResponse> ServiceupdatemessageGetAsync()
        {
            var p = new ServiceupdatemessageGetParameter();
            return await this.SendAsync<ServiceupdatemessageGetParameter, ServiceupdatemessageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageGetResponse> ServiceupdatemessageGetAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageGetParameter();
            return await this.SendAsync<ServiceupdatemessageGetParameter, ServiceupdatemessageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageGetResponse> ServiceupdatemessageGetAsync(ServiceupdatemessageGetParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageGetParameter, ServiceupdatemessageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageGetResponse> ServiceupdatemessageGetAsync(ServiceupdatemessageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageGetParameter, ServiceupdatemessageGetResponse>(parameter, cancellationToken);
        }
    }
}
