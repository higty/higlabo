using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/numbercolumn?view=graph-rest-1.0
    /// </summary>
    public partial class NumberColumn
    {
        public String? DecimalPlaces { get; set; }
        public String? DisplayAs { get; set; }
        public Double? Maximum { get; set; }
        public Double? Minimum { get; set; }
    }
}
