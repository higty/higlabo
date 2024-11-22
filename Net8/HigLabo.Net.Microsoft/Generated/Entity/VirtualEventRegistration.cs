using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventregistration?view=graph-rest-1.0
/// </summary>
public partial class VirtualEventRegistration
{
    public enum VirtualEventRegistrationVirtualEventAttendeeRegistrationStatus
    {
        Registered,
        Canceled,
        Waitlisted,
        PendingApproval,
        RejectedByOrganizer,
        UnknownFutureValue,
    }

    public DateTimeOffset? CancelationDateTime { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? Id { get; set; }
    public string? LastName { get; set; }
    public DateTimeOffset? RegistrationDateTime { get; set; }
    public VirtualEventRegistrationQuestionAnswer[]? RegistrationQuestionAnswers { get; set; }
    public VirtualEventRegistrationVirtualEventAttendeeRegistrationStatus Status { get; set; }
    public string? UserId { get; set; }
    public string? PreferredTimezone { get; set; }
    public string? PreferredLanguage { get; set; }
    public VirtualEventSession[]? Sessions { get; set; }
}
