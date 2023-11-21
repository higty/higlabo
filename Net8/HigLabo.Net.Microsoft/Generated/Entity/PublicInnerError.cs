using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/publicinnererror?view=graph-rest-1.0
    /// </summary>
    public partial class PublicInnerError
    {
        public string? Code { get; set; }
        public PublicErrorDetail[]? Details { get; set; }
        public string? Message { get; set; }
        public string? Target { get; set; }
    }
}
