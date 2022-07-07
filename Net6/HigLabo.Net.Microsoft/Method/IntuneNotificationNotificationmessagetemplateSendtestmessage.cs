using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneNotificationNotificationmessagetemplateSendtestmessageParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_SendTestMessage,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_NotificationMessageTemplates_NotificationMessageTemplateId_SendTestMessage: return $"/deviceManagement/notificationMessageTemplates/{NotificationMessageTemplateId}/sendTestMessage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string NotificationMessageTemplateId { get; set; }
    }
    public partial class IntuneNotificationNotificationmessagetemplateSendtestmessageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-sendtestmessage?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateSendtestmessageResponse> IntuneNotificationNotificationmessagetemplateSendtestmessageAsync()
        {
            var p = new IntuneNotificationNotificationmessagetemplateSendtestmessageParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateSendtestmessageParameter, IntuneNotificationNotificationmessagetemplateSendtestmessageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-sendtestmessage?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateSendtestmessageResponse> IntuneNotificationNotificationmessagetemplateSendtestmessageAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneNotificationNotificationmessagetemplateSendtestmessageParameter();
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateSendtestmessageParameter, IntuneNotificationNotificationmessagetemplateSendtestmessageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-sendtestmessage?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateSendtestmessageResponse> IntuneNotificationNotificationmessagetemplateSendtestmessageAsync(IntuneNotificationNotificationmessagetemplateSendtestmessageParameter parameter)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateSendtestmessageParameter, IntuneNotificationNotificationmessagetemplateSendtestmessageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-notification-notificationmessagetemplate-sendtestmessage?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneNotificationNotificationmessagetemplateSendtestmessageResponse> IntuneNotificationNotificationmessagetemplateSendtestmessageAsync(IntuneNotificationNotificationmessagetemplateSendtestmessageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneNotificationNotificationmessagetemplateSendtestmessageParameter, IntuneNotificationNotificationmessagetemplateSendtestmessageResponse>(parameter, cancellationToken);
        }
    }
}
