using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackagemultiplechoicequestion?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageMultipleChoiceQuestion
    {
        public AccessPackageAnswerChoice[]? Choices { get; set; }
        public string? Id { get; set; }
        public bool? IsAnswerEditable { get; set; }
        public bool? IsMultipleSelectionAllowed { get; set; }
        public bool? IsRequired { get; set; }
        public AccessPackageLocalizedText[]? Localizations { get; set; }
        public Int32? Sequence { get; set; }
        public string? Text { get; set; }
    }
}
