using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/worksheetprotection?view=graph-rest-1.0
    /// </summary>
    public partial class WorksheetProtection
    {
        public WorksheetProtectionOptions? Options { get; set; }
        public bool? Protected { get; set; }
    }
}
