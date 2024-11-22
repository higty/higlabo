using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
/// </summary>
public partial class BookingcustomQuestionUpdateParameter : IRestApiParameter
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

    public enum BookingcustomQuestionUpdateParameterAnswerInputType
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
    public BookingcustomQuestionUpdateParameterAnswerInputType AnswerInputType { get; set; }
    public String[]? AnswerOptions { get; set; }
    public string? DisplayName { get; set; }
}
public partial class BookingcustomQuestionUpdateResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionUpdateResponse> BookingcustomQuestionUpdateAsync()
    {
        var p = new BookingcustomQuestionUpdateParameter();
        return await this.SendAsync<BookingcustomQuestionUpdateParameter, BookingcustomQuestionUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionUpdateResponse> BookingcustomQuestionUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new BookingcustomQuestionUpdateParameter();
        return await this.SendAsync<BookingcustomQuestionUpdateParameter, BookingcustomQuestionUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionUpdateResponse> BookingcustomQuestionUpdateAsync(BookingcustomQuestionUpdateParameter parameter)
    {
        return await this.SendAsync<BookingcustomQuestionUpdateParameter, BookingcustomQuestionUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionUpdateResponse> BookingcustomQuestionUpdateAsync(BookingcustomQuestionUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingcustomQuestionUpdateParameter, BookingcustomQuestionUpdateResponse>(parameter, cancellationToken);
    }
}
