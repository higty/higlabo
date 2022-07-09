using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/onenoteoperationerror?view=graph-rest-1.0
    /// </summary>
    public partial class OnenoteOperationError
    {
        public string? Code { get; set; }
        public string? Message { get; set; }
    }
}
