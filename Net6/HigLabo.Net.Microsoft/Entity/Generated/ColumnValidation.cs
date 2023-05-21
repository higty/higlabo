using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/columnvalidation?view=graph-rest-1.0
    /// </summary>
    public partial class ColumnValidation
    {
        public string? DefaultLanguage { get; set; }
        public string Descriptions { get; set; }
        public string? Formula { get; set; }
    }
}
