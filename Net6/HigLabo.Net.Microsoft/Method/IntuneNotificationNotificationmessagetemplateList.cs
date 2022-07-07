using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationNotificationmessagetemplateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_NotificationMessageTemplates,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_NotificationMessageTemplates: return $"/deviceManagement/notificationMessageTemplates";
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
    public partial class IntuneNotificationNotificationmessagetemplateListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-notification-notificationmessagetemplate?view=graph-rest-1.0
        /// </summary>
        public partial class NotificationMessageTemplate
        {
            public enum NotificationMessageTemplateNotificationTemplateBrandingOptions
            {
                None,
                IncludeCompanyLogo,
                IncludeCompanyName,
                IncludeContactInformation,
            }

            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public string? DisplayName { get; set; }
            public string? DefaultLocale { get; set; }
            public NotificationTemplateBrandingOptions? BrandingOptions { get; set; }
        }

        public NotificationMessageTemplate[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateListResponse> IntuneNotificationNotificationmessagetemplateListAsync()
        {
            var p = new IntuneNotificationNotificationmessagetemplateListParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateListParameter, IntuneNotificationNotificationmessagetemplateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateListResponse> IntuneNotificationNotificationmessagetemplateListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationNotificationmessagetemplateListParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateListParameter, IntuneNotificationNotificationmessagetemplateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateListResponse> IntuneNotificationNotificationmessagetemplateListAsync(IntuneNotificationNotificationmessagetemplateListParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateListParameter, IntuneNotificationNotificationmessagetemplateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateListResponse> IntuneNotificationNotificationmessagetemplateListAsync(IntuneNotificationNotificationmessagetemplateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateListParameter, IntuneNotificationNotificationmessagetemplateListResponse>(parameter, cancellationToken);
        }
    }
}
