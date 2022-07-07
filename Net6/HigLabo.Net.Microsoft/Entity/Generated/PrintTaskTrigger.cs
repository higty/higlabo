using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/printtasktrigger?view=graph-rest-1.0
    /// </summary>
    public partial class PrintTaskTrigger
    {
        public string? Id { get; set; }
        public PrintEvent? Event { get; set; }
    }
}
