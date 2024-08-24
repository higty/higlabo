using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackagetextinputquestion?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageTextInputQuestion
    {
        public string? Id { get; set; }
        public bool? IsAnswerEditable { get; set; }
        public bool? IsRequired { get; set; }
        public bool? IsSingleLineQuestion { get; set; }
        public AccessPackageLocalizedText[]? Localizations { get; set; }
        public string? RegexPattern { get; set; }
        public Int32? Sequence { get; set; }
        public string? Text { get; set; }
    }
}
