using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/printtasktrigger?view=graph-rest-1.0
    /// </summary>
    public partial class PrintTaskTrigger
    {
        public PrintEvent? Event { get; set; }
        public string? Id { get; set; }
        public PrintTaskDefinition? Definition { get; set; }
    }
}
