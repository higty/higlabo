using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/workbookoperation?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookOperation
    {
        public string? Status { get; set; }
        public string? Id { get; set; }
        public WorkbookOperationError? Error { get; set; }
        public string? ResourceLocation { get; set; }
    }
}
