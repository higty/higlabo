using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnlinemeetingDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId,
            Users_UserId_OnlineMeetings_MeetingId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_OnlineMeetings_MeetingId: return $"/me/onlineMeetings/{MeetingId}";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId: return $"/users/{UserId}/onlineMeetings/{MeetingId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string MeetingId { get; set; }
        public string UserId { get; set; }
    }
    public partial class OnlinemeetingDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync()
        {
            var p = new OnlinemeetingDeleteParameter();
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OnlinemeetingDeleteParameter();
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync(OnlinemeetingDeleteParameter parameter)
        {
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingDeleteResponse> OnlinemeetingDeleteAsync(OnlinemeetingDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnlinemeetingDeleteParameter, OnlinemeetingDeleteResponse>(parameter, cancellationToken);
        }
    }
}
