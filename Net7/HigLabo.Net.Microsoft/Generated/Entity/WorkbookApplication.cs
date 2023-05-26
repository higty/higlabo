using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookapplication?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookApplication
    {
        public enum WorkbookApplicationstring
        {
            Automatic,
            AutomaticExceptTables,
            Manual,
        }

        public WorkbookApplicationstring CalculationMode { get; set; }
    }
}
