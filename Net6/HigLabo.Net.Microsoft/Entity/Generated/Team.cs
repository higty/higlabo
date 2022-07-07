using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/team?view=graph-rest-1.0
    /// </summary>
    public partial class Team
    {
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Classification { get; set; }
        public TeamSpecialization? Specialization { get; set; }
        public TeamVisibilityType? Visibility { get; set; }
        public TeamFunSettings? FunSettings { get; set; }
        public TeamGuestSettings? GuestSettings { get; set; }
        public string? InternalId { get; set; }
        public bool? IsArchived { get; set; }
        public TeamMemberSettings? MemberSettings { get; set; }
        public TeamMessagingSettings? MessagingSettings { get; set; }
        public string? WebUrl { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
}
