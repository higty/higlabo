using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printtask?view=graph-rest-1.0
    /// </summary>
    public partial class PrintTask
    {
        public string? Id { get; set; }
        public PrintTaskStatus? Status { get; set; }
        public string? ParentUrl { get; set; }
        public PrintTaskDefinition? Definition { get; set; }
        public PrintTaskTrigger? Trigger { get; set; }
    }
}
