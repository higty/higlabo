using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-shared-mimecontent?view=graph-rest-1.0
    /// </summary>
    public partial class MimeContent
    {
        public string? Type { get; set; }
        public string? Value { get; set; }
    }
}
