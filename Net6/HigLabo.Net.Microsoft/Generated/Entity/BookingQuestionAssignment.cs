using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/bookingquestionassignment?view=graph-rest-1.0
    /// </summary>
    public partial class BookingQuestionAssignment
    {
        public bool? IsRequired { get; set; }
        public string? QuestionId { get; set; }
    }
}
