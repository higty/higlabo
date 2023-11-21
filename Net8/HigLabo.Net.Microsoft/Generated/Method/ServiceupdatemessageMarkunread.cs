using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceupdatemessageMarkunreadParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_MarkUnread: return $"/admin/serviceAnnouncement/messages/markUnread";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_MarkUnread,
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
    public partial class ServiceupdatemessageMarkunreadResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync()
        {
            var p = new ServiceupdatemessageMarkunreadParameter();
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageMarkunreadParameter();
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync(ServiceupdatemessageMarkunreadParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync(ServiceupdatemessageMarkunreadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(parameter, cancellationToken);
        }
    }
}
