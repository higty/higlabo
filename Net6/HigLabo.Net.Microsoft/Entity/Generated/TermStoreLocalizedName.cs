using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/termstore-localizedname?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreLocalizedName
    {
        public string LanguageTag { get; set; }
        public string Name { get; set; }
    }
}
