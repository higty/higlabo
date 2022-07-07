using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/incompletedata?view=graph-rest-1.0
    /// </summary>
    public partial class IncompleteData
    {
        public DateTimeOffset? MissingDataBeforeDateTime { get; set; }
        public bool? WasThrottled { get; set; }
    }
}
