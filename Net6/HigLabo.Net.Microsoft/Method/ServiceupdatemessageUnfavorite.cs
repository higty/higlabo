using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceupdatemessageUnfavoriteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Admin_ServiceAnnouncement_Messages_Unfavorite: return $"/admin/serviceAnnouncement/messages/unfavorite";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Admin_ServiceAnnouncement_Messages_Unfavorite,
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
