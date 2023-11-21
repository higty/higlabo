using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markread?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceupdatemessageMarkreadParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_MarkRead: return $"/admin/serviceAnnouncement/messages/markRead";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_MarkRead,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? MessageIds { get; set; }
    }
    public partial class ServiceupdatemessageMarkreadResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markread?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkreadResponse> ServiceupdatemessageMarkreadAsync()
        {
            var p = new ServiceupdatemessageMarkreadParameter();
            return await this.SendAsync<ServiceupdatemessageMarkreadParameter, ServiceupdatemessageMarkreadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkreadResponse> ServiceupdatemessageMarkreadAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageMarkreadParameter();
            return await this.SendAsync<ServiceupdatemessageMarkreadParameter, ServiceupdatemessageMarkreadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkreadResponse> ServiceupdatemessageMarkreadAsync(ServiceupdatemessageMarkreadParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageMarkreadParameter, ServiceupdatemessageMarkreadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkreadResponse> ServiceupdatemessageMarkreadAsync(ServiceupdatemessageMarkreadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageMarkreadParameter, ServiceupdatemessageMarkreadResponse>(parameter, cancellationToken);
        }
    }
}
