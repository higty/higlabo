using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
    /// </summary>
    public partial class BookingcustomQuestionDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? BookingBusinessesId { get; set; }
            public string? BookingCustomQuestionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions_BookingCustomQuestionId: return $"/solutions/bookingBusinesses/{BookingBusinessesId}/customQuestions/{BookingCustomQuestionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Solutions_BookingBusinesses_BookingBusinessesId_CustomQuestions_BookingCustomQuestionId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class BookingcustomQuestionDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingcustomQuestionDeleteResponse> BookingcustomQuestionDeleteAsync()
        {
            var p = new BookingcustomQuestionDeleteParameter();
            return await this.SendAsync<BookingcustomQuestionDeleteParameter, BookingcustomQuestionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingcustomQuestionDeleteResponse> BookingcustomQuestionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomQuestionDeleteParameter();
            return await this.SendAsync<BookingcustomQuestionDeleteParameter, BookingcustomQuestionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingcustomQuestionDeleteResponse> BookingcustomQuestionDeleteAsync(BookingcustomQuestionDeleteParameter parameter)
        {
            return await this.SendAsync<BookingcustomQuestionDeleteParameter, BookingcustomQuestionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<BookingcustomQuestionDeleteResponse> BookingcustomQuestionDeleteAsync(BookingcustomQuestionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomQuestionDeleteParameter, BookingcustomQuestionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
