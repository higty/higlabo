using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingbusinessPostCustomquestionsParameter : IRestApiParameter
    {
        public enum BookingbusinessPostCustomquestionsParameterAnswerInputType
        {
            Text,
            RadioButton,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public BookingbusinessPostCustomquestionsParameterAnswerInputType AnswerInputType { get; set; }
        public String[]? AnswerOptions { get; set; }
        public string? DisplayName { get; set; }
        public string BookingBusinessesId { get; set; }
    }
    public partial class BookingbusinessPostCustomquestionsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomquestionsResponse> BookingbusinessPostCustomquestionsAsync()
        {
            var p = new BookingbusinessPostCustomquestionsParameter();
            return await this.SendAsync<BookingbusinessPostCustomquestionsParameter, BookingbusinessPostCustomquestionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomquestionsResponse> BookingbusinessPostCustomquestionsAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessPostCustomquestionsParameter();
            return await this.SendAsync<BookingbusinessPostCustomquestionsParameter, BookingbusinessPostCustomquestionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomquestionsResponse> BookingbusinessPostCustomquestionsAsync(BookingbusinessPostCustomquestionsParameter parameter)
        {
            return await this.SendAsync<BookingbusinessPostCustomquestionsParameter, BookingbusinessPostCustomquestionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessPostCustomquestionsResponse> BookingbusinessPostCustomquestionsAsync(BookingbusinessPostCustomquestionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessPostCustomquestionsParameter, BookingbusinessPostCustomquestionsResponse>(parameter, cancellationToken);
        }
    }
}
