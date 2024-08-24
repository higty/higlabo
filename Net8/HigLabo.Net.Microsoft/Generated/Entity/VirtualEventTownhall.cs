using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventtownhall?view=graph-rest-1.0
    /// </summary>
    public partial class VirtualEventTownhall
    {
        public enum VirtualEventTownhallMeetingAudience
        {
            Everyone,
            Organization,
            UnknownFutureValue,
        }
        public enum VirtualEventTownhallVirtualEventStatus
        {
            Draft,
            Published,
            Canceled,
            UnknownFutureValue,
        }

        public VirtualEventTownhallMeetingAudience Audience { get; set; }
        public CommunicationsUserIdentity[]? CoOrganizers { get; set; }
        public CommunicationsIdentitySet? CreatedBy { get; set; }
        public ItemBody? Description { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeTimeZone? EndDateTime { get; set; }
        public string? Id { get; set; }
        public Identity[]? InvitedAttendees { get; set; }
        public bool? IsInviteOnly { get; set; }
        public VirtualEventSettings? Settings { get; set; }
        public DateTimeTimeZone? StartDateTime { get; set; }
        public VirtualEventTownhallVirtualEventStatus Status { get; set; }
        public VirtualEventPresenter[]? Presenters { get; set; }
        public VirtualEventSession[]? Sessions { get; set; }
    }
}
