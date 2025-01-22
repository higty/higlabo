using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventwebinar?view=graph-rest-1.0
/// </summary>
public partial class VirtualEventWebinar
{
    public enum VirtualEventWebinarMeetingAudience
    {
        Everyone,
        Organization,
        UnknownFutureValue,
    }
    public enum VirtualEventWebinarVirtualEventStatus
    {
        Draft,
        Published,
        Canceled,
        UnknownFutureValue,
    }

    public VirtualEventWebinarMeetingAudience Audience { get; set; }
    public CommunicationsUserIdentity[]? CoOrganizers { get; set; }
    public CommunicationsIdentitySet? CreatedBy { get; set; }
    public ItemBody? Description { get; set; }
    public string? DisplayName { get; set; }
    public DateTimeTimeZone? EndDateTime { get; set; }
    public DateTimeTimeZone? StartDateTime { get; set; }
    public string? Id { get; set; }
    public VirtualEventSettings? Settings { get; set; }
    public VirtualEventWebinarVirtualEventStatus Status { get; set; }
    public VirtualEventWebinarRegistrationConfiguration? RegistrationConfiguration { get; set; }
    public VirtualEventRegistration[]? Registrations { get; set; }
    public VirtualEventSession[]? Sessions { get; set; }
}
