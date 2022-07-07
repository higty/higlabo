using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OnlinemeetingGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_OnlineMeetings_MeetingId,
            Users_UserId_OnlineMeetings_MeetingId,
            Communications_OnlineMeetings_,
            Me_OnlineMeetings,
            Users_UserId_OnlineMeetings,
            Me_OnlineMeetings_MeetingId_AttendeeReport,
            Users_UserId_OnlineMeetings_MeetingId_AttendeeReport,
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
                    case ApiPath.Communications_OnlineMeetings_: return $"/communications/onlineMeetings/";
                    case ApiPath.Me_OnlineMeetings: return $"/me/onlineMeetings";
                    case ApiPath.Users_UserId_OnlineMeetings: return $"/users/{UserId}/onlineMeetings";
                    case ApiPath.Me_OnlineMeetings_MeetingId_AttendeeReport: return $"/me/onlineMeetings/{MeetingId}/attendeeReport";
                    case ApiPath.Users_UserId_OnlineMeetings_MeetingId_AttendeeReport: return $"/users/{UserId}/onlineMeetings/{MeetingId}/attendeeReport";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string MeetingId { get; set; }
        public string UserId { get; set; }
    }
    public partial class OnlinemeetingGetResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingGetResponse> OnlinemeetingGetAsync()
        {
            var p = new OnlinemeetingGetParameter();
            return await this.SendAsync<OnlinemeetingGetParameter, OnlinemeetingGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingGetResponse> OnlinemeetingGetAsync(CancellationToken cancellationToken)
        {
            var p = new OnlinemeetingGetParameter();
            return await this.SendAsync<OnlinemeetingGetParameter, OnlinemeetingGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingGetResponse> OnlinemeetingGetAsync(OnlinemeetingGetParameter parameter)
        {
            return await this.SendAsync<OnlinemeetingGetParameter, OnlinemeetingGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/onlinemeeting-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OnlinemeetingGetResponse> OnlinemeetingGetAsync(OnlinemeetingGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OnlinemeetingGetParameter, OnlinemeetingGetResponse>(parameter, cancellationToken);
        }
    }
}
