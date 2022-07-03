using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/ipnamedlocation?view=graph-rest-1.0
    /// </summary>
    public partial class IpNamedLocation
    {
        public DateTimeOffset CreatedDateTime { get; set; }
        public string DisplayName { get; set; }
        public string Id { get; set; }
        public IpRange[] IpRanges { get; set; }
        public bool IsTrusted { get; set; }
        public DateTimeOffset ModifiedDateTime { get; set; }
    }
}
