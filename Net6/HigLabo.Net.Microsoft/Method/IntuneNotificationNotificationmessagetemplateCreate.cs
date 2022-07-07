using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationNotificationmessagetemplateCreateParameter : IRestApiParameter
    {
        public enum IntuneNotificationNotificationmessagetemplateCreateParameterNotificationTemplateBrandingOptions
        {
            None,
            IncludeCompanyLogo,
            IncludeCompanyName,
            IncludeContactInformation,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public string? DefaultLocale { get; set; }
        public IntuneNotificationNotificationmessagetemplateCreateParameterNotificationTemplateBrandingOptions BrandingOptions { get; set; }
    }
    public partial class IntuneNotificationNotificationmessagetemplateCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateCreateResponse> IntuneNotificationNotificationmessagetemplateCreateAsync()
        {
            var p = new IntuneNotificationNotificationmessagetemplateCreateParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateCreateParameter, IntuneNotificationNotificationmessagetemplateCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateCreateResponse> IntuneNotificationNotificationmessagetemplateCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationNotificationmessagetemplateCreateParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateCreateParameter, IntuneNotificationNotificationmessagetemplateCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateCreateResponse> IntuneNotificationNotificationmessagetemplateCreateAsync(IntuneNotificationNotificationmessagetemplateCreateParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateCreateParameter, IntuneNotificationNotificationmessagetemplateCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateCreateResponse> IntuneNotificationNotificationmessagetemplateCreateAsync(IntuneNotificationNotificationmessagetemplateCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateCreateParameter, IntuneNotificationNotificationmessagetemplateCreateResponse>(parameter, cancellationToken);
        }
    }
}
