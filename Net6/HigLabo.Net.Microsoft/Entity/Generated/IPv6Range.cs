using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-ipv6range?view=graph-rest-1.0
    /// </summary>
    public partial class IPv6Range
    {
        public string LowerAddress { get; set; }
        public string UpperAddress { get; set; }
    }
}
