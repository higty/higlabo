using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/schedule?view=graph-rest-1.0
    /// </summary>
    public partial class Schedule
    {
        public String? Id { get; set; }
        public bool Enabled { get; set; }
        public String? TimeZone { get; set; }
        public ScheduleOperationStatus ProvisionStatus { get; set; }
        public String? ProvisionStatusCode { get; set; }
        public bool TimeClockEnabled { get; set; }
        public bool OpenShiftsEnabled { get; set; }
        public bool SwapShiftsRequestsEnabled { get; set; }
        public bool OfferShiftRequestsEnabled { get; set; }
        public bool TimeOffRequestsEnabled { get; set; }
    }
}
