using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-localizeddescription?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreLocalizedDescription
    {
        public string? Description { get; set; }
        public string? LanguageTag { get; set; }
    }
}
