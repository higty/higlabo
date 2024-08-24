using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageanswerchoice?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAnswerChoice
    {
        public string? ActualValue { get; set; }
        public AccessPackageLocalizedText[]? Localizations { get; set; }
        public string? Text { get; set; }
    }
}
