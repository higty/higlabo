using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/presence?view=graph-rest-1.0
    /// </summary>
    public partial class Presence
    {
        public enum Presencestring
        {
            Available,
            AvailableIdle,
            Away,
            BeRightBack,
            Busy,
            BusyIdle,
            DoNotDisturb,
            Offline,
            PresenceUnknown,
        }

        public string? Id { get; set; }
        public Presencestring Availability { get; set; }
        public Presencestring Activity { get; set; }
    }
}
