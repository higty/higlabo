using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class BookingcustomquestionUpdateParameter : IRestApiParameter
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

        public enum BookingcustomquestionUpdateParameterAnswerInputType
        {
            Text,
            RadioButton,
            UnknownFutureValue,
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public BookingcustomquestionUpdateParameterAnswerInputType AnswerInputType { get; set; }
        public String[]? AnswerOptions { get; set; }
        public string? DisplayName { get; set; }
    }
    public partial class BookingcustomquestionUpdateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionUpdateResponse> BookingcustomquestionUpdateAsync()
        {
            var p = new BookingcustomquestionUpdateParameter();
            return await this.SendAsync<BookingcustomquestionUpdateParameter, BookingcustomquestionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionUpdateResponse> BookingcustomquestionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new BookingcustomquestionUpdateParameter();
            return await this.SendAsync<BookingcustomquestionUpdateParameter, BookingcustomquestionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionUpdateResponse> BookingcustomquestionUpdateAsync(BookingcustomquestionUpdateParameter parameter)
        {
            return await this.SendAsync<BookingcustomquestionUpdateParameter, BookingcustomquestionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
        /// </summary>
        public async Task<BookingcustomquestionUpdateResponse> BookingcustomquestionUpdateAsync(BookingcustomquestionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<BookingcustomquestionUpdateParameter, BookingcustomquestionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
