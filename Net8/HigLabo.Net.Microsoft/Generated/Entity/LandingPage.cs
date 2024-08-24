using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/landingpage?view=graph-rest-1.0
    /// </summary>
    public partial class LandingPage
    {
        public enum LandingPageSimulationContentSource
        {
            Unknown,
            Global,
            Tenant,
            UnknownFutureValue,
        }
        public enum LandingPageSimulationContentStatus
        {
            Unknown,
            Draft,
            Ready,
            Archive,
            Delete,
            UnknownFutureValue,
        }

        public EmailIdentity? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public EmailIdentity? LastModifiedBy { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Locale { get; set; }
        public LandingPageSimulationContentSource Source { get; set; }
        public Simulation? Status { get; set; }
        public String[]? SupportedLocales { get; set; }
        public LandingPageDetail[]? Details { get; set; }
    }
}
