using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationNotificationmessagetemplateDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string NotificationMessageTemplateId { get; set; }
    }
    public partial class IntuneNotificationNotificationmessagetemplateDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateDeleteResponse> IntuneNotificationNotificationmessagetemplateDeleteAsync()
        {
            var p = new IntuneNotificationNotificationmessagetemplateDeleteParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateDeleteParameter, IntuneNotificationNotificationmessagetemplateDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateDeleteResponse> IntuneNotificationNotificationmessagetemplateDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationNotificationmessagetemplateDeleteParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateDeleteParameter, IntuneNotificationNotificationmessagetemplateDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateDeleteResponse> IntuneNotificationNotificationmessagetemplateDeleteAsync(IntuneNotificationNotificationmessagetemplateDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateDeleteParameter, IntuneNotificationNotificationmessagetemplateDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateDeleteResponse> IntuneNotificationNotificationmessagetemplateDeleteAsync(IntuneNotificationNotificationmessagetemplateDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateDeleteParameter, IntuneNotificationNotificationmessagetemplateDeleteResponse>(parameter, cancellationToken);
        }
    }
}
