using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceannouncementListMessagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages: return $"/admin/serviceAnnouncement/messages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ActionRequiredByDateTime,
            AttachmentsArchive,
            Body,
            Category,
            Details,
            EndDateTime,
            HasAttachments,
            Id,
            IsMajorChange,
            LastModifiedDateTime,
            Services,
            Severity,
            StartDateTime,
            Tags,
            Title,
            ViewPoint,
            Attachments,
        }
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages,
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
    public partial class ServiceannouncementListMessagesResponse : RestApiResponse
    {
        public ServiceUpdateMessage[]? Value { get; set; }
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
