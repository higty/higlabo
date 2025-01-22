using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/bookingcustomquestion?view=graph-rest-1.0
/// </summary>
public partial class BookingCustomQuestion
{
    public enum BookingCustomQuestionAnswerInputType
    {
        Text,
        RadioButton,
        UnknownFutureValue,
    }

    public BookingCustomQuestionAnswerInputType AnswerInputType { get; set; }
    public String[]? AnswerOptions { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
}
