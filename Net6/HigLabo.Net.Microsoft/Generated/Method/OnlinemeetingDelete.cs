using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
    /// </summary>
    public partial class OnlinemeetingDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? MeetingId { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OnlineMeetings_MeetingId: return $"/me/onlineMeetings/{MeetingId}";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId: return $"/users/{UserId}/onlineMeetings/{MeetingId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId,
            Users_UserId_OnlineMeetings_MeetingId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class OnlinemeetingDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync()
        {
            var p = new OnlinemeetingDeleteParameter();
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OnlinemeetingDeleteParameter();
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync(OnlinemeetingDeleteParameter parameter)
        {
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync(OnlinemeetingDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(parameter, cancellationToken);
        }
    }
}
