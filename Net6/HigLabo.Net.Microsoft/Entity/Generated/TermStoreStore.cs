using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-store?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreStore
    {
        public string? DefaultLanguageTag { get; set; }
        public string? Id { get; set; }
        public String[]? LanguageTags { get; set; }
        public TermStoreGroup[]? Groups { get; set; }
        public TermStoreSet[]? Sets { get; set; }
    }
}
