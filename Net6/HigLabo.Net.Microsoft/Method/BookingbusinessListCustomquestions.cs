using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessListCustomquestionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/customQuestions";
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
    }
    public partial class BookingbusinessListCustomquestionsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/bookingcustomquestion?view=graph-rest-1.0
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

        public BookingCustomQuestion[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync()
        {
            var p = new BookingbusinessListCustomquestionsParameter();
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListCustomquestionsParameter();
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync(BookingbusinessListCustomquestionsParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync(BookingbusinessListCustomquestionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(parameter, cancellationToken);
        }
    }
}
