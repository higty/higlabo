using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageMarkunreadParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_MarkUnread,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_MarkUnread: return $"/admin/serviceAnnouncement/messages/markUnread";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? MessageIds { get; set; }
    }
    public partial class ServiceupdatemessageMarkunreadResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync()
        {
            var p = new ServiceupdatemessageMarkunreadParameter();
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageMarkunreadParameter();
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync(ServiceupdatemessageMarkunreadParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-markunread?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageMarkunreadResponse> ServiceupdatemessageMarkunreadAsync(ServiceupdatemessageMarkunreadParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageMarkunreadParameter, ServiceupdatemessageMarkunreadResponse>(parameter, cancellationToken);
        }
    }
}
