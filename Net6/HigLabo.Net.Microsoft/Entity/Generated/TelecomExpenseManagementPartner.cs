using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-tem-telecomexpensemanagementpartner?view=graph-rest-1.0
    /// </summary>
    public partial class TelecomExpenseManagementPartner
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Url { get; set; }
        public bool? AppAuthorized { get; set; }
        public bool? Enabled { get; set; }
        public DateTimeOffset? LastConnectionDateTime { get; set; }
    }
}
