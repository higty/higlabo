using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
    /// </summary>
    public partial class BookingBusinessListCustomQuestionsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class BookingBusinessListCustomQuestionsResponse : RestApiResponse<BookingCustomQuestion>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomQuestionsResponse> BookingBusinessListCustomQuestionsAsync()
        {
            var p = new BookingBusinessListCustomQuestionsParameter();
            return await this.SendAsync<BookingBusinessListCustomQuestionsParameter, BookingBusinessListCustomQuestionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomQuestionsResponse> BookingBusinessListCustomQuestionsAsync(CancellationToken cancellationToken)
        {
            var p = new BookingBusinessListCustomQuestionsParameter();
            return await this.SendAsync<BookingBusinessListCustomQuestionsParameter, BookingBusinessListCustomQuestionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomQuestionsResponse> BookingBusinessListCustomQuestionsAsync(BookingBusinessListCustomQuestionsParameter parameter)
        {
            return await this.SendAsync<BookingBusinessListCustomQuestionsParameter, BookingBusinessListCustomQuestionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingBusinessListCustomQuestionsResponse> BookingBusinessListCustomQuestionsAsync(BookingBusinessListCustomQuestionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingBusinessListCustomQuestionsParameter, BookingBusinessListCustomQuestionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-list-customquestions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<BookingCustomQuestion> BookingBusinessListCustomQuestionsEnumerateAsync(BookingBusinessListCustomQuestionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<BookingBusinessListCustomQuestionsParameter, BookingBusinessListCustomQuestionsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<BookingCustomQuestion>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
