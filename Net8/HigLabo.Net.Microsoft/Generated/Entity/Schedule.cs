using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/schedule?view=graph-rest-1.0
    /// </summary>
    public partial class Schedule
    {
        public enum ScheduleOperationStatus
        {
            NotStarted,
            Running,
            Completed,
            Failed,
        }

        public bool? Enabled { get; set; }
        public string? Id { get; set; }
        public bool? OfferShiftRequestsEnabled { get; set; }
        public bool? OpenShiftsEnabled { get; set; }
        public ScheduleOperationStatus ProvisionStatus { get; set; }
        public string? ProvisionStatusCode { get; set; }
        public bool? SwapShiftsRequestsEnabled { get; set; }
        public bool? TimeClockEnabled { get; set; }
        public bool? TimeOffRequestsEnabled { get; set; }
        public string? TimeZone { get; set; }
        public OpenShiftChangeRequest[]? OpenShiftChangeRequests { get; set; }
        public OpenShift[]? OpenShifts { get; set; }
        public SchedulingGroup[]? SchedulingGroups { get; set; }
        public Shift[]? Shifts { get; set; }
        public SwapShiftsChangeRequest[]? SwapShiftChangeRequests { get; set; }
        public TimeOff[]? TimesOff { get; set; }
        public TimeOffReason[]? TimeOffReasons { get; set; }
        public TimeOffRequest[]? Timeoffrequest { get; set; }
        public WorkforceIntegration[]? WorkforceIntegrations { get; set; }
    }
}
