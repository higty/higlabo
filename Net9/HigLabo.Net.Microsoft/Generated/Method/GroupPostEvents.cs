using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-post-events?view=graph-rest-1.0
/// </summary>
public partial class GroupPostEventsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

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

    public enum EventOnlineMeetingProviderType
    {
        Unknown,
        TeamsForBusiness,
        SkypeForBusiness,
        SkypeForConsumer,
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
    string IRestApiParameter.HttpMethod { get; } = "POST";
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
    public string? Importance { get; set; }
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
    public Attachment[]? Attachments { get; set; }
    public Calendar? Calendar { get; set; }
    public Extension[]? Extensions { get; set; }
    public Event[]? Instances { get; set; }
    public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
    public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
}
public partial class GroupPostEventsResponse : RestApiResponse
{
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
    public string? Importance { get; set; }
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
    public Attachment[]? Attachments { get; set; }
    public Calendar? Calendar { get; set; }
    public Extension[]? Extensions { get; set; }
    public Event[]? Instances { get; set; }
    public MultiValueLegacyExtendedProperty[]? MultiValueExtendedProperties { get; set; }
    public SingleValueLegacyExtendedProperty[]? SingleValueExtendedProperties { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-post-events?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-events?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostEventsResponse> GroupPostEventsAsync()
    {
        var p = new GroupPostEventsParameter();
        return await this.SendAsync<GroupPostEventsParameter, GroupPostEventsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-events?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostEventsResponse> GroupPostEventsAsync(CancellationToken cancellationToken)
    {
        var p = new GroupPostEventsParameter();
        return await this.SendAsync<GroupPostEventsParameter, GroupPostEventsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-events?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostEventsResponse> GroupPostEventsAsync(GroupPostEventsParameter parameter)
    {
        return await this.SendAsync<GroupPostEventsParameter, GroupPostEventsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-events?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupPostEventsResponse> GroupPostEventsAsync(GroupPostEventsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupPostEventsParameter, GroupPostEventsResponse>(parameter, cancellationToken);
    }
}
