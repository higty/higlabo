using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/publicerrordetail?view=graph-rest-1.0
    /// </summary>
    public partial class PublicErrorDetail
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
    }
}
