using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/calculatedcolumn?view=graph-rest-1.0
    /// </summary>
    public partial class CalculatedColumn
    {
        public string? Format { get; set; }
        public string? Formula { get; set; }
        public string? OutputType { get; set; }
    }
}
