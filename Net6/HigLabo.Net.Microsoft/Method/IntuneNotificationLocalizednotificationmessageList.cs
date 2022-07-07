using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationLocalizednotificationmessageListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_LocalizedNotificationMessages,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_LocalizedNotificationMessages: return $"/deviceManagement/notificationMessageTemplates/{NotificationMessageTemplateId}/localizedNotificationMessages";
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
        public string NotificationMessageTemplateId { get; set; }
    }
    public partial class IntuneNotificationLocalizednotificationmessageListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-notification-localizednotificationmessage?view=graph-rest-1.0
        /// </summary>
        public partial class LocalizedNotificationMessage
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? Locale { get; set; }
            public string? Subject { get; set; }
            public string? MessageTemplate { get; set; }
            public bool? IsDefault { get; set; }
        }

        public LocalizedNotificationMessage[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageListResponse> IntuneNotificationLocalizednotificationmessageListAsync()
        {
            var p = new IntuneNotificationLocalizednotificationmessageListParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageListParameter, IntuneNotificationLocalizednotificationmessageListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageListResponse> IntuneNotificationLocalizednotificationmessageListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationLocalizednotificationmessageListParameter();
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageListParameter, IntuneNotificationLocalizednotificationmessageListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageListResponse> IntuneNotificationLocalizednotificationmessageListAsync(IntuneNotificationLocalizednotificationmessageListParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageListParameter, IntuneNotificationLocalizednotificationmessageListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-localizednotificationmessage-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationLocalizednotificationmessageListResponse> IntuneNotificationLocalizednotificationmessageListAsync(IntuneNotificationLocalizednotificationmessageListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationLocalizednotificationmessageListParameter, IntuneNotificationLocalizednotificationmessageListResponse>(parameter, cancellationToken);
        }
    }
}
