using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/displaynamelocalization?view=graph-rest-1.0
    /// </summary>
    public partial class DisplayNameLocalization
    {
        public string? DisplayName { get; set; }
        public string? LanguageTag { get; set; }
    }
}
