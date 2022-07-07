using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/timestamp?view=graph-rest-1.0
    /// </summary>
    public partial class TimeStamp
    {
        public DateOnly? Date { get; set; }
        public TimeOnly? Time { get; set; }
        public string? TimeZone { get; set; }
    }
}
