using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/integerrange?view=graph-rest-1.0
    /// </summary>
    public partial class IntegerRange
    {
        public Int64? Start { get; set; }
        public Int64? End { get; set; }
    }
}
