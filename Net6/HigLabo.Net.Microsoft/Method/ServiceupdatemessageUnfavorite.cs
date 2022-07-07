using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageUnfavoriteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_Unfavorite,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_Unfavorite: return $"/admin/serviceAnnouncement/messages/unfavorite";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? MessageIds { get; set; }
    }
    public partial class ServiceupdatemessageUnfavoriteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnfavoriteResponse> ServiceupdatemessageUnfavoriteAsync()
        {
            var p = new ServiceupdatemessageUnfavoriteParameter();
            return await this.SendAsync<ServiceupdatemessageUnfavoriteParameter, ServiceupdatemessageUnfavoriteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnfavoriteResponse> ServiceupdatemessageUnfavoriteAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceupdatemessageUnfavoriteParameter();
            return await this.SendAsync<ServiceupdatemessageUnfavoriteParameter, ServiceupdatemessageUnfavoriteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnfavoriteResponse> ServiceupdatemessageUnfavoriteAsync(ServiceupdatemessageUnfavoriteParameter parameter)
        {
            return await this.SendAsync<ServiceupdatemessageUnfavoriteParameter, ServiceupdatemessageUnfavoriteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceupdatemessage-unfavorite?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceupdatemessageUnfavoriteResponse> ServiceupdatemessageUnfavoriteAsync(ServiceupdatemessageUnfavoriteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceupdatemessageUnfavoriteParameter, ServiceupdatemessageUnfavoriteResponse>(parameter, cancellationToken);
        }
    }
}
