using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/bookingquestionanswer?view=graph-rest-1.0
    /// </summary>
    public partial class BookingQuestionAnswer
    {
        public enum BookingQuestionAnswerAnswerInputType
        {
            Text,
            RadioButton,
            UnknownFutureValue,
        }

        public string? Answer { get; set; }
        public BookingQuestionAnswerAnswerInputType AnswerInputType { get; set; }
        public String[]? AnswerOptions { get; set; }
        public bool? IsRequired { get; set; }
        public string? Question { get; set; }
        public string? QuestionId { get; set; }
        public String[]? SelectedOptions { get; set; }
    }
}
