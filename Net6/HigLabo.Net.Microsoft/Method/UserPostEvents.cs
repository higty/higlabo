using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserPostEventsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Me_Events,
            Users_IdOrUserPrincipalName_Events,
            Me_Calendar_Events,
            Users_IdOrUserPrincipalName_Calendar_Events,
            Me_Calendars_Id_Events,
            Users_IdOrUserPrincipalName_Calendars_Id_Events,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Events: return $"/me/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Events: return $"/users/{IdOrUserPrincipalName}/events";
                    case ApiPath.Me_Calendar_Events: return $"/me/calendar/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendar_Events: return $"/users/{IdOrUserPrincipalName}/calendar/events";
                    case ApiPath.Me_Calendars_Id_Events: return $"/me/calendars/{Id}/events";
                    case ApiPath.Users_IdOrUserPrincipalName_Calendars_Id_Events: return $"/users/{IdOrUserPrincipalName}/calendars/{Id}/events";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string IdOrUserPrincipalName { get; set; }
        public string Id { get; set; }
    }
    public partial class UserPostEventsResponse : RestApiResponse
    {
        public enum EventImportance
        {
            Low,
            Normal,
            High,
        }
        public enum EventOnlineMeetingProviderType
        {
            Unknown,
            TeamsForBusiness,
            SkypeForBusiness,
            SkypeForConsumer,
        }

        public bool? AllowNewTimeProposals { get; set; }
        public Attendee[]? Attendees { get; set; }
        public ItemBody? Body { get; set; }
        public string? BodyPreview { get; set; }
        public String[]? Categories { get; set; }
        public string? ChangeKey { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeTimeZone? End { get; set; }
        public bool? HasAttachments { get; set; }
        public bool? HideAttendees { get; set; }
        public string? ICalUId { get; set; }
        public string? Id { get; set; }
        public EventImportance Importance { get; set; }
        public bool? IsAllDay { get; set; }
        public bool? IsCancelled { get; set; }
        public bool? IsDraft { get; set; }
        public bool? IsOnlineMeeting { get; set; }
        public bool? IsOrganizer { get; set; }
        public bool? IsReminderOn { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Location? Location { get; set; }
        public Location[]? Locations { get; set; }
        public OnlineMeetingInfo? OnlineMeeting { get; set; }
        public EventOnlineMeetingProviderType OnlineMeetingProvider { get; set; }
        public string? OnlineMeetingUrl { get; set; }
        public Recipient? Organizer { get; set; }
        public string? OriginalEndTimeZone { get; set; }
        public DateTimeOffset? OriginalStart { get; set; }
        public string? OriginalStartTimeZone { get; set; }
        public PatternedRecurrence? Recurrence { get; set; }
        public Int32? ReminderMinutesBeforeStart { get; set; }
        public bool? ResponseRequested { get; set; }
        public ResponseStatus? ResponseStatus { get; set; }
        public string? Sensitivity { get; set; }
        public string? SeriesMasterId { get; set; }
        public string? ShowAs { get; set; }
        public DateTimeTimeZone? Start { get; set; }
        public string? Subject { get; set; }
        public string? TransactionId { get; set; }
        public string? Type { get; set; }
        public string? WebLink { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostEventsResponse> UserPostEventsAsync()
        {
            var p = new UserPostEventsParameter();
            return await this.SendAsync<UserPostEventsParameter, UserPostEventsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostEventsResponse> UserPostEventsAsync(CancellationToken cancellationToken)
        {
            var p = new UserPostEventsParameter();
            return await this.SendAsync<UserPostEventsParameter, UserPostEventsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostEventsResponse> UserPostEventsAsync(UserPostEventsParameter parameter)
        {
            return await this.SendAsync<UserPostEventsParameter, UserPostEventsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-post-events?view=graph-rest-1.0
        /// </summary>
        public async Task<UserPostEventsResponse> UserPostEventsAsync(UserPostEventsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserPostEventsParameter, UserPostEventsResponse>(parameter, cancellationToken);
        }
    }
}
