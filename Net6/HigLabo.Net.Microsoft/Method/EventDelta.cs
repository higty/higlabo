using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EventDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_CalendarView_Delta: return $"/me/calendarView/delta";
                    case ApiPath.Users_Id_CalendarView_Delta: return $"/users/{Id}/calendarView/delta";
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
            Me_CalendarView_Delta,
            Users_Id_CalendarView_Delta,
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
    public partial class EventDeltaResponse : RestApiResponse
    {
        public Event[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeltaResponse> EventDeltaAsync()
        {
            var p = new EventDeltaParameter();
            return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeltaResponse> EventDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EventDeltaParameter();
            return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeltaResponse> EventDeltaAsync(EventDeltaParameter parameter)
        {
            return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/event-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EventDeltaResponse> EventDeltaAsync(EventDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EventDeltaParameter, EventDeltaResponse>(parameter, cancellationToken);
        }
    }
}
