using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class GroupListCalendarviewParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_CalendarView: return $"/groups/{Id}/calendarView";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AllowNewTimeProposals,
            Attendees,
            Body,
            BodyPreview,
            Categories,
            ChangeKey,
            CreatedDateTime,
            End,
            HasAttachments,
            HideAttendees,
            ICalUId,
            Id,
            Importance,
            IsAllDay,
            IsCancelled,
            IsDraft,
            IsOnlineMeeting,
            IsOrganizer,
            IsReminderOn,
            LastModifiedDateTime,
            Location,
            Locations,
            OnlineMeeting,
            OnlineMeetingProvider,
            OnlineMeetingUrl,
            Organizer,
            OriginalEndTimeZone,
            OriginalStart,
            OriginalStartTimeZone,
            Recurrence,
            ReminderMinutesBeforeStart,
            ResponseRequested,
            ResponseStatus,
            Sensitivity,
            SeriesMasterId,
            ShowAs,
            Start,
            Subject,
            TransactionId,
            Type,
            WebLink,
            Attachments,
            Calendar,
            Extensions,
            Instances,
            MultiValueExtendedProperties,
            SingleValueExtendedProperties,
        }
        public enum ApiPath
        {
            Groups_Id_CalendarView,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class GroupListCalendarviewResponse : RestApiResponse
    {
        public Event[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListCalendarviewResponse> GroupListCalendarviewAsync()
        {
            var p = new GroupListCalendarviewParameter();
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListCalendarviewResponse> GroupListCalendarviewAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListCalendarviewParameter();
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListCalendarviewResponse> GroupListCalendarviewAsync(GroupListCalendarviewParameter parameter)
        {
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-list-calendarview?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListCalendarviewResponse> GroupListCalendarviewAsync(GroupListCalendarviewParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListCalendarviewParameter, GroupListCalendarviewResponse>(parameter, cancellationToken);
        }
    }
}
