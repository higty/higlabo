using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookoperation?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookOperation
    {
        public WorkbookOperationError? Error { get; set; }
        public string? Id { get; set; }
        public string? ResourceLocation { get; set; }
        public string? Status { get; set; }
        public int? StatusCode { get; set; }
    }
}
