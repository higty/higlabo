using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageArchiveParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_Archive,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_Archive: return $"/admin/serviceAnnouncement/messages/archive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? MessageIds { get; set; }
    }
    public partial class ServiceupdatemessageArchiveResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync()
        {
            var p = new ServiceupdatemessageArchiveParameter();
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageArchiveParameter();
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync(ServiceupdatemessageArchiveParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync(ServiceupdatemessageArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(parameter, cancellationToken);
        }
    }
}
