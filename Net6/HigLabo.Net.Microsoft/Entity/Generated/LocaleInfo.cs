using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/localeinfo?view=graph-rest-1.0
    /// </summary>
    public partial class LocaleInfo
    {
        public String? Locale { get; set; }
        public String? DisplayName { get; set; }
    }
}
