using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationNotificationmessagetemplateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId: return $"/deviceManagement/notificationMessageTemplates/{NotificationMessageTemplateId}";
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
    public partial class IntuneNotificationNotificationmessagetemplateGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateGetResponse> IntuneNotificationNotificationmessagetemplateGetAsync()
        {
            var p = new IntuneNotificationNotificationmessagetemplateGetParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateGetParameter, IntuneNotificationNotificationmessagetemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateGetResponse> IntuneNotificationNotificationmessagetemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationNotificationmessagetemplateGetParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateGetParameter, IntuneNotificationNotificationmessagetemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateGetResponse> IntuneNotificationNotificationmessagetemplateGetAsync(IntuneNotificationNotificationmessagetemplateGetParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateGetParameter, IntuneNotificationNotificationmessagetemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateGetResponse> IntuneNotificationNotificationmessagetemplateGetAsync(IntuneNotificationNotificationmessagetemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateGetParameter, IntuneNotificationNotificationmessagetemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
