using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/shiftpreferences?view=graph-rest-1.0
    /// </summary>
    public partial class ShiftPreferences
    {
        public string Id { get; set; }
        public ShiftAvailability[] Availability { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public IdentitySet? LastModifiedBy { get; set; }
    }
}
