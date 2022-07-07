using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcustomquestionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions_BookingCustomQuestionId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions_BookingCustomQuestionId: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/customQuestions/{BookingCustomQuestionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string BookingBusinessesId { get; set; }
        public string BookingCustomQuestionId { get; set; }
    }
    public partial class BookingcustomquestionGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionGetResponse> BookingcustomquestionGetAsync()
        {
            var p = new BookingcustomquestionGetParameter();
            return await this.SendAsync<BookingcustomquestionGetParameter, BookingcustomquestionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionGetResponse> BookingcustomquestionGetAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomquestionGetParameter();
            return await this.SendAsync<BookingcustomquestionGetParameter, BookingcustomquestionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionGetResponse> BookingcustomquestionGetAsync(BookingcustomquestionGetParameter parameter)
        {
            return await this.SendAsync<BookingcustomquestionGetParameter, BookingcustomquestionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionGetResponse> BookingcustomquestionGetAsync(BookingcustomquestionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomquestionGetParameter, BookingcustomquestionGetResponse>(parameter, cancellationToken);
        }
    }
}
