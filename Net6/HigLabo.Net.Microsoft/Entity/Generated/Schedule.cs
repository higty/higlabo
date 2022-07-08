using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/schedule?view=graph-rest-1.0
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

        public string? Id { get; set; }
        public bool? Enabled { get; set; }
        public string? TimeZone { get; set; }
        public ScheduleOperationStatus ProvisionStatus { get; set; }
        public string? ProvisionStatusCode { get; set; }
        public bool? TimeClockEnabled { get; set; }
        public bool? OpenShiftsEnabled { get; set; }
        public bool? SwapShiftsRequestsEnabled { get; set; }
        public bool? OfferShiftRequestsEnabled { get; set; }
        public bool? TimeOffRequestsEnabled { get; set; }
        public Shift[]? Shifts { get; set; }
        public TimeOff[]? TimesOff { get; set; }
        public TimeOffReason[]? TimeOffReasons { get; set; }
        public SchedulingGroup[]? SchedulingGroups { get; set; }
        public OpenShift[]? Openshifts { get; set; }
        public WorkforceIntegration[]? Workforceintegrations { get; set; }
        public SwapShiftsChangeRequest[]? Swapshiftchangerequests { get; set; }
        public OpenShiftChangeRequest[]? Openshiftchangerequests { get; set; }
        public TimeOffRequest[]? Timeoffrequest { get; set; }
    }
}
