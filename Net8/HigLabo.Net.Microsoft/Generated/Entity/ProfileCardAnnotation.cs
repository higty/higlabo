using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/profilecardannotation?view=graph-rest-1.0
    /// </summary>
    public partial class ProfileCardAnnotation
    {
        public string? DisplayName { get; set; }
        public DisplayNameLocalization[]? Localizations { get; set; }
    }
}
