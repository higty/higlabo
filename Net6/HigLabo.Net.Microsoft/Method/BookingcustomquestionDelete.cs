using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcustomquestionDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string BookingBusinessesId { get; set; }
        public string BookingCustomQuestionId { get; set; }
    }
    public partial class BookingcustomquestionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionDeleteResponse> BookingcustomquestionDeleteAsync()
        {
            var p = new BookingcustomquestionDeleteParameter();
            return await this.SendAsync<BookingcustomquestionDeleteParameter, BookingcustomquestionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionDeleteResponse> BookingcustomquestionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomquestionDeleteParameter();
            return await this.SendAsync<BookingcustomquestionDeleteParameter, BookingcustomquestionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionDeleteResponse> BookingcustomquestionDeleteAsync(BookingcustomquestionDeleteParameter parameter)
        {
            return await this.SendAsync<BookingcustomquestionDeleteParameter, BookingcustomquestionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionDeleteResponse> BookingcustomquestionDeleteAsync(BookingcustomquestionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomquestionDeleteParameter, BookingcustomquestionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
