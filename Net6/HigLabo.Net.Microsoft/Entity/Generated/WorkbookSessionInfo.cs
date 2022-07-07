using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/workbooksessioninfo?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookSessionInfo
    {
        public string? Id { get; set; }
        public bool? PersistChanges { get; set; }
    }
}
