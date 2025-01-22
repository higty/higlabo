using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
/// </summary>
public partial class BookingBusinessPostCustomQuestionsParameter : IRestApiParameter
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

    public enum BookingBusinessPostCustomQuestionsParameterAnswerInputType
    {
        Text,
        RadioButton,
        UnknownFutureValue,
    }
    public enum BookingCustomQuestionAnswerInputType
    {
        Text,
        RadioButton,
        UnknownFutureValue,
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
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public BookingBusinessPostCustomQuestionsParameterAnswerInputType AnswerInputType { get; set; }
    public String[]? AnswerOptions { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
}
public partial class BookingBusinessPostCustomQuestionsResponse : RestApiResponse
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
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomQuestionsResponse> BookingBusinessPostCustomQuestionsAsync()
    {
        var p = new BookingBusinessPostCustomQuestionsParameter();
        return await this.SendAsync<BookingBusinessPostCustomQuestionsParameter, BookingBusinessPostCustomQuestionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomQuestionsResponse> BookingBusinessPostCustomQuestionsAsync(CancellationToken cancellationToken)
    {
        var p = new BookingBusinessPostCustomQuestionsParameter();
        return await this.SendAsync<BookingBusinessPostCustomQuestionsParameter, BookingBusinessPostCustomQuestionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomQuestionsResponse> BookingBusinessPostCustomQuestionsAsync(BookingBusinessPostCustomQuestionsParameter parameter)
    {
        return await this.SendAsync<BookingBusinessPostCustomQuestionsParameter, BookingBusinessPostCustomQuestionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingbusiness-post-customquestions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingBusinessPostCustomQuestionsResponse> BookingBusinessPostCustomQuestionsAsync(BookingBusinessPostCustomQuestionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingBusinessPostCustomQuestionsParameter, BookingBusinessPostCustomQuestionsResponse>(parameter, cancellationToken);
    }
}
