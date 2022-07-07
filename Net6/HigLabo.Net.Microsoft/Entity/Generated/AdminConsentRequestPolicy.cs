using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/adminconsentrequestpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class AdminConsentRequestPolicy
    {
        public bool? IsEnabled { get; set; }
        public bool? NotifyReviewers { get; set; }
        public bool? RemindersEnabled { get; set; }
        public Int32? RequestDurationInDays { get; set; }
        public AccessReviewReviewerScope[]? Reviewers { get; set; }
        public Int32? Version { get; set; }
    }
}
