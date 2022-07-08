using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcustomquestionDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string BookingBusinessesId { get; set; }
            public string BookingCustomQuestionId { get; set; }

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
