using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookworksheetprotection?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookWorksheetProtection
    {
        public WorkbookWorksheetProtectionOptions? Options { get; set; }
        public bool? Protected { get; set; }
    }
}
