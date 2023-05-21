using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/alteredquerytoken?view=graph-rest-1.0
    /// </summary>
    public partial class AlteredQueryToken
    {
        public Int32? Length { get; set; }
        public Int32? Offset { get; set; }
        public string? Suggestion { get; set; }
    }
}
