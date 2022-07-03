using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/publicerror?view=graph-rest-1.0
    /// </summary>
    public partial class PublicError
    {
        public String? Code { get; set; }
        public PublicErrorDetail[] Details { get; set; }
        public PublicInnerError? InnerError { get; set; }
        public String? Message { get; set; }
        public string Target { get; set; }
    }
}
