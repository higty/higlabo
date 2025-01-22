using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
/// </summary>
public partial class BookingcustomQuestionGetParameter : IRestApiParameter, IQueryParameterProperty
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

    public enum Field
    {
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
public partial class BookingcustomQuestionGetResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionGetResponse> BookingcustomQuestionGetAsync()
    {
        var p = new BookingcustomQuestionGetParameter();
        return await this.SendAsync<BookingcustomQuestionGetParameter, BookingcustomQuestionGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionGetResponse> BookingcustomQuestionGetAsync(CancellationToken cancellationToken)
    {
        var p = new BookingcustomQuestionGetParameter();
        return await this.SendAsync<BookingcustomQuestionGetParameter, BookingcustomQuestionGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionGetResponse> BookingcustomQuestionGetAsync(BookingcustomQuestionGetParameter parameter)
    {
        return await this.SendAsync<BookingcustomQuestionGetParameter, BookingcustomQuestionGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/bookingcustomquestion-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<BookingcustomQuestionGetResponse> BookingcustomQuestionGetAsync(BookingcustomQuestionGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<BookingcustomQuestionGetParameter, BookingcustomQuestionGetResponse>(parameter, cancellationToken);
    }
}
