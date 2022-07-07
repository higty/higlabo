using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserFindmeetingtimesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_FindMeetingTimes,
            Users_IdOruserPrincipalName_FindMeetingTimes,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_FindMeetingTimes: return $"/me/findMeetingTimes";
                    case ApiPath.Users_IdOruserPrincipalName_FindMeetingTimes: return $"/users/{IdOrUserPrincipalName}/findMeetingTimes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public AttendeeBase[]? Attendees { get; set; }
        public Boolean? IsOrganizerOptional { get; set; }
        public LocationConstraint? LocationConstraint { get; set; }
        public Int32? MaxCandidates { get; set; }
        public string? MeetingDuration { get; set; }
        public Double? MinimumAttendeePercentage { get; set; }
        public Boolean? ReturnSuggestionReasons { get; set; }
        public TimeConstraint? TimeConstraint { get; set; }
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UserFindmeetingtimesResponse : RestApiResponse
    {
        public string? EmptySuggestionsReason { get; set; }
        public MeetingTimeSuggestion[]? MeetingTimeSuggestions { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-findmeetingtimes?view=graph-rest-1.0
        /// </summary>
        public async Task<UserFindmeetingtimesResponse> UserFindmeetingtimesAsync()
        {
            var p = new UserFindmeetingtimesParameter();
            return await this.SendAsync<UserFindmeetingtimesParameter, UserFindmeetingtimesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-findmeetingtimes?view=graph-rest-1.0
        /// </summary>
        public async Task<UserFindmeetingtimesResponse> UserFindmeetingtimesAsync(CancellationToken cancellationToken)
        {
            var p = new UserFindmeetingtimesParameter();
            return await this.SendAsync<UserFindmeetingtimesParameter, UserFindmeetingtimesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-findmeetingtimes?view=graph-rest-1.0
        /// </summary>
        public async Task<UserFindmeetingtimesResponse> UserFindmeetingtimesAsync(UserFindmeetingtimesParameter parameter)
        {
            return await this.SendAsync<UserFindmeetingtimesParameter, UserFindmeetingtimesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-findmeetingtimes?view=graph-rest-1.0
        /// </summary>
        public async Task<UserFindmeetingtimesResponse> UserFindmeetingtimesAsync(UserFindmeetingtimesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserFindmeetingtimesParameter, UserFindmeetingtimesResponse>(parameter, cancellationToken);
        }
    }
}
