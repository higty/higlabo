using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListEventsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Events: return $"/groups/{Id}/events";
                    case ApiPath.Groups_Id_Calendar_Events: return $"/groups/{Id}/calendar/events";
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
            Groups_Id_Events,
            Groups_Id_Calendar_Events,
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
    public partial class GroupListEventsResponse : RestApiResponse
    {
        public Event[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListEventsResponse> GroupListEventsAsync()
        {
            var p = new GroupListEventsParameter();
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListEventsResponse> GroupListEventsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListEventsParameter();
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListEventsResponse> GroupListEventsAsync(GroupListEventsParameter parameter)
        {
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-events?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListEventsResponse> GroupListEventsAsync(GroupListEventsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListEventsParameter, GroupListEventsResponse>(parameter, cancellationToken);
        }
    }
}
