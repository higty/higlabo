using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
    /// </summary>
    public partial class BookingbusinessListCustomquestionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BookingBusinessesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/customQuestions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AnswerInputType,
            AnswerOptions,
            DisplayName,
            Id,
        }
        public enum ApiPath
        {
            Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    }
    public partial class BookingbusinessListCustomquestionsResponse : RestApiResponse
    {
        public BookingCustomQuestion[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync()
        {
            var p = new BookingbusinessListCustomquestionsParameter();
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync(CancellationToken cancellationToken)
        {
            var p = new BookingbusinessListCustomquestionsParameter();
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync(BookingbusinessListCustomquestionsParameter parameter)
        {
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingbusinessListCustomquestionsResponse> BookingbusinessListCustomquestionsAsync(BookingbusinessListCustomquestionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingbusinessListCustomquestionsParameter, BookingbusinessListCustomquestionsResponse>(parameter, cancellationToken);
        }
    }
}
