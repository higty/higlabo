using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/virtualeventregistrationquestionanswer?view=graph-rest-1.0
    /// </summary>
    public partial class VirtualEventRegistrationQuestionAnswer
    {
        public bool? BooleanValue { get; set; }
        public string? DisplayName { get; set; }
        public String[]? MultiChoiceValues { get; set; }
        public string? QuestionId { get; set; }
        public string? Value { get; set; }
    }
}
