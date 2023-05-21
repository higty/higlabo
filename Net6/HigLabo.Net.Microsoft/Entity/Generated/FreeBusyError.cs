using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/freebusyerror?view=graph-rest-1.0
    /// </summary>
    public partial class FreeBusyError
    {
        public string? Message { get; set; }
        public string? ResponseCode { get; set; }
    }
}
