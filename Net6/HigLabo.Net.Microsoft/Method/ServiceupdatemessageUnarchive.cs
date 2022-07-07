using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageUnarchiveParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_Unarchive,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_Unarchive: return $"/admin/serviceAnnouncement/messages/unarchive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? MessageIds { get; set; }
    }
    public partial class ServiceupdatemessageUnarchiveResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnarchiveResponse> ServiceupdatemessageUnarchiveAsync()
        {
            var p = new ServiceupdatemessageUnarchiveParameter();
            return await this.SendAsync<ServiceupdatemessageUnarchiveParameter, ServiceupdatemessageUnarchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnarchiveResponse> ServiceupdatemessageUnarchiveAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageUnarchiveParameter();
            return await this.SendAsync<ServiceupdatemessageUnarchiveParameter, ServiceupdatemessageUnarchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnarchiveResponse> ServiceupdatemessageUnarchiveAsync(ServiceupdatemessageUnarchiveParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageUnarchiveParameter, ServiceupdatemessageUnarchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unarchive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnarchiveResponse> ServiceupdatemessageUnarchiveAsync(ServiceupdatemessageUnarchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageUnarchiveParameter, ServiceupdatemessageUnarchiveResponse>(parameter, cancellationToken);
        }
    }
}
