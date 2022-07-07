using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsupdatescheduledinstall?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsUpdateScheduledInstall
    {
        public enum WindowsUpdateScheduledInstallWeeklySchedule
        {
            UserDefined,
            Everyday,
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
        }

        public WeeklySchedule ScheduledInstallDay { get; set; }
        public TimeOnly ScheduledInstallTime { get; set; }
    }
}
