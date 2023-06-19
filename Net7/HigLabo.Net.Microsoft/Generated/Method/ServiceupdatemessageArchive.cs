using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceupdatemessageArchiveParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_Archive: return $"/admin/serviceAnnouncement/messages/archive";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_Archive,
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
    public partial class ServiceupdatemessageArchiveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync()
        {
            var p = new ServiceupdatemessageArchiveParameter();
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageArchiveParameter();
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync(ServiceupdatemessageArchiveParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceupdatemessage-archive?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceupdatemessageArchiveResponse> ServiceupdatemessageArchiveAsync(ServiceupdatemessageArchiveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageArchiveParameter, ServiceupdatemessageArchiveResponse>(parameter, cancellationToken);
        }
    }
}
