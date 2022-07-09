using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageListAttachmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ServiceUpdateMessageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments: return $"/admin/serviceAnnouncement/messages/{ServiceUpdateMessageId}/attachments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Content,
            ContentType,
            Id,
            LastModifiedDateTime,
            Name,
            Size,
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_ServiceUpdateMessageId_Attachments,
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
    public partial class ServiceupdatemessageListAttachmentsResponse : RestApiResponse
    {
        public ServiceAnnouncementAttachment[]? Value { get; set; }
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
